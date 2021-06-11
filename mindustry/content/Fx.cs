// Decompiled with JetBrains decompiler
// Type: mindustry.content.Fx
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Fx : Object
  {
    internal static Effect __\u003C\u003Enone;
    internal static Effect __\u003C\u003EunitSpawn;
    internal static Effect __\u003C\u003EunitCapKill;
    internal static Effect __\u003C\u003EunitControl;
    internal static Effect __\u003C\u003EunitDespawn;
    internal static Effect __\u003C\u003EunitSpirit;
    internal static Effect __\u003C\u003EitemTransfer;
    internal static Effect __\u003C\u003EpointBeam;
    internal static Effect __\u003C\u003EpointHit;
    internal static Effect __\u003C\u003Elightning;
    internal static Effect __\u003C\u003EcommandSend;
    internal static Effect __\u003C\u003EupgradeCore;
    internal static Effect __\u003C\u003EplaceBlock;
    internal static Effect __\u003C\u003EtapBlock;
    internal static Effect __\u003C\u003EbreakBlock;
    internal static Effect __\u003C\u003Eselect;
    internal static Effect __\u003C\u003Esmoke;
    internal static Effect __\u003C\u003EfallSmoke;
    internal static Effect __\u003C\u003EunitWreck;
    internal static Effect __\u003C\u003ErocketSmoke;
    internal static Effect __\u003C\u003ErocketSmokeLarge;
    internal static Effect __\u003C\u003Emagmasmoke;
    internal static Effect __\u003C\u003Espawn;
    internal static Effect __\u003C\u003Epadlaunch;
    internal static Effect __\u003C\u003EvtolHover;
    internal static Effect __\u003C\u003EunitDrop;
    internal static Effect __\u003C\u003EunitLand;
    internal static Effect __\u003C\u003EunitLandSmall;
    internal static Effect __\u003C\u003EunitPickup;
    internal static Effect __\u003C\u003ElandShock;
    internal static Effect __\u003C\u003Epickup;
    internal static Effect __\u003C\u003EgreenBomb;
    internal static Effect __\u003C\u003EgreenLaserCharge;
    internal static Effect __\u003C\u003EgreenLaserChargeSmall;
    internal static Effect __\u003C\u003EhealWaveDynamic;
    internal static Effect __\u003C\u003EhealWave;
    internal static Effect __\u003C\u003Eheal;
    internal static Effect __\u003C\u003EshieldWave;
    internal static Effect __\u003C\u003EshieldApply;
    internal static Effect __\u003C\u003EhitBulletSmall;
    internal static Effect __\u003C\u003EhitFuse;
    internal static Effect __\u003C\u003EhitBulletBig;
    internal static Effect __\u003C\u003EhitFlameSmall;
    internal static Effect __\u003C\u003EhitLiquid;
    internal static Effect __\u003C\u003EhitLaserBlast;
    internal static Effect __\u003C\u003EhitLancer;
    internal static Effect __\u003C\u003EhitBeam;
    internal static Effect __\u003C\u003EhitMeltdown;
    internal static Effect __\u003C\u003EhitMeltHeal;
    internal static Effect __\u003C\u003EinstBomb;
    internal static Effect __\u003C\u003EinstTrail;
    internal static Effect __\u003C\u003EinstShoot;
    internal static Effect __\u003C\u003EinstHit;
    internal static Effect __\u003C\u003EhitLaser;
    internal static Effect __\u003C\u003EhitYellowLaser;
    internal static Effect __\u003C\u003Edespawn;
    internal static Effect __\u003C\u003EflakExplosion;
    internal static Effect __\u003C\u003EplasticExplosion;
    internal static Effect __\u003C\u003EplasticExplosionFlak;
    internal static Effect __\u003C\u003EblastExplosion;
    internal static Effect __\u003C\u003EsapExplosion;
    internal static Effect __\u003C\u003EmassiveExplosion;
    internal static Effect __\u003C\u003EartilleryTrail;
    internal static Effect __\u003C\u003EincendTrail;
    internal static Effect __\u003C\u003EmissileTrail;
    internal static Effect __\u003C\u003Eabsorb;
    internal static Effect __\u003C\u003EforceShrink;
    internal static Effect __\u003C\u003EflakExplosionBig;
    internal static Effect __\u003C\u003Eburning;
    internal static Effect __\u003C\u003Efire;
    internal static Effect __\u003C\u003EfireSmoke;
    internal static Effect __\u003C\u003Esteam;
    internal static Effect __\u003C\u003Efireballsmoke;
    internal static Effect __\u003C\u003Eballfire;
    internal static Effect __\u003C\u003Efreezing;
    internal static Effect __\u003C\u003Emelting;
    internal static Effect __\u003C\u003Ewet;
    internal static Effect __\u003C\u003Emuddy;
    internal static Effect __\u003C\u003Esapped;
    internal static Effect __\u003C\u003EsporeSlowed;
    internal static Effect __\u003C\u003Eoily;
    internal static Effect __\u003C\u003Eoverdriven;
    internal static Effect __\u003C\u003Eoverclocked;
    internal static Effect __\u003C\u003EdropItem;
    internal static Effect __\u003C\u003Eshockwave;
    internal static Effect __\u003C\u003EbigShockwave;
    internal static Effect __\u003C\u003EnuclearShockwave;
    internal static Effect __\u003C\u003EimpactShockwave;
    internal static Effect __\u003C\u003EspawnShockwave;
    internal static Effect __\u003C\u003Eexplosion;
    internal static Effect __\u003C\u003EdynamicExplosion;
    internal static Effect __\u003C\u003EblockExplosion;
    internal static Effect __\u003C\u003EblockExplosionSmoke;
    internal static Effect __\u003C\u003EshootSmall;
    internal static Effect __\u003C\u003EshootHeal;
    internal static Effect __\u003C\u003EshootHealYellow;
    internal static Effect __\u003C\u003EshootSmallSmoke;
    internal static Effect __\u003C\u003EshootBig;
    internal static Effect __\u003C\u003EshootBig2;
    internal static Effect __\u003C\u003EshootBigSmoke;
    internal static Effect __\u003C\u003EshootBigSmoke2;
    internal static Effect __\u003C\u003EshootSmallFlame;
    internal static Effect __\u003C\u003EshootPyraFlame;
    internal static Effect __\u003C\u003EshootLiquid;
    internal static Effect __\u003C\u003Ecasing1;
    internal static Effect __\u003C\u003Ecasing2;
    internal static Effect __\u003C\u003Ecasing3;
    internal static Effect __\u003C\u003Ecasing4;
    internal static Effect __\u003C\u003Ecasing2Double;
    internal static Effect __\u003C\u003Ecasing3Double;
    internal static Effect __\u003C\u003ErailShoot;
    internal static Effect __\u003C\u003ErailTrail;
    internal static Effect __\u003C\u003ErailHit;
    internal static Effect __\u003C\u003ElancerLaserShoot;
    internal static Effect __\u003C\u003ElancerLaserShootSmoke;
    internal static Effect __\u003C\u003ElancerLaserCharge;
    internal static Effect __\u003C\u003ElancerLaserChargeBegin;
    internal static Effect __\u003C\u003ElightningCharge;
    internal static Effect __\u003C\u003EsparkShoot;
    internal static Effect __\u003C\u003ElightningShoot;
    internal static Effect __\u003C\u003EthoriumShoot;
    internal static Effect __\u003C\u003Ereactorsmoke;
    internal static Effect __\u003C\u003Enuclearsmoke;
    internal static Effect __\u003C\u003Ecloudsmoke;
    internal static Effect __\u003C\u003Enuclearcloud;
    internal static Effect __\u003C\u003Eimpactsmoke;
    internal static Effect __\u003C\u003Eimpactcloud;
    internal static Effect __\u003C\u003Eredgeneratespark;
    internal static Effect __\u003C\u003Egeneratespark;
    internal static Effect __\u003C\u003Efuelburn;
    internal static Effect __\u003C\u003EcoreBurn;
    internal static Effect __\u003C\u003Eplasticburn;
    internal static Effect __\u003C\u003Epulverize;
    internal static Effect __\u003C\u003EpulverizeRed;
    internal static Effect __\u003C\u003EpulverizeRedder;
    internal static Effect __\u003C\u003EpulverizeSmall;
    internal static Effect __\u003C\u003EpulverizeMedium;
    internal static Effect __\u003C\u003Eproducesmoke;
    internal static Effect __\u003C\u003EsmokeCloud;
    internal static Effect __\u003C\u003Esmeltsmoke;
    internal static Effect __\u003C\u003Eformsmoke;
    internal static Effect __\u003C\u003Eblastsmoke;
    internal static Effect __\u003C\u003Elava;
    internal static Effect __\u003C\u003Edooropen;
    internal static Effect __\u003C\u003Edoorclose;
    internal static Effect __\u003C\u003Edooropenlarge;
    internal static Effect __\u003C\u003Edoorcloselarge;
    internal static Effect __\u003C\u003Epurify;
    internal static Effect __\u003C\u003Epurifyoil;
    internal static Effect __\u003C\u003Epurifystone;
    internal static Effect __\u003C\u003Egenerate;
    internal static Effect __\u003C\u003Emine;
    internal static Effect __\u003C\u003EmineBig;
    internal static Effect __\u003C\u003EmineHuge;
    internal static Effect __\u003C\u003Esmelt;
    internal static Effect __\u003C\u003EteleportActivate;
    internal static Effect __\u003C\u003Eteleport;
    internal static Effect __\u003C\u003EteleportOut;
    internal static Effect __\u003C\u003Eripple;
    internal static Effect __\u003C\u003Ebubble;
    internal static Effect __\u003C\u003Elaunch;
    internal static Effect __\u003C\u003ElaunchPod;
    internal static Effect __\u003C\u003EhealWaveMend;
    internal static Effect __\u003C\u003EoverdriveWave;
    internal static Effect __\u003C\u003EhealBlock;
    internal static Effect __\u003C\u003EhealBlockFull;
    internal static Effect __\u003C\u003ErotateBlock;
    internal static Effect __\u003C\u003ElightBlock;
    internal static Effect __\u003C\u003EoverdriveBlockFull;
    internal static Effect __\u003C\u003EshieldBreak;
    internal static Effect __\u003C\u003EunitShieldBreak;
    internal static Effect __\u003C\u003EcoreLand;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 244, 106, 154, 191, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024281(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] Effect.EffectContainer obj2)
    {
      Draw.color(Pal.shield);
      Lines.stroke(obj2.fout() * 2f + 0.1f);
      Angles.randLenVectors((long) obj0.id, ByteCodeHelper.f2i(obj1 * 1.2f), obj1 / 2f + obj2.finpow() * obj1 * 1.25f, (Floatc2) new Fx.__\u003C\u003EAnon1(obj2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 248, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024280(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fout() * 5f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 176, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024269(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(obj1.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj1.finpow() * 30f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 183, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024270(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 162, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024266(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.circle(obj0.x + obj1, obj0.y + obj2, 1f + obj0.fin() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 146, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024263(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fslope() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 136, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024261(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fin() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 119, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024258([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(obj0.fout() * 4f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.fin() * 27f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 126, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024259(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fin() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 110, 119, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024256(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Color.__\u003C\u003Ewhite, obj0.color, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, 0.5f + obj0.fout() * 2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 103, 119, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024254(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(obj0.color, Color.__\u003C\u003ElightGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 96, 119, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024252(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(obj0.color, Color.__\u003C\u003ElightGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f + 0.2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 89, 119, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024250(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(obj0.color, Color.__\u003C\u003ElightGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 37, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024240(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fslope() * 4f;
      Draw.color(Color.__\u003C\u003Eorange, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 29, 118, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024238(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = 2f + obj0.fout() * 6f;
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003EdarkGray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 22, 118, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024236(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.plasticSmoke, Color.__\u003C\u003ElightGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fout() * 2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 15, 119, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024234(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Color.__\u003C\u003Ewhite, obj0.color, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, 0.5f + obj0.fout() * 2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 7, 106, 127, 3, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024232(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Draw.alpha((0.5f - Math.abs(obj3 - 0.5f)) * 2f);
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.5f + obj4 * 4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 0, 118, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024230(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.accent, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, 1f + obj0.fout() * 3f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 249, 106, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024228(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.stoneGray);
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 242, 106, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024226(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.stoneGray);
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 235, 118, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024224(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.redderDust, Pal.stoneGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2.5f + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 228, 118, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024222(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.redDust, Pal.stoneGray, obj0.fin());
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 221, 106, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024220(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Pal.stoneGray);
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f + 0.5f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 214, 123, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024218(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Draw.color(Color.valueOf("e9ead3"), Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 206, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024216(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 4f;
      Draw.color(Pal.accent, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 198, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024214(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 4f;
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 190, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024212(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 4f;
      Draw.color(Pal.orangeSpark, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 182, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024210(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 4f;
      Draw.color(Pal.redSpark, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 174, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024208(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 15f;
      Draw.color(Pal.lighterOrange, Color.__\u003C\u003ElightGray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 166, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024206(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fslope() * 4f;
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 158, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024204(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fout() * 14f;
      Draw.color(Color.__\u003C\u003Elime, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 149, 111, 106, 108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024202(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float radius = obj0.fslope() * 2f;
      Draw.color(Color.__\u003C\u003Egray);
      Draw.alpha(obj0.fslope());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, radius);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 141, 111, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024200(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = obj0.fslope() * 4f;
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 133, 118, 118, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024198(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float num = 1f + obj0.fout() * 5f;
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Fill.circle(obj0.x + obj1, obj0.y + obj2, num / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 127, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024196(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fin() * 5f + 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 118, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024194(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fin() * 5f + 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 109, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024192(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fslope() * 5f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 100, 127, 46})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024190(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Drawf.tri(obj0.x + obj1, obj0.y + obj2, obj0.fslope() * 3f + 1f, obj0.fslope() * 3f + 1f, Mathf.angle(obj1, obj2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 84, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024187(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fslope() * 3f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 76, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024185(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), obj0.fout() * 9f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 35, 118, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024180([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 3f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 50f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 188, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024172(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.5f + obj0.fout() * 2.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 180, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024170(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.65f + obj0.fout() * 1.6f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 172, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024168(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.65f + obj0.fout() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 164, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024166(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2.4f + 0.2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 156, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024164(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f + 0.2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 134, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024160(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 104, 127, 8, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024155(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 3f);
      Fill.circle(obj0.x + obj1 / 2f, obj0.y + obj2 / 2f, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 81, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024151(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3.1f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 14f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 88, 127, 15, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024152(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 3f + 0.5f);
      Fill.circle(obj0.x + obj1 / 2f, obj0.y + obj2 / 2f, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 96, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024153(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 60, 115, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024147(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] Effect.EffectContainer obj2)
    {
      Lines.stroke(3.1f * obj2.fout());
      Lines.circle(obj0.x, obj0.y, (3f + obj2.fin() * 14f) * obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 67, 127, 22, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024148(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      Fill.circle(obj0.x + obj2, obj0.y + obj3, obj5 * (2f + obj1) * 3f + 0.5f);
      Fill.circle(obj0.x + obj2 / 2f, obj0.y + obj3 / 2f, obj5 * obj1 * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 75, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024149(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      Lines.lineAngle(obj0.x + obj2, obj0.y + obj3, Mathf.angle(obj2, obj3), 1f + obj5 * 4f * (3f + obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 37, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024143(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 44, 127, 15, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024144(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 3f + 0.5f);
      Fill.circle(obj0.x + obj1 / 2f, obj0.y + obj2 / 2f, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 52, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024145(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 244, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024134(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2.3f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 236, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024132(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 222, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024129(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.square(obj0.x + obj1, obj0.y + obj2, obj0.fslope() * 1.1f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 200, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024125(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fout() * 1.2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 192, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024123(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 1.2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 184, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024121(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fout() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 176, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024119(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fout() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 168, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024117(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fslope() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 160, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024115(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fslope() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 148, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024113(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.2f + obj0.fslope() * 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 140, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024111(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, 0.1f + obj0.fout() * 1.4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 118, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024107(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 25f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 125, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024108(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 132, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024109(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 62, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002498(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 4f + obj1.fin() * 30f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 69, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002499(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 76, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024100(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 40, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002494(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 80f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 47, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002495(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 54, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002496(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 18, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002490(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 15f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 25, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002491(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 32, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002492(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 252, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002486(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 34f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 3, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002487(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 10, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002488(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 230, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002482(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 24f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 237, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002483(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 244, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002484(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 208, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002478(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(3f * obj1.fout());
      Lines.circle(obj0.x, obj0.y, 3f + obj1.fin() * 10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 215, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002479(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 3f + 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 222, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002480(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, Mathf.angle(obj1, obj2), 1f + obj0.fout() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 198, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002476(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 2f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 168, 106, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002470(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Draw.color(Pal.bulletYellow);
      Lines.stroke(obj1.fout() * 2f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj1.fin() * 30f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 174, 106, 191, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002472(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Draw.color(Pal.bulletYellowBack);
      Angles.randLenVectors((long) obj0.id, 25, 5f + obj0.fin() * 80f, obj0.rotation, 60f, (Floatc2) new Fx.__\u003C\u003EAnon93(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 176, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002471(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1,
      [In] float obj2,
      [In] float obj3)
    {
      Fill.square(obj0.x + obj2, obj0.y + obj3, obj1.fout() * 3f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 138, 118, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002468([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.bulletYellowBack, obj0.fin());
      Lines.stroke(obj0.fout() * 3f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 50f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 103, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002464(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 93, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002462(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 83, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002460(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 73, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002458(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 63, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002456(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 54, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002454(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 45, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002452(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 3f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 35, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002450(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 4f + 1.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 18, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002447(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(0.5f + obj1.fout());
      Lines.circle(obj0.x, obj0.y, obj1.fin() * 7f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 25, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002448(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 3f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 2, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002444(
      [In] Effect.EffectContainer obj0,
      [In] Effect.EffectContainer obj1)
    {
      Lines.stroke(0.5f + obj1.fout());
      Lines.circle(obj0.x, obj0.y, obj1.fin() * 5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 9, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002445(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      float angle = Mathf.angle(obj1, obj2);
      Lines.lineAngle(obj0.x + obj1, obj0.y + obj2, angle, obj0.fout() * 3f + 1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 210, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002436(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fin() * 5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 164, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002430(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 3f + 0.1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 157, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002428(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 150, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002426(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.circle(obj0.x + obj1, obj0.y + obj2, obj0.fout() * 4f + 0.4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 75, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002414(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2)
    {
      Fill.square(obj0.x + obj1, obj0.y + obj2, 1f + obj0.fout() * (3f + obj0.rotation));
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Effect.EffectContainer obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 159, 6, 150, 140, 108, 145, 151, 133, 140, 191, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00241([In] Effect.EffectContainer obj0)
    {
      object data = obj0.data;
      UnitType unitType;
      if (!(data is UnitType) || !object.ReferenceEquals((object) (unitType = (UnitType) data), (object) (UnitType) data))
        return;
      float num = 1f + obj0.fout() * 2f;
      TextureRegion region = unitType.icon(Cicon.__\u003C\u003Efull);
      Draw.alpha(obj0.fout());
      Draw.mixcol(Color.__\u003C\u003Ewhite, obj0.fin());
      Draw.rect(region, obj0.x, obj0.y, 180f);
      Draw.reset();
      Draw.alpha(obj0.fin());
      Draw.rect(region, obj0.x, obj0.y, (float) region.width * Draw.scl * num, (float) region.height * Draw.scl * num, obj0.rotation - 90f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {0, 106, 145, 123, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00242([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Escarlet);
      Draw.alpha(obj0.fout((Interp) Interp.pow4Out));
      float num = 10f + obj0.fout((Interp) Interp.pow10In) * 25f;
      Draw.rect(Icon.warning.getRegion(), obj0.x, obj0.y, num, num);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {8, 142, 108, 138, 111, 108, 127, 56, 106, 108, 127, 13, 115, 127, 13, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00243([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Unit))
        return;
      Unit unit = (Unit) obj0.data();
      int num = unit is BlockUnitc ? 1 : 0;
      Draw.mixcol(Pal.accent, 1f);
      Draw.alpha(obj0.fout());
      Draw.rect(num == 0 ? unit.type.icon(Cicon.__\u003C\u003Efull) : ((BlockUnitc) unit).tile().block.icon(Cicon.__\u003C\u003Efull), unit.x, unit.y, num == 0 ? unit.rotation - 90f : 0.0f);
      Draw.alpha(1f);
      Lines.stroke(obj0.fslope());
      Lines.square(unit.x, unit.y, obj0.fout() * unit.hitSize * 2f, 45f);
      Lines.stroke(obj0.fslope() * 2f);
      Lines.square(unit.x, unit.y, obj0.fout() * unit.hitSize * 3f, 45f);
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {25, 159, 1, 108, 109, 102, 141, 111, 127, 15, 133, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00244([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Unit) || ((Unit) obj0.data()).type == null)
        return;
      Unit unit = (Unit) obj0.data();
      float num = obj0.fout((Interp) Interp.pow2Out);
      float scl = Draw.scl;
      Draw.scl *= num;
      Draw.mixcol(Pal.accent, 1f);
      Draw.rect(unit.type.icon(Cicon.__\u003C\u003Efull), unit.x, unit.y, unit.rotation - 90f);
      Draw.reset();
      Draw.scl = scl;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {40, 110, 140, 138, 127, 20, 118, 143, 148, 127, 20, 107, 139, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00245([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Position))
        return;
      Position v = (Position) obj0.data();
      Draw.color(Pal.accent);
      Tmp.__\u003C\u003Ev1.set(obj0.x, obj0.y).interpolate(Tmp.__\u003C\u003Ev2.set(v), obj0.fin(), (Interp) Interp.pow2In);
      float x = Tmp.__\u003C\u003Ev1.x;
      float y = Tmp.__\u003C\u003Ev1.y;
      float radius = 2.5f * obj0.fin();
      Fill.square(x, y, 1.5f * radius, 45f);
      Tmp.__\u003C\u003Ev1.set(obj0.x, obj0.y).interpolate(Tmp.__\u003C\u003Ev2.set(v), obj0.fin(), (Interp) Interp.pow5In);
      Fill.square(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, radius, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {59, 110, 108, 127, 36, 127, 30, 118, 134, 123, 152, 107, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00246([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Position))
        return;
      Position v = (Position) obj0.data();
      Tmp.__\u003C\u003Ev1.set(obj0.x, obj0.y).interpolate(Tmp.__\u003C\u003Ev2.set(v), obj0.fin(), (Interp) Interp.pow3).add(Tmp.__\u003C\u003Ev2.sub(obj0.x, obj0.y).nor().rotate90(1).scl(Mathf.randomSeedRange((long) obj0.id, 1f) * obj0.fslope() * 10f));
      float x = Tmp.__\u003C\u003Ev1.x;
      float y = Tmp.__\u003C\u003Ev1.y;
      float num = 1f;
      Lines.stroke(obj0.fslope() * 2f * num, Pal.accent);
      Lines.circle(x, y, obj0.fslope() * 2f * num);
      Draw.color(obj0.color);
      Fill.circle(x, y, obj0.fslope() * 1.5f * num);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {74, 142, 140, 107, 108, 106, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00247([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Position))
        return;
      Position position = (Position) obj0.data();
      Draw.color(obj0.color);
      Draw.alpha(obj0.fout());
      Lines.stroke(1.5f);
      Lines.line(obj0.x, obj0.y, position.getX(), position.getY());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {85, 119, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00248([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, obj0.color, obj0.fin());
      Lines.stroke(obj0.fout() + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 6f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {91, 110, 140, 115, 151, 109, 109, 143, 254, 60, 230, 71, 126, 126, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00249([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Seq))
        return;
      Seq seq = (Seq) obj0.data();
      Lines.stroke(3f * obj0.fout());
      Draw.color(obj0.color, Color.__\u003C\u003Ewhite, obj0.fin());
      for (int index = 0; index < seq.size - 1; ++index)
      {
        Vec2 vec2_1 = (Vec2) seq.get(index);
        Vec2 vec2_2 = (Vec2) seq.get(index + 1);
        Lines.line(vec2_1.x, vec2_1.y, vec2_2.x, vec2_2.y, false);
      }
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        Vec2 vec2 = (Vec2) iterator.next();
        Fill.circle(vec2.x, vec2.y, Lines.getStroke() / 2f);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002410([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.command);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 120f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {116, 118, 108, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002411([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.accent, obj0.fin());
      Draw.alpha(obj0.fout());
      Fill.square(obj0.x, obj0.y, 4f * obj0.rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 106, 122, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002412([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Lines.stroke(3f - obj0.fin() * 2f);
      Lines.square(obj0.x, obj0.y, 4f * obj0.rotation + obj0.fin() * 3f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 64, 106, 122, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002413([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Lines.stroke(3f - obj0.fin() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + 5.333333f * obj0.rotation * obj0.fin());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 70, 106, 122, 159, 15, 191, 49})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002415([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.remove);
      Lines.stroke(3f - obj0.fin() * 2f);
      Lines.square(obj0.x, obj0.y, 4f * obj0.rotation + obj0.fin() * 3f);
      Angles.randLenVectors((long) obj0.id, 3 + ByteCodeHelper.f2i(obj0.rotation * 3f), obj0.rotation * 2f + 8f * obj0.rotation * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon111(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 80, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002416([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Lines.stroke(obj0.fout() * 3f);
      Lines.circle(obj0.x, obj0.y, 3f + obj0.fin() * 14f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 86, 118, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002417([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray, Pal.darkishGray, obj0.fin());
      Fill.circle(obj0.x, obj0.y, (7f - obj0.fin() * 7f) / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 91, 117, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002418([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray, Color.__\u003C\u003EdarkGray, obj0.rotation);
      Fill.circle(obj0.x, obj0.y, obj0.fout() * 3.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 96, 142, 143, 108, 127, 9, 117, 159, 1, 124, 145, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002419([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is TextureRegion))
        return;
      Draw.mixcol(Pal.rubble, 1f);
      TextureRegion region = (TextureRegion) obj0.data();
      float amount = obj0.fin((Interp) Interp.pow5Out) * 2f * Mathf.randomSeed((long) obj0.id, 1f);
      float num = Mathf.randomSeed((long) (obj0.id + 1), 10f);
      Tmp.__\u003C\u003Ev1.trns(Mathf.randomSeed((long) (obj0.id + 2), 360f), amount);
      Draw.z(Mathf.lerp(90f, 20f, obj0.fin()));
      Draw.alpha(obj0.fout((Interp) Interp.pow5Out));
      Draw.rect(region, obj0.x + Tmp.__\u003C\u003Ev1.x, obj0.y + Tmp.__\u003C\u003Ev1.y, obj0.rotation - 90f + num * obj0.fin((Interp) Interp.pow5Out));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 112, 106, 127, 20, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002420([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Draw.alpha(Mathf.clamp(obj0.fout() * 1.6f - Interp.pow3In.apply(obj0.rotation) * 1.2f));
      Fill.circle(obj0.x, obj0.y, 1f + 6f * obj0.rotation - obj0.fin() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 118, 106, 127, 20, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002421([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Draw.alpha(Mathf.clamp(obj0.fout() * 1.6f - Interp.pow3In.apply(obj0.rotation) * 1.2f));
      Fill.circle(obj0.x, obj0.y, 1f + 6f * obj0.rotation * 1.3f - obj0.fin() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 124, 106, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002422([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Fill.circle(obj0.x, obj0.y, obj0.fslope() * 6f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 129, 115, 106, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002423([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(2f * obj0.fout());
      Draw.color(Pal.accent);
      Lines.poly(obj0.x, obj0.y, 4, 5f + obj0.fin() * 12f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 135, 115, 106, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002424([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(4f * obj0.fout());
      Draw.color(Pal.accent);
      Lines.poly(obj0.x, obj0.y, 4, 5f + obj0.fin() * 60f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 141, 111, 123, 118, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002425([In] Effect.EffectContainer obj0)
    {
      float len = obj0.finpow() * 10f;
      float angle = obj0.rotation + Mathf.randomSeedRange((long) obj0.id, 30f);
      Draw.color(Pal.lightFlame, Pal.lightOrange, obj0.fin());
      Fill.circle(obj0.x + Angles.trnsx(angle, len), obj0.y + Angles.trnsy(angle, len), 2f * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 148, 106, 191, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002427([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightishGray);
      Angles.randLenVectors((long) obj0.id, 9, 3f + 20f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon110(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 155, 127, 0, 191, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002429([In] Effect.EffectContainer obj0)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(obj0.color).mul(1.1f));
      Angles.randLenVectors((long) obj0.id, 6, 17f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon109(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 162, 127, 0, 191, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002431([In] Effect.EffectContainer obj0)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(obj0.color).mul(1.1f));
      Angles.randLenVectors((long) obj0.id, ByteCodeHelper.f2i(6f * obj0.rotation), 12f * obj0.finpow() * obj0.rotation, (Floatc2) new Fx.__\u003C\u003EAnon108(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 106, 115, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002432([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightishGray);
      Lines.stroke(obj0.fin() * 2f);
      Lines.poly(obj0.x, obj0.y, 4, 13f * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 175, 106, 115, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002433([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lancerLaser);
      Lines.stroke(obj0.fout() * 3f);
      Lines.poly(obj0.x, obj0.y, 12, 20f * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 181, 106, 115, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002434([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightishGray);
      Lines.stroke(obj0.fout() * 2f);
      Lines.spikes(obj0.x, obj0.y, 1f + obj0.fin() * 6f, obj0.fout() * 4f, 6);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 187, 106, 115, 159, 7, 106, 102, 63, 10, 198, 101, 102, 63, 10, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002435([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 65f);
      Draw.color(Pal.heal);
      for (int index = 0; index < 4; ++index)
        Drawf.tri(obj0.x, obj0.y, 6f, 100f * obj0.fout(), (float) (index * 90));
      Draw.color();
      for (int index = 0; index < 4; ++index)
        Drawf.tri(obj0.x, obj0.y, 3f, 35f * obj0.fout(), (float) (index * 90));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 203, 106, 115, 159, 7, 159, 0, 223, 8, 133, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002437([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fin() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.fout() * 100f);
      Fill.circle(obj0.x, obj0.y, obj0.fin() * 20f);
      Angles.randLenVectors((long) obj0.id, 20, 40f * obj0.fout(), (Floatc2) new Fx.__\u003C\u003EAnon107(obj0));
      Draw.color();
      Fill.circle(obj0.x, obj0.y, obj0.fin() * 10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 219, 106, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002438([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fin() * 2f);
      Lines.circle(obj0.x, obj0.y, obj0.fout() * 50f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 225, 106, 115, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002439([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * obj0.rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 231, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002440([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 60f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 237, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002441([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 2f + obj0.finpow() * 7f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 243, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002442([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.shield);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 60f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 249, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002443([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.shield);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 2f + obj0.finpow() * 7f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 255, 150, 246, 69, 147, 223, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002446([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.lightOrange, obj0.fin());
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon105(obj0));
      Lines.stroke(0.5f + obj0.fout());
      Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 15f, (Floatc2) new Fx.__\u003C\u003EAnon106(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 15, 150, 246, 69, 147, 223, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002449([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.surge, obj0.fin());
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon103(obj0));
      Lines.stroke(0.5f + obj0.fout());
      Angles.randLenVectors((long) obj0.id, 6, obj0.fin() * 15f, (Floatc2) new Fx.__\u003C\u003EAnon104(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 31, 118, 154, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002451([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.lightOrange, obj0.fin());
      Lines.stroke(0.5f + obj0.fout() * 1.5f);
      Angles.randLenVectors((long) obj0.id, 8, obj0.finpow() * 30f, obj0.rotation, 50f, (Floatc2) new Fx.__\u003C\u003EAnon102(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 41, 118, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002453([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightFlame, Pal.darkFlame, obj0.fin());
      Lines.stroke(0.5f + obj0.fout());
      Angles.randLenVectors((long) obj0.id, 2, obj0.fin() * 15f, obj0.rotation, 50f, (Floatc2) new Fx.__\u003C\u003EAnon101(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 51, 139, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002455([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 15f, obj0.rotation, 60f, (Floatc2) new Fx.__\u003C\u003EAnon100(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 59, 107, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002457([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fout() * 1.5f);
      Angles.randLenVectors((long) obj0.id, 8, obj0.finpow() * 17f, obj0.rotation, 360f, (Floatc2) new Fx.__\u003C\u003EAnon99(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 69, 106, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002459([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite);
      Lines.stroke(obj0.fout() * 1.5f);
      Angles.randLenVectors((long) obj0.id, 8, obj0.finpow() * 17f, obj0.rotation, 360f, (Floatc2) new Fx.__\u003C\u003EAnon98(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 79, 107, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002461([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fout() * 2f);
      Angles.randLenVectors((long) obj0.id, 6, obj0.finpow() * 18f, obj0.rotation, 360f, (Floatc2) new Fx.__\u003C\u003EAnon97(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 89, 106, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002463([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.meltdownHit);
      Lines.stroke(obj0.fout() * 2f);
      Angles.randLenVectors((long) obj0.id, 6, obj0.finpow() * 18f, obj0.rotation, 360f, (Floatc2) new Fx.__\u003C\u003EAnon96(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 99, 106, 147, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002465([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(obj0.fout() * 2f);
      Angles.randLenVectors((long) obj0.id, 6, obj0.finpow() * 18f, obj0.rotation, 360f, (Floatc2) new Fx.__\u003C\u003EAnon95(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 109, 106, 115, 159, 7, 102, 63, 13, 198, 101, 102, 63, 13, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002466([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.bulletYellowBack);
      Lines.stroke(obj0.fout() * 4f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 20f);
      for (int index = 0; index < 4; ++index)
        Drawf.tri(obj0.x, obj0.y, 6f, 80f * obj0.fout(), (float) (index * 90 + 45));
      Draw.color();
      for (int index = 0; index < 4; ++index)
        Drawf.tri(obj0.x, obj0.y, 3f, 30f * obj0.fout(), (float) (index * 90 + 45));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 124, 105, 148, 144, 110, 114, 127, 16, 255, 3, 56, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002467([In] Effect.EffectContainer obj0)
    {
      for (int index = 0; index < 2; ++index)
      {
        Draw.color(index != 0 ? Pal.bulletYellow : Pal.bulletYellowBack);
        float num = index != 0 ? 0.5f : 1f;
        float rotation = obj0.rotation + 180f;
        float width = 15f * obj0.fout() * num;
        Drawf.tri(obj0.x, obj0.y, width, (30f + Mathf.randomSeedRange((long) obj0.id, 15f)) * num, rotation);
        Drawf.tri(obj0.x, obj0.y, width, 10f * num, rotation + 180f);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 137, 245, 70, 138, 118, 127, 22, 31, 22, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002469([In] Effect.EffectContainer obj0)
    {
      obj0.scaled(10f, (Cons) new Fx.__\u003C\u003EAnon94());
      Draw.color(Pal.bulletYellowBack);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = signs[index];
        Drawf.tri(obj0.x, obj0.y, 13f * obj0.fout(), 85f, obj0.rotation + 90f * (float) num);
        Drawf.tri(obj0.x, obj0.y, 13f * obj0.fout(), 50f, obj0.rotation + 20f * (float) num);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 152, 138, 105, 148, 144, 105, 125, 115, 127, 19, 255, 4, 60, 233, 59, 233, 77, 246, 70, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002473([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.bulletYellowBack);
      for (int index1 = 0; index1 < 2; ++index1)
      {
        Draw.color(index1 != 0 ? Pal.bulletYellow : Pal.bulletYellowBack);
        float num = index1 != 0 ? 0.5f : 1f;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          float rotation = obj0.rotation + Mathf.randomSeedRange((long) (obj0.id + index2), 50f);
          float width = 23f * obj0.fout() * num;
          Drawf.tri(obj0.x, obj0.y, width, (80f + Mathf.randomSeedRange((long) (obj0.id + index2), 40f)) * num, rotation);
          Drawf.tri(obj0.x, obj0.y, width, 20f * num, rotation + 180f);
        }
      }
      obj0.scaled(10f, (Cons) new Fx.__\u003C\u003EAnon91(obj0));
      obj0.scaled(12f, (Cons) new Fx.__\u003C\u003EAnon92(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 182, 118, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002474([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.heal, obj0.fin());
      Lines.stroke(0.5f + obj0.fout());
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 188, 118, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002475([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.lightTrail, obj0.fin());
      Lines.stroke(0.5f + obj0.fout());
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 194, 118, 140, 255, 18, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002477([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) obj0.id, 7, obj0.fin() * 7f, obj0.rotation, 40f, (Floatc2) new Fx.__\u003C\u003EAnon90(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 205, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002481([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.bulletYellow);
      obj0.scaled(6f, (Cons) new Fx.__\u003C\u003EAnon87(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 5, 2f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon88(obj0));
      Draw.color(Pal.lighterOrange);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 4, 1f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon89(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 227, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002485([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.plastaniumFront);
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon84(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 7, 2f + 28f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon85(obj0));
      Draw.color(Pal.plastaniumBack);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 4, 1f + 25f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon86(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 249, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002489([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.plastaniumFront);
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon81(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 7, 2f + 30f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon82(obj0));
      Draw.color(Pal.plastaniumBack);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 4, 1f + 30f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon83(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 15, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002493([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.missileYellow);
      obj0.scaled(6f, (Cons) new Fx.__\u003C\u003EAnon78(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 5, 2f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon79(obj0));
      Draw.color(Pal.missileYellowBack);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 4, 1f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon80(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 37, 138, 246, 69, 138, 223, 15, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u002497([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.sapBullet);
      obj0.scaled(6f, (Cons) new Fx.__\u003C\u003EAnon75(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 9, 2f + 70f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon76(obj0));
      Draw.color(Pal.sapBulletBack);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 8, 1f + 60f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon77(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 59, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024101([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.missileYellow);
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon72(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 8, 2f + 30f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon73(obj0));
      Draw.color(Pal.missileYellowBack);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 6, 1f + 29f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon74(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 81, 107, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024102([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Fill.circle(obj0.x, obj0.y, obj0.rotation * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 86, 106, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024103([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange);
      Fill.circle(obj0.x, obj0.y, obj0.rotation * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 91, 107, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024104([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Fill.circle(obj0.x, obj0.y, obj0.rotation * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 96, 106, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024105([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Lines.stroke(2f * obj0.fout());
      Lines.circle(obj0.x, obj0.y, 5f * obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 102, 114, 108, 159, 4, 106, 106, 127, 2, 106, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024106([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color, obj0.fout());
      if (Vars.renderer.animateShields)
      {
        Fill.poly(obj0.x, obj0.y, 6, obj0.rotation * obj0.fout());
      }
      else
      {
        Lines.stroke(1.5f);
        Draw.alpha(0.09f);
        Fill.poly(obj0.x, obj0.y, 6, obj0.rotation * obj0.fout());
        Draw.alpha(1f);
        Lines.poly(obj0.x, obj0.y, 6, obj0.rotation * obj0.fout());
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 115, 138, 246, 69, 138, 223, 14, 106, 140, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024110([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.bulletYellowBack);
      obj0.scaled(6f, (Cons) new Fx.__\u003C\u003EAnon69(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 6, 2f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon70(obj0));
      Draw.color(Pal.bulletYellow);
      Lines.stroke(obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 4, 1f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon71(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 137, 150, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024112([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightFlame, Pal.darkFlame, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 3, 2f + obj0.fin() * 7f, (Floatc2) new Fx.__\u003C\u003EAnon68(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 145, 150, 223, 14, 133, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024114([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightFlame, Pal.darkFlame, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 2, 2f + obj0.fin() * 9f, (Floatc2) new Fx.__\u003C\u003EAnon67(obj0));
      Draw.color();
      Drawf.light(Team.__\u003C\u003Ederelict, obj0.x, obj0.y, 20f * obj0.fslope(), Pal.lightFlame, 0.5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 157, 138, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024116([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 1, 2f + obj0.fin() * 7f, (Floatc2) new Fx.__\u003C\u003EAnon66(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 165, 138, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024118([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003ElightGray);
      Angles.randLenVectors((long) obj0.id, 2, 2f + obj0.fin() * 7f, (Floatc2) new Fx.__\u003C\u003EAnon65(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 173, 138, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024120([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 1, 2f + obj0.fin() * 7f, (Floatc2) new Fx.__\u003C\u003EAnon64(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 181, 150, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024122([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightFlame, Pal.darkFlame, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 2, 2f + obj0.fin() * 7f, (Floatc2) new Fx.__\u003C\u003EAnon63(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 189, 143, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024124([In] Effect.EffectContainer obj0)
    {
      Draw.color(Liquids.cryofluid.color);
      Angles.randLenVectors((long) obj0.id, 2, 1f + obj0.fin() * 2f, (Floatc2) new Fx.__\u003C\u003EAnon62(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 197, 159, 23, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024126([In] Effect.EffectContainer obj0)
    {
      Draw.color(Liquids.slag.color, Color.__\u003C\u003Ewhite, obj0.fout() / 5f + Mathf.randomSeedRange((long) obj0.id, 0.12f));
      Angles.randLenVectors((long) obj0.id, 2, 1f + obj0.fin() * 3f, (Floatc2) new Fx.__\u003C\u003EAnon61(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 205, 111, 153, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024127([In] Effect.EffectContainer obj0)
    {
      Draw.color(Liquids.water.color);
      Draw.alpha(Mathf.clamp(obj0.fin() * 2f));
      Fill.circle(obj0.x, obj0.y, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 212, 111, 153, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024128([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.valueOf("432722"));
      Draw.alpha(Mathf.clamp(obj0.fin() * 2f));
      Fill.circle(obj0.x, obj0.y, obj0.fout());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 219, 138, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024130([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.sap);
      Angles.randLenVectors((long) obj0.id, 2, 1f + obj0.fin() * 2f, (Floatc2) new Fx.__\u003C\u003EAnon60(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 227, 138, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024131([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.spore);
      Fill.circle(obj0.x, obj0.y, obj0.fslope() * 1.1f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 233, 143, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024133([In] Effect.EffectContainer obj0)
    {
      Draw.color(Liquids.oil.color);
      Angles.randLenVectors((long) obj0.id, 2, 1f + obj0.fin() * 2f, (Floatc2) new Fx.__\u003C\u003EAnon59(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 241, 138, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024135([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Angles.randLenVectors((long) obj0.id, 2, 1f + obj0.fin() * 2f, (Floatc2) new Fx.__\u003C\u003EAnon58(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 249, 138, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024136([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Fill.square(obj0.x, obj0.y, obj0.fslope() * 2f, 45f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 255, 111, 143, 127, 39})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024137([In] Effect.EffectContainer obj0)
    {
      float len = 20f * obj0.finpow();
      float num = 7f * obj0.fout();
      Draw.rect(((UnlockableContent) obj0.data).icon(Cicon.__\u003C\u003Emedium), obj0.x + Angles.trnsx(obj0.rotation, len), obj0.y + Angles.trnsy(obj0.rotation, len), num, num);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 6, 118, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024138([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 2f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 28f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 12, 118, 115, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024139([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 3f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 50f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 18, 118, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024140([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 3f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 140f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 24, 118, 122, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024141([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 4f + 0.2f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * 200f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 30, 118, 122, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024142([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003ElightGray, obj0.fin());
      Lines.stroke(obj0.fout() * 3f + 0.5f);
      Lines.circle(obj0.x, obj0.y, obj0.fin() * (obj0.rotation + 50f));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 36, 246, 69, 138, 255, 14, 69, 123, 147, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024146([In] Effect.EffectContainer obj0)
    {
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon55(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 6, 2f + 19f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon56(obj0));
      Draw.color(Pal.lighterOrange, Pal.lightOrange, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(1.5f * obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 8, 1f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon57(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 57, 135, 255, 2, 69, 138, 255, 21, 69, 123, 159, 12, 191, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024150([In] Effect.EffectContainer obj0)
    {
      float rotation = obj0.rotation;
      obj0.scaled(5f + rotation * 2f, (Cons) new Fx.__\u003C\u003EAnon52(obj0, rotation));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, obj0.finpow(), ByteCodeHelper.f2i(6f * rotation), 21f * rotation, (Angles.ParticleConsumer) new Fx.__\u003C\u003EAnon53(obj0, rotation));
      Draw.color(Pal.lighterOrange, Pal.lightOrange, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(1.7f * obj0.fout() * (1f + (rotation - 1f) / 2f));
      Angles.randLenVectors((long) (obj0.id + 1), obj0.finpow(), ByteCodeHelper.f2i(9f * rotation), 40f * rotation, (Angles.ParticleConsumer) new Fx.__\u003C\u003EAnon54(obj0, rotation));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 80, 246, 69, 138, 255, 14, 69, 123, 147, 191, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024154([In] Effect.EffectContainer obj0)
    {
      obj0.scaled(7f, (Cons) new Fx.__\u003C\u003EAnon49(obj0));
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 6, 2f + 19f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon50(obj0));
      Draw.color(Pal.lighterOrange, Pal.lightOrange, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(1.7f * obj0.fout());
      Angles.randLenVectors((long) (obj0.id + 1), 9, 1f + 23f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon51(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 101, 138, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024156([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Egray);
      Angles.randLenVectors((long) obj0.id, 6, 4f + 30f * obj0.finpow(), (Floatc2) new Fx.__\u003C\u003EAnon48(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 110, 118, 118, 127, 7, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024157([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Pal.lightOrange, obj0.fin());
      float width = 1f + 5f * obj0.fout();
      Drawf.tri(obj0.x, obj0.y, width, 15f * obj0.fout(), obj0.rotation);
      Drawf.tri(obj0.x, obj0.y, width, 3f * obj0.fout(), obj0.rotation + 180f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 117, 106, 118, 127, 7, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024158([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      float width = 1f + 5f * obj0.fout();
      Drawf.tri(obj0.x, obj0.y, width, 17f * obj0.fout(), obj0.rotation);
      Drawf.tri(obj0.x, obj0.y, width, 4f * obj0.fout(), obj0.rotation + 180f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 124, 106, 118, 127, 7, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024159([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightTrail);
      float width = 1f + 5f * obj0.fout();
      Drawf.tri(obj0.x, obj0.y, width, 17f * obj0.fout(), obj0.rotation);
      Drawf.tri(obj0.x, obj0.y, width, 4f * obj0.fout(), obj0.rotation + 180f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 131, 155, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024161([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 5, obj0.finpow() * 6f, obj0.rotation, 20f, (Floatc2) new Fx.__\u003C\u003EAnon47(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 139, 118, 118, 127, 7, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024162([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Pal.lightOrange, obj0.fin());
      float width = 1.2f + 7f * obj0.fout();
      Drawf.tri(obj0.x, obj0.y, width, 25f * obj0.fout(), obj0.rotation);
      Drawf.tri(obj0.x, obj0.y, width, 4f * obj0.fout(), obj0.rotation + 180f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 146, 118, 118, 127, 7, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024163([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Color.__\u003C\u003Egray, obj0.fin());
      float width = 1.2f + 8f * obj0.fout();
      Drawf.tri(obj0.x, obj0.y, width, 29f * obj0.fout(), obj0.rotation);
      Drawf.tri(obj0.x, obj0.y, width, 5f * obj0.fout(), obj0.rotation + 180f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 153, 155, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024165([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lighterOrange, Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 8, obj0.finpow() * 19f, obj0.rotation, 10f, (Floatc2) new Fx.__\u003C\u003EAnon46(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 161, 155, 191, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024167([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Color.__\u003C\u003ElightGray, Color.__\u003C\u003Egray, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 9, obj0.finpow() * 23f, obj0.rotation, 20f, (Floatc2) new Fx.__\u003C\u003EAnon45(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 169, 155, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024169([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightFlame, Pal.darkFlame, Color.__\u003C\u003Egray, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 8, obj0.finpow() * 60f, obj0.rotation, 10f, (Floatc2) new Fx.__\u003C\u003EAnon44(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 177, 155, 191, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024171([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightPyraFlame, Pal.darkPyraFlame, Color.__\u003C\u003Egray, obj0.fin());
      Angles.randLenVectors((long) obj0.id, 10, obj0.finpow() * 70f, obj0.rotation, 10f, (Floatc2) new Fx.__\u003C\u003EAnon43(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 185, 159, 19, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024173([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color, Color.__\u003C\u003Ewhite, obj0.fout() / 6f + Mathf.randomSeedRange((long) obj0.id, 0.1f));
      Angles.randLenVectors((long) obj0.id, 6, obj0.finpow() * 60f, obj0.rotation, 11f, (Floatc2) new Fx.__\u003C\u003EAnon42(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 193, 123, 113, 116, 141, 122, 118, 104, 127, 18, 127, 22, 243, 61, 229, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024174([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Color.__\u003C\u003ElightGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.3f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int num2 = -Mathf.sign(obj0.rotation);
      float len = (2f + obj0.finpow() * 6f) * (float) num2;
      float angle = num1 + obj0.fin() * 30f * (float) num2;
      Fill.rect(obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 1f, 2f, num1 + obj0.fin() * 50f * (float) num2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 209, 123, 113, 116, 109, 122, 118, 119, 127, 18, 127, 22, 243, 61, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024175([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Color.__\u003C\u003ElightGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.5f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int num2 = -Mathf.sign(obj0.rotation);
      float len = (2f + obj0.finpow() * 10f) * (float) num2;
      float angle = num1 + obj0.fin() * 20f * (float) num2;
      Draw.rect((TextureRegion) Core.atlas.find("casing"), obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 2f, 3f, num1 + obj0.fin() * 50f * (float) num2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 223, 123, 113, 116, 109, 122, 159, 8, 119, 127, 18, 159, 22, 243, 60, 229, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024176([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Pal.lightishGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.5f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int num2 = -Mathf.sign(obj0.rotation);
      float len = (4f + obj0.finpow() * 9f) * (float) num2;
      float angle = num1 + Mathf.randomSeedRange((long) (obj0.id + num2 + 6), 20f * obj0.fin()) * (float) num2;
      Draw.rect((TextureRegion) Core.atlas.find("casing"), obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 2.5f, 4f, num1 + obj0.fin() * 50f * (float) num2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 239, 123, 113, 116, 109, 122, 159, 8, 119, 127, 18, 159, 22, 243, 60, 229, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024177([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Pal.lightishGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.5f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int num2 = -Mathf.sign(obj0.rotation);
      float len = (4f + obj0.finpow() * 9f) * (float) num2;
      float angle = num1 + Mathf.randomSeedRange((long) (obj0.id + num2 + 6), 20f * obj0.fin()) * (float) num2;
      Draw.rect((TextureRegion) Core.atlas.find("casing"), obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 3f, 6f, num1 + obj0.fin() * 50f * (float) num2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 255, 123, 113, 116, 119, 124, 120, 121, 127, 21, 127, 23, 244, 61, 229, 61, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024178([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Color.__\u003C\u003ElightGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.5f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num2 = signs[index];
        float len = (2f + obj0.finpow() * 10f) * (float) num2;
        float angle = num1 + obj0.fin() * 20f * (float) num2;
        Draw.rect((TextureRegion) Core.atlas.find("casing"), obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 2f, 3f, num1 + obj0.fin() * 50f * (float) num2);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 15, 123, 113, 148, 119, 124, 159, 11, 121, 127, 21, 159, 23, 244, 60, 229, 60, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024179([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lightOrange, Pal.lightishGray, Pal.lightishGray, obj0.fin());
      Draw.alpha(obj0.fout(0.5f));
      float num1 = Math.abs(obj0.rotation) + 90f;
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num2 = signs[index];
        float len = (4f + obj0.finpow() * 9f) * (float) num2;
        float angle = num1 + Mathf.randomSeedRange((long) (obj0.id + num2 + 6), 20f * obj0.fin()) * (float) num2;
        Draw.rect((TextureRegion) Core.atlas.find("casing"), obj0.x + Angles.trnsx(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 7), 3f * obj0.fin()), obj0.y + Angles.trnsy(angle, len) + Mathf.randomSeedRange((long) (obj0.id + num2 + 8), 3f * obj0.fin()), 2.5f, 4f, num1 + obj0.fin() * 50f * (float) num2);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 34, 245, 70, 138, 115, 63, 22, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024181([In] Effect.EffectContainer obj0)
    {
      obj0.scaled(10f, (Cons) new Fx.__\u003C\u003EAnon41());
      Draw.color(Pal.orangeSpark);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = signs[index];
        Drawf.tri(obj0.x, obj0.y, 13f * obj0.fout(), 85f, obj0.rotation + 90f * (float) num);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 48, 138, 115, 63, 29, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024182([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.orangeSpark);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = signs[index];
        Drawf.tri(obj0.x, obj0.y, 10f * obj0.fout(), 24f, obj0.rotation + 90f + 90f * (float) num);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 56, 138, 115, 63, 22, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024183([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.orangeSpark);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = signs[index];
        Drawf.tri(obj0.x, obj0.y, 10f * obj0.fout(), 60f, obj0.rotation + 140f * (float) num);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 64, 138, 115, 63, 22, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024184([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lancerLaser);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = signs[index];
        Drawf.tri(obj0.x, obj0.y, 4f * obj0.fout(), 29f, obj0.rotation + 90f * (float) num);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 72, 106, 159, 7, 191, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024186([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite);
      float length = obj0.data is Float ? ((Float) obj0.data).floatValue() : 70f;
      Angles.randLenVectors((long) obj0.id, 7, length, obj0.rotation, 0.0f, (Floatc2) new Fx.__\u003C\u003EAnon40(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 81, 138, 191, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024188([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lancerLaser);
      Angles.randLenVectors((long) obj0.id, 2, 1f + 20f * obj0.fout(), obj0.rotation, 120f, (Floatc2) new Fx.__\u003C\u003EAnon39(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 89, 106, 159, 0, 101, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024189([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lancerLaser);
      Fill.circle(obj0.x, obj0.y, obj0.fin() * 3f);
      Draw.color();
      Fill.circle(obj0.x, obj0.y, obj0.fin() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 97, 138, 191, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024191([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.lancerLaser);
      Angles.randLenVectors((long) obj0.id, 2, 1f + 20f * obj0.fout(), obj0.rotation, 120f, (Floatc2) new Fx.__\u003C\u003EAnon38(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 105, 119, 154, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024193([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, obj0.color, obj0.fin());
      Lines.stroke(obj0.fout() * 1.2f + 0.6f);
      Angles.randLenVectors((long) obj0.id, 7, 25f * obj0.finpow(), obj0.rotation, 3f, (Floatc2) new Fx.__\u003C\u003EAnon37(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 114, 118, 154, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024195([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.lancerLaser, obj0.fin());
      Lines.stroke(obj0.fout() * 1.2f + 0.5f);
      Angles.randLenVectors((long) obj0.id, 7, 25f * obj0.finpow(), obj0.rotation, 50f, (Floatc2) new Fx.__\u003C\u003EAnon36(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 123, 118, 154, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024197([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Ewhite, Pal.thoriumPink, obj0.fin());
      Lines.stroke(obj0.fout() * 1.2f + 0.5f);
      Angles.randLenVectors((long) obj0.id, 7, 25f * obj0.finpow(), obj0.rotation, 50f, (Floatc2) new Fx.__\u003C\u003EAnon35(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 132, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024199([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 4, obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon34(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 140, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024201([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 4, obj0.fin() * 13f, (Floatc2) new Fx.__\u003C\u003EAnon33(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 148, 255, 15, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024203([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 12, 15f + obj0.fin() * 45f, (Floatc2) new Fx.__\u003C\u003EAnon32(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 157, 255, 8, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024205([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 10, obj0.finpow() * 90f, (Floatc2) new Fx.__\u003C\u003EAnon31(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 165, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024207([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 7, obj0.fin() * 20f, (Floatc2) new Fx.__\u003C\u003EAnon30(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 173, 255, 8, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024209([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 20, obj0.finpow() * 160f, (Floatc2) new Fx.__\u003C\u003EAnon29(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 181, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024211([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon28(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 189, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024213([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon27(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 197, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024215([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 9f, (Floatc2) new Fx.__\u003C\u003EAnon26(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 205, 255, 7, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024217([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, obj0.fin() * 9f, (Floatc2) new Fx.__\u003C\u003EAnon25(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 213, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024219([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, 3f + obj0.fin() * 5f, (Floatc2) new Fx.__\u003C\u003EAnon24(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 220, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024221([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, 3f + obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon23(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 227, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024223([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, 3f + obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon22(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 234, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024225([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, 3f + obj0.fin() * 9f, (Floatc2) new Fx.__\u003C\u003EAnon21(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 241, 223, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024227([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 3, obj0.fin() * 5f, (Floatc2) new Fx.__\u003C\u003EAnon20(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 248, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024229([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 5, 3f + obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon19(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {164, 255, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024231([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 8, 4f + obj0.fin() * 18f, (Floatc2) new Fx.__\u003C\u003EAnon18(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 6, 255, 6, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024233([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, obj0.fin(), 30, 30f, (Angles.ParticleConsumer) new Fx.__\u003C\u003EAnon17(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 14, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024235([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 6, 4f + obj0.fin() * 5f, (Floatc2) new Fx.__\u003C\u003EAnon16(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 21, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024237([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 6, 5f + obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon15(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 28, 255, 15, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024239([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 12, 1f + obj0.fin() * 23f, (Floatc2) new Fx.__\u003C\u003EAnon14(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 36, 255, 14, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024241([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 3, 1f + obj0.fin() * 10f, (Floatc2) new Fx.__\u003C\u003EAnon13(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 44, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024242([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(obj0.fout() * 1.6f);
      Lines.square(obj0.x, obj0.y, 4f + obj0.fin() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 49, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024243([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(obj0.fout() * 1.6f);
      Lines.square(obj0.x, obj0.y, 4f + obj0.fout() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 54, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024244([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(obj0.fout() * 1.6f);
      Lines.square(obj0.x, obj0.y, 8f + obj0.fin() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 59, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024245([In] Effect.EffectContainer obj0)
    {
      Lines.stroke(obj0.fout() * 1.6f);
      Lines.square(obj0.x, obj0.y, 8f + obj0.fout() * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 64, 118, 106, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024246([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Eroyal, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(2f);
      Lines.spikes(obj0.x, obj0.y, obj0.fin() * 4f, 2f, 6);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 70, 118, 106, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024247([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Eblack, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(2f);
      Lines.spikes(obj0.x, obj0.y, obj0.fin() * 4f, 2f, 6);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 76, 118, 106, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024248([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Eorange, Color.__\u003C\u003Egray, obj0.fin());
      Lines.stroke(2f);
      Lines.spikes(obj0.x, obj0.y, obj0.fin() * 4f, 2f, 6);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 82, 118, 106, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024249([In] Effect.EffectContainer obj0)
    {
      Draw.color(Color.__\u003C\u003Eorange, Color.__\u003C\u003Eyellow, obj0.fin());
      Lines.stroke(1f);
      Lines.spikes(obj0.x, obj0.y, obj0.fin() * 5f, 2f, 8);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 88, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024251([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 6, 3f + obj0.fin() * 6f, (Floatc2) new Fx.__\u003C\u003EAnon12(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 95, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024253([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 6, 4f + obj0.fin() * 8f, (Floatc2) new Fx.__\u003C\u003EAnon11(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 102, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024255([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 8, 5f + obj0.fin() * 10f, (Floatc2) new Fx.__\u003C\u003EAnon10(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 109, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024257([In] Effect.EffectContainer obj0) => Angles.randLenVectors((long) obj0.id, 6, 2f + obj0.fin() * 5f, (Floatc2) new Fx.__\u003C\u003EAnon9(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {165, 116, 139, 245, 69, 147, 191, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024260([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      obj0.scaled(8f, (Cons) new Fx.__\u003C\u003EAnon7());
      Lines.stroke(obj0.fout() * 2f);
      Angles.randLenVectors((long) obj0.id, 30, 4f + 40f * obj0.fin(), (Floatc2) new Fx.__\u003C\u003EAnon8(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 131, 107, 115, 159, 7, 191, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024262([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fin() * 2f);
      Lines.circle(obj0.x, obj0.y, 7f + obj0.fout() * 8f);
      Angles.randLenVectors((long) obj0.id, 20, 6f + 20f * obj0.fout(), (Floatc2) new Fx.__\u003C\u003EAnon6(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 141, 107, 115, 159, 7, 191, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024264([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 7f + obj0.fin() * 8f);
      Angles.randLenVectors((long) obj0.id, 20, 4f + 20f * obj0.fin(), (Floatc2) new Fx.__\u003C\u003EAnon5(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 151, 147, 127, 0, 115, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024265([In] Effect.EffectContainer obj0)
    {
      obj0.lifetime = 30f * obj0.rotation;
      Draw.color(Tmp.__\u003C\u003Ec1.set(obj0.color).mul(1.5f));
      Lines.stroke(obj0.fout() * 1.4f);
      Lines.circle(obj0.x, obj0.y, (2f + obj0.fin() * 4f) * obj0.rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 159, 127, 0, 115, 189})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024267([In] Effect.EffectContainer obj0)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(obj0.color).shiftValue(0.1f));
      Lines.stroke(obj0.fout() + 0.2f);
      Angles.randLenVectors((long) obj0.id, 2, 8f, (Floatc2) new Fx.__\u003C\u003EAnon4(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 167, 106, 115, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024268([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.command);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, 4f + obj0.finpow() * 120f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 173, 138, 246, 69, 147, 223, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024271([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.engine);
      obj0.scaled(25f, (Cons) new Fx.__\u003C\u003EAnon2(obj0));
      Lines.stroke(obj0.fout() * 2f);
      Angles.randLenVectors((long) obj0.id, 24, obj0.finpow() * 50f, (Floatc2) new Fx.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 189, 107, 115, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024272([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fout() * 2f);
      Lines.circle(obj0.x, obj0.y, obj0.finpow() * obj0.rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 195, 107, 108, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024273([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(obj0.fout());
      Lines.circle(obj0.x, obj0.y, obj0.finpow() * obj0.rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 201, 106, 122, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024274([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.heal);
      Lines.stroke(2f * obj0.fout() + 0.5f);
      Lines.square(obj0.x, obj0.y, 1f + (obj0.fin() * obj0.rotation * 8f / 2f - 1f));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 207, 107, 108, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024275([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Draw.alpha(obj0.fout());
      Fill.square(obj0.x, obj0.y, obj0.rotation * 8f / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 213, 106, 115, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024276([In] Effect.EffectContainer obj0)
    {
      Draw.color(Pal.accent);
      Draw.alpha(obj0.fout() * 1f);
      Fill.square(obj0.x, obj0.y, obj0.rotation * 8f / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 219, 107, 115, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024277([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Draw.alpha(obj0.fout() * 1f);
      Fill.square(obj0.x, obj0.y, obj0.rotation * 8f / 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 225, 107, 115, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024278([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Draw.alpha(obj0.fslope() * 0.4f);
      Fill.square(obj0.x, obj0.y, obj0.rotation * 8f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 231, 107, 115, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024279([In] Effect.EffectContainer obj0)
    {
      Draw.color(obj0.color);
      Lines.stroke(3f * obj0.fout());
      Lines.poly(obj0.x, obj0.y, 6, obj0.rotation + obj0.fin());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 237, 142, 140, 143, 247, 73, 113, 108, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024282([In] Effect.EffectContainer obj0)
    {
      if (!(obj0.data is Unitc))
        return;
      float rad = ((Unit) obj0.data()).hitSize() * 1.3f;
      obj0.scaled(16f, (Cons) new Fx.__\u003C\u003EAnon0(obj0, rad));
      Draw.color(Pal.shield, obj0.fout());
      Lines.stroke(obj0.fout());
      Lines.circle(obj0.x, obj0.y, rad);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u0024283([In] Effect.EffectContainer obj0)
    {
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fx()
    {
    }

    [LineNumberTable(new byte[] {159, 136, 141, 159, 4, 254, 85, 254, 72, 254, 81, 254, 79, 254, 83, 254, 79, 254, 75, 254, 70, 255, 4, 83, 254, 70, 254, 70, 254, 70, 254, 70, 254, 74, 254, 70, 254, 69, 254, 69, 254, 80, 254, 70, 254, 70, 254, 69, 254, 70, 254, 70, 254, 71, 254, 69, 138, 254, 69, 138, 254, 69, 138, 222, 138, 222, 138, 254, 70, 255, 4, 80, 255, 4, 80, 255, 4, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 80, 254, 80, 254, 74, 254, 74, 254, 72, 254, 74, 254, 74, 254, 74, 254, 74, 254, 74, 255, 4, 79, 254, 77, 254, 79, 255, 4, 94, 254, 70, 254, 70, 254, 75, 254, 86, 254, 86, 254, 86, 254, 86, 254, 86, 254, 86, 254, 69, 254, 69, 254, 69, 254, 70, 254, 75, 138, 254, 86, 254, 72, 254, 76, 254, 72, 254, 72, 254, 72, 254, 72, 254, 72, 254, 72, 254, 71, 254, 71, 254, 72, 254, 70, 254, 72, 254, 72, 254, 70, 254, 71, 255, 4, 70, 255, 4, 70, 255, 4, 70, 255, 4, 70, 255, 4, 70, 254, 85, 255, 4, 87, 254, 85, 254, 73, 254, 71, 254, 71, 254, 71, 254, 72, 254, 71, 254, 71, 254, 72, 254, 72, 255, 4, 72, 255, 4, 72, 255, 4, 72, 254, 78, 138, 254, 76, 138, 254, 78, 138, 254, 78, 138, 254, 78, 138, 254, 81, 138, 254, 78, 254, 72, 255, 4, 72, 254, 72, 254, 73, 254, 72, 254, 72, 254, 72, 254, 73, 254, 73, 254, 73, 254, 72, 254, 72, 254, 73, 255, 4, 72, 254, 72, 255, 4, 72, 254, 72, 254, 72, 254, 72, 254, 72, 254, 71, 254, 71, 254, 71, 254, 71, 254, 71, 254, 71, 254, 71, 254, 72, 254, 71, 254, 71, 254, 72, 254, 72, 254, 69, 254, 69, 254, 69, 254, 69, 254, 70, 254, 70, 254, 70, 254, 70, 254, 71, 254, 71, 254, 71, 254, 71, 254, 79, 254, 74, 254, 74, 254, 70, 138, 254, 72, 254, 70, 254, 80, 254, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 70, 254, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fx()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.content.Fx"))
        return;
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Enone = new Effect(0.0f, 0.0f, (Cons) new Fx.__\u003C\u003EAnon112());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitSpawn = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon113());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitCapKill = new Effect(80f, (Cons) new Fx.__\u003C\u003EAnon114());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitControl = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon115());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitDespawn = new Effect(100f, (Cons) new Fx.__\u003C\u003EAnon116());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitSpirit = new Effect(17f, (Cons) new Fx.__\u003C\u003EAnon117());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EitemTransfer = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon118());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpointBeam = new Effect(25f, (Cons) new Fx.__\u003C\u003EAnon119());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpointHit = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon120());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Elightning = new Effect(10f, 500f, (Cons) new Fx.__\u003C\u003EAnon121());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EcommandSend = new Effect(28f, (Cons) new Fx.__\u003C\u003EAnon122());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EupgradeCore = new Effect(120f, (Cons) new Fx.__\u003C\u003EAnon123());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EplaceBlock = new Effect(16f, (Cons) new Fx.__\u003C\u003EAnon124());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EtapBlock = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon125());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EbreakBlock = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon126());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eselect = new Effect(23f, (Cons) new Fx.__\u003C\u003EAnon127());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Esmoke = new Effect(100f, (Cons) new Fx.__\u003C\u003EAnon128());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EfallSmoke = new Effect(110f, (Cons) new Fx.__\u003C\u003EAnon129());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitWreck = new Effect(200f, (Cons) new Fx.__\u003C\u003EAnon130());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErocketSmoke = new Effect(120f, (Cons) new Fx.__\u003C\u003EAnon131());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErocketSmokeLarge = new Effect(220f, (Cons) new Fx.__\u003C\u003EAnon132());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Emagmasmoke = new Effect(110f, (Cons) new Fx.__\u003C\u003EAnon133());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Espawn = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon134());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epadlaunch = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon135());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EvtolHover = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon136());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitDrop = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon137()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitLand = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon138()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitLandSmall = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon139()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitPickup = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon140()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElandShock = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon141()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epickup = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon142());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EgreenBomb = new Effect(40f, 100f, (Cons) new Fx.__\u003C\u003EAnon143());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EgreenLaserCharge = new Effect(80f, 100f, (Cons) new Fx.__\u003C\u003EAnon144());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EgreenLaserChargeSmall = new Effect(40f, 100f, (Cons) new Fx.__\u003C\u003EAnon145());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhealWaveDynamic = new Effect(22f, (Cons) new Fx.__\u003C\u003EAnon146());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhealWave = new Effect(22f, (Cons) new Fx.__\u003C\u003EAnon147());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eheal = new Effect(11f, (Cons) new Fx.__\u003C\u003EAnon148());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshieldWave = new Effect(22f, (Cons) new Fx.__\u003C\u003EAnon149());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshieldApply = new Effect(11f, (Cons) new Fx.__\u003C\u003EAnon150());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitBulletSmall = new Effect(14f, (Cons) new Fx.__\u003C\u003EAnon151());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitFuse = new Effect(14f, (Cons) new Fx.__\u003C\u003EAnon152());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitBulletBig = new Effect(13f, (Cons) new Fx.__\u003C\u003EAnon153());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitFlameSmall = new Effect(14f, (Cons) new Fx.__\u003C\u003EAnon154());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitLiquid = new Effect(16f, (Cons) new Fx.__\u003C\u003EAnon155());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitLaserBlast = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon156());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitLancer = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon157());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitBeam = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon158());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitMeltdown = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon159());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitMeltHeal = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon160());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EinstBomb = new Effect(15f, 100f, (Cons) new Fx.__\u003C\u003EAnon161());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EinstTrail = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon162());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EinstShoot = new Effect(24f, (Cons) new Fx.__\u003C\u003EAnon163());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EinstHit = new Effect(20f, 200f, (Cons) new Fx.__\u003C\u003EAnon164());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitLaser = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon165());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhitYellowLaser = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon166());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Edespawn = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon167());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EflakExplosion = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon168());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EplasticExplosion = new Effect(24f, (Cons) new Fx.__\u003C\u003EAnon169());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EplasticExplosionFlak = new Effect(28f, (Cons) new Fx.__\u003C\u003EAnon170());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EblastExplosion = new Effect(22f, (Cons) new Fx.__\u003C\u003EAnon171());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EsapExplosion = new Effect(25f, (Cons) new Fx.__\u003C\u003EAnon172());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EmassiveExplosion = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon173());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EartilleryTrail = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon174());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EincendTrail = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon175());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EmissileTrail = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon176());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eabsorb = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon177());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EforceShrink = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon178()).layer(125f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EflakExplosionBig = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon179());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eburning = new Effect(35f, (Cons) new Fx.__\u003C\u003EAnon180());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Efire = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon181());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EfireSmoke = new Effect(35f, (Cons) new Fx.__\u003C\u003EAnon182());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Esteam = new Effect(35f, (Cons) new Fx.__\u003C\u003EAnon183());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Efireballsmoke = new Effect(25f, (Cons) new Fx.__\u003C\u003EAnon184());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eballfire = new Effect(25f, (Cons) new Fx.__\u003C\u003EAnon185());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Efreezing = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon186());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Emelting = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon187());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ewet = new Effect(80f, (Cons) new Fx.__\u003C\u003EAnon188());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Emuddy = new Effect(80f, (Cons) new Fx.__\u003C\u003EAnon189());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Esapped = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon190());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EsporeSlowed = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon191());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eoily = new Effect(42f, (Cons) new Fx.__\u003C\u003EAnon192());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eoverdriven = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon193());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eoverclocked = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon194());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EdropItem = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon195());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eshockwave = new Effect(10f, 80f, (Cons) new Fx.__\u003C\u003EAnon196());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EbigShockwave = new Effect(10f, 80f, (Cons) new Fx.__\u003C\u003EAnon197());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EnuclearShockwave = new Effect(10f, 200f, (Cons) new Fx.__\u003C\u003EAnon198());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EimpactShockwave = new Effect(13f, 300f, (Cons) new Fx.__\u003C\u003EAnon199());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EspawnShockwave = new Effect(20f, 400f, (Cons) new Fx.__\u003C\u003EAnon200());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eexplosion = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon201());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EdynamicExplosion = new Effect(30f, 100f, (Cons) new Fx.__\u003C\u003EAnon202());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EblockExplosion = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon203());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EblockExplosionSmoke = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon204());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootSmall = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon205());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootHeal = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon206());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootHealYellow = new Effect(8f, (Cons) new Fx.__\u003C\u003EAnon207());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootSmallSmoke = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon208());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootBig = new Effect(9f, (Cons) new Fx.__\u003C\u003EAnon209());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootBig2 = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon210());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootBigSmoke = new Effect(17f, (Cons) new Fx.__\u003C\u003EAnon211());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootBigSmoke2 = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon212());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootSmallFlame = new Effect(32f, 80f, (Cons) new Fx.__\u003C\u003EAnon213());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootPyraFlame = new Effect(33f, 80f, (Cons) new Fx.__\u003C\u003EAnon214());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshootLiquid = new Effect(40f, 80f, (Cons) new Fx.__\u003C\u003EAnon215());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing1 = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon216()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing2 = new Effect(34f, (Cons) new Fx.__\u003C\u003EAnon217()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing3 = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon218()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing4 = new Effect(45f, (Cons) new Fx.__\u003C\u003EAnon219()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing2Double = new Effect(34f, (Cons) new Fx.__\u003C\u003EAnon220()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecasing3Double = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon221()).layer(100f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErailShoot = new Effect(24f, (Cons) new Fx.__\u003C\u003EAnon222());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErailTrail = new Effect(16f, (Cons) new Fx.__\u003C\u003EAnon223());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErailHit = new Effect(18f, 200f, (Cons) new Fx.__\u003C\u003EAnon224());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElancerLaserShoot = new Effect(21f, (Cons) new Fx.__\u003C\u003EAnon225());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElancerLaserShootSmoke = new Effect(26f, (Cons) new Fx.__\u003C\u003EAnon226());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElancerLaserCharge = new Effect(38f, (Cons) new Fx.__\u003C\u003EAnon227());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElancerLaserChargeBegin = new Effect(60f, (Cons) new Fx.__\u003C\u003EAnon228());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElightningCharge = new Effect(38f, (Cons) new Fx.__\u003C\u003EAnon229());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EsparkShoot = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon230());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElightningShoot = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon231());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EthoriumShoot = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon232());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ereactorsmoke = new Effect(17f, (Cons) new Fx.__\u003C\u003EAnon233());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Enuclearsmoke = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon234());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ecloudsmoke = new Effect(70f, (Cons) new Fx.__\u003C\u003EAnon235());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Enuclearcloud = new Effect(90f, 200f, (Cons) new Fx.__\u003C\u003EAnon236());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eimpactsmoke = new Effect(60f, (Cons) new Fx.__\u003C\u003EAnon237());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eimpactcloud = new Effect(140f, 400f, (Cons) new Fx.__\u003C\u003EAnon238());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eredgeneratespark = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon239());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Egeneratespark = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon240());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Efuelburn = new Effect(23f, (Cons) new Fx.__\u003C\u003EAnon241());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EcoreBurn = new Effect(23f, (Cons) new Fx.__\u003C\u003EAnon242());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eplasticburn = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon243());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epulverize = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon244());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpulverizeRed = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon245());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpulverizeRedder = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon246());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpulverizeSmall = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon247());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EpulverizeMedium = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon248());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eproducesmoke = new Effect(12f, (Cons) new Fx.__\u003C\u003EAnon249());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EsmokeCloud = new Effect(70f, (Cons) new Fx.__\u003C\u003EAnon250());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Esmeltsmoke = new Effect(15f, (Cons) new Fx.__\u003C\u003EAnon251());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eformsmoke = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon252());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eblastsmoke = new Effect(26f, (Cons) new Fx.__\u003C\u003EAnon253());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Elava = new Effect(18f, (Cons) new Fx.__\u003C\u003EAnon254());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Edooropen = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon255());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Edoorclose = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon256());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Edooropenlarge = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon257());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Edoorcloselarge = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon258());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epurify = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon259());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epurifyoil = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon260());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Epurifystone = new Effect(10f, (Cons) new Fx.__\u003C\u003EAnon261());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Egenerate = new Effect(11f, (Cons) new Fx.__\u003C\u003EAnon262());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Emine = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon263());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EmineBig = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon264());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EmineHuge = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon265());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Esmelt = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon266());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EteleportActivate = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon267());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eteleport = new Effect(60f, (Cons) new Fx.__\u003C\u003EAnon268());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EteleportOut = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon269());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Eripple = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon270()).layer(20f);
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Ebubble = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon271());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003Elaunch = new Effect(28f, (Cons) new Fx.__\u003C\u003EAnon272());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElaunchPod = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon273());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhealWaveMend = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon274());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EoverdriveWave = new Effect(50f, (Cons) new Fx.__\u003C\u003EAnon275());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhealBlock = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon276());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EhealBlockFull = new Effect(20f, (Cons) new Fx.__\u003C\u003EAnon277());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ErotateBlock = new Effect(30f, (Cons) new Fx.__\u003C\u003EAnon278());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003ElightBlock = new Effect(60f, (Cons) new Fx.__\u003C\u003EAnon279());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EoverdriveBlockFull = new Effect(60f, (Cons) new Fx.__\u003C\u003EAnon280());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EshieldBreak = new Effect(40f, (Cons) new Fx.__\u003C\u003EAnon281());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EunitShieldBreak = new Effect(35f, (Cons) new Fx.__\u003C\u003EAnon282());
      Effect.__\u003Cclinit\u003E();
      Fx.__\u003C\u003EcoreLand = new Effect(120f, (Cons) new Fx.__\u003C\u003EAnon283());
    }

    [Modifiers]
    public static Effect none
    {
      [HideFromJava] get => Fx.__\u003C\u003Enone;
    }

    [Modifiers]
    public static Effect unitSpawn
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitSpawn;
    }

    [Modifiers]
    public static Effect unitCapKill
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitCapKill;
    }

    [Modifiers]
    public static Effect unitControl
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitControl;
    }

    [Modifiers]
    public static Effect unitDespawn
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitDespawn;
    }

    [Modifiers]
    public static Effect unitSpirit
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitSpirit;
    }

    [Modifiers]
    public static Effect itemTransfer
    {
      [HideFromJava] get => Fx.__\u003C\u003EitemTransfer;
    }

    [Modifiers]
    public static Effect pointBeam
    {
      [HideFromJava] get => Fx.__\u003C\u003EpointBeam;
    }

    [Modifiers]
    public static Effect pointHit
    {
      [HideFromJava] get => Fx.__\u003C\u003EpointHit;
    }

    [Modifiers]
    public static Effect lightning
    {
      [HideFromJava] get => Fx.__\u003C\u003Elightning;
    }

    [Modifiers]
    public static Effect commandSend
    {
      [HideFromJava] get => Fx.__\u003C\u003EcommandSend;
    }

    [Modifiers]
    public static Effect upgradeCore
    {
      [HideFromJava] get => Fx.__\u003C\u003EupgradeCore;
    }

    [Modifiers]
    public static Effect placeBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003EplaceBlock;
    }

    [Modifiers]
    public static Effect tapBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003EtapBlock;
    }

    [Modifiers]
    public static Effect breakBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003EbreakBlock;
    }

    [Modifiers]
    public static Effect select
    {
      [HideFromJava] get => Fx.__\u003C\u003Eselect;
    }

    [Modifiers]
    public static Effect smoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Esmoke;
    }

    [Modifiers]
    public static Effect fallSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003EfallSmoke;
    }

    [Modifiers]
    public static Effect unitWreck
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitWreck;
    }

    [Modifiers]
    public static Effect rocketSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003ErocketSmoke;
    }

    [Modifiers]
    public static Effect rocketSmokeLarge
    {
      [HideFromJava] get => Fx.__\u003C\u003ErocketSmokeLarge;
    }

    [Modifiers]
    public static Effect magmasmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Emagmasmoke;
    }

    [Modifiers]
    public static Effect spawn
    {
      [HideFromJava] get => Fx.__\u003C\u003Espawn;
    }

    [Modifiers]
    public static Effect padlaunch
    {
      [HideFromJava] get => Fx.__\u003C\u003Epadlaunch;
    }

    [Modifiers]
    public static Effect vtolHover
    {
      [HideFromJava] get => Fx.__\u003C\u003EvtolHover;
    }

    [Modifiers]
    public static Effect unitDrop
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitDrop;
    }

    [Modifiers]
    public static Effect unitLand
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitLand;
    }

    [Modifiers]
    public static Effect unitLandSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitLandSmall;
    }

    [Modifiers]
    public static Effect unitPickup
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitPickup;
    }

    [Modifiers]
    public static Effect landShock
    {
      [HideFromJava] get => Fx.__\u003C\u003ElandShock;
    }

    [Modifiers]
    public static Effect pickup
    {
      [HideFromJava] get => Fx.__\u003C\u003Epickup;
    }

    [Modifiers]
    public static Effect greenBomb
    {
      [HideFromJava] get => Fx.__\u003C\u003EgreenBomb;
    }

    [Modifiers]
    public static Effect greenLaserCharge
    {
      [HideFromJava] get => Fx.__\u003C\u003EgreenLaserCharge;
    }

    [Modifiers]
    public static Effect greenLaserChargeSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EgreenLaserChargeSmall;
    }

    [Modifiers]
    public static Effect healWaveDynamic
    {
      [HideFromJava] get => Fx.__\u003C\u003EhealWaveDynamic;
    }

    [Modifiers]
    public static Effect healWave
    {
      [HideFromJava] get => Fx.__\u003C\u003EhealWave;
    }

    [Modifiers]
    public static Effect heal
    {
      [HideFromJava] get => Fx.__\u003C\u003Eheal;
    }

    [Modifiers]
    public static Effect shieldWave
    {
      [HideFromJava] get => Fx.__\u003C\u003EshieldWave;
    }

    [Modifiers]
    public static Effect shieldApply
    {
      [HideFromJava] get => Fx.__\u003C\u003EshieldApply;
    }

    [Modifiers]
    public static Effect hitBulletSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitBulletSmall;
    }

    [Modifiers]
    public static Effect hitFuse
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitFuse;
    }

    [Modifiers]
    public static Effect hitBulletBig
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitBulletBig;
    }

    [Modifiers]
    public static Effect hitFlameSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitFlameSmall;
    }

    [Modifiers]
    public static Effect hitLiquid
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitLiquid;
    }

    [Modifiers]
    public static Effect hitLaserBlast
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitLaserBlast;
    }

    [Modifiers]
    public static Effect hitLancer
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitLancer;
    }

    [Modifiers]
    public static Effect hitBeam
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitBeam;
    }

    [Modifiers]
    public static Effect hitMeltdown
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitMeltdown;
    }

    [Modifiers]
    public static Effect hitMeltHeal
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitMeltHeal;
    }

    [Modifiers]
    public static Effect instBomb
    {
      [HideFromJava] get => Fx.__\u003C\u003EinstBomb;
    }

    [Modifiers]
    public static Effect instTrail
    {
      [HideFromJava] get => Fx.__\u003C\u003EinstTrail;
    }

    [Modifiers]
    public static Effect instShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003EinstShoot;
    }

    [Modifiers]
    public static Effect instHit
    {
      [HideFromJava] get => Fx.__\u003C\u003EinstHit;
    }

    [Modifiers]
    public static Effect hitLaser
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitLaser;
    }

    [Modifiers]
    public static Effect hitYellowLaser
    {
      [HideFromJava] get => Fx.__\u003C\u003EhitYellowLaser;
    }

    [Modifiers]
    public static Effect despawn
    {
      [HideFromJava] get => Fx.__\u003C\u003Edespawn;
    }

    [Modifiers]
    public static Effect flakExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EflakExplosion;
    }

    [Modifiers]
    public static Effect plasticExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EplasticExplosion;
    }

    [Modifiers]
    public static Effect plasticExplosionFlak
    {
      [HideFromJava] get => Fx.__\u003C\u003EplasticExplosionFlak;
    }

    [Modifiers]
    public static Effect blastExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EblastExplosion;
    }

    [Modifiers]
    public static Effect sapExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EsapExplosion;
    }

    [Modifiers]
    public static Effect massiveExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EmassiveExplosion;
    }

    [Modifiers]
    public static Effect artilleryTrail
    {
      [HideFromJava] get => Fx.__\u003C\u003EartilleryTrail;
    }

    [Modifiers]
    public static Effect incendTrail
    {
      [HideFromJava] get => Fx.__\u003C\u003EincendTrail;
    }

    [Modifiers]
    public static Effect missileTrail
    {
      [HideFromJava] get => Fx.__\u003C\u003EmissileTrail;
    }

    [Modifiers]
    public static Effect absorb
    {
      [HideFromJava] get => Fx.__\u003C\u003Eabsorb;
    }

    [Modifiers]
    public static Effect forceShrink
    {
      [HideFromJava] get => Fx.__\u003C\u003EforceShrink;
    }

    [Modifiers]
    public static Effect flakExplosionBig
    {
      [HideFromJava] get => Fx.__\u003C\u003EflakExplosionBig;
    }

    [Modifiers]
    public static Effect burning
    {
      [HideFromJava] get => Fx.__\u003C\u003Eburning;
    }

    [Modifiers]
    public static Effect fire
    {
      [HideFromJava] get => Fx.__\u003C\u003Efire;
    }

    [Modifiers]
    public static Effect fireSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003EfireSmoke;
    }

    [Modifiers]
    public static Effect steam
    {
      [HideFromJava] get => Fx.__\u003C\u003Esteam;
    }

    [Modifiers]
    public static Effect fireballsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Efireballsmoke;
    }

    [Modifiers]
    public static Effect ballfire
    {
      [HideFromJava] get => Fx.__\u003C\u003Eballfire;
    }

    [Modifiers]
    public static Effect freezing
    {
      [HideFromJava] get => Fx.__\u003C\u003Efreezing;
    }

    [Modifiers]
    public static Effect melting
    {
      [HideFromJava] get => Fx.__\u003C\u003Emelting;
    }

    [Modifiers]
    public static Effect wet
    {
      [HideFromJava] get => Fx.__\u003C\u003Ewet;
    }

    [Modifiers]
    public static Effect muddy
    {
      [HideFromJava] get => Fx.__\u003C\u003Emuddy;
    }

    [Modifiers]
    public static Effect sapped
    {
      [HideFromJava] get => Fx.__\u003C\u003Esapped;
    }

    [Modifiers]
    public static Effect sporeSlowed
    {
      [HideFromJava] get => Fx.__\u003C\u003EsporeSlowed;
    }

    [Modifiers]
    public static Effect oily
    {
      [HideFromJava] get => Fx.__\u003C\u003Eoily;
    }

    [Modifiers]
    public static Effect overdriven
    {
      [HideFromJava] get => Fx.__\u003C\u003Eoverdriven;
    }

    [Modifiers]
    public static Effect overclocked
    {
      [HideFromJava] get => Fx.__\u003C\u003Eoverclocked;
    }

    [Modifiers]
    public static Effect dropItem
    {
      [HideFromJava] get => Fx.__\u003C\u003EdropItem;
    }

    [Modifiers]
    public static Effect shockwave
    {
      [HideFromJava] get => Fx.__\u003C\u003Eshockwave;
    }

    [Modifiers]
    public static Effect bigShockwave
    {
      [HideFromJava] get => Fx.__\u003C\u003EbigShockwave;
    }

    [Modifiers]
    public static Effect nuclearShockwave
    {
      [HideFromJava] get => Fx.__\u003C\u003EnuclearShockwave;
    }

    [Modifiers]
    public static Effect impactShockwave
    {
      [HideFromJava] get => Fx.__\u003C\u003EimpactShockwave;
    }

    [Modifiers]
    public static Effect spawnShockwave
    {
      [HideFromJava] get => Fx.__\u003C\u003EspawnShockwave;
    }

    [Modifiers]
    public static Effect explosion
    {
      [HideFromJava] get => Fx.__\u003C\u003Eexplosion;
    }

    [Modifiers]
    public static Effect dynamicExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EdynamicExplosion;
    }

    [Modifiers]
    public static Effect blockExplosion
    {
      [HideFromJava] get => Fx.__\u003C\u003EblockExplosion;
    }

    [Modifiers]
    public static Effect blockExplosionSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003EblockExplosionSmoke;
    }

    [Modifiers]
    public static Effect shootSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootSmall;
    }

    [Modifiers]
    public static Effect shootHeal
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootHeal;
    }

    [Modifiers]
    public static Effect shootHealYellow
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootHealYellow;
    }

    [Modifiers]
    public static Effect shootSmallSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootSmallSmoke;
    }

    [Modifiers]
    public static Effect shootBig
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootBig;
    }

    [Modifiers]
    public static Effect shootBig2
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootBig2;
    }

    [Modifiers]
    public static Effect shootBigSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootBigSmoke;
    }

    [Modifiers]
    public static Effect shootBigSmoke2
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootBigSmoke2;
    }

    [Modifiers]
    public static Effect shootSmallFlame
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootSmallFlame;
    }

    [Modifiers]
    public static Effect shootPyraFlame
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootPyraFlame;
    }

    [Modifiers]
    public static Effect shootLiquid
    {
      [HideFromJava] get => Fx.__\u003C\u003EshootLiquid;
    }

    [Modifiers]
    public static Effect casing1
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing1;
    }

    [Modifiers]
    public static Effect casing2
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing2;
    }

    [Modifiers]
    public static Effect casing3
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing3;
    }

    [Modifiers]
    public static Effect casing4
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing4;
    }

    [Modifiers]
    public static Effect casing2Double
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing2Double;
    }

    [Modifiers]
    public static Effect casing3Double
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecasing3Double;
    }

    [Modifiers]
    public static Effect railShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003ErailShoot;
    }

    [Modifiers]
    public static Effect railTrail
    {
      [HideFromJava] get => Fx.__\u003C\u003ErailTrail;
    }

    [Modifiers]
    public static Effect railHit
    {
      [HideFromJava] get => Fx.__\u003C\u003ErailHit;
    }

    [Modifiers]
    public static Effect lancerLaserShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003ElancerLaserShoot;
    }

    [Modifiers]
    public static Effect lancerLaserShootSmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003ElancerLaserShootSmoke;
    }

    [Modifiers]
    public static Effect lancerLaserCharge
    {
      [HideFromJava] get => Fx.__\u003C\u003ElancerLaserCharge;
    }

    [Modifiers]
    public static Effect lancerLaserChargeBegin
    {
      [HideFromJava] get => Fx.__\u003C\u003ElancerLaserChargeBegin;
    }

    [Modifiers]
    public static Effect lightningCharge
    {
      [HideFromJava] get => Fx.__\u003C\u003ElightningCharge;
    }

    [Modifiers]
    public static Effect sparkShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003EsparkShoot;
    }

    [Modifiers]
    public static Effect lightningShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003ElightningShoot;
    }

    [Modifiers]
    public static Effect thoriumShoot
    {
      [HideFromJava] get => Fx.__\u003C\u003EthoriumShoot;
    }

    [Modifiers]
    public static Effect reactorsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Ereactorsmoke;
    }

    [Modifiers]
    public static Effect nuclearsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Enuclearsmoke;
    }

    [Modifiers]
    public static Effect cloudsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Ecloudsmoke;
    }

    [Modifiers]
    public static Effect nuclearcloud
    {
      [HideFromJava] get => Fx.__\u003C\u003Enuclearcloud;
    }

    [Modifiers]
    public static Effect impactsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Eimpactsmoke;
    }

    [Modifiers]
    public static Effect impactcloud
    {
      [HideFromJava] get => Fx.__\u003C\u003Eimpactcloud;
    }

    [Modifiers]
    public static Effect redgeneratespark
    {
      [HideFromJava] get => Fx.__\u003C\u003Eredgeneratespark;
    }

    [Modifiers]
    public static Effect generatespark
    {
      [HideFromJava] get => Fx.__\u003C\u003Egeneratespark;
    }

    [Modifiers]
    public static Effect fuelburn
    {
      [HideFromJava] get => Fx.__\u003C\u003Efuelburn;
    }

    [Modifiers]
    public static Effect coreBurn
    {
      [HideFromJava] get => Fx.__\u003C\u003EcoreBurn;
    }

    [Modifiers]
    public static Effect plasticburn
    {
      [HideFromJava] get => Fx.__\u003C\u003Eplasticburn;
    }

    [Modifiers]
    public static Effect pulverize
    {
      [HideFromJava] get => Fx.__\u003C\u003Epulverize;
    }

    [Modifiers]
    public static Effect pulverizeRed
    {
      [HideFromJava] get => Fx.__\u003C\u003EpulverizeRed;
    }

    [Modifiers]
    public static Effect pulverizeRedder
    {
      [HideFromJava] get => Fx.__\u003C\u003EpulverizeRedder;
    }

    [Modifiers]
    public static Effect pulverizeSmall
    {
      [HideFromJava] get => Fx.__\u003C\u003EpulverizeSmall;
    }

    [Modifiers]
    public static Effect pulverizeMedium
    {
      [HideFromJava] get => Fx.__\u003C\u003EpulverizeMedium;
    }

    [Modifiers]
    public static Effect producesmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Eproducesmoke;
    }

    [Modifiers]
    public static Effect smokeCloud
    {
      [HideFromJava] get => Fx.__\u003C\u003EsmokeCloud;
    }

    [Modifiers]
    public static Effect smeltsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Esmeltsmoke;
    }

    [Modifiers]
    public static Effect formsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Eformsmoke;
    }

    [Modifiers]
    public static Effect blastsmoke
    {
      [HideFromJava] get => Fx.__\u003C\u003Eblastsmoke;
    }

    [Modifiers]
    public static Effect lava
    {
      [HideFromJava] get => Fx.__\u003C\u003Elava;
    }

    [Modifiers]
    public static Effect dooropen
    {
      [HideFromJava] get => Fx.__\u003C\u003Edooropen;
    }

    [Modifiers]
    public static Effect doorclose
    {
      [HideFromJava] get => Fx.__\u003C\u003Edoorclose;
    }

    [Modifiers]
    public static Effect dooropenlarge
    {
      [HideFromJava] get => Fx.__\u003C\u003Edooropenlarge;
    }

    [Modifiers]
    public static Effect doorcloselarge
    {
      [HideFromJava] get => Fx.__\u003C\u003Edoorcloselarge;
    }

    [Modifiers]
    public static Effect purify
    {
      [HideFromJava] get => Fx.__\u003C\u003Epurify;
    }

    [Modifiers]
    public static Effect purifyoil
    {
      [HideFromJava] get => Fx.__\u003C\u003Epurifyoil;
    }

    [Modifiers]
    public static Effect purifystone
    {
      [HideFromJava] get => Fx.__\u003C\u003Epurifystone;
    }

    [Modifiers]
    public static Effect generate
    {
      [HideFromJava] get => Fx.__\u003C\u003Egenerate;
    }

    [Modifiers]
    public static Effect mine
    {
      [HideFromJava] get => Fx.__\u003C\u003Emine;
    }

    [Modifiers]
    public static Effect mineBig
    {
      [HideFromJava] get => Fx.__\u003C\u003EmineBig;
    }

    [Modifiers]
    public static Effect mineHuge
    {
      [HideFromJava] get => Fx.__\u003C\u003EmineHuge;
    }

    [Modifiers]
    public static Effect smelt
    {
      [HideFromJava] get => Fx.__\u003C\u003Esmelt;
    }

    [Modifiers]
    public static Effect teleportActivate
    {
      [HideFromJava] get => Fx.__\u003C\u003EteleportActivate;
    }

    [Modifiers]
    public static Effect teleport
    {
      [HideFromJava] get => Fx.__\u003C\u003Eteleport;
    }

    [Modifiers]
    public static Effect teleportOut
    {
      [HideFromJava] get => Fx.__\u003C\u003EteleportOut;
    }

    [Modifiers]
    public static Effect ripple
    {
      [HideFromJava] get => Fx.__\u003C\u003Eripple;
    }

    [Modifiers]
    public static Effect bubble
    {
      [HideFromJava] get => Fx.__\u003C\u003Ebubble;
    }

    [Modifiers]
    public static Effect launch
    {
      [HideFromJava] get => Fx.__\u003C\u003Elaunch;
    }

    [Modifiers]
    public static Effect launchPod
    {
      [HideFromJava] get => Fx.__\u003C\u003ElaunchPod;
    }

    [Modifiers]
    public static Effect healWaveMend
    {
      [HideFromJava] get => Fx.__\u003C\u003EhealWaveMend;
    }

    [Modifiers]
    public static Effect overdriveWave
    {
      [HideFromJava] get => Fx.__\u003C\u003EoverdriveWave;
    }

    [Modifiers]
    public static Effect healBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003EhealBlock;
    }

    [Modifiers]
    public static Effect healBlockFull
    {
      [HideFromJava] get => Fx.__\u003C\u003EhealBlockFull;
    }

    [Modifiers]
    public static Effect rotateBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003ErotateBlock;
    }

    [Modifiers]
    public static Effect lightBlock
    {
      [HideFromJava] get => Fx.__\u003C\u003ElightBlock;
    }

    [Modifiers]
    public static Effect overdriveBlockFull
    {
      [HideFromJava] get => Fx.__\u003C\u003EoverdriveBlockFull;
    }

    [Modifiers]
    public static Effect shieldBreak
    {
      [HideFromJava] get => Fx.__\u003C\u003EshieldBreak;
    }

    [Modifiers]
    public static Effect unitShieldBreak
    {
      [HideFromJava] get => Fx.__\u003C\u003EunitShieldBreak;
    }

    [Modifiers]
    public static Effect coreLand
    {
      [HideFromJava] get => Fx.__\u003C\u003EcoreLand;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon0([In] Effect.EffectContainer obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024281(this.arg\u00241, this.arg\u00242, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon1([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024280(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon2([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024269(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon3([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024270(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon4([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024266(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon5([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024263(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon6([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024261(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024258((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon8([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024259(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon9([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024256(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon10([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024254(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon11([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024252(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon12([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024250(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon13([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024240(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon14([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024238(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon15([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024236(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon16([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024234(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Angles.ParticleConsumer
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon17([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void accept([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => Fx.lambda\u0024static\u0024232(this.arg\u00241, obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon18([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024230(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon19([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024228(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon20([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024226(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon21([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024224(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon22([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024222(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon23([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024220(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon24([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024218(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon25([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024216(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon26([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024214(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon27([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024212(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon28([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024210(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon29([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024208(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon30([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024206(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon31([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024204(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon32([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024202(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon33([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024200(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon34([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024198(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon35([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024196(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon36([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024194(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon37([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024192(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon38([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024190(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon39([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024187(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon40([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024185(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      internal __\u003C\u003EAnon41()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024180((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon42([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024172(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon43([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024170(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon44([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024168(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon45([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024166(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon46([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024164(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon47([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024160(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon48([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024155(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon49([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024151(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon50([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024152(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon51([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024153(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon52([In] Effect.EffectContainer obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024147(this.arg\u00241, this.arg\u00242, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Angles.ParticleConsumer
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon53([In] Effect.EffectContainer obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => Fx.lambda\u0024static\u0024148(this.arg\u00241, this.arg\u00242, obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Angles.ParticleConsumer
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon54([In] Effect.EffectContainer obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => Fx.lambda\u0024static\u0024149(this.arg\u00241, this.arg\u00242, obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon55([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024143(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon56([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024144(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon57([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024145(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon58([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024134(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon59([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024132(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon60([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024129(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon61([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024125(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon62([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024123(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon63([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024121(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon64([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024119(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon65([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024117(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon66([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024115(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon67([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024113(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon68([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024111(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon69([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024107(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon70([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024108(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon71([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024109(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon72([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002498(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon73([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002499(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon74([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u0024100(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon75([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002494(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon76([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002495(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon77 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon77([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002496(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon78 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon78([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002490(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon79 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon79([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002491(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon80 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon80([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002492(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon81 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon81([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002486(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon82 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon82([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002487(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon83 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon83([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002488(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon84 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon84([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002482(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon85 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon85([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002483(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon86 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon86([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002484(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon87 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon87([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002478(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon88 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon88([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002479(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon89 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon89([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002480(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon90 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon90([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002476(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon91 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon91([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002470(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon92 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon92([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002472(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon93 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly Effect.EffectContainer arg\u00242;

      internal __\u003C\u003EAnon93([In] Effect.EffectContainer obj0, [In] Effect.EffectContainer obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002471(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon94 : Cons
    {
      internal __\u003C\u003EAnon94()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002468((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon95 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon95([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002464(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon96 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon96([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002462(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon97 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon97([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002460(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon98 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon98([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002458(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon99 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon99([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002456(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon100 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon100([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002454(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon101 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon101([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002452(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon102 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon102([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002450(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon103 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon103([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002447(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon104 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon104([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002448(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon105 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon105([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Fx.lambda\u0024static\u002444(this.arg\u00241, (Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon106 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon106([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002445(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon107 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon107([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002436(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon108 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon108([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002430(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon109 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon109([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002428(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon110 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon110([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002426(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon111 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;

      internal __\u003C\u003EAnon111([In] Effect.EffectContainer obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => Fx.lambda\u0024static\u002414(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon112 : Cons
    {
      internal __\u003C\u003EAnon112()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00240((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon113 : Cons
    {
      internal __\u003C\u003EAnon113()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00241((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon114 : Cons
    {
      internal __\u003C\u003EAnon114()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00242((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon115 : Cons
    {
      internal __\u003C\u003EAnon115()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00243((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon116 : Cons
    {
      internal __\u003C\u003EAnon116()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00244((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon117 : Cons
    {
      internal __\u003C\u003EAnon117()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00245((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon118 : Cons
    {
      internal __\u003C\u003EAnon118()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00246((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon119 : Cons
    {
      internal __\u003C\u003EAnon119()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00247((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon120 : Cons
    {
      internal __\u003C\u003EAnon120()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00248((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon121 : Cons
    {
      internal __\u003C\u003EAnon121()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u00249((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon122 : Cons
    {
      internal __\u003C\u003EAnon122()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002410((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon123 : Cons
    {
      internal __\u003C\u003EAnon123()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002411((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon124 : Cons
    {
      internal __\u003C\u003EAnon124()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002412((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon125 : Cons
    {
      internal __\u003C\u003EAnon125()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002413((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon126 : Cons
    {
      internal __\u003C\u003EAnon126()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002415((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon127 : Cons
    {
      internal __\u003C\u003EAnon127()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002416((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon128 : Cons
    {
      internal __\u003C\u003EAnon128()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002417((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon129 : Cons
    {
      internal __\u003C\u003EAnon129()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002418((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon130 : Cons
    {
      internal __\u003C\u003EAnon130()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002419((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon131 : Cons
    {
      internal __\u003C\u003EAnon131()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002420((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon132 : Cons
    {
      internal __\u003C\u003EAnon132()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002421((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon133 : Cons
    {
      internal __\u003C\u003EAnon133()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002422((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon134 : Cons
    {
      internal __\u003C\u003EAnon134()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002423((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon135 : Cons
    {
      internal __\u003C\u003EAnon135()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002424((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon136 : Cons
    {
      internal __\u003C\u003EAnon136()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002425((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon137 : Cons
    {
      internal __\u003C\u003EAnon137()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002427((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon138 : Cons
    {
      internal __\u003C\u003EAnon138()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002429((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon139 : Cons
    {
      internal __\u003C\u003EAnon139()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002431((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon140 : Cons
    {
      internal __\u003C\u003EAnon140()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002432((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon141 : Cons
    {
      internal __\u003C\u003EAnon141()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002433((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon142 : Cons
    {
      internal __\u003C\u003EAnon142()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002434((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon143 : Cons
    {
      internal __\u003C\u003EAnon143()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002435((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon144 : Cons
    {
      internal __\u003C\u003EAnon144()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002437((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon145 : Cons
    {
      internal __\u003C\u003EAnon145()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002438((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon146 : Cons
    {
      internal __\u003C\u003EAnon146()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002439((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon147 : Cons
    {
      internal __\u003C\u003EAnon147()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002440((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon148 : Cons
    {
      internal __\u003C\u003EAnon148()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002441((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon149 : Cons
    {
      internal __\u003C\u003EAnon149()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002442((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon150 : Cons
    {
      internal __\u003C\u003EAnon150()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002443((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon151 : Cons
    {
      internal __\u003C\u003EAnon151()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002446((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon152 : Cons
    {
      internal __\u003C\u003EAnon152()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002449((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon153 : Cons
    {
      internal __\u003C\u003EAnon153()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002451((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon154 : Cons
    {
      internal __\u003C\u003EAnon154()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002453((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon155 : Cons
    {
      internal __\u003C\u003EAnon155()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002455((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon156 : Cons
    {
      internal __\u003C\u003EAnon156()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002457((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon157 : Cons
    {
      internal __\u003C\u003EAnon157()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002459((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon158 : Cons
    {
      internal __\u003C\u003EAnon158()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002461((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon159 : Cons
    {
      internal __\u003C\u003EAnon159()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002463((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon160 : Cons
    {
      internal __\u003C\u003EAnon160()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002465((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon161 : Cons
    {
      internal __\u003C\u003EAnon161()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002466((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon162 : Cons
    {
      internal __\u003C\u003EAnon162()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002467((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon163 : Cons
    {
      internal __\u003C\u003EAnon163()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002469((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon164 : Cons
    {
      internal __\u003C\u003EAnon164()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002473((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon165 : Cons
    {
      internal __\u003C\u003EAnon165()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002474((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon166 : Cons
    {
      internal __\u003C\u003EAnon166()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002475((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon167 : Cons
    {
      internal __\u003C\u003EAnon167()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002477((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon168 : Cons
    {
      internal __\u003C\u003EAnon168()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002481((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon169 : Cons
    {
      internal __\u003C\u003EAnon169()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002485((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon170 : Cons
    {
      internal __\u003C\u003EAnon170()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002489((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon171 : Cons
    {
      internal __\u003C\u003EAnon171()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002493((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon172 : Cons
    {
      internal __\u003C\u003EAnon172()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u002497((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon173 : Cons
    {
      internal __\u003C\u003EAnon173()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024101((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon174 : Cons
    {
      internal __\u003C\u003EAnon174()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024102((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon175 : Cons
    {
      internal __\u003C\u003EAnon175()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024103((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon176 : Cons
    {
      internal __\u003C\u003EAnon176()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024104((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon177 : Cons
    {
      internal __\u003C\u003EAnon177()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024105((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon178 : Cons
    {
      internal __\u003C\u003EAnon178()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024106((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon179 : Cons
    {
      internal __\u003C\u003EAnon179()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024110((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon180 : Cons
    {
      internal __\u003C\u003EAnon180()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024112((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon181 : Cons
    {
      internal __\u003C\u003EAnon181()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024114((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon182 : Cons
    {
      internal __\u003C\u003EAnon182()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024116((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon183 : Cons
    {
      internal __\u003C\u003EAnon183()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024118((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon184 : Cons
    {
      internal __\u003C\u003EAnon184()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024120((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon185 : Cons
    {
      internal __\u003C\u003EAnon185()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024122((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon186 : Cons
    {
      internal __\u003C\u003EAnon186()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024124((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon187 : Cons
    {
      internal __\u003C\u003EAnon187()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024126((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon188 : Cons
    {
      internal __\u003C\u003EAnon188()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024127((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon189 : Cons
    {
      internal __\u003C\u003EAnon189()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024128((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon190 : Cons
    {
      internal __\u003C\u003EAnon190()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024130((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon191 : Cons
    {
      internal __\u003C\u003EAnon191()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024131((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon192 : Cons
    {
      internal __\u003C\u003EAnon192()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024133((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon193 : Cons
    {
      internal __\u003C\u003EAnon193()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024135((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon194 : Cons
    {
      internal __\u003C\u003EAnon194()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024136((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon195 : Cons
    {
      internal __\u003C\u003EAnon195()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024137((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon196 : Cons
    {
      internal __\u003C\u003EAnon196()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024138((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon197 : Cons
    {
      internal __\u003C\u003EAnon197()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024139((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon198 : Cons
    {
      internal __\u003C\u003EAnon198()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024140((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon199 : Cons
    {
      internal __\u003C\u003EAnon199()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024141((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon200 : Cons
    {
      internal __\u003C\u003EAnon200()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024142((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon201 : Cons
    {
      internal __\u003C\u003EAnon201()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024146((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon202 : Cons
    {
      internal __\u003C\u003EAnon202()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024150((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon203 : Cons
    {
      internal __\u003C\u003EAnon203()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024154((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon204 : Cons
    {
      internal __\u003C\u003EAnon204()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024156((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon205 : Cons
    {
      internal __\u003C\u003EAnon205()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024157((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon206 : Cons
    {
      internal __\u003C\u003EAnon206()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024158((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon207 : Cons
    {
      internal __\u003C\u003EAnon207()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024159((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon208 : Cons
    {
      internal __\u003C\u003EAnon208()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024161((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon209 : Cons
    {
      internal __\u003C\u003EAnon209()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024162((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon210 : Cons
    {
      internal __\u003C\u003EAnon210()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024163((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon211 : Cons
    {
      internal __\u003C\u003EAnon211()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024165((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon212 : Cons
    {
      internal __\u003C\u003EAnon212()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024167((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon213 : Cons
    {
      internal __\u003C\u003EAnon213()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024169((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon214 : Cons
    {
      internal __\u003C\u003EAnon214()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024171((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon215 : Cons
    {
      internal __\u003C\u003EAnon215()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024173((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon216 : Cons
    {
      internal __\u003C\u003EAnon216()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024174((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon217 : Cons
    {
      internal __\u003C\u003EAnon217()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024175((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon218 : Cons
    {
      internal __\u003C\u003EAnon218()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024176((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon219 : Cons
    {
      internal __\u003C\u003EAnon219()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024177((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon220 : Cons
    {
      internal __\u003C\u003EAnon220()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024178((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon221 : Cons
    {
      internal __\u003C\u003EAnon221()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024179((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon222 : Cons
    {
      internal __\u003C\u003EAnon222()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024181((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon223 : Cons
    {
      internal __\u003C\u003EAnon223()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024182((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon224 : Cons
    {
      internal __\u003C\u003EAnon224()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024183((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon225 : Cons
    {
      internal __\u003C\u003EAnon225()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024184((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon226 : Cons
    {
      internal __\u003C\u003EAnon226()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024186((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon227 : Cons
    {
      internal __\u003C\u003EAnon227()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024188((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon228 : Cons
    {
      internal __\u003C\u003EAnon228()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024189((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon229 : Cons
    {
      internal __\u003C\u003EAnon229()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024191((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon230 : Cons
    {
      internal __\u003C\u003EAnon230()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024193((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon231 : Cons
    {
      internal __\u003C\u003EAnon231()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024195((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon232 : Cons
    {
      internal __\u003C\u003EAnon232()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024197((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon233 : Cons
    {
      internal __\u003C\u003EAnon233()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024199((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon234 : Cons
    {
      internal __\u003C\u003EAnon234()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024201((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon235 : Cons
    {
      internal __\u003C\u003EAnon235()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024203((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon236 : Cons
    {
      internal __\u003C\u003EAnon236()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024205((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon237 : Cons
    {
      internal __\u003C\u003EAnon237()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024207((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon238 : Cons
    {
      internal __\u003C\u003EAnon238()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024209((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon239 : Cons
    {
      internal __\u003C\u003EAnon239()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024211((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon240 : Cons
    {
      internal __\u003C\u003EAnon240()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024213((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon241 : Cons
    {
      internal __\u003C\u003EAnon241()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024215((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon242 : Cons
    {
      internal __\u003C\u003EAnon242()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024217((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon243 : Cons
    {
      internal __\u003C\u003EAnon243()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024219((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon244 : Cons
    {
      internal __\u003C\u003EAnon244()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024221((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon245 : Cons
    {
      internal __\u003C\u003EAnon245()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024223((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon246 : Cons
    {
      internal __\u003C\u003EAnon246()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024225((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon247 : Cons
    {
      internal __\u003C\u003EAnon247()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024227((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon248 : Cons
    {
      internal __\u003C\u003EAnon248()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024229((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon249 : Cons
    {
      internal __\u003C\u003EAnon249()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024231((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon250 : Cons
    {
      internal __\u003C\u003EAnon250()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024233((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon251 : Cons
    {
      internal __\u003C\u003EAnon251()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024235((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon252 : Cons
    {
      internal __\u003C\u003EAnon252()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024237((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon253 : Cons
    {
      internal __\u003C\u003EAnon253()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024239((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon254 : Cons
    {
      internal __\u003C\u003EAnon254()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024241((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon255 : Cons
    {
      internal __\u003C\u003EAnon255()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024242((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon256 : Cons
    {
      internal __\u003C\u003EAnon256()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024243((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon257 : Cons
    {
      internal __\u003C\u003EAnon257()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024244((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon258 : Cons
    {
      internal __\u003C\u003EAnon258()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024245((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon259 : Cons
    {
      internal __\u003C\u003EAnon259()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024246((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon260 : Cons
    {
      internal __\u003C\u003EAnon260()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024247((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon261 : Cons
    {
      internal __\u003C\u003EAnon261()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024248((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon262 : Cons
    {
      internal __\u003C\u003EAnon262()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024249((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon263 : Cons
    {
      internal __\u003C\u003EAnon263()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024251((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon264 : Cons
    {
      internal __\u003C\u003EAnon264()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024253((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon265 : Cons
    {
      internal __\u003C\u003EAnon265()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024255((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon266 : Cons
    {
      internal __\u003C\u003EAnon266()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024257((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon267 : Cons
    {
      internal __\u003C\u003EAnon267()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024260((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon268 : Cons
    {
      internal __\u003C\u003EAnon268()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024262((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon269 : Cons
    {
      internal __\u003C\u003EAnon269()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024264((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon270 : Cons
    {
      internal __\u003C\u003EAnon270()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024265((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon271 : Cons
    {
      internal __\u003C\u003EAnon271()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024267((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon272 : Cons
    {
      internal __\u003C\u003EAnon272()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024268((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon273 : Cons
    {
      internal __\u003C\u003EAnon273()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024271((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon274 : Cons
    {
      internal __\u003C\u003EAnon274()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024272((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon275 : Cons
    {
      internal __\u003C\u003EAnon275()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024273((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon276 : Cons
    {
      internal __\u003C\u003EAnon276()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024274((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon277 : Cons
    {
      internal __\u003C\u003EAnon277()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024275((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon278 : Cons
    {
      internal __\u003C\u003EAnon278()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024276((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon279 : Cons
    {
      internal __\u003C\u003EAnon279()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024277((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon280 : Cons
    {
      internal __\u003C\u003EAnon280()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024278((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon281 : Cons
    {
      internal __\u003C\u003EAnon281()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024279((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon282 : Cons
    {
      internal __\u003C\u003EAnon282()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024282((Effect.EffectContainer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon283 : Cons
    {
      internal __\u003C\u003EAnon283()
      {
      }

      public void get([In] object obj0) => Fx.lambda\u0024static\u0024283((Effect.EffectContainer) obj0);
    }
  }
}
