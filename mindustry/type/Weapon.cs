// Decompiled with JetBrains decompiler
// Type: mindustry.type.Weapon
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.graphics;
using arc.graphics.g2d;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.graphics;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class Weapon : Object, Cloneable.__Interface
  {
    public string name;
    public BulletType bullet;
    public Effect ejectEffect;
    public bool mirror;
    public bool flipSprite;
    public bool alternate;
    public bool rotate;
    public bool top;
    public bool continuous;
    public float rotateSpeed;
    public float reload;
    public int shots;
    public float spacing;
    public float inaccuracy;
    public float shake;
    public float recoil;
    public float shootX;
    public float shootY;
    public float x;
    public float y;
    public float xRand;
    public float shadow;
    public float velocityRnd;
    public float firstShotDelay;
    public float shotDelay;
    public float shootCone;
    public float cooldownTime;
    public float soundPitchMin;
    public float soundPitchMax;
    public bool ignoreRotation;
    public float minShootVelocity;
    public int otherSide;
    public Sound shootSound;
    public Sound chargeSound;
    public Sound noAmmoSound;
    public TextureRegion region;
    public TextureRegion heatRegion;
    public TextureRegion outlineRegion;
    public Color heatColor;
    public StatusEffect shootStatus;
    public float shootStatusDuration;

    [LineNumberTable(new byte[] {41, 232, 159, 180, 203, 139, 135, 135, 135, 135, 199, 203, 135, 139, 139, 139, 139, 150, 150, 139, 139, 139, 139, 139, 139, 139, 150, 135, 139, 135, 139, 139, 235, 72, 139, 139, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Weapon(string name)
    {
      Weapon weapon = this;
      this.name = "";
      this.ejectEffect = Fx.__\u003C\u003Enone;
      this.mirror = true;
      this.flipSprite = false;
      this.alternate = true;
      this.rotate = false;
      this.top = true;
      this.rotateSpeed = 20f;
      this.shots = 1;
      this.spacing = 0.0f;
      this.inaccuracy = 0.0f;
      this.shake = 0.0f;
      this.recoil = 1.5f;
      this.shootX = 0.0f;
      this.shootY = 3f;
      this.x = 5f;
      this.y = 0.0f;
      this.xRand = 0.0f;
      this.shadow = -1f;
      this.velocityRnd = 0.0f;
      this.firstShotDelay = 0.0f;
      this.shotDelay = 0.0f;
      this.shootCone = 5f;
      this.cooldownTime = 20f;
      this.soundPitchMin = 0.8f;
      this.soundPitchMax = 1f;
      this.ignoreRotation = false;
      this.minShootVelocity = -1f;
      this.otherSide = -1;
      this.shootSound = Sounds.pew;
      this.chargeSound = Sounds.none;
      this.noAmmoSound = Sounds.noammo;
      this.heatColor = Pal.turretHeat;
      this.shootStatus = StatusEffects.none;
      this.shootStatusDuration = 300f;
      this.name = name;
    }

    [LineNumberTable(new byte[] {46, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Weapon()
      : this("")
    {
    }

    [LineNumberTable(new byte[] {51, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Weapon copy()
    {
      Weapon weapon;
      CloneNotSupportedException supportedException1;
      try
      {
        weapon = (Weapon) this.clone();
      }
      catch (CloneNotSupportedException ex)
      {
        supportedException1 = (CloneNotSupportedException) ByteCodeHelper.MapException<CloneNotSupportedException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return weapon;
label_3:
      CloneNotSupportedException supportedException2 = supportedException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("very good language design", (Exception) supportedException2);
    }

    [LineNumberTable(new byte[] {58, 127, 6, 127, 16, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      this.region = Core.atlas.find(this.name, (TextureRegion) Core.atlas.find("clear"));
      this.heatRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.name).append("-heat").toString());
      this.outlineRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.name).append("-outline").toString());
    }

    [HideFromJava]
    public static implicit operator Cloneable([In] Weapon obj0)
    {
      Cloneable cloneable;
      cloneable.__\u003Cref\u003E = (__Null) obj0;
      return cloneable;
    }
  }
}
