// Decompiled with JetBrains decompiler
// Type: mindustry.content.UnitTypes
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ai.types;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.abilities;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class UnitTypes : Object, ContentList
  {
    public static UnitType mace;
    public static UnitType dagger;
    public static UnitType crawler;
    public static UnitType fortress;
    public static UnitType scepter;
    public static UnitType reign;
    public static UnitType nova;
    public static UnitType pulsar;
    public static UnitType quasar;
    public static UnitType vela;
    public static UnitType corvus;
    public static UnitType atrax;
    public static UnitType spiroct;
    public static UnitType arkyid;
    public static UnitType toxopid;
    public static UnitType flare;
    public static UnitType eclipse;
    public static UnitType horizon;
    public static UnitType zenith;
    public static UnitType antumbra;
    public static UnitType mono;
    public static UnitType poly;
    public static UnitType mega;
    public static UnitType quad;
    public static UnitType oct;
    public static UnitType alpha;
    public static UnitType beta;
    public static UnitType gamma;
    public static UnitType risso;
    public static UnitType minke;
    public static UnitType bryde;
    public static UnitType sei;
    public static UnitType omura;
    public static UnitType block;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitTypes()
    {
    }

    [LineNumberTable(new byte[] {20, 240, 78, 240, 95, 240, 97, 240, 125, 240, 126, 240, 97, 240, 120, 240, 108, 240, 160, 71, 240, 160, 76, 240, 92, 240, 104, 240, 160, 67, 240, 160, 102, 240, 160, 123, 240, 93, 240, 103, 240, 109, 240, 160, 74, 240, 160, 80, 240, 83, 240, 119, 240, 117, 240, 160, 71, 240, 94, 240, 115, 240, 107, 240, 160, 95, 240, 160, 86, 240, 117, 240, 101, 240, 106, 240, 108, 240, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      UnitTypes.dagger = (UnitType) new UnitTypes.\u0031(this, "dagger");
      UnitTypes.mace = (UnitType) new UnitTypes.\u0032(this, "mace");
      UnitTypes.fortress = (UnitType) new UnitTypes.\u0033(this, "fortress");
      UnitTypes.scepter = (UnitType) new UnitTypes.\u0034(this, "scepter");
      UnitTypes.reign = (UnitType) new UnitTypes.\u0035(this, "reign");
      UnitTypes.nova = (UnitType) new UnitTypes.\u0036(this, "nova");
      UnitTypes.pulsar = (UnitType) new UnitTypes.\u0037(this, "pulsar");
      UnitTypes.quasar = (UnitType) new UnitTypes.\u0038(this, "quasar");
      UnitTypes.vela = (UnitType) new UnitTypes.\u0039(this, "vela");
      UnitTypes.corvus = (UnitType) new UnitTypes.\u00310(this, "corvus");
      UnitTypes.crawler = (UnitType) new UnitTypes.\u00311(this, "crawler");
      UnitTypes.atrax = (UnitType) new UnitTypes.\u00312(this, "atrax");
      UnitTypes.spiroct = (UnitType) new UnitTypes.\u00313(this, "spiroct");
      UnitTypes.arkyid = (UnitType) new UnitTypes.\u00314(this, "arkyid");
      UnitTypes.toxopid = (UnitType) new UnitTypes.\u00315(this, "toxopid");
      UnitTypes.flare = (UnitType) new UnitTypes.\u00316(this, "flare");
      UnitTypes.horizon = (UnitType) new UnitTypes.\u00317(this, "horizon");
      UnitTypes.zenith = (UnitType) new UnitTypes.\u00318(this, "zenith");
      UnitTypes.antumbra = (UnitType) new UnitTypes.\u00319(this, "antumbra");
      UnitTypes.eclipse = (UnitType) new UnitTypes.\u00320(this, "eclipse");
      UnitTypes.mono = (UnitType) new UnitTypes.\u00321(this, "mono");
      UnitTypes.poly = (UnitType) new UnitTypes.\u00322(this, "poly");
      UnitTypes.mega = (UnitType) new UnitTypes.\u00323(this, "mega");
      UnitTypes.quad = (UnitType) new UnitTypes.\u00324(this, "quad");
      UnitTypes.oct = (UnitType) new UnitTypes.\u00325(this, "oct");
      UnitTypes.risso = (UnitType) new UnitTypes.\u00326(this, "risso");
      UnitTypes.minke = (UnitType) new UnitTypes.\u00327(this, "minke");
      UnitTypes.bryde = (UnitType) new UnitTypes.\u00328(this, "bryde");
      UnitTypes.sei = (UnitType) new UnitTypes.\u00329(this, "sei");
      UnitTypes.omura = (UnitType) new UnitTypes.\u00330(this, "omura");
      UnitTypes.alpha = (UnitType) new UnitTypes.\u00331(this, "alpha");
      UnitTypes.beta = (UnitType) new UnitTypes.\u00332(this, "beta");
      UnitTypes.gamma = (UnitType) new UnitTypes.\u00333(this, "gamma");
      UnitTypes.block = (UnitType) new UnitTypes.\u00334(this, "block");
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {20, 112, 107, 107, 107, 246, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0031 obj = this;
        this.speed = 0.5f;
        this.hitSize = 8f;
        this.health = 140f;
        this.weapons.add((object) new UnitTypes.\u0031.\u0031(this, "large-weapon"));
      }

      [HideFromJava]
      static \u0031() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0031 this\u00241;

        [LineNumberTable(new byte[] {24, 112, 107, 107, 107, 103, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0031 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0031.\u0031 obj = this;
          this.reload = 14f;
          this.x = 4f;
          this.y = 2f;
          this.top = false;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = Bullets.standardCopper;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 105, 112, 107, 107, 107, 107, 139, 135, 103, 107, 107, 107, 107, 103, 107, 103, 107, 139, 139, 103, 107, 135, 246, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00310 obj = this;
        this.hitSize = 29f;
        this.health = 18000f;
        this.armor = 9f;
        this.landShake = 1.5f;
        this.rotateSpeed = 1.5f;
        this.commandLimit = 8;
        this.legCount = 4;
        this.legLength = 14f;
        this.legBaseOffset = 11f;
        this.legMoveSpace = 1.5f;
        this.legTrns = 0.58f;
        this.hovering = true;
        this.visualElevation = 0.2f;
        this.allowLegStep = true;
        this.ammoType = AmmoTypes.powerHigh;
        this.groundLayer = 75f;
        this.speed = 0.3f;
        this.mineTier = 2;
        this.mineSpeed = 7f;
        this.drawShields = false;
        this.weapons.add((object) new UnitTypes.\u00310.\u0031(this, "corvus-weapon"));
      }

      [HideFromJava]
      static \u00310() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00310 this\u00241;

        [LineNumberTable(new byte[] {161, 131, 112, 107, 107, 107, 103, 103, 107, 107, 118, 107, 139, 139, 107, 107, 144, 236, 90})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00310 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00310.\u0031 obj2 = this;
          this.shootSound = Sounds.laserblast;
          this.chargeSound = Sounds.lasercharge;
          this.soundPitchMin = 1f;
          this.top = false;
          this.mirror = false;
          this.shake = 14f;
          this.shootY = 5f;
          UnitTypes.\u00310.\u0031 obj3 = this;
          float num1 = 0.0f;
          double num2 = (double) num1;
          this.y = num1;
          this.x = (float) num2;
          this.reload = 350f;
          this.recoil = 0.0f;
          this.cooldownTime = 350f;
          this.shootStatusDuration = 120f;
          this.shootStatus = StatusEffects.unmoving;
          this.firstShotDelay = Fx.__\u003C\u003EgreenLaserCharge.lifetime;
          this.bullet = (BulletType) new UnitTypes.\u00310.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00310.\u0031 this\u00242;

          [LineNumberTable(new byte[] {161, 149, 111, 107, 107, 139, 139, 107, 103, 107, 104, 107, 107, 103, 150, 139, 107, 135, 107, 107, 107, 127, 20})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00310.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00310.\u0031.\u0031 obj1 = this;
            this.length = 460f;
            this.damage = 560f;
            this.width = 75f;
            this.lifetime = 65f;
            this.lightningSpacing = 35f;
            this.lightningLength = 5;
            this.lightningDelay = 1.1f;
            this.lightningLengthRand = 15;
            this.lightningDamage = 50f;
            this.lightningAngleRand = 40f;
            this.largeHit = true;
            UnitTypes.\u00310.\u0031.\u0031 obj2 = this;
            Color heal = Pal.heal;
            Color color = heal;
            this.lightningColor = heal;
            this.lightColor = color;
            this.shootEffect = Fx.__\u003C\u003EgreenLaserCharge;
            this.healPercent = 25f;
            this.collidesTeam = true;
            this.sideAngle = 15f;
            this.sideWidth = 0.0f;
            this.sideLength = 0.0f;
            this.colors = new Color[3]
            {
              Pal.heal.cpy().a(0.4f),
              Pal.heal,
              Color.__\u003C\u003Ewhite
            };
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 181, 112, 144, 107, 107, 107, 107, 139, 241, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00311 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00311.__\u003C\u003EAnon0();
        this.speed = 1f;
        this.hitSize = 8f;
        this.health = 180f;
        this.mechSideSway = 0.25f;
        this.range = 40f;
        this.weapons.add((object) new UnitTypes.\u00311.\u0031(this));
      }

      [HideFromJava]
      static \u00311() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00311 this\u00241;

        [LineNumberTable(new byte[] {161, 190, 111, 107, 107, 107, 107, 251, 75})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00311 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          UnitTypes.\u00311.\u0031 obj = this;
          this.reload = 24f;
          this.shootCone = 180f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.shootSound = Sounds.explosion;
          this.bullet = (BulletType) new UnitTypes.\u00311.\u0031.\u0031(this, 0.0f, 0.0f, "clear");
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BombBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00311.\u0031 this\u00242;

          [LineNumberTable(new byte[] {161, 195, 117, 107, 107, 107, 107, 103, 107, 103, 103, 103})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00311.\u0031 obj0, [In] float obj1, [In] float obj2, [In] string obj3)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2, obj3);
            UnitTypes.\u00311.\u0031.\u0031 obj = this;
            this.hitEffect = Fx.__\u003C\u003Epulverize;
            this.lifetime = 10f;
            this.speed = 1f;
            this.splashDamageRadius = 58f;
            this.instantDisappear = true;
            this.splashDamage = 85f;
            this.killShooter = true;
            this.hittable = false;
            this.collidesAir = true;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new SuicideAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 209, 112, 107, 107, 107, 107, 103, 107, 159, 2, 103, 107, 107, 107, 103, 139, 103, 107, 139, 246, 82})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00312 obj = this;
        this.speed = 0.5f;
        this.drag = 0.4f;
        this.hitSize = 10f;
        this.rotateSpeed = 3f;
        this.targetAir = false;
        this.health = 600f;
        this.immunities = ObjectSet.with((object[]) new StatusEffect[2]
        {
          StatusEffects.burning,
          StatusEffects.melting
        });
        this.legCount = 4;
        this.legLength = 9f;
        this.legTrns = 0.6f;
        this.legMoveSpace = 1.4f;
        this.hovering = true;
        this.armor = 3f;
        this.allowLegStep = true;
        this.visualElevation = 0.2f;
        this.groundLayer = 74f;
        this.weapons.add((object) new UnitTypes.\u00312.\u0031(this, "eruption"));
      }

      [HideFromJava]
      static \u00312() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00312 this\u00241;

        [LineNumberTable(new byte[] {161, 229, 112, 103, 107, 107, 107, 107, 107, 139, 241, 72})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00312 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00312.\u0031 obj = this;
          this.top = false;
          this.shootY = 3f;
          this.reload = 10f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.recoil = 1f;
          this.x = 7f;
          this.shootSound = Sounds.flame;
          this.bullet = (BulletType) new UnitTypes.\u00312.\u0031.\u0031(this, Liquids.slag);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LiquidBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00312.\u0031 this\u00242;

          [LineNumberTable(new byte[] {161, 238, 112, 107, 107, 107, 107, 107, 103})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00312.\u0031 obj0, [In] Liquid obj1)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1);
            UnitTypes.\u00312.\u0031.\u0031 obj = this;
            this.damage = 11f;
            this.speed = 2.3f;
            this.drag = 0.01f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            this.lifetime = 56f;
            this.collidesAir = false;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 249, 112, 107, 107, 107, 107, 107, 127, 2, 103, 107, 107, 107, 107, 103, 107, 139, 139, 103, 107, 139, 246, 88, 246, 83})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00313 obj = this;
        this.speed = 0.4f;
        this.drag = 0.4f;
        this.hitSize = 12f;
        this.rotateSpeed = 3f;
        this.health = 900f;
        this.immunities = ObjectSet.with((object[]) new StatusEffect[2]
        {
          StatusEffects.burning,
          StatusEffects.melting
        });
        this.legCount = 6;
        this.legLength = 13f;
        this.legTrns = 0.8f;
        this.legMoveSpace = 1.4f;
        this.legBaseOffset = 2f;
        this.hovering = true;
        this.armor = 5f;
        this.ammoType = AmmoTypes.power;
        this.buildSpeed = 0.75f;
        this.allowLegStep = true;
        this.visualElevation = 0.3f;
        this.groundLayer = 75f;
        this.weapons.add((object) new UnitTypes.\u00313.\u0031(this, "spiroct-weapon"));
        this.weapons.add((object) new UnitTypes.\u00313.\u0032(this, "mount-purple-weapon"));
      }

      [HideFromJava]
      static \u00313() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00313 this\u00241;

        [LineNumberTable(new byte[] {162, 15, 112, 107, 107, 107, 107, 103, 139, 107, 139, 236, 75})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00313 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00313.\u0031 obj = this;
          this.shootY = 4f;
          this.reload = 15f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.recoil = 2f;
          this.rotate = true;
          this.shootSound = Sounds.sap;
          this.x = 8.5f;
          this.y = -1.5f;
          this.bullet = (BulletType) new UnitTypes.\u00313.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : SapBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00313.\u0031 this\u00242;

          [LineNumberTable(new byte[] {162, 26, 111, 107, 107, 107, 107, 123, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00313.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00313.\u0031.\u0031 obj1 = this;
            this.sapStrength = 0.4f;
            this.length = 75f;
            this.damage = 20f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            UnitTypes.\u00313.\u0031.\u0031 obj2 = this;
            Color color1 = Color.valueOf("bf92f9");
            Color color2 = color1;
            this.color = color1;
            this.hitColor = color2;
            this.despawnEffect = Fx.__\u003C\u003Enone;
            this.width = 0.54f;
            this.lifetime = 35f;
            this.knockback = -1.24f;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00313 this\u00241;

        [LineNumberTable(new byte[] {162, 39, 112, 107, 103, 107, 107, 139, 236, 75})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00313 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00313.\u0032 obj = this;
          this.reload = 20f;
          this.rotate = true;
          this.x = 4f;
          this.y = 3f;
          this.shootSound = Sounds.sap;
          this.bullet = (BulletType) new UnitTypes.\u00313.\u0032.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : SapBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00313.\u0032 this\u00242;

          [LineNumberTable(new byte[] {162, 46, 111, 107, 107, 107, 107, 123, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00313.\u0032 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00313.\u0032.\u0031 obj1 = this;
            this.sapStrength = 0.8f;
            this.length = 40f;
            this.damage = 16f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            UnitTypes.\u00313.\u0032.\u0031 obj2 = this;
            Color color1 = Color.valueOf("bf92f9");
            Color color2 = color1;
            this.color = color1;
            this.hitColor = color2;
            this.despawnEffect = Fx.__\u003C\u003Enone;
            this.width = 0.4f;
            this.lifetime = 25f;
            this.knockback = -0.65f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 60, 112, 107, 107, 107, 107, 139, 139, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 139, 107, 139, 103, 103, 107, 139, 231, 76, 255, 27, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00314 obj2 = this;
        this.drag = 0.1f;
        this.speed = 0.5f;
        this.hitSize = 21f;
        this.health = 8000f;
        this.armor = 6f;
        this.rotateSpeed = 2.7f;
        this.legCount = 6;
        this.legMoveSpace = 1f;
        this.legPairOffset = 3f;
        this.legLength = 30f;
        this.legExtension = -15f;
        this.legBaseOffset = 10f;
        this.landShake = 1f;
        this.legLengthScl = 0.96f;
        this.rippleScale = 2f;
        this.legSpeed = 0.2f;
        this.ammoType = AmmoTypes.power;
        this.buildSpeed = 1f;
        this.legSplashDamage = 32f;
        this.legSplashRange = 30f;
        this.hovering = true;
        this.allowLegStep = true;
        this.visualElevation = 0.65f;
        this.groundLayer = 75f;
        UnitTypes.\u00314.\u0031 obj3 = new UnitTypes.\u00314.\u0031(this);
        this.weapons.add((object) new UnitTypes.\u00314.\u0032(this, "spiroct-weapon", (BulletType) obj3), (object) new UnitTypes.\u00314.\u0033(this, "spiroct-weapon", (BulletType) obj3), (object) new UnitTypes.\u00314.\u0034(this, "spiroct-weapon", (BulletType) obj3), (object) new UnitTypes.\u00314.\u0035(this, "large-purple-mount"));
      }

      [HideFromJava]
      static \u00314() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : SapBulletType
      {
        [Modifiers]
        internal UnitTypes.\u00314 this\u00241;

        [LineNumberTable(new byte[] {162, 90, 111, 107, 107, 107, 107, 123, 107, 107, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00314 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          UnitTypes.\u00314.\u0031 obj1 = this;
          this.sapStrength = 0.85f;
          this.length = 55f;
          this.damage = 37f;
          this.shootEffect = Fx.__\u003C\u003EshootSmall;
          UnitTypes.\u00314.\u0031 obj2 = this;
          Color color1 = Color.valueOf("bf92f9");
          Color color2 = color1;
          this.color = color1;
          this.hitColor = color2;
          this.despawnEffect = Fx.__\u003C\u003Enone;
          this.width = 0.55f;
          this.lifetime = 30f;
          this.knockback = -1f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024sapper;
        [Modifiers]
        internal UnitTypes.\u00314 this\u00241;

        [LineNumberTable(new byte[] {162, 103, 119, 107, 107, 107, 103, 108, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00314 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024sapper = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00314.\u0032 obj = this;
          this.reload = 9f;
          this.x = 4f;
          this.y = 8f;
          this.rotate = true;
          this.bullet = this.val\u0024sapper;
          this.shootSound = Sounds.sap;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0033 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024sapper;
        [Modifiers]
        internal UnitTypes.\u00314 this\u00241;

        [LineNumberTable(new byte[] {162, 111, 119, 107, 107, 107, 103, 108, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0033([In] UnitTypes.\u00314 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024sapper = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00314.\u0033 obj = this;
          this.reload = 15f;
          this.x = 9f;
          this.y = 6f;
          this.rotate = true;
          this.bullet = this.val\u0024sapper;
          this.shootSound = Sounds.sap;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0034 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024sapper;
        [Modifiers]
        internal UnitTypes.\u00314 this\u00241;

        [LineNumberTable(new byte[] {162, 119, 119, 107, 107, 107, 103, 108, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0034([In] UnitTypes.\u00314 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024sapper = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00314.\u0034 obj = this;
          this.reload = 23f;
          this.x = 14f;
          this.y = 0.0f;
          this.rotate = true;
          this.bullet = this.val\u0024sapper;
          this.shootSound = Sounds.sap;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0035 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00314 this\u00241;

        [LineNumberTable(new byte[] {162, 127, 112, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 139, 246, 83})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0035([In] UnitTypes.\u00314 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00314.\u0035 obj = this;
          this.y = -7f;
          this.x = 9f;
          this.shootY = 7f;
          this.reload = 45f;
          this.shake = 3f;
          this.rotateSpeed = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.shootSound = Sounds.artillery;
          this.rotate = true;
          this.shadow = 8f;
          this.recoil = 3f;
          this.bullet = (BulletType) new UnitTypes.\u00314.\u0035.\u0031(this, 2f, 12f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ArtilleryBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00314.\u0035 this\u00242;

          [LineNumberTable(new byte[] {162, 140, 115, 107, 107, 107, 118, 103, 107, 107, 107, 107, 118, 103, 104, 107, 144, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00314.\u0035 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00314.\u0035.\u0031 obj3 = this;
            this.hitEffect = Fx.__\u003C\u003EsapExplosion;
            this.knockback = 0.8f;
            this.lifetime = 70f;
            UnitTypes.\u00314.\u0035.\u0031 obj4 = this;
            float num1 = 19f;
            double num2 = (double) num1;
            this.height = num1;
            this.width = (float) num2;
            this.collidesTiles = true;
            this.ammoMultiplier = 4f;
            this.splashDamageRadius = 70f;
            this.splashDamage = 65f;
            this.backColor = Pal.sapBulletBack;
            UnitTypes.\u00314.\u0035.\u0031 obj5 = this;
            Color sapBullet = Pal.sapBullet;
            Color color = sapBullet;
            this.lightningColor = sapBullet;
            this.frontColor = color;
            this.lightning = 3;
            this.lightningLength = 10;
            this.smokeEffect = Fx.__\u003C\u003EshootBigSmoke2;
            this.this\u00242.shake = 5f;
            this.status = StatusEffects.sapped;
            this.statusDuration = 600f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 162, 112, 107, 107, 107, 107, 139, 139, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 139, 107, 139, 103, 103, 107, 139, 246, 95, 246, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00315 obj = this;
        this.drag = 0.1f;
        this.speed = 0.5f;
        this.hitSize = 21f;
        this.health = 22000f;
        this.armor = 13f;
        this.rotateSpeed = 1.9f;
        this.legCount = 8;
        this.legMoveSpace = 0.8f;
        this.legPairOffset = 3f;
        this.legLength = 75f;
        this.legExtension = -20f;
        this.legBaseOffset = 8f;
        this.landShake = 1f;
        this.legSpeed = 0.1f;
        this.legLengthScl = 0.93f;
        this.rippleScale = 3f;
        this.legSpeed = 0.19f;
        this.ammoType = AmmoTypes.powerHigh;
        this.buildSpeed = 1f;
        this.legSplashDamage = 80f;
        this.legSplashRange = 60f;
        this.hovering = true;
        this.allowLegStep = true;
        this.visualElevation = 0.95f;
        this.groundLayer = 75f;
        this.weapons.add((object) new UnitTypes.\u00315.\u0031(this, "large-purple-mount"));
        this.weapons.add((object) new UnitTypes.\u00315.\u0032(this, "toxopid-cannon"));
      }

      [HideFromJava]
      static \u00315() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00315 this\u00241;

        [LineNumberTable(new byte[] {162, 194, 112, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 107, 103, 139, 236, 77})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00315 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00315.\u0031 obj = this;
          this.y = -5f;
          this.x = 11f;
          this.shootY = 7f;
          this.reload = 30f;
          this.shake = 4f;
          this.rotateSpeed = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.shootSound = Sounds.shootBig;
          this.rotate = true;
          this.shadow = 12f;
          this.recoil = 3f;
          this.shots = 2;
          this.spacing = 17f;
          this.bullet = (BulletType) new UnitTypes.\u00315.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ShrapnelBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00315.\u0031 this\u00242;

          [LineNumberTable(new byte[] {162, 209, 111, 107, 107, 107, 107, 107, 107, 104, 107, 107, 107, 118})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00315.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00315.\u0031.\u0031 obj1 = this;
            this.length = 90f;
            this.damage = 110f;
            this.width = 25f;
            this.serrationLenScl = 7f;
            this.serrationSpaceOffset = 60f;
            this.serrationFadeOffset = 0.0f;
            this.serrations = 10;
            this.serrationWidth = 6f;
            this.fromColor = Pal.sapBullet;
            this.toColor = Pal.sapBulletBack;
            UnitTypes.\u00315.\u0031.\u0031 obj2 = this;
            Effect sparkShoot = Fx.__\u003C\u003EsparkShoot;
            Effect effect = sparkShoot;
            this.smokeEffect = sparkShoot;
            this.shootEffect = effect;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00315 this\u00241;

        [LineNumberTable(new byte[] {162, 224, 112, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 103, 139, 246, 105})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00315 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00315.\u0032 obj = this;
          this.y = -14f;
          this.x = 0.0f;
          this.shootY = 22f;
          this.mirror = false;
          this.reload = 210f;
          this.shake = 10f;
          this.recoil = 10f;
          this.rotateSpeed = 1f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing3;
          this.shootSound = Sounds.artillery;
          this.rotate = true;
          this.shadow = 30f;
          this.bullet = (BulletType) new UnitTypes.\u00315.\u0032.\u0031(this, 3f, 50f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ArtilleryBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00315.\u0032 this\u00242;

          [LineNumberTable(new byte[] {162, 238, 115, 107, 107, 107, 118, 114, 107, 107, 107, 107, 118, 103, 104, 107, 139, 107, 139, 107, 136, 246, 82})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00315.\u0032 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00315.\u0032.\u0031 obj3 = this;
            this.hitEffect = Fx.__\u003C\u003EsapExplosion;
            this.knockback = 0.8f;
            this.lifetime = 80f;
            UnitTypes.\u00315.\u0032.\u0031 obj4 = this;
            float num1 = 25f;
            double num2 = (double) num1;
            this.height = num1;
            this.width = (float) num2;
            UnitTypes.\u00315.\u0032.\u0031 obj5 = this;
            int num3 = 1;
            int num4 = num3;
            this.collides = num3 != 0;
            this.collidesTiles = num4 != 0;
            this.ammoMultiplier = 4f;
            this.splashDamageRadius = 80f;
            this.splashDamage = 75f;
            this.backColor = Pal.sapBulletBack;
            UnitTypes.\u00315.\u0032.\u0031 obj6 = this;
            Color sapBullet = Pal.sapBullet;
            Color color = sapBullet;
            this.lightningColor = sapBullet;
            this.frontColor = color;
            this.lightning = 5;
            this.lightningLength = 20;
            this.smokeEffect = Fx.__\u003C\u003EshootBigSmoke2;
            this.hitShake = 10f;
            this.status = StatusEffects.sapped;
            this.statusDuration = 600f;
            this.fragLifeMin = 0.3f;
            this.fragBullets = 9;
            this.fragBullet = (BulletType) new UnitTypes.\u00315.\u0032.\u0031.\u0031(this, 2.3f, 30f);
          }

          [InnerClass]
          [EnclosingMethod(null, null, null)]
          [SpecialName]
          internal class \u0031 : ArtilleryBulletType
          {
            [Modifiers]
            internal UnitTypes.\u00315.\u0032.\u0031 this\u00243;

            [LineNumberTable(new byte[] {163, 4, 115, 107, 107, 107, 118, 103, 107, 107, 107, 118, 103, 103, 107, 139, 107, 107})]
            [MethodImpl(MethodImplOptions.NoInlining)]
            internal \u0031([In] UnitTypes.\u00315.\u0032.\u0031 obj0, [In] float obj1, [In] float obj2)
            {
              this.this\u00243 = obj0;
              // ISSUE: explicit constructor call
              base.\u002Ector(obj1, obj2);
              UnitTypes.\u00315.\u0032.\u0031.\u0031 obj3 = this;
              this.hitEffect = Fx.__\u003C\u003EsapExplosion;
              this.knockback = 0.8f;
              this.lifetime = 90f;
              UnitTypes.\u00315.\u0032.\u0031.\u0031 obj4 = this;
              float num1 = 20f;
              double num2 = (double) num1;
              this.height = num1;
              this.width = (float) num2;
              this.collidesTiles = false;
              this.splashDamageRadius = 70f;
              this.splashDamage = 40f;
              this.backColor = Pal.sapBulletBack;
              UnitTypes.\u00315.\u0032.\u0031.\u0031 obj5 = this;
              Color sapBullet = Pal.sapBullet;
              Color color = sapBullet;
              this.lightningColor = sapBullet;
              this.frontColor = color;
              this.lightning = 2;
              this.lightningLength = 5;
              this.smokeEffect = Fx.__\u003C\u003EshootBigSmoke2;
              this.hitShake = 5f;
              this.status = StatusEffects.sapped;
              this.statusDuration = 600f;
            }
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 29, 112, 107, 107, 107, 103, 107, 107, 107, 103, 103, 135, 241, 79})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00316 obj = this;
        this.speed = 3f;
        this.accel = 0.08f;
        this.drag = 0.01f;
        this.flying = true;
        this.health = 75f;
        this.engineOffset = 5.5f;
        this.range = 140f;
        this.targetAir = false;
        this.commandLimit = 4;
        this.circleTarget = true;
        this.weapons.add((object) new UnitTypes.\u00316.\u0031(this));
      }

      [HideFromJava]
      static \u00316() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00316 this\u00241;

        [LineNumberTable(new byte[] {163, 41, 111, 107, 107, 107, 107, 246, 72, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00316 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          UnitTypes.\u00316.\u0031 obj = this;
          this.y = 0.0f;
          this.x = 2f;
          this.reload = 13f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = (BulletType) new UnitTypes.\u00316.\u0031.\u0031(this, 2.5f, 9f);
          this.shootSound = Sounds.pew;
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00316.\u0031 this\u00242;

          [LineNumberTable(new byte[] {163, 46, 115, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00316.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00316.\u0031.\u0031 obj = this;
            this.width = 7f;
            this.height = 9f;
            this.lifetime = 45f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
            this.ammoMultiplier = 2f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00317 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 58, 112, 107, 107, 107, 107, 103, 107, 103, 107, 107, 103, 107, 107, 103, 135, 241, 85})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00317 obj = this;
        this.health = 340f;
        this.speed = 1.7f;
        this.accel = 0.08f;
        this.drag = 0.016f;
        this.flying = true;
        this.hitSize = 9f;
        this.targetAir = false;
        this.engineOffset = 7.8f;
        this.range = 140f;
        this.faceTarget = false;
        this.armor = 3f;
        this.targetFlag = BlockFlag.__\u003C\u003Efactory;
        this.commandLimit = 5;
        this.circleTarget = true;
        this.weapons.add((object) new UnitTypes.\u00317.\u0031(this));
      }

      [HideFromJava]
      static \u00317() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00317 this\u00241;

        [LineNumberTable(new byte[] {163, 74, 111, 107, 107, 107, 107, 107, 107, 107, 103, 107, 246, 74})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00317 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          UnitTypes.\u00317.\u0031 obj = this;
          this.minShootVelocity = 0.75f;
          this.x = 3f;
          this.shootY = 0.0f;
          this.reload = 12f;
          this.shootCone = 180f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.inaccuracy = 15f;
          this.ignoreRotation = true;
          this.shootSound = Sounds.none;
          this.bullet = (BulletType) new UnitTypes.\u00317.\u0031.\u0031(this, 27f, 25f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BombBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00317.\u0031 this\u00242;

          [LineNumberTable(new byte[] {163, 84, 115, 107, 107, 107, 107, 139, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00317.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00317.\u0031.\u0031 obj = this;
            this.width = 10f;
            this.height = 14f;
            this.hitEffect = Fx.__\u003C\u003EflakExplosion;
            this.shootEffect = Fx.__\u003C\u003Enone;
            this.smokeEffect = Fx.__\u003C\u003Enone;
            this.status = StatusEffects.blasted;
            this.statusDuration = 60f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00318 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 97, 112, 107, 107, 107, 107, 103, 107, 107, 103, 139, 107, 139, 246, 93})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00318 obj = this;
        this.health = 700f;
        this.speed = 1.8f;
        this.accel = 0.04f;
        this.drag = 0.016f;
        this.flying = true;
        this.range = 140f;
        this.hitSize = 20f;
        this.lowAltitude = true;
        this.armor = 5f;
        this.engineOffset = 12f;
        this.engineSize = 3f;
        this.weapons.add((object) new UnitTypes.\u00318.\u0031(this, "zenith-missiles"));
      }

      [HideFromJava]
      static \u00318() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00318 this\u00241;

        [LineNumberTable(new byte[] {163, 111, 112, 107, 107, 103, 107, 103, 107, 107, 139, 246, 82})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00318 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00318.\u0031 obj = this;
          this.reload = 40f;
          this.x = 7f;
          this.rotate = true;
          this.shake = 1f;
          this.shots = 2;
          this.inaccuracy = 5f;
          this.velocityRnd = 0.2f;
          this.shootSound = Sounds.missile;
          this.bullet = (BulletType) new UnitTypes.\u00318.\u0031.\u0031(this, 3f, 14f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : MissileBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00318.\u0031 this\u00242;

          [LineNumberTable(new byte[] {163, 121, 115, 107, 107, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00318.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00318.\u0031.\u0031 obj = this;
            this.width = 8f;
            this.height = 8f;
            this.shrinkY = 0.0f;
            this.drag = -3f / 1000f;
            this.homingRange = 60f;
            this.keepVelocity = false;
            this.splashDamageRadius = 25f;
            this.splashDamage = 16f;
            this.lifetime = 60f;
            this.trailColor = Pal.unitBack;
            this.backColor = Pal.unitBack;
            this.frontColor = Pal.unitFront;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
            this.weaveScale = 6f;
            this.weaveMag = 1f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00319 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 142, 112, 107, 107, 107, 107, 103, 103, 107, 107, 107, 107, 107, 139, 241, 80, 255, 15, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00319([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00319 obj2 = this;
        this.speed = 0.8f;
        this.accel = 0.04f;
        this.drag = 0.04f;
        this.rotateSpeed = 1.9f;
        this.flying = true;
        this.lowAltitude = true;
        this.health = 7000f;
        this.armor = 9f;
        this.engineOffset = 21f;
        this.engineSize = 5.3f;
        this.hitSize = 56f;
        this.targetFlag = BlockFlag.__\u003C\u003Ebattery;
        UnitTypes.\u00319.\u0031 obj3 = new UnitTypes.\u00319.\u0031(this, 2.7f, 10f);
        this.weapons.add((object) new UnitTypes.\u00319.\u0032(this, "missiles-mount", (BulletType) obj3), (object) new UnitTypes.\u00319.\u0033(this, "missiles-mount", (BulletType) obj3), (object) new UnitTypes.\u00319.\u0034(this, "large-bullet-mount"));
      }

      [HideFromJava]
      static \u00319() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : MissileBulletType
      {
        [Modifiers]
        internal UnitTypes.\u00319 this\u00241;

        [LineNumberTable(new byte[] {163, 156, 115, 107, 107, 107, 107, 107, 107, 107, 107, 107, 139, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00319 obj0, [In] float obj1, [In] float obj2)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1, obj2);
          UnitTypes.\u00319.\u0031 obj = this;
          this.width = 8f;
          this.height = 8f;
          this.shrinkY = 0.0f;
          this.drag = -0.01f;
          this.splashDamageRadius = 20f;
          this.splashDamage = 30f;
          this.ammoMultiplier = 4f;
          this.lifetime = 50f;
          this.hitEffect = Fx.__\u003C\u003EblastExplosion;
          this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
          this.status = StatusEffects.blasted;
          this.statusDuration = 60f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024missiles;
        [Modifiers]
        internal UnitTypes.\u00319 this\u00241;

        [LineNumberTable(new byte[] {163, 173, 119, 107, 107, 107, 107, 107, 108, 107, 103, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00319 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024missiles = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00319.\u0032 obj = this;
          this.y = 8f;
          this.x = 17f;
          this.reload = 20f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.rotateSpeed = 8f;
          this.bullet = this.val\u0024missiles;
          this.shootSound = Sounds.missile;
          this.rotate = true;
          this.shadow = 6f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0033 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024missiles;
        [Modifiers]
        internal UnitTypes.\u00319 this\u00241;

        [LineNumberTable(new byte[] {163, 184, 119, 107, 107, 107, 107, 107, 108, 107, 103, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0033([In] UnitTypes.\u00319 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024missiles = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00319.\u0033 obj = this;
          this.y = -8f;
          this.x = 17f;
          this.reload = 35f;
          this.rotateSpeed = 8f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = this.val\u0024missiles;
          this.shootSound = Sounds.missile;
          this.rotate = true;
          this.shadow = 6f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0034 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00319 this\u00241;

        [LineNumberTable(new byte[] {163, 195, 112, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 246, 70})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0034([In] UnitTypes.\u00319 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00319.\u0034 obj = this;
          this.y = 2f;
          this.x = 10f;
          this.shootY = 10f;
          this.reload = 12f;
          this.shake = 1f;
          this.rotateSpeed = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.shootSound = Sounds.shootBig;
          this.rotate = true;
          this.shadow = 8f;
          this.bullet = (BulletType) new UnitTypes.\u00319.\u0034.\u0031(this, 7f, 50f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00319.\u0034 this\u00242;

          [LineNumberTable(new byte[] {163, 206, 115, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00319.\u0034 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00319.\u0034.\u0031 obj = this;
            this.width = 12f;
            this.height = 18f;
            this.lifetime = 25f;
            this.shootEffect = Fx.__\u003C\u003EshootBig;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {34, 112, 107, 107, 107, 139, 145, 246, 85})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0032 obj = this;
        this.speed = 0.4f;
        this.hitSize = 9f;
        this.health = 500f;
        this.armor = 4f;
        this.immunities.add((object) StatusEffects.burning);
        this.weapons.add((object) new UnitTypes.\u0032.\u0031(this, "flamethrower"));
      }

      [HideFromJava]
      static \u0032() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0032 this\u00241;

        [LineNumberTable(new byte[] {42, 112, 103, 107, 107, 107, 107, 107, 246, 77})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0032 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0032.\u0031 obj = this;
          this.top = false;
          this.shootSound = Sounds.flame;
          this.shootY = 2f;
          this.reload = 14f;
          this.recoil = 1f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.bullet = (BulletType) new UnitTypes.\u0032.\u0031.\u0031(this, 3.9f, 30f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BulletType
        {
          [Modifiers]
          internal UnitTypes.\u0032.\u0031 this\u00242;

          [LineNumberTable(new byte[] {49, 115, 107, 107, 107, 103, 107, 107, 107, 107, 107, 103, 103})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0032.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u0032.\u0031.\u0031 obj = this;
            this.ammoMultiplier = 3f;
            this.hitSize = 7f;
            this.lifetime = 12f;
            this.pierce = true;
            this.statusDuration = 240f;
            this.shootEffect = Fx.__\u003C\u003EshootSmallFlame;
            this.hitEffect = Fx.__\u003C\u003EhitFlameSmall;
            this.despawnEffect = Fx.__\u003C\u003Enone;
            this.status = StatusEffects.burning;
            this.keepVelocity = false;
            this.hittable = false;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00320 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 216, 112, 107, 107, 107, 107, 103, 103, 107, 107, 107, 107, 103, 107, 139, 241, 76, 255, 15, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00320([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00320 obj2 = this;
        this.speed = 0.52f;
        this.accel = 0.04f;
        this.drag = 0.04f;
        this.rotateSpeed = 1f;
        this.flying = true;
        this.lowAltitude = true;
        this.health = 20000f;
        this.engineOffset = 38f;
        this.engineSize = 7.3f;
        this.hitSize = 58f;
        this.destructibleWreck = false;
        this.armor = 13f;
        this.targetFlag = BlockFlag.__\u003C\u003Ereactor;
        UnitTypes.\u00320.\u0031 obj3 = new UnitTypes.\u00320.\u0031(this, 4f, 5f);
        this.weapons.add((object) new UnitTypes.\u00320.\u0032(this, "large-laser-mount"), (object) new UnitTypes.\u00320.\u0033(this, "large-artillery", (BulletType) obj3), (object) new UnitTypes.\u00320.\u0034(this, "large-artillery", (BulletType) obj3));
      }

      [HideFromJava]
      static \u00320() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : FlakBulletType
      {
        [Modifiers]
        internal UnitTypes.\u00320 this\u00241;

        [LineNumberTable(new byte[] {163, 231, 115, 107, 107, 107, 107, 103, 139, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00320 obj0, [In] float obj1, [In] float obj2)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1, obj2);
          UnitTypes.\u00320.\u0031 obj = this;
          this.shootEffect = Fx.__\u003C\u003EshootBig;
          this.ammoMultiplier = 4f;
          this.splashDamage = 42f;
          this.splashDamageRadius = 25f;
          this.collidesGround = true;
          this.lifetime = 38f;
          this.status = StatusEffects.blasted;
          this.statusDuration = 60f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00320 this\u00241;

        [LineNumberTable(new byte[] {163, 244, 112, 107, 107, 107, 107, 107, 107, 107, 107, 107, 135, 236, 74})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00320 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00320.\u0032 obj = this;
          this.shake = 4f;
          this.shootY = 9f;
          this.x = 18f;
          this.y = 5f;
          this.rotateSpeed = 2f;
          this.reload = 45f;
          this.recoil = 4f;
          this.shootSound = Sounds.laser;
          this.shadow = 20f;
          this.rotate = true;
          this.bullet = (BulletType) new UnitTypes.\u00320.\u0032.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00320.\u0032 this\u00242;

          [LineNumberTable(new byte[] {164, 0, 111, 107, 107, 107, 107, 107, 107, 107, 127, 15})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00320.\u0032 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00320.\u0032.\u0031 obj = this;
            this.damage = 90f;
            this.sideAngle = 20f;
            this.sideWidth = 1.5f;
            this.sideLength = 80f;
            this.width = 25f;
            this.length = 200f;
            this.shootEffect = Fx.__\u003C\u003Eshockwave;
            this.colors = new Color[3]
            {
              Color.valueOf("ec7458aa"),
              Color.valueOf("ff9c5a"),
              Color.__\u003C\u003Ewhite
            };
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0033 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024fragBullet;
        [Modifiers]
        internal UnitTypes.\u00320 this\u00241;

        [LineNumberTable(new byte[] {164, 11, 119, 107, 107, 107, 107, 107, 107, 103, 139, 108})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0033([In] UnitTypes.\u00320 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024fragBullet = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00320.\u0033 obj = this;
          this.x = 11f;
          this.y = 27f;
          this.rotateSpeed = 2f;
          this.reload = 9f;
          this.shootSound = Sounds.shoot;
          this.shadow = 7f;
          this.rotate = true;
          this.recoil = 0.5f;
          this.bullet = this.val\u0024fragBullet;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0034 : Weapon
      {
        [Modifiers]
        internal BulletType val\u0024fragBullet;
        [Modifiers]
        internal UnitTypes.\u00320 this\u00241;

        [LineNumberTable(new byte[] {164, 23, 119, 107, 107, 107, 107, 107, 107, 107, 103, 107, 108})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0034([In] UnitTypes.\u00320 obj0, [In] string obj1, [In] BulletType obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024fragBullet = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00320.\u0034 obj = this;
          this.y = -13f;
          this.x = 20f;
          this.reload = 12f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.rotateSpeed = 7f;
          this.shake = 1f;
          this.shootSound = Sounds.shoot;
          this.rotate = true;
          this.shadow = 12f;
          this.bullet = this.val\u0024fragBullet;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00321 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 40, 112, 144, 103, 107, 107, 107, 107, 107, 107, 107, 135, 139, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00321([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00321 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00321.__\u003C\u003EAnon0();
        this.flying = true;
        this.drag = 0.06f;
        this.accel = 0.12f;
        this.speed = 1.5f;
        this.health = 100f;
        this.engineSize = 1.8f;
        this.engineOffset = 5.7f;
        this.range = 50f;
        this.isCounted = false;
        this.ammoType = AmmoTypes.powerLow;
        this.mineTier = 1;
        this.mineSpeed = 2.5f;
      }

      [HideFromJava]
      static \u00321() => UnitType.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new MinerAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00322 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 59, 112, 144, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 135, 139, 103, 139, 159, 0, 246, 95})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00322([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00322 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00322.__\u003C\u003EAnon0();
        this.flying = true;
        this.drag = 0.05f;
        this.speed = 2.6f;
        this.rotateSpeed = 15f;
        this.accel = 0.1f;
        this.range = 130f;
        this.health = 400f;
        this.buildSpeed = 0.5f;
        this.engineOffset = 6.5f;
        this.hitSize = 8f;
        this.lowAltitude = true;
        this.ammoType = AmmoTypes.power;
        this.mineTier = 2;
        this.mineSpeed = 3.5f;
        this.abilities.add((object) new RepairFieldAbility(5f, 300f, 50f));
        this.weapons.add((object) new UnitTypes.\u00322.\u0031(this, "heal-weapon-mount"));
      }

      [HideFromJava]
      static \u00322() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00322 this\u00241;

        [LineNumberTable(new byte[] {164, 81, 112, 103, 107, 107, 107, 107, 107, 107, 103, 107, 107, 135, 246, 81})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00322 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00322.\u0031 obj = this;
          this.top = false;
          this.y = -2.5f;
          this.x = 3.5f;
          this.reload = 30f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.recoil = 2f;
          this.shootSound = Sounds.missile;
          this.shots = 1;
          this.velocityRnd = 0.5f;
          this.inaccuracy = 15f;
          this.alternate = true;
          this.bullet = (BulletType) new UnitTypes.\u00322.\u0031.\u0031(this, 4f, 12f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : MissileBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00322.\u0031 this\u00242;

          [LineNumberTable(new byte[] {164, 94, 115, 107, 107, 107, 107, 103, 107, 107, 118, 107, 139, 107, 103, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00322.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00322.\u0031.\u0031 obj3 = this;
            this.homingPower = 0.08f;
            this.weaveMag = 4f;
            this.weaveScale = 4f;
            this.lifetime = 56f;
            this.keepVelocity = false;
            this.shootEffect = Fx.__\u003C\u003EshootHeal;
            this.smokeEffect = Fx.__\u003C\u003EhitLaser;
            UnitTypes.\u00322.\u0031.\u0031 obj4 = this;
            Effect hitLaser = Fx.__\u003C\u003EhitLaser;
            Effect effect = hitLaser;
            this.despawnEffect = hitLaser;
            this.hitEffect = effect;
            this.frontColor = Color.__\u003C\u003Ewhite;
            this.hitSound = Sounds.none;
            this.healPercent = 5.5f;
            this.collidesTeam = true;
            this.backColor = Pal.heal;
            this.trailColor = Pal.heal;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new BuilderAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00323 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 114, 112, 144, 103, 107, 107, 107, 107, 107, 107, 103, 103, 107, 103, 107, 107, 107, 107, 135, 139, 255, 2, 93})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00323([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00323 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00323.__\u003C\u003EAnon0();
        this.mineTier = 3;
        this.mineSpeed = 4f;
        this.health = 460f;
        this.armor = 3f;
        this.speed = 2.5f;
        this.accel = 0.06f;
        this.drag = 0.017f;
        this.lowAltitude = true;
        this.flying = true;
        this.engineOffset = 10.5f;
        this.rotateShooting = false;
        this.hitSize = 15f;
        this.engineSize = 3f;
        this.payloadCapacity = 256f;
        this.buildSpeed = 2.6f;
        this.isCounted = false;
        this.ammoType = AmmoTypes.power;
        this.weapons.add((object) new UnitTypes.\u00323.\u0031(this, "heal-weapon-mount"), (object) new UnitTypes.\u00323.\u0032(this, "heal-weapon-mount"));
      }

      [HideFromJava]
      static \u00323() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00323 this\u00241;

        [LineNumberTable(new byte[] {164, 137, 112, 107, 107, 107, 107, 103, 246, 71})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00323 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00323.\u0031 obj = this;
          this.shootSound = Sounds.lasershoot;
          this.reload = 25f;
          this.x = 8f;
          this.y = -6f;
          this.rotate = true;
          this.bullet = (BulletType) new UnitTypes.\u00323.\u0031.\u0031(this, 5.2f, 10f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBoltBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00323.\u0031 this\u00242;

          [LineNumberTable(new byte[] {164, 143, 115, 107, 107, 103, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00323.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00323.\u0031.\u0031 obj = this;
            this.lifetime = 35f;
            this.healPercent = 5.5f;
            this.collidesTeam = true;
            this.backColor = Pal.heal;
            this.frontColor = Color.__\u003C\u003Ewhite;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00323 this\u00241;

        [LineNumberTable(new byte[] {164, 151, 112, 107, 107, 107, 107, 103, 246, 71})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00323 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00323.\u0032 obj = this;
          this.shootSound = Sounds.lasershoot;
          this.reload = 15f;
          this.x = 4f;
          this.y = 5f;
          this.rotate = true;
          this.bullet = (BulletType) new UnitTypes.\u00323.\u0032.\u0031(this, 5.2f, 8f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBoltBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00323.\u0032 this\u00242;

          [LineNumberTable(new byte[] {164, 157, 115, 107, 107, 103, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00323.\u0032 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00323.\u0032.\u0031 obj = this;
            this.lifetime = 35f;
            this.healPercent = 3f;
            this.collidesTeam = true;
            this.backColor = Pal.heal;
            this.frontColor = Color.__\u003C\u003Ewhite;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new RepairAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00324 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 167, 112, 107, 107, 107, 107, 107, 107, 103, 103, 103, 107, 107, 103, 107, 107, 107, 107, 107, 103, 139, 139, 241, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00324([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00324 obj = this;
        this.armor = 8f;
        this.health = 6000f;
        this.speed = 1.4f;
        this.rotateSpeed = 2f;
        this.accel = 0.05f;
        this.drag = 0.017f;
        this.lowAltitude = false;
        this.flying = true;
        this.circleTarget = true;
        this.engineOffset = 12f;
        this.engineSize = 6f;
        this.rotateShooting = false;
        this.hitSize = 32f;
        this.payloadCapacity = 576f;
        this.buildSpeed = 2.5f;
        this.buildBeamOffset = 23f;
        this.range = 140f;
        this.targetAir = false;
        this.targetFlag = BlockFlag.__\u003C\u003Ebattery;
        this.ammoType = AmmoTypes.powerHigh;
        this.weapons.add((object) new UnitTypes.\u00324.\u0031(this));
      }

      [HideFromJava]
      static \u00324() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00324 this\u00241;

        [LineNumberTable(new byte[] {164, 191, 111, 118, 103, 107, 139, 107, 139, 236, 99})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00324 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          UnitTypes.\u00324.\u0031 obj1 = this;
          UnitTypes.\u00324.\u0031 obj2 = this;
          float num1 = 0.0f;
          double num2 = (double) num1;
          this.y = num1;
          this.x = (float) num2;
          this.mirror = false;
          this.reload = 55f;
          this.minShootVelocity = 0.01f;
          this.soundPitchMin = 1f;
          this.shootSound = Sounds.plasmadrop;
          this.bullet = (BulletType) new UnitTypes.\u00324.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00324.\u0031 this\u00242;

          [LineNumberTable(new byte[] {164, 200, 111, 107, 150, 107, 140, 107, 107, 139, 139, 112, 112, 139, 135, 139, 107, 107, 103, 139, 150, 107, 135, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00324.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00324.\u0031.\u0031 obj1 = this;
            this.sprite = "large-bomb";
            UnitTypes.\u00324.\u0031.\u0031 obj2 = this;
            float num1 = 30f;
            double num2 = (double) num1;
            this.height = num1;
            this.width = (float) num2;
            this.maxRange = 30f;
            this.this\u00242.ignoreRotation = true;
            this.backColor = Pal.heal;
            this.frontColor = Color.__\u003C\u003Ewhite;
            this.mixColorTo = Color.__\u003C\u003Ewhite;
            this.hitSound = Sounds.plasmaboom;
            this.this\u00242.shootCone = 180f;
            this.this\u00242.ejectEffect = Fx.__\u003C\u003Enone;
            this.despawnShake = 4f;
            this.collidesAir = false;
            this.lifetime = 70f;
            this.despawnEffect = Fx.__\u003C\u003EgreenBomb;
            this.hitEffect = Fx.__\u003C\u003EmassiveExplosion;
            this.keepVelocity = false;
            this.spin = 2f;
            UnitTypes.\u00324.\u0031.\u0031 obj3 = this;
            float num3 = 0.7f;
            double num4 = (double) num3;
            this.shrinkY = num3;
            this.shrinkX = (float) num4;
            this.speed = 1f / 1000f;
            this.collides = false;
            this.healPercent = 15f;
            this.splashDamage = 220f;
            this.splashDamageRadius = 80f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00325 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 238, 112, 144, 107, 107, 107, 107, 107, 107, 103, 107, 107, 103, 107, 107, 107, 103, 103, 103, 139, 107, 136, 127, 25})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00325([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00325 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00325.__\u003C\u003EAnon0();
        this.armor = 16f;
        this.health = 24000f;
        this.speed = 0.8f;
        this.rotateSpeed = 1f;
        this.accel = 0.04f;
        this.drag = 0.018f;
        this.flying = true;
        this.engineOffset = 46f;
        this.engineSize = 7.8f;
        this.rotateShooting = false;
        this.hitSize = 60f;
        this.payloadCapacity = 1797.76f;
        this.buildSpeed = 4f;
        this.drawShields = false;
        this.commandLimit = 6;
        this.lowAltitude = true;
        this.buildBeamOffset = 43f;
        this.ammoCapacity = 1300;
        this.ammoResupplyAmount = 20;
        this.abilities.add((object) new ForceFieldAbility(140f, 4f, 7000f, 480f), (object) new RepairFieldAbility(130f, 120f, 140f));
      }

      [HideFromJava]
      static \u00325() => UnitType.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new DefenderAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00326 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 12, 112, 107, 107, 107, 107, 107, 107, 104, 135, 139, 246, 74, 246, 91})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00326([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00326 obj = this;
        this.speed = 1.1f;
        this.drag = 0.13f;
        this.hitSize = 9f;
        this.health = 280f;
        this.accel = 0.4f;
        this.rotateSpeed = 3.3f;
        this.trailLength = 20;
        this.rotateShooting = false;
        this.armor = 2f;
        this.weapons.add((object) new UnitTypes.\u00326.\u0031(this, "mount-weapon"));
        this.weapons.add((object) new UnitTypes.\u00326.\u0032(this, "missiles-mount"));
      }

      [HideFromJava]
      static \u00326() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00326 this\u00241;

        [LineNumberTable(new byte[] {165, 24, 112, 107, 107, 107, 107, 103, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00326 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00326.\u0031 obj = this;
          this.reload = 12f;
          this.x = 4f;
          this.shootY = 4f;
          this.y = 1.5f;
          this.rotate = true;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = Bullets.standardCopper;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00326 this\u00241;

        [LineNumberTable(new byte[] {165, 34, 112, 103, 107, 107, 107, 103, 107, 107, 251, 82})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00326 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00326.\u0032 obj = this;
          this.mirror = false;
          this.reload = 20f;
          this.x = 0.0f;
          this.y = -5f;
          this.rotate = true;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.shootSound = Sounds.missile;
          this.bullet = (BulletType) new UnitTypes.\u00326.\u0032.\u0031(this, 2.7f, 12f, "missile");
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : MissileBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00326.\u0032 this\u00242;

          [LineNumberTable(new byte[] {165, 42, 117, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00326.\u0032 obj0, [In] float obj1, [In] float obj2, [In] string obj3)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2, obj3);
            UnitTypes.\u00326.\u0032.\u0031 obj = this;
            this.keepVelocity = true;
            this.width = 8f;
            this.height = 8f;
            this.shrinkY = 0.0f;
            this.drag = -3f / 1000f;
            this.homingRange = 60f;
            this.splashDamageRadius = 25f;
            this.splashDamage = 10f;
            this.lifetime = 80f;
            this.trailColor = Color.__\u003C\u003Egray;
            this.backColor = Pal.bulletYellowBack;
            this.frontColor = Pal.bulletYellow;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
            this.weaveScale = 8f;
            this.weaveMag = 2f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00327 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 63, 112, 107, 107, 107, 107, 107, 107, 107, 135, 104, 107, 107, 139, 159, 5, 246, 76, 246, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00327([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00327 obj = this;
        this.health = 600f;
        this.speed = 0.9f;
        this.drag = 0.15f;
        this.hitSize = 11f;
        this.armor = 4f;
        this.accel = 0.3f;
        this.rotateSpeed = 2.6f;
        this.rotateShooting = false;
        this.trailLength = 20;
        this.trailX = 5.5f;
        this.trailY = -4f;
        this.trailScl = 1.9f;
        this.abilities.add((object) new StatusFieldAbility(StatusEffects.overclock, 360f, 360f, 60f));
        this.weapons.add((object) new UnitTypes.\u00327.\u0031(this, "mount-weapon"));
        this.weapons.add((object) new UnitTypes.\u00327.\u0032(this, "artillery-mount"));
      }

      [HideFromJava]
      static \u00327() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00327 this\u00241;

        [LineNumberTable(new byte[] {165, 80, 112, 107, 107, 107, 103, 107, 107, 107, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00327 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00327.\u0031 obj = this;
          this.reload = 15f;
          this.x = 5f;
          this.y = 3.5f;
          this.rotate = true;
          this.rotateSpeed = 5f;
          this.inaccuracy = 10f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.shootSound = Sounds.shoot;
          this.bullet = Bullets.flakLead;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00327 this\u00241;

        [LineNumberTable(new byte[] {165, 92, 112, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00327 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00327.\u0032 obj = this;
          this.reload = 30f;
          this.x = 5f;
          this.y = -5f;
          this.rotate = true;
          this.inaccuracy = 2f;
          this.rotateSpeed = 2f;
          this.shake = 1.5f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing2;
          this.shootSound = Sounds.bang;
          this.bullet = Bullets.artilleryDense;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00328 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 106, 112, 107, 107, 107, 107, 107, 107, 107, 135, 104, 107, 107, 139, 159, 5, 246, 105, 246, 99})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00328([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00328 obj = this;
        this.health = 900f;
        this.speed = 0.85f;
        this.accel = 0.2f;
        this.rotateSpeed = 1.8f;
        this.drag = 0.17f;
        this.hitSize = 16f;
        this.armor = 7f;
        this.rotateShooting = false;
        this.trailLength = 22;
        this.trailX = 7f;
        this.trailY = -9f;
        this.trailScl = 1.5f;
        this.abilities.add((object) new ShieldRegenFieldAbility(20f, 40f, 240f, 60f));
        this.weapons.add((object) new UnitTypes.\u00328.\u0031(this, "large-artillery"));
        this.weapons.add((object) new UnitTypes.\u00328.\u0032(this, "missiles-mount"));
      }

      [HideFromJava]
      static \u00328() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00328 this\u00241;

        [LineNumberTable(new byte[] {165, 123, 112, 107, 103, 107, 107, 107, 103, 107, 107, 107, 139, 103, 107, 107, 139, 246, 86})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00328 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00328.\u0031 obj = this;
          this.reload = 65f;
          this.mirror = false;
          this.x = 0.0f;
          this.y = -3.5f;
          this.rotateSpeed = 1.7f;
          this.rotate = true;
          this.shootY = 7f;
          this.shake = 5f;
          this.recoil = 4f;
          this.shadow = 12f;
          this.shots = 1;
          this.inaccuracy = 3f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing3;
          this.shootSound = Sounds.artillery;
          this.bullet = (BulletType) new UnitTypes.\u00328.\u0031.\u0031(this, 3.2f, 12f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ArtilleryBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00328.\u0031 this\u00242;

          [LineNumberTable(new byte[] {165, 140, 115, 107, 107, 107, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 139, 139, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00328.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00328.\u0031.\u0031 obj = this;
            this.trailMult = 0.8f;
            this.hitEffect = Fx.__\u003C\u003EmassiveExplosion;
            this.knockback = 1.5f;
            this.lifetime = 100f;
            this.height = 15.5f;
            this.width = 15f;
            this.collidesTiles = false;
            this.ammoMultiplier = 4f;
            this.splashDamageRadius = 40f;
            this.splashDamage = 80f;
            this.backColor = Pal.missileYellowBack;
            this.frontColor = Pal.missileYellow;
            this.trailEffect = Fx.__\u003C\u003EartilleryTrail;
            this.trailSize = 6f;
            this.hitShake = 4f;
            this.shootEffect = Fx.__\u003C\u003EshootBig2;
            this.status = StatusEffects.blasted;
            this.statusDuration = 60f;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00328 this\u00241;

        [LineNumberTable(new byte[] {165, 164, 112, 107, 107, 139, 139, 107, 103, 103, 107, 107, 107, 139, 107, 246, 82})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00328 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00328.\u0032 obj = this;
          this.reload = 20f;
          this.x = 8.5f;
          this.y = -9f;
          this.shadow = 6f;
          this.rotateSpeed = 4f;
          this.rotate = true;
          this.shots = 2;
          this.shotDelay = 3f;
          this.inaccuracy = 5f;
          this.velocityRnd = 0.1f;
          this.shootSound = Sounds.missile;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.bullet = (BulletType) new UnitTypes.\u00328.\u0032.\u0031(this, 2.7f, 12f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : MissileBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00328.\u0032 this\u00242;

          [LineNumberTable(new byte[] {165, 180, 115, 107, 107, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00328.\u0032 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00328.\u0032.\u0031 obj = this;
            this.width = 8f;
            this.height = 8f;
            this.shrinkY = 0.0f;
            this.drag = -3f / 1000f;
            this.homingRange = 60f;
            this.keepVelocity = false;
            this.splashDamageRadius = 25f;
            this.splashDamage = 10f;
            this.lifetime = 80f;
            this.trailColor = Color.__\u003C\u003Egray;
            this.backColor = Pal.bulletYellowBack;
            this.frontColor = Pal.bulletYellow;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
            this.weaveScale = 8f;
            this.weaveMag = 1f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00329 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 201, 112, 107, 139, 107, 107, 107, 107, 107, 135, 104, 107, 107, 139, 246, 108, 246, 88})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00329([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00329 obj = this;
        this.health = 10500f;
        this.armor = 12f;
        this.speed = 0.73f;
        this.drag = 0.17f;
        this.hitSize = 39f;
        this.accel = 0.2f;
        this.rotateSpeed = 1.3f;
        this.rotateShooting = false;
        this.trailLength = 50;
        this.trailX = 18f;
        this.trailY = -21f;
        this.trailScl = 3f;
        this.weapons.add((object) new UnitTypes.\u00329.\u0031(this, "sei-launcher"));
        this.weapons.add((object) new UnitTypes.\u00329.\u0032(this, "large-bullet-mount"));
      }

      [HideFromJava]
      static \u00329() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00329 this\u00241;

        [LineNumberTable(new byte[] {165, 217, 144, 107, 107, 103, 107, 135, 139, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 139, 246, 83})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00329 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00329.\u0031 obj = this;
          this.x = 0.0f;
          this.y = 0.0f;
          this.rotate = true;
          this.rotateSpeed = 4f;
          this.mirror = false;
          this.shadow = 20f;
          this.shootY = 2f;
          this.recoil = 4f;
          this.reload = 45f;
          this.shots = 6;
          this.spacing = 10f;
          this.velocityRnd = 0.4f;
          this.inaccuracy = 7f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.shake = 3f;
          this.shootSound = Sounds.missile;
          this.xRand = 8f;
          this.shotDelay = 1f;
          this.bullet = (BulletType) new UnitTypes.\u00329.\u0031.\u0031(this, 4.2f, 42f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : MissileBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00329.\u0031 this\u00242;

          [LineNumberTable(new byte[] {165, 240, 115, 107, 107, 107, 118, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00329.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00329.\u0031.\u0031 obj3 = this;
            this.homingPower = 0.12f;
            this.width = 8f;
            this.height = 8f;
            UnitTypes.\u00329.\u0031.\u0031 obj4 = this;
            float num1 = 0.0f;
            double num2 = (double) num1;
            this.shrinkY = num1;
            this.shrinkX = (float) num2;
            this.drag = -3f / 1000f;
            this.homingRange = 80f;
            this.keepVelocity = false;
            this.splashDamageRadius = 35f;
            this.splashDamage = 45f;
            this.lifetime = 62f;
            this.trailColor = Pal.bulletYellowBack;
            this.backColor = Pal.bulletYellowBack;
            this.frontColor = Pal.bulletYellow;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.despawnEffect = Fx.__\u003C\u003EblastExplosion;
            this.weaveScale = 8f;
            this.weaveMag = 2f;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00329 this\u00241;

        [LineNumberTable(new byte[] {166, 5, 112, 107, 107, 107, 107, 107, 103, 107, 107, 107, 107, 107, 139, 103, 107, 107, 246, 70})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u00329 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00329.\u0032 obj = this;
          this.reload = 60f;
          this.cooldownTime = 90f;
          this.x = 17.5f;
          this.y = -16.5f;
          this.rotateSpeed = 4f;
          this.rotate = true;
          this.shootY = 7f;
          this.shake = 2f;
          this.recoil = 3f;
          this.shadow = 12f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing3;
          this.shootSound = Sounds.shootBig;
          this.shots = 3;
          this.shotDelay = 4f;
          this.inaccuracy = 1f;
          this.bullet = (BulletType) new UnitTypes.\u00329.\u0032.\u0031(this, 7f, 57f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00329.\u0032 this\u00242;

          [LineNumberTable(new byte[] {166, 22, 115, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00329.\u0032 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00329.\u0032.\u0031 obj = this;
            this.width = 13f;
            this.height = 19f;
            this.shootEffect = Fx.__\u003C\u003EshootBig;
            this.lifetime = 35f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {65, 112, 107, 107, 107, 103, 107, 107, 139, 246, 86})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0033 obj = this;
        this.speed = 0.39f;
        this.hitSize = 13f;
        this.rotateSpeed = 3f;
        this.targetAir = false;
        this.health = 800f;
        this.armor = 9f;
        this.mechFrontSway = 0.55f;
        this.weapons.add((object) new UnitTypes.\u0033.\u0031(this, "artillery"));
      }

      [HideFromJava]
      static \u0033() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0033 this\u00241;

        [LineNumberTable(new byte[] {74, 112, 103, 107, 107, 107, 107, 107, 107, 107, 251, 76})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0033 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0033.\u0031 obj = this;
          this.top = false;
          this.y = 1f;
          this.x = 9f;
          this.reload = 60f;
          this.recoil = 4f;
          this.shake = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing2;
          this.shootSound = Sounds.artillery;
          this.bullet = (BulletType) new UnitTypes.\u0033.\u0031.\u0031(this, 2f, 8f, "shell");
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ArtilleryBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0033.\u0031 this\u00242;

          [LineNumberTable(new byte[] {83, 117, 107, 107, 107, 118, 103, 103, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0033.\u0031 obj0, [In] float obj1, [In] float obj2, [In] string obj3)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2, obj3);
            UnitTypes.\u0033.\u0031.\u0031 obj4 = this;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.knockback = 0.8f;
            this.lifetime = 110f;
            UnitTypes.\u0033.\u0031.\u0031 obj5 = this;
            float num1 = 14f;
            double num2 = (double) num1;
            this.height = num1;
            this.width = (float) num2;
            this.collides = true;
            this.collidesTiles = true;
            this.splashDamageRadius = 28f;
            this.splashDamage = 54f;
            this.backColor = Pal.bulletYellowBack;
            this.frontColor = Pal.bulletYellow;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00330 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 31, 112, 107, 107, 107, 107, 107, 107, 107, 135, 134, 159, 22, 104, 107, 107, 139, 246, 93})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00330([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00330 obj = this;
        this.health = 22000f;
        this.speed = 0.62f;
        this.drag = 0.18f;
        this.hitSize = 50f;
        this.armor = 16f;
        this.accel = 0.19f;
        this.rotateSpeed = 0.9f;
        this.rotateShooting = false;
        float spawnTime = 900f;
        this.abilities.add((object) new UnitSpawnAbility(UnitTypes.flare, spawnTime, 19.25f, -31.75f), (object) new UnitSpawnAbility(UnitTypes.flare, spawnTime, -19.25f, -31.75f));
        this.trailLength = 70;
        this.trailX = 23f;
        this.trailY = -32f;
        this.trailScl = 3.5f;
        this.weapons.add((object) new UnitTypes.\u00330.\u0031(this, "omura-cannon"));
      }

      [HideFromJava]
      static \u00330() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00330 this\u00241;

        [LineNumberTable(new byte[] {166, 50, 112, 107, 107, 103, 107, 107, 107, 103, 107, 107, 107, 107, 139, 103, 139, 236, 75})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00330 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00330.\u0031 obj = this;
          this.reload = 110f;
          this.cooldownTime = 90f;
          this.mirror = false;
          this.x = 0.0f;
          this.y = -3.5f;
          this.rotateSpeed = 1.4f;
          this.rotate = true;
          this.shootY = 23f;
          this.shake = 6f;
          this.recoil = 10.5f;
          this.shadow = 50f;
          this.shootSound = Sounds.railgun;
          this.shots = 1;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.bullet = (BulletType) new UnitTypes.\u00330.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : RailBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00330.\u0031 this\u00242;

          [LineNumberTable(new byte[] {166, 67, 111, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00330.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u00330.\u0031.\u0031 obj = this;
            this.shootEffect = Fx.__\u003C\u003ErailShoot;
            this.length = 500f;
            this.updateEffectSeg = 60f;
            this.pierceEffect = Fx.__\u003C\u003ErailHit;
            this.updateEffect = Fx.__\u003C\u003ErailTrail;
            this.hitEffect = Fx.__\u003C\u003EmassiveExplosion;
            this.smokeEffect = Fx.__\u003C\u003EshootBig2;
            this.damage = 1250f;
            this.pierceDamageFactor = 0.5f;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00331 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 84, 112, 112, 135, 103, 107, 103, 107, 107, 107, 107, 107, 104, 107, 107, 107, 103, 135, 246, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00331([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00331 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00331.__\u003C\u003EAnon0();
        this.isCounted = false;
        this.flying = true;
        this.mineSpeed = 6.5f;
        this.mineTier = 1;
        this.buildSpeed = 0.5f;
        this.drag = 0.05f;
        this.speed = 3f;
        this.rotateSpeed = 15f;
        this.accel = 0.1f;
        this.itemCapacity = 30;
        this.health = 150f;
        this.engineOffset = 6f;
        this.hitSize = 8f;
        this.commandLimit = 3;
        this.alwaysUnlocked = true;
        this.weapons.add((object) new UnitTypes.\u00331.\u0031(this, "small-basic-weapon"));
      }

      [HideFromJava]
      static \u00331() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00331 this\u00241;

        [LineNumberTable(new byte[] {166, 103, 112, 107, 107, 107, 103, 139, 246, 72})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00331 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00331.\u0031 obj = this;
          this.reload = 17f;
          this.x = 2.75f;
          this.y = 1f;
          this.top = false;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = (BulletType) new UnitTypes.\u00331.\u0031.\u0031(this, 2.5f, 11f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00331.\u0031 this\u00242;

          [LineNumberTable(new byte[] {166, 110, 115, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00331.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00331.\u0031.\u0031 obj = this;
            this.width = 7f;
            this.height = 9f;
            this.lifetime = 60f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
            this.buildingDamageMultiplier = 0.01f;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new BuilderAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00332 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 121, 112, 112, 135, 103, 107, 103, 107, 107, 107, 107, 107, 104, 107, 107, 107, 103, 103, 135, 246, 84})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00332([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00332 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00332.__\u003C\u003EAnon0();
        this.isCounted = false;
        this.flying = true;
        this.mineSpeed = 7f;
        this.mineTier = 1;
        this.buildSpeed = 0.75f;
        this.drag = 0.05f;
        this.speed = 3.3f;
        this.rotateSpeed = 17f;
        this.accel = 0.1f;
        this.itemCapacity = 50;
        this.health = 170f;
        this.engineOffset = 6f;
        this.hitSize = 9f;
        this.rotateShooting = false;
        this.lowAltitude = true;
        this.commandLimit = 4;
        this.weapons.add((object) new UnitTypes.\u00332.\u0031(this, "small-mount-weapon"));
      }

      [HideFromJava]
      static \u00332() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00332 this\u00241;

        [LineNumberTable(new byte[] {166, 141, 112, 103, 107, 107, 107, 103, 103, 107, 107, 139, 246, 72})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00332 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00332.\u0031 obj = this;
          this.top = false;
          this.reload = 20f;
          this.x = 3f;
          this.y = 0.5f;
          this.rotate = true;
          this.shots = 2;
          this.shotDelay = 4f;
          this.spacing = 0.0f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = (BulletType) new UnitTypes.\u00332.\u0031.\u0031(this, 3f, 11f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00332.\u0031 this\u00242;

          [LineNumberTable(new byte[] {166, 152, 115, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00332.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00332.\u0031.\u0031 obj = this;
            this.width = 7f;
            this.height = 9f;
            this.lifetime = 60f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
            this.buildingDamageMultiplier = 0.01f;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new BuilderAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00333 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 163, 112, 112, 135, 103, 107, 103, 107, 107, 107, 107, 107, 104, 107, 107, 107, 135, 246, 85})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00333([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00333 obj = this;
        this.defaultController = (Prov) new UnitTypes.\u00333.__\u003C\u003EAnon0();
        this.isCounted = false;
        this.flying = true;
        this.mineSpeed = 8f;
        this.mineTier = 2;
        this.buildSpeed = 1f;
        this.drag = 0.05f;
        this.speed = 3.55f;
        this.rotateSpeed = 19f;
        this.accel = 0.11f;
        this.itemCapacity = 70;
        this.health = 220f;
        this.engineOffset = 6f;
        this.hitSize = 11f;
        this.commandLimit = 5;
        this.weapons.add((object) new UnitTypes.\u00333.\u0031(this, "small-mount-weapon"));
      }

      [HideFromJava]
      static \u00333() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u00333 this\u00241;

        [LineNumberTable(new byte[] {166, 181, 112, 103, 107, 107, 107, 103, 107, 107, 107, 139, 246, 73})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u00333 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u00333.\u0031 obj = this;
          this.top = false;
          this.reload = 15f;
          this.x = 1f;
          this.y = 2f;
          this.shots = 2;
          this.spacing = 2f;
          this.inaccuracy = 3f;
          this.shotDelay = 3f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = (BulletType) new UnitTypes.\u00333.\u0031.\u0031(this, 3.5f, 11f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u00333.\u0031 this\u00242;

          [LineNumberTable(new byte[] {166, 192, 115, 107, 107, 107, 107, 107, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u00333.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u00333.\u0031.\u0031 obj = this;
            this.width = 6.5f;
            this.height = 11f;
            this.lifetime = 70f;
            this.shootEffect = Fx.__\u003C\u003EshootSmall;
            this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
            this.buildingDamageMultiplier = 0.01f;
            this.homingPower = 0.04f;
          }
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new BuilderAI();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00334 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 207, 144, 107, 107, 107, 107, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00334([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u00334 obj = this;
        this.speed = 0.0f;
        this.hitSize = 0.0f;
        this.health = 1f;
        this.rotateSpeed = 360f;
        this.itemCapacity = 0;
        this.commandLimit = 0;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool isHidden() => true;

      [HideFromJava]
      static \u00334() => UnitType.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {98, 112, 107, 107, 107, 107, 107, 103, 139, 103, 107, 135, 255, 13, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0034 obj = this;
        this.speed = 0.35f;
        this.hitSize = 20f;
        this.rotateSpeed = 2.1f;
        this.health = 9000f;
        this.armor = 10f;
        this.canDrown = false;
        this.mechFrontSway = 1f;
        this.mechStepParticles = true;
        this.mechStepShake = 0.15f;
        this.singleTarget = true;
        this.weapons.add((object) new UnitTypes.\u0034.\u0031(this, "scepter-weapon"), (object) new UnitTypes.\u0034.\u0032(this, "mount-weapon"), (object) new UnitTypes.\u0034.\u0033(this, "mount-weapon"));
      }

      [HideFromJava]
      static \u0034() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0034 this\u00241;

        [LineNumberTable(new byte[] {112, 112, 103, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 139, 246, 75})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0034 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0034.\u0031 obj = this;
          this.top = false;
          this.y = 1f;
          this.x = 16f;
          this.shootY = 8f;
          this.reload = 45f;
          this.recoil = 5f;
          this.shake = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing3;
          this.shootSound = Sounds.bang;
          this.shots = 3;
          this.inaccuracy = 3f;
          this.shotDelay = 4f;
          this.bullet = (BulletType) new UnitTypes.\u0034.\u0031.\u0031(this, 7f, 45f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0034.\u0031 this\u00242;

          [LineNumberTable(new byte[] {126, 115, 107, 107, 107, 107, 103, 103, 139, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0034.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u0034.\u0031.\u0031 obj = this;
            this.width = 11f;
            this.height = 20f;
            this.lifetime = 25f;
            this.shootEffect = Fx.__\u003C\u003EshootBig;
            this.lightning = 2;
            this.lightningLength = 6;
            this.lightningColor = Pal.surge;
            this.lightningDamage = 19f;
          }
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0034 this\u00241;

        [LineNumberTable(new byte[] {160, 75, 112, 107, 107, 107, 103, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] UnitTypes.\u0034 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0034.\u0032 obj = this;
          this.reload = 13f;
          this.x = 8.5f;
          this.y = 6f;
          this.rotate = true;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = Bullets.standardCopper;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0033 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0034 this\u00241;

        [LineNumberTable(new byte[] {160, 83, 112, 107, 107, 107, 103, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0033([In] UnitTypes.\u0034 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0034.\u0033 obj = this;
          this.reload = 16f;
          this.x = 8.5f;
          this.y = -7f;
          this.rotate = true;
          this.ejectEffect = Fx.__\u003C\u003Ecasing1;
          this.bullet = Bullets.standardCopper;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 95, 112, 107, 107, 107, 107, 107, 103, 107, 103, 107, 139, 246, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0035 obj = this;
        this.speed = 0.35f;
        this.hitSize = 26f;
        this.rotateSpeed = 1.65f;
        this.health = 24000f;
        this.armor = 14f;
        this.mechStepParticles = true;
        this.mechStepShake = 0.75f;
        this.canDrown = false;
        this.mechFrontSway = 1.9f;
        this.mechSideSway = 0.6f;
        this.weapons.add((object) new UnitTypes.\u0035.\u0031(this, "reign-weapon"));
      }

      [HideFromJava]
      static \u0035() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0035 this\u00241;

        [LineNumberTable(new byte[] {160, 108, 112, 103, 107, 107, 107, 107, 107, 107, 107, 139, 246, 94})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0035 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0035.\u0031 obj = this;
          this.top = false;
          this.y = 1f;
          this.x = 21.5f;
          this.shootY = 11f;
          this.reload = 9f;
          this.recoil = 5f;
          this.shake = 2f;
          this.ejectEffect = Fx.__\u003C\u003Ecasing4;
          this.shootSound = Sounds.bang;
          this.bullet = (BulletType) new UnitTypes.\u0035.\u0031.\u0031(this, 13f, 65f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : BasicBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0035.\u0031 this\u00242;

          [LineNumberTable(new byte[] {160, 119, 115, 103, 104, 107, 107, 107, 107, 139, 107, 107, 139, 103, 107, 139, 246, 76})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0035.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u0035.\u0031.\u0031 obj = this;
            this.pierce = true;
            this.pierceCap = 10;
            this.width = 14f;
            this.height = 33f;
            this.lifetime = 15f;
            this.shootEffect = Fx.__\u003C\u003EshootBig;
            this.fragVelocityMin = 0.4f;
            this.hitEffect = Fx.__\u003C\u003EblastExplosion;
            this.splashDamage = 16f;
            this.splashDamageRadius = 13f;
            this.fragBullets = 2;
            this.fragLifeMin = 0.0f;
            this.fragCone = 30f;
            this.fragBullet = (BulletType) new UnitTypes.\u0035.\u0031.\u0031.\u0031(this, 9f, 18f);
          }

          [InnerClass]
          [EnclosingMethod(null, null, null)]
          [SpecialName]
          internal class \u0031 : BasicBulletType
          {
            [Modifiers]
            internal UnitTypes.\u0035.\u0031.\u0031 this\u00243;

            [LineNumberTable(new byte[] {160, 136, 115, 107, 107, 103, 103, 135, 107, 107, 107, 107})]
            [MethodImpl(MethodImplOptions.NoInlining)]
            internal \u0031([In] UnitTypes.\u0035.\u0031.\u0031 obj0, [In] float obj1, [In] float obj2)
            {
              this.this\u00243 = obj0;
              // ISSUE: explicit constructor call
              base.\u002Ector(obj1, obj2);
              UnitTypes.\u0035.\u0031.\u0031.\u0031 obj = this;
              this.width = 10f;
              this.height = 10f;
              this.pierce = true;
              this.pierceBuilding = true;
              this.pierceCap = 3;
              this.lifetime = 20f;
              this.hitEffect = Fx.__\u003C\u003EflakExplosion;
              this.splashDamage = 15f;
              this.splashDamageRadius = 10f;
            }
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 157, 112, 103, 107, 107, 107, 107, 107, 107, 135, 127, 0, 139, 246, 82})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0036 obj = this;
        this.canBoost = true;
        this.boostMultiplier = 1.5f;
        this.speed = 0.55f;
        this.hitSize = 8f;
        this.health = 120f;
        this.buildSpeed = 0.8f;
        this.armor = 1f;
        this.commandLimit = 8;
        this.abilities.add((object) new RepairFieldAbility(10f, 240f, 60f));
        this.ammoType = AmmoTypes.power;
        this.weapons.add((object) new UnitTypes.\u0036.\u0031(this, "heal-weapon"));
      }

      [HideFromJava]
      static \u0036() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0036 this\u00241;

        [LineNumberTable(new byte[] {160, 170, 112, 103, 107, 107, 107, 103, 107, 107, 139, 246, 71})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0036 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0036.\u0031 obj = this;
          this.top = false;
          this.shootY = 2f;
          this.reload = 24f;
          this.x = 4.5f;
          this.alternate = false;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.recoil = 2f;
          this.shootSound = Sounds.lasershoot;
          this.bullet = (BulletType) new UnitTypes.\u0036.\u0031.\u0031(this, 5.2f, 14f);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBoltBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0036.\u0031 this\u00242;

          [LineNumberTable(new byte[] {160, 180, 115, 107, 107, 103, 107, 107})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0036.\u0031 obj0, [In] float obj1, [In] float obj2)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector(obj1, obj2);
            UnitTypes.\u0036.\u0031.\u0031 obj = this;
            this.lifetime = 32f;
            this.healPercent = 5f;
            this.collidesTeam = true;
            this.backColor = Pal.heal;
            this.frontColor = Color.__\u003C\u003Ewhite;
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 190, 112, 103, 107, 107, 107, 107, 107, 107, 139, 103, 107, 136, 127, 5, 139, 246, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0037 obj = this;
        this.canBoost = true;
        this.boostMultiplier = 1.6f;
        this.speed = 0.7f;
        this.hitSize = 10f;
        this.health = 320f;
        this.buildSpeed = 0.9f;
        this.armor = 4f;
        this.riseSpeed = 0.07f;
        this.mineTier = 2;
        this.mineSpeed = 5f;
        this.commandLimit = 9;
        this.abilities.add((object) new ShieldRegenFieldAbility(20f, 40f, 300f, 60f));
        this.ammoType = AmmoTypes.power;
        this.weapons.add((object) new UnitTypes.\u0037.\u0031(this, "heal-shotgun-weapon"));
      }

      [HideFromJava]
      static \u0037() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0037 this\u00241;

        [LineNumberTable(new byte[] {160, 207, 112, 103, 107, 107, 107, 139, 107, 103, 107, 107, 107, 107, 107, 139, 236, 84})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0037 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0037.\u0031 obj = this;
          this.top = false;
          this.x = 5f;
          this.shake = 2.2f;
          this.y = 0.5f;
          this.shootY = 2.5f;
          this.reload = 38f;
          this.shots = 3;
          this.inaccuracy = 35f;
          this.shotDelay = 0.5f;
          this.spacing = 0.0f;
          this.ejectEffect = Fx.__\u003C\u003Enone;
          this.recoil = 2.5f;
          this.shootSound = Sounds.spark;
          this.bullet = (BulletType) new UnitTypes.\u0037.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LightningBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0037.\u0031 this\u00242;

          [LineNumberTable(new byte[] {160, 223, 111, 118, 107, 103, 103, 139, 139, 246, 74})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0037.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u0037.\u0031.\u0031 obj1 = this;
            UnitTypes.\u0037.\u0031.\u0031 obj2 = this;
            Color heal = Pal.heal;
            Color color = heal;
            this.hitColor = heal;
            this.lightningColor = color;
            this.damage = 12f;
            this.lightningLength = 7;
            this.lightningLengthRand = 7;
            this.shootEffect = Fx.__\u003C\u003EshootHeal;
            this.healPercent = 2f;
            this.lightningType = (BulletType) new UnitTypes.\u0037.\u0031.\u0031.\u0031(this, 0.0001f, 0.0f);
          }

          [InnerClass]
          [EnclosingMethod(null, null, null)]
          [SpecialName]
          internal class \u0031 : BulletType
          {
            [Modifiers]
            internal UnitTypes.\u0037.\u0031.\u0031 this\u00243;

            [LineNumberTable(new byte[] {160, 232, 115, 112, 107, 107, 107, 107, 103, 107, 103})]
            [MethodImpl(MethodImplOptions.NoInlining)]
            internal \u0031([In] UnitTypes.\u0037.\u0031.\u0031 obj0, [In] float obj1, [In] float obj2)
            {
              this.this\u00243 = obj0;
              // ISSUE: explicit constructor call
              base.\u002Ector(obj1, obj2);
              UnitTypes.\u0037.\u0031.\u0031.\u0031 obj = this;
              this.lifetime = Fx.__\u003C\u003Elightning.lifetime;
              this.hitEffect = Fx.__\u003C\u003EhitLancer;
              this.despawnEffect = Fx.__\u003C\u003Enone;
              this.status = StatusEffects.shocked;
              this.statusDuration = 10f;
              this.hittable = false;
              this.healPercent = 2f;
              this.collidesTeam = true;
            }
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 246, 112, 103, 107, 107, 107, 103, 107, 107, 139, 104, 107, 139, 107, 139, 107, 135, 159, 5, 246, 84})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0038 obj = this;
        this.mineTier = 3;
        this.boostMultiplier = 2f;
        this.health = 650f;
        this.buildSpeed = 1.7f;
        this.canBoost = true;
        this.armor = 9f;
        this.landShake = 2f;
        this.riseSpeed = 0.05f;
        this.commandLimit = 10;
        this.mechFrontSway = 0.55f;
        this.ammoType = AmmoTypes.power;
        this.speed = 0.4f;
        this.hitSize = 10f;
        this.mineSpeed = 6f;
        this.drawShields = false;
        this.abilities.add((object) new ForceFieldAbility(60f, 0.3f, 400f, 360f));
        this.weapons.add((object) new UnitTypes.\u0038.\u0031(this, "beam-weapon"));
      }

      [HideFromJava]
      static \u0038() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0038 this\u00241;

        [LineNumberTable(new byte[] {161, 12, 112, 103, 107, 107, 107, 107, 107, 139, 236, 74})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0038 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0038.\u0031 obj = this;
          this.top = false;
          this.shake = 2f;
          this.shootY = 4f;
          this.x = 6.5f;
          this.reload = 50f;
          this.recoil = 4f;
          this.shootSound = Sounds.laser;
          this.bullet = (BulletType) new UnitTypes.\u0038.\u0031.\u0031(this);
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : LaserBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0038.\u0031 this\u00242;

          [LineNumberTable(new byte[] {161, 21, 111, 107, 107, 107, 107, 107, 107, 103, 127, 20})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0038.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u0038.\u0031.\u0031 obj = this;
            this.damage = 45f;
            this.recoil = 1f;
            this.sideAngle = 45f;
            this.sideWidth = 1f;
            this.sideLength = 70f;
            this.healPercent = 10f;
            this.collidesTeam = true;
            this.colors = new Color[3]
            {
              Pal.heal.cpy().a(0.4f),
              Pal.heal,
              Color.__\u003C\u003Ewhite
            };
          }
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : UnitType
    {
      [Modifiers]
      internal UnitTypes this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 34, 112, 139, 107, 103, 107, 139, 103, 107, 139, 107, 107, 107, 107, 103, 139, 107, 107, 103, 107, 153, 135, 246, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] UnitTypes obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UnitTypes.\u0039 obj = this;
        this.hitSize = 23f;
        this.rotateSpeed = 1.6f;
        this.canDrown = false;
        this.mechFrontSway = 1f;
        this.buildSpeed = 3f;
        this.mechStepParticles = true;
        this.mechStepShake = 0.15f;
        this.ammoType = AmmoTypes.powerHigh;
        this.speed = 0.39f;
        this.boostMultiplier = 2.2f;
        this.engineOffset = 12f;
        this.engineSize = 6f;
        this.lowAltitude = true;
        this.riseSpeed = 0.02f;
        this.health = 7500f;
        this.armor = 9f;
        this.canBoost = true;
        this.landShake = 4f;
        this.immunities = ObjectSet.with((object[]) new StatusEffect[1]
        {
          StatusEffects.burning
        });
        this.commandLimit = 8;
        this.weapons.add((object) new UnitTypes.\u0039.\u0031(this, "vela-weapon"));
      }

      [HideFromJava]
      static \u0039() => UnitType.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Weapon
      {
        [Modifiers]
        internal UnitTypes.\u0039 this\u00241;

        [LineNumberTable(new byte[] {161, 61, 112, 103, 103, 107, 107, 150, 151, 107, 107, 107, 107, 103, 139, 236, 87, 107, 121})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] UnitTypes.\u0039 obj0, [In] string obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          UnitTypes.\u0039.\u0031 obj2 = this;
          this.mirror = false;
          this.top = false;
          this.shake = 4f;
          this.shootY = 13f;
          UnitTypes.\u0039.\u0031 obj3 = this;
          float num1 = 0.0f;
          double num2 = (double) num1;
          this.y = num1;
          this.x = (float) num2;
          this.firstShotDelay = Fx.__\u003C\u003EgreenLaserChargeSmall.lifetime - 1f;
          this.reload = 155f;
          this.recoil = 0.0f;
          this.chargeSound = Sounds.lasercharge2;
          this.shootSound = Sounds.beam;
          this.continuous = true;
          this.cooldownTime = 200f;
          this.bullet = (BulletType) new UnitTypes.\u0039.\u0031.\u0031(this);
          this.shootStatus = StatusEffects.slow;
          this.shootStatusDuration = this.bullet.lifetime + this.firstShotDelay;
        }

        [InnerClass]
        [EnclosingMethod(null, null, null)]
        [SpecialName]
        internal class \u0031 : ContinuousLaserBulletType
        {
          [Modifiers]
          internal UnitTypes.\u0039.\u0031 this\u00242;

          [LineNumberTable(new byte[] {161, 77, 111, 107, 107, 107, 107, 107, 107, 107, 139, 139, 107, 107, 167, 107, 135, 127, 58})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] UnitTypes.\u0039.\u0031 obj0)
          {
            this.this\u00242 = obj0;
            // ISSUE: explicit constructor call
            base.\u002Ector();
            UnitTypes.\u0039.\u0031.\u0031 obj = this;
            this.damage = 30f;
            this.length = 175f;
            this.hitEffect = Fx.__\u003C\u003EhitMeltHeal;
            this.drawSize = 420f;
            this.lifetime = 160f;
            this.shake = 1f;
            this.despawnEffect = Fx.__\u003C\u003EsmokeCloud;
            this.smokeEffect = Fx.__\u003C\u003Enone;
            this.shootEffect = Fx.__\u003C\u003EgreenLaserChargeSmall;
            this.incendChance = 0.1f;
            this.incendSpread = 5f;
            this.incendAmount = 1;
            this.healPercent = 1f;
            this.collidesTeam = true;
            this.colors = new Color[4]
            {
              Pal.heal.cpy().a(0.2f),
              Pal.heal.cpy().a(0.5f),
              Pal.heal.cpy().mul(1.2f),
              Color.__\u003C\u003Ewhite
            };
          }
        }
      }
    }
  }
}
