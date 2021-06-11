// Decompiled with JetBrains decompiler
// Type: mindustry.content.Bullets
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Bullets : Object, ContentList
  {
    public static BulletType artilleryDense;
    public static BulletType artilleryPlastic;
    public static BulletType artilleryPlasticFrag;
    public static BulletType artilleryHoming;
    public static BulletType artilleryIncendiary;
    public static BulletType artilleryExplosive;
    public static BulletType flakScrap;
    public static BulletType flakLead;
    public static BulletType flakGlass;
    public static BulletType flakGlassFrag;
    public static BulletType fragGlass;
    public static BulletType fragExplosive;
    public static BulletType fragPlastic;
    public static BulletType fragSurge;
    public static BulletType fragGlassFrag;
    public static BulletType fragPlasticFrag;
    public static BulletType missileExplosive;
    public static BulletType missileIncendiary;
    public static BulletType missileSurge;
    public static BulletType standardCopper;
    public static BulletType standardDense;
    public static BulletType standardThorium;
    public static BulletType standardHoming;
    public static BulletType standardIncendiary;
    public static BulletType standardDenseBig;
    public static BulletType standardThoriumBig;
    public static BulletType standardIncendiaryBig;
    public static BulletType waterShot;
    public static BulletType cryoShot;
    public static BulletType slagShot;
    public static BulletType oilShot;
    public static BulletType heavyWaterShot;
    public static BulletType heavyCryoShot;
    public static BulletType heavySlagShot;
    public static BulletType heavyOilShot;
    public static BulletType damageLightning;
    public static BulletType damageLightningGround;
    public static BulletType fireball;
    public static BulletType basicFlame;
    public static BulletType pyraFlame;
    public static BulletType driverBolt;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bullets()
    {
    }

    [LineNumberTable(new byte[] {159, 188, 245, 74, 117, 112, 139, 250, 74, 250, 75, 250, 78, 250, 78, 250, 79, 250, 80, 250, 75, 245, 75, 245, 76, 245, 78, 250, 74, 250, 74, 245, 79, 245, 77, 245, 75, 245, 75, 245, 79, 245, 79, 245, 78, 245, 73, 245, 72, 250, 73, 250, 73, 250, 75, 250, 70, 250, 73, 250, 77, 245, 104, 245, 79, 245, 78, 240, 69, 208, 240, 69, 208, 240, 76, 240, 76, 240, 76, 240, 76, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Bullets.damageLightning = (BulletType) new Bullets.\u0031(this, 0.0001f, 0.0f);
      Bullets.damageLightningGround = (BulletType) new Bullets.\u0032(this, 0.0001f, 0.0f);
      JsonIO.copy((object) Bullets.damageLightning, (object) Bullets.damageLightningGround);
      Bullets.damageLightningGround.collidesAir = false;
      Bullets.artilleryDense = (BulletType) new Bullets.\u0033(this, 3f, 20f, "shell");
      Bullets.artilleryPlasticFrag = (BulletType) new Bullets.\u0034(this, 2.5f, 10f, "bullet");
      Bullets.artilleryPlastic = (BulletType) new Bullets.\u0035(this, 3.4f, 20f, "shell");
      Bullets.artilleryHoming = (BulletType) new Bullets.\u0036(this, 3f, 20f, "shell");
      Bullets.artilleryIncendiary = (BulletType) new Bullets.\u0037(this, 3f, 20f, "shell");
      Bullets.artilleryExplosive = (BulletType) new Bullets.\u0038(this, 2f, 20f, "shell");
      Bullets.flakGlassFrag = (BulletType) new Bullets.\u0039(this, 3f, 5f, "bullet");
      Bullets.flakLead = (BulletType) new Bullets.\u00310(this, 4.2f, 3f);
      Bullets.flakScrap = (BulletType) new Bullets.\u00311(this, 4f, 3f);
      Bullets.flakGlass = (BulletType) new Bullets.\u00312(this, 4f, 3f);
      Bullets.fragGlassFrag = (BulletType) new Bullets.\u00313(this, 3f, 5f, "bullet");
      Bullets.fragPlasticFrag = (BulletType) new Bullets.\u00314(this, 2.5f, 10f, "bullet");
      Bullets.fragGlass = (BulletType) new Bullets.\u00315(this, 4f, 3f);
      Bullets.fragPlastic = (BulletType) new Bullets.\u00316(this, 4f, 6f);
      Bullets.fragExplosive = (BulletType) new Bullets.\u00317(this, 4f, 5f);
      Bullets.fragSurge = (BulletType) new Bullets.\u00318(this, 4.5f, 13f);
      Bullets.missileExplosive = (BulletType) new Bullets.\u00319(this, 3.7f, 10f);
      Bullets.missileIncendiary = (BulletType) new Bullets.\u00320(this, 3.7f, 12f);
      Bullets.missileSurge = (BulletType) new Bullets.\u00321(this, 3.7f, 18f);
      Bullets.standardCopper = (BulletType) new Bullets.\u00322(this, 2.5f, 9f);
      Bullets.standardDense = (BulletType) new Bullets.\u00323(this, 3.5f, 18f);
      Bullets.standardThorium = (BulletType) new Bullets.\u00324(this, 4f, 29f, "bullet");
      Bullets.standardHoming = (BulletType) new Bullets.\u00325(this, 3f, 12f, "bullet");
      Bullets.standardIncendiary = (BulletType) new Bullets.\u00326(this, 3.2f, 11f, "bullet");
      Bullets.standardDenseBig = (BulletType) new Bullets.\u00327(this, 7f, 55f, "bullet");
      Bullets.standardThoriumBig = (BulletType) new Bullets.\u00328(this, 8f, 80f, "bullet");
      Bullets.standardIncendiaryBig = (BulletType) new Bullets.\u00329(this, 7f, 60f, "bullet");
      Bullets.fireball = (BulletType) new Bullets.\u00330(this, 1f, 4f);
      Bullets.basicFlame = (BulletType) new Bullets.\u00331(this, 3.35f, 16f);
      Bullets.pyraFlame = (BulletType) new Bullets.\u00332(this, 3.35f, 25f);
      Bullets.waterShot = (BulletType) new Bullets.\u00333(this, Liquids.water);
      Bullets.cryoShot = (BulletType) new Bullets.\u00334(this, Liquids.cryofluid);
      Bullets.slagShot = (BulletType) new Bullets.\u00335(this, Liquids.slag);
      Bullets.oilShot = (BulletType) new Bullets.\u00336(this, Liquids.oil);
      Bullets.heavyWaterShot = (BulletType) new Bullets.\u00337(this, Liquids.water);
      Bullets.heavyCryoShot = (BulletType) new Bullets.\u00338(this, Liquids.cryofluid);
      Bullets.heavySlagShot = (BulletType) new Bullets.\u00339(this, Liquids.slag);
      Bullets.heavyOilShot = (BulletType) new Bullets.\u00340(this, Liquids.oil);
      Bullets.driverBolt = (BulletType) new MassDriverBolt();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : BulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {159, 188, 115, 112, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u0031 obj = this;
        this.lifetime = Fx.__\u003C\u003Elightning.lifetime;
        this.hitEffect = Fx.__\u003C\u003EhitLancer;
        this.despawnEffect = Fx.__\u003C\u003Enone;
        this.status = StatusEffects.shocked;
        this.statusDuration = 10f;
        this.hittable = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {101, 115, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00310 obj = this;
        this.lifetime = 60f;
        this.ammoMultiplier = 4f;
        this.shootEffect = Fx.__\u003C\u003EshootSmall;
        this.width = 6f;
        this.height = 8f;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.splashDamage = 40.5f;
        this.splashDamageRadius = 15f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {112, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00311 obj = this;
        this.lifetime = 60f;
        this.ammoMultiplier = 5f;
        this.shootEffect = Fx.__\u003C\u003EshootSmall;
        this.reloadMultiplier = 0.5f;
        this.width = 6f;
        this.height = 8f;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.splashDamage = 33f;
        this.splashDamageRadius = 24f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {124, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00312 obj = this;
        this.lifetime = 60f;
        this.ammoMultiplier = 5f;
        this.shootEffect = Fx.__\u003C\u003EshootSmall;
        this.reloadMultiplier = 0.8f;
        this.width = 6f;
        this.height = 8f;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.splashDamage = 33f;
        this.splashDamageRadius = 20f;
        this.fragBullet = Bullets.flakGlassFrag;
        this.fragBullets = 6;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 74, 117, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00313 obj = this;
        this.width = 5f;
        this.height = 12f;
        this.shrinkY = 1f;
        this.lifetime = 20f;
        this.backColor = Pal.gray;
        this.frontColor = Color.__\u003C\u003Ewhite;
        this.despawnEffect = Fx.__\u003C\u003Enone;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 84, 117, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00314 obj = this;
        this.width = 10f;
        this.height = 12f;
        this.shrinkY = 1f;
        this.lifetime = 15f;
        this.backColor = Pal.plastaniumBack;
        this.frontColor = Pal.plastaniumFront;
        this.despawnEffect = Fx.__\u003C\u003Enone;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 94, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00315 obj = this;
        this.ammoMultiplier = 3f;
        this.shootEffect = Fx.__\u003C\u003EshootSmall;
        this.reloadMultiplier = 0.8f;
        this.width = 6f;
        this.height = 8f;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.splashDamage = 27f;
        this.splashDamageRadius = 16f;
        this.fragBullet = Bullets.fragGlassFrag;
        this.fragBullets = 4;
        this.explodeRange = 20f;
        this.collidesGround = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 109, 115, 107, 107, 107, 103, 107, 107, 107, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00316 obj = this;
        this.splashDamageRadius = 40f;
        this.splashDamage = 37.5f;
        this.fragBullet = Bullets.fragPlasticFrag;
        this.fragBullets = 6;
        this.hitEffect = Fx.__\u003C\u003EplasticExplosion;
        this.frontColor = Pal.plastaniumFront;
        this.backColor = Pal.plastaniumBack;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.collidesGround = true;
        this.explodeRange = 20f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00317 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 122, 115, 107, 107, 107, 107, 135, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00317 obj = this;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.ammoMultiplier = 5f;
        this.splashDamage = 39f;
        this.splashDamageRadius = 60f;
        this.collidesGround = true;
        this.status = StatusEffects.blasted;
        this.statusDuration = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00318 : FlakBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 133, 115, 107, 107, 107, 103, 103, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00318 obj = this;
        this.ammoMultiplier = 5f;
        this.splashDamage = 75f;
        this.splashDamageRadius = 38f;
        this.lightning = 2;
        this.lightningLength = 7;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.collidesGround = true;
        this.explodeRange = 20f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00319 : MissileBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 144, 115, 107, 107, 107, 107, 107, 107, 107, 107, 139, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00319([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00319 obj = this;
        this.width = 8f;
        this.height = 8f;
        this.shrinkY = 0.0f;
        this.drag = -0.01f;
        this.splashDamageRadius = 30f;
        this.splashDamage = 45f;
        this.ammoMultiplier = 4f;
        this.hitEffect = Fx.__\u003C\u003EblastExplosion;
        this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
        this.status = StatusEffects.blasted;
        this.statusDuration = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : BulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(56)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00320 : MissileBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 159, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00320([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00320 obj = this;
        this.frontColor = Pal.lightishOrange;
        this.backColor = Pal.lightOrange;
        this.width = 7f;
        this.height = 8f;
        this.shrinkY = 0.0f;
        this.drag = -0.01f;
        this.homingPower = 0.08f;
        this.splashDamageRadius = 20f;
        this.splashDamage = 30f;
        this.makeFire = true;
        this.hitEffect = Fx.__\u003C\u003EblastExplosion;
        this.status = StatusEffects.burning;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00321 : MissileBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 174, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00321([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00321 obj = this;
        this.width = 8f;
        this.height = 8f;
        this.shrinkY = 0.0f;
        this.drag = -0.01f;
        this.splashDamageRadius = 25f;
        this.splashDamage = 37.5f;
        this.hitEffect = Fx.__\u003C\u003EblastExplosion;
        this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
        this.lightningDamage = 10f;
        this.lightning = 2;
        this.lightningLength = 10;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00322 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 188, 115, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00322([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00322 obj = this;
        this.width = 7f;
        this.height = 9f;
        this.lifetime = 60f;
        this.shootEffect = Fx.__\u003C\u003EshootSmall;
        this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
        this.ammoMultiplier = 2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00323 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 197, 115, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00323([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00323 obj = this;
        this.width = 9f;
        this.height = 12f;
        this.reloadMultiplier = 0.6f;
        this.ammoMultiplier = 4f;
        this.lifetime = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00324 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 205, 117, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00324([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00324 obj = this;
        this.width = 10f;
        this.height = 13f;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.smokeEffect = Fx.__\u003C\u003EshootBigSmoke;
        this.ammoMultiplier = 4f;
        this.lifetime = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00325 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 214, 117, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00325([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00325 obj = this;
        this.width = 7f;
        this.height = 9f;
        this.homingPower = 0.08f;
        this.reloadMultiplier = 1.5f;
        this.ammoMultiplier = 5f;
        this.lifetime = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00326 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 223, 117, 107, 107, 107, 107, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00326([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00326 obj = this;
        this.width = 10f;
        this.height = 12f;
        this.frontColor = Pal.lightishOrange;
        this.backColor = Pal.lightOrange;
        this.status = StatusEffects.burning;
        this.makeFire = true;
        this.inaccuracy = 3f;
        this.lifetime = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00327 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 234, 117, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00327([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00327 obj = this;
        this.width = 15f;
        this.height = 21f;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00328 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 240, 117, 107, 107, 107, 103, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00328([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00328 obj = this;
        this.width = 16f;
        this.height = 23f;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.pierceCap = 2;
        this.pierceBuilding = true;
        this.knockback = 0.7f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00329 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {160, 249, 117, 107, 107, 107, 107, 107, 107, 103, 103, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00329([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u00329 obj = this;
        this.width = 16f;
        this.height = 21f;
        this.frontColor = Pal.lightishOrange;
        this.backColor = Pal.lightOrange;
        this.status = StatusEffects.burning;
        this.shootEffect = Fx.__\u003C\u003EshootBig;
        this.makeFire = true;
        this.pierceCap = 2;
        this.pierceBuilding = true;
        this.knockback = 0.7f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : ArtilleryBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {10, 117, 107, 107, 107, 118, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0033 obj4 = this;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.knockback = 0.8f;
        this.lifetime = 80f;
        Bullets.\u0033 obj5 = this;
        float num1 = 11f;
        double num2 = (double) num1;
        this.height = num1;
        this.width = (float) num2;
        this.collidesTiles = false;
        this.splashDamageRadius = 18.75f;
        this.splashDamage = 33f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00330 : BulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 6, 147, 103, 103, 103, 107, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00330([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00330 obj3 = this;
        this.pierce = true;
        this.collidesTiles = false;
        this.collides = false;
        this.drag = 0.03f;
        Bullets.\u00330 obj4 = this;
        Effect none = Fx.__\u003C\u003Enone;
        Effect effect = none;
        this.despawnEffect = none;
        this.hitEffect = effect;
      }

      [LineNumberTable(new byte[] {161, 17, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void init([In] Bullet obj0) => obj0.vel.setLength(0.6f + Mathf.random(2f));

      [LineNumberTable(new byte[] {161, 22, 123, 127, 0, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw([In] Bullet obj0)
      {
        Draw.color(Pal.lightFlame, Pal.darkFlame, Color.__\u003C\u003Egray, obj0.fin());
        Fill.circle(obj0.x, obj0.y, 3f * obj0.fout());
        Draw.reset();
      }

      [LineNumberTable(new byte[] {161, 29, 120, 119, 99, 198, 120, 182, 120, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void update([In] Bullet obj0)
      {
        if (Mathf.chance(0.04 * (double) Time.delta))
        {
          Tile tile = Vars.world.tileWorld(obj0.x, obj0.y);
          if (tile != null)
            Fires.create(tile);
        }
        if (Mathf.chance(0.1 * (double) Time.delta))
          Fx.__\u003C\u003Efireballsmoke.at(obj0.x, obj0.y);
        if (!Mathf.chance(0.1 * (double) Time.delta))
          return;
        Fx.__\u003C\u003Eballfire.at(obj0.x, obj0.y);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00331 : BulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 46, 115, 107, 107, 107, 103, 103, 107, 107, 107, 107, 107, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00331([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00331 obj = this;
        this.ammoMultiplier = 3f;
        this.hitSize = 7f;
        this.lifetime = 18f;
        this.pierce = true;
        this.collidesAir = false;
        this.statusDuration = 240f;
        this.shootEffect = Fx.__\u003C\u003EshootSmallFlame;
        this.hitEffect = Fx.__\u003C\u003EhitFlameSmall;
        this.despawnEffect = Fx.__\u003C\u003Enone;
        this.status = StatusEffects.burning;
        this.keepVelocity = false;
        this.hittable = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00332 : BulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 61, 115, 107, 107, 107, 103, 103, 107, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00332([In] Bullets obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Bullets.\u00332 obj = this;
        this.ammoMultiplier = 4f;
        this.hitSize = 7f;
        this.lifetime = 18f;
        this.pierce = true;
        this.collidesAir = false;
        this.statusDuration = 360f;
        this.shootEffect = Fx.__\u003C\u003EshootPyraFlame;
        this.hitEffect = Fx.__\u003C\u003EhitFlameSmall;
        this.despawnEffect = Fx.__\u003C\u003Enone;
        this.status = StatusEffects.burning;
        this.hittable = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00333 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 75, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00333([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00333 obj = this;
        this.knockback = 0.7f;
        this.drag = 0.01f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00334 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 80, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00334([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00334 obj = this;
        this.drag = 0.01f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00335 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 84, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00335([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00335 obj = this;
        this.damage = 4f;
        this.drag = 0.01f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00336 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 89, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00336([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00336 obj = this;
        this.drag = 0.01f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00337 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 93, 112, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00337([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00337 obj = this;
        this.lifetime = 49f;
        this.speed = 4f;
        this.knockback = 1.7f;
        this.puddleSize = 8f;
        this.orbSize = 4f;
        this.drag = 1f / 1000f;
        this.ammoMultiplier = 0.4f;
        this.statusDuration = 240f;
        this.damage = 0.2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00338 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 105, 112, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00338([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00338 obj = this;
        this.lifetime = 49f;
        this.speed = 4f;
        this.knockback = 1.3f;
        this.puddleSize = 8f;
        this.orbSize = 4f;
        this.drag = 1f / 1000f;
        this.ammoMultiplier = 0.4f;
        this.statusDuration = 240f;
        this.damage = 0.2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00339 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 117, 112, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00339([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00339 obj = this;
        this.lifetime = 49f;
        this.speed = 4f;
        this.knockback = 1.3f;
        this.puddleSize = 8f;
        this.orbSize = 4f;
        this.damage = 4.75f;
        this.drag = 1f / 1000f;
        this.ammoMultiplier = 0.4f;
        this.statusDuration = 240f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {20, 117, 107, 107, 107, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0034 obj = this;
        this.width = 10f;
        this.height = 12f;
        this.shrinkY = 1f;
        this.lifetime = 15f;
        this.backColor = Pal.plastaniumBack;
        this.frontColor = Pal.plastaniumFront;
        this.despawnEffect = Fx.__\u003C\u003Enone;
        this.collidesAir = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00340 : LiquidBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {161, 129, 112, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00340([In] Bullets obj0, [In] Liquid obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Bullets.\u00340 obj = this;
        this.lifetime = 49f;
        this.speed = 4f;
        this.knockback = 1.3f;
        this.puddleSize = 8f;
        this.orbSize = 4f;
        this.drag = 1f / 1000f;
        this.ammoMultiplier = 0.4f;
        this.statusDuration = 240f;
        this.damage = 0.2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : ArtilleryBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {31, 117, 107, 107, 107, 118, 103, 107, 107, 107, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0035 obj4 = this;
        this.hitEffect = Fx.__\u003C\u003EplasticExplosion;
        this.knockback = 1f;
        this.lifetime = 80f;
        Bullets.\u0035 obj5 = this;
        float num1 = 13f;
        double num2 = (double) num1;
        this.height = num1;
        this.width = (float) num2;
        this.collidesTiles = false;
        this.splashDamageRadius = 26.25f;
        this.splashDamage = 45f;
        this.fragBullet = Bullets.artilleryPlasticFrag;
        this.fragBullets = 10;
        this.backColor = Pal.plastaniumBack;
        this.frontColor = Pal.plastaniumFront;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : ArtilleryBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {45, 117, 107, 107, 107, 118, 103, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0036 obj4 = this;
        this.hitEffect = Fx.__\u003C\u003EflakExplosion;
        this.knockback = 0.8f;
        this.lifetime = 80f;
        Bullets.\u0036 obj5 = this;
        float num1 = 11f;
        double num2 = (double) num1;
        this.height = num1;
        this.width = (float) num2;
        this.collidesTiles = false;
        this.splashDamageRadius = 18.75f;
        this.splashDamage = 33f;
        this.reloadMultiplier = 1.2f;
        this.ammoMultiplier = 3f;
        this.homingPower = 0.08f;
        this.homingRange = 50f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : ArtilleryBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {59, 117, 107, 107, 107, 118, 103, 107, 107, 107, 107, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0037 obj4 = this;
        this.hitEffect = Fx.__\u003C\u003EblastExplosion;
        this.knockback = 0.8f;
        this.lifetime = 80f;
        Bullets.\u0037 obj5 = this;
        float num1 = 13f;
        double num2 = (double) num1;
        this.height = num1;
        this.width = (float) num2;
        this.collidesTiles = false;
        this.splashDamageRadius = 18.75f;
        this.splashDamage = 35f;
        this.status = StatusEffects.burning;
        this.frontColor = Pal.lightishOrange;
        this.backColor = Pal.lightOrange;
        this.makeFire = true;
        this.trailEffect = Fx.__\u003C\u003EincendTrail;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : ArtilleryBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {74, 117, 107, 107, 107, 118, 103, 107, 107, 107, 107, 139, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0038 obj4 = this;
        this.hitEffect = Fx.__\u003C\u003EblastExplosion;
        this.knockback = 0.8f;
        this.lifetime = 80f;
        Bullets.\u0038 obj5 = this;
        float num1 = 14f;
        double num2 = (double) num1;
        this.height = num1;
        this.width = (float) num2;
        this.collidesTiles = false;
        this.ammoMultiplier = 4f;
        this.splashDamageRadius = 33.75f;
        this.splashDamage = 50f;
        this.backColor = Pal.missileYellowBack;
        this.frontColor = Pal.missileYellow;
        this.status = StatusEffects.blasted;
        this.statusDuration = 60f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : BasicBulletType
    {
      [Modifiers]
      internal Bullets this\u00240;

      [LineNumberTable(new byte[] {90, 117, 107, 107, 107, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] Bullets obj0, [In] float obj1, [In] float obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        Bullets.\u0039 obj = this;
        this.width = 5f;
        this.height = 12f;
        this.shrinkY = 1f;
        this.lifetime = 20f;
        this.backColor = Pal.gray;
        this.frontColor = Color.__\u003C\u003Ewhite;
        this.despawnEffect = Fx.__\u003C\u003Enone;
        this.collidesGround = false;
      }
    }
  }
}
