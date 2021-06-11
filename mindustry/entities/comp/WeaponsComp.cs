// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.WeaponsComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.audio;
using mindustry.entities.bullet;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Teamc", "mindustry.gen.Posc", "mindustry.gen.Rotc", "mindustry.gen.Velc", "mindustry.gen.Statusc"})]
  internal abstract class WeaponsComp : 
    Object,
    Teamc,
    Posc,
    Position,
    Entityc,
    Rotc,
    Velc,
    Statusc,
    Flyingc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject
  {
    internal float x;
    internal float y;
    internal float rotation;
    internal float reloadMultiplier;
    internal bool disarmed;
    internal Vec2 vel;
    internal UnitType type;
    internal static int sequenceNum;
    internal WeaponMount[] mounts;
    [NonSerialized]
    internal bool isRotate;
    [NonSerialized]
    internal float aimX;
    [NonSerialized]
    internal float aimY;
    internal bool isShooting;
    internal float ammo;

    [LineNumberTable(new byte[] {159, 129, 164, 120, 104, 8, 200, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void controlWeapons([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        weaponMount.rotate = num1 != 0;
        weaponMount.shoot = num2 != 0;
      }
      this.isRotate = num1 != 0;
      this.isShooting = num2 != 0;
    }

    [LineNumberTable(new byte[] {19, 127, 1, 159, 15, 116, 148, 116, 104, 8, 230, 69, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void aim([In] float obj0, [In] float obj1)
    {
      Tmp.__\u003C\u003Ev1.set(obj0, obj1).sub(this.x, this.y);
      if ((double) Tmp.__\u003C\u003Ev1.len() < (double) this.type.aimDst)
        Tmp.__\u003C\u003Ev1.setLength(this.type.aimDst);
      obj0 = Tmp.__\u003C\u003Ev1.x + this.x;
      obj1 = Tmp.__\u003C\u003Ev1.y + this.y;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        weaponMount.aimX = obj0;
        weaponMount.aimY = obj1;
      }
      this.aimX = obj0;
      this.aimY = obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canShoot() => !this.disarmed;

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract bool isLocal();

    [LineNumberTable(new byte[] {160, 67, 135, 110, 150, 159, 29, 104, 159, 19, 102, 99, 255, 12, 72, 191, 8, 137, 99, 255, 4, 75, 127, 8, 117, 171, 121, 123, 123, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void shoot(
      [In] WeaponMount obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7,
      [In] int obj8)
    {
      Weapon weapon = obj0.__\u003C\u003Eweapon;
      float x = this.x;
      float y = this.y;
      int num1 = (double) (weapon.firstShotDelay + weapon.shotDelay) > 0.0 ? 1 : 0;
      (num1 == 0 ? (!weapon.continuous ? weapon.shootSound : Sounds.none) : weapon.chargeSound).at(obj1, obj2, Mathf.random(weapon.soundPitchMin, weapon.soundPitchMax));
      BulletType bullet = weapon.bullet;
      float num2 = !bullet.scaleVelocity ? 1f : Mathf.clamp(Mathf.dst(obj1, obj2, obj3, obj4) / bullet.range());
      WeaponsComp.sequenceNum = 0;
      if (num1 != 0)
        Angles.shotgun(weapon.shots, weapon.spacing, obj7, (Floatc) new WeaponsComp.__\u003C\u003EAnon0(this, weapon, obj0, obj1, x, obj2, y, num2));
      else
        Angles.shotgun(weapon.shots, weapon.spacing, obj7, (Floatc) new WeaponsComp.__\u003C\u003EAnon1(this, obj0, weapon, obj1, obj2, num2));
      int num3 = bullet.keepVelocity ? 1 : 0;
      if (num1 != 0)
      {
        Time.run(weapon.firstShotDelay, (Runnable) new WeaponsComp.__\u003C\u003EAnon2(this, obj7, bullet, weapon, obj1, obj2, obj0));
      }
      else
      {
        this.vel.add(Tmp.__\u003C\u003Ev1.trns(obj7 + 180f, bullet.recoil));
        Effect.shake(weapon.shake, weapon.shake, obj1, obj2);
        obj0.heat = 1f;
      }
      weapon.ejectEffect.at(obj5, obj6, obj7 * (float) obj8);
      bullet.shootEffect.at(obj1, obj2, obj7, num3 == 0 ? (object) (WeaponsComp) null : (object) this);
      bullet.smokeEffect.at(obj1, obj2, obj7, num3 == 0 ? (object) (WeaponsComp) null : (object) this);
      this.apply(weapon.shootStatus, weapon.shootStatusDuration);
    }

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0, [In] float obj1);

    [HideFromJava]
    public abstract bool isAdded();

    [LineNumberTable(new byte[] {160, 116, 141, 120, 115, 126, 235, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Bullet bullet([In] Weapon obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      float y = Mathf.range(obj0.xRand);
      return obj0.bullet.create((Entityc) this, this.team(), obj1 + Angles.trnsx(obj3, 0.0f, y), obj2 + Angles.trnsy(obj3, 0.0f, y), obj3, 1f - obj0.velocityRnd + Mathf.random(obj0.velocityRnd), obj4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 80, 223, 26, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00241(
      [In] Weapon obj0,
      [In] WeaponMount obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7)
    {
      Time.run((float) WeaponsComp.sequenceNum * obj0.shotDelay + obj0.firstShotDelay, (Runnable) new WeaponsComp.__\u003C\u003EAnon3(this, obj1, obj0, obj2, obj3, obj4, obj5, obj7, obj6));
      ++WeaponsComp.sequenceNum;
    }

    [Modifiers]
    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00242(
      [In] WeaponMount obj0,
      [In] Weapon obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      obj0.bullet = this.bullet(obj1, obj2, obj3, obj5 + Mathf.range(obj1.inaccuracy), obj4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 94, 137, 127, 6, 119, 108, 104, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00243(
      [In] float obj0,
      [In] BulletType obj1,
      [In] Weapon obj2,
      [In] float obj3,
      [In] float obj4,
      [In] WeaponMount obj5)
    {
      if (!this.isAdded())
        return;
      this.vel.add(Tmp.__\u003C\u003Ev1.trns(obj0 + 180f, obj1.recoil));
      Effect.shake(obj2.shake, obj2.shake, obj3, obj4);
      obj5.heat = 1f;
      if (obj2.continuous)
        return;
      obj2.shootSound.at(obj3, obj4, Mathf.random(obj2.soundPitchMin, obj2.soundPitchMax));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 81, 105, 127, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00240(
      [In] WeaponMount obj0,
      [In] Weapon obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7)
    {
      if (!this.isAdded())
        return;
      obj0.bullet = this.bullet(obj1, obj2 + this.x - obj3, obj4 + this.y - obj5, obj6 + Mathf.range(obj1.inaccuracy), obj7);
    }

    [LineNumberTable(new byte[] {159, 159, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal WeaponsComp()
    {
      WeaponsComp weaponsComp = this;
      this.mounts = new WeaponMount[0];
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float ammof() => this.ammo / (float) this.type.ammoCapacity;

    [LineNumberTable(new byte[] {159, 180, 116, 40, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setWeaponRotation([In] float obj0)
    {
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
        mounts[index].rotation = obj0;
    }

    [LineNumberTable(new byte[] {159, 186, 118, 108, 62, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setupWeapons([In] UnitType obj0)
    {
      this.mounts = new WeaponMount[obj0.weapons.size];
      for (int index = 0; index < this.mounts.Length; ++index)
        this.mounts[index] = new WeaponMount((Weapon) obj0.weapons.get(index));
    }

    [LineNumberTable(new byte[] {159, 130, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void controlWeapons([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      this.controlWeapons(num != 0, num != 0);
    }

    [LineNumberTable(new byte[] {14, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void aim([In] Position obj0) => this.aim(obj0.getX(), obj0.getY());

    [LineNumberTable(new byte[] {40, 116, 104, 125, 167, 104, 235, 57, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        if (weaponMount.bullet != null)
        {
          weaponMount.bullet.time = weaponMount.bullet.lifetime - 10f;
          weaponMount.bullet = (Bullet) null;
        }
        if (weaponMount.sound != null)
          weaponMount.sound.stop();
      }
    }

    [LineNumberTable(new byte[] {55, 135, 120, 105, 159, 9, 127, 9, 127, 12, 127, 12, 124, 124, 191, 46, 120, 127, 35, 141, 117, 112, 110, 127, 21, 127, 1, 127, 2, 251, 69, 159, 23, 105, 249, 69, 159, 74, 127, 13, 212, 127, 8, 127, 12, 159, 12, 127, 8, 127, 10, 107, 108, 220, 159, 18, 191, 23, 159, 32, 159, 22, 159, 13, 142, 115, 248, 159, 188, 233, 160, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      int num1 = this.canShoot() ? 1 : 0;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        Weapon weapon = weaponMount.__\u003C\u003Eweapon;
        weaponMount.reload = Math.max(weaponMount.reload - Time.delta * this.reloadMultiplier, 0.0f);
        float angle = this.rotation - 90f + (!weapon.rotate ? 0.0f : weaponMount.rotation);
        float num2 = this.x + Angles.trnsx(this.rotation - 90f, weapon.x, weapon.y);
        float num3 = this.y + Angles.trnsy(this.rotation - 90f, weapon.x, weapon.y);
        float x1 = num2 + Angles.trnsx(angle, weapon.shootX, weapon.shootY);
        float y1 = num3 + Angles.trnsy(angle, weapon.shootX, weapon.shootY);
        float num4 = !weapon.rotate ? Angles.angle(x1, y1, weaponMount.aimX, weaponMount.aimY) + (this.rotation - this.angleTo(weaponMount.aimX, weaponMount.aimY)) : angle + 90f;
        if (weapon.continuous && weaponMount.bullet != null)
        {
          if (!weaponMount.bullet.isAdded() || (double) weaponMount.bullet.time >= (double) weaponMount.bullet.lifetime || !object.ReferenceEquals((object) weaponMount.bullet.type, (object) weapon.bullet))
          {
            weaponMount.bullet = (Bullet) null;
          }
          else
          {
            weaponMount.bullet.rotation(angle + 90f);
            weaponMount.bullet.set(x1, y1);
            weaponMount.reload = weapon.reload;
            this.vel.add(Tmp.__\u003C\u003Ev1.trns(this.rotation + 180f, weaponMount.bullet.type.recoil));
            if (!object.ReferenceEquals((object) weapon.shootSound, (object) Sounds.none) && !Vars.headless)
            {
              if (weaponMount.sound == null)
                weaponMount.sound = new SoundLoop(weapon.shootSound, 1f);
              weaponMount.sound.update(this.x, this.y, true);
            }
          }
        }
        else
        {
          weaponMount.heat = Math.max(weaponMount.heat - Time.delta * this.reloadMultiplier / weaponMount.__\u003C\u003Eweapon.cooldownTime, 0.0f);
          if (weaponMount.sound != null)
            weaponMount.sound.update(this.x, this.y, false);
        }
        if (weapon.otherSide != -1 && weapon.alternate && (weaponMount.side == weapon.flipSprite && (double) (weaponMount.reload + Time.delta * this.reloadMultiplier) > (double) (weapon.reload / 2f)) && (double) weaponMount.reload <= (double) (weapon.reload / 2f))
        {
          this.mounts[weapon.otherSide].side = !this.mounts[weapon.otherSide].side;
          weaponMount.side = !weaponMount.side;
        }
        if (weapon.rotate && (weaponMount.rotate || weaponMount.shoot) && num1 != 0)
        {
          float x2 = this.x + Angles.trnsx(this.rotation - 90f, weapon.x, weapon.y);
          float y2 = this.y + Angles.trnsy(this.rotation - 90f, weapon.x, weapon.y);
          weaponMount.targetRotation = Angles.angle(x2, y2, weaponMount.aimX, weaponMount.aimY) - this.rotation;
          weaponMount.rotation = Angles.moveToward(weaponMount.rotation, weaponMount.targetRotation, weapon.rotateSpeed * Time.delta);
        }
        else if (!weapon.rotate)
        {
          weaponMount.rotation = 0.0f;
          weaponMount.targetRotation = this.angleTo(weaponMount.aimX, weaponMount.aimY);
        }
        if (weaponMount.shoot && num1 != 0 && ((double) this.ammo > 0.0 || !Vars.state.rules.unitAmmo || this.team().rules().infiniteAmmo) && ((!weapon.alternate || weaponMount.side == weapon.flipSprite) && ((double) this.vel.len() >= (double) weaponMount.__\u003C\u003Eweapon.minShootVelocity || Vars.net.active() && !this.isLocal())) && (double) weaponMount.reload <= 9.99999974737875E-05 && Angles.within(!weapon.rotate ? this.rotation : weaponMount.rotation, weaponMount.targetRotation, weaponMount.__\u003C\u003Eweapon.shootCone))
        {
          this.shoot(weaponMount, x1, y1, weaponMount.aimX, weaponMount.aimY, num2, num3, num4, Mathf.sign(weapon.x));
          weaponMount.reload = weapon.reload;
          --this.ammo;
          if ((double) this.ammo < 0.0)
            this.ammo = 0.0f;
        }
      }
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void write([In] Writes obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

    [HideFromJava]
    public abstract EntityCollisions.SolidPred solidity();

    [HideFromJava]
    public abstract bool canPass([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract bool canPassOn();

    [HideFromJava]
    public abstract bool moving();

    [HideFromJava]
    public abstract void move([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract Vec2 vel();

    [HideFromJava]
    public abstract float drag();

    [HideFromJava]
    public abstract void drag([In] float obj0);

    [HideFromJava]
    public abstract bool isValid();

    [HideFromJava]
    public abstract float healthf();

    [HideFromJava]
    public abstract void killed();

    [HideFromJava]
    public abstract void kill();

    [HideFromJava]
    public abstract void heal();

    [HideFromJava]
    public abstract bool damaged();

    [HideFromJava]
    public abstract void damagePierce([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damagePierce([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract void damageContinuousPierce([In] float obj0);

    [HideFromJava]
    public abstract void clampHealth();

    [HideFromJava]
    public abstract void heal([In] float obj0);

    [HideFromJava]
    public abstract void healFract([In] float obj0);

    [HideFromJava]
    public abstract float health();

    [HideFromJava]
    public abstract void health([In] float obj0);

    [HideFromJava]
    public abstract float hitTime();

    [HideFromJava]
    public abstract void hitTime([In] float obj0);

    [HideFromJava]
    public abstract float maxHealth();

    [HideFromJava]
    public abstract void maxHealth([In] float obj0);

    [HideFromJava]
    public abstract bool dead();

    [HideFromJava]
    public abstract void dead([In] bool obj0);

    [HideFromJava]
    public abstract float hitSize();

    [HideFromJava]
    public abstract void hitbox([In] Rect obj0);

    [HideFromJava]
    public abstract void getCollisions([In] Cons obj0);

    [HideFromJava]
    public abstract void updateLastPosition();

    [HideFromJava]
    public abstract void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2);

    [HideFromJava]
    public abstract float deltaLen();

    [HideFromJava]
    public abstract float deltaAngle();

    [HideFromJava]
    public abstract bool collides([In] Hitboxc obj0);

    [HideFromJava]
    public abstract void hitboxTile([In] Rect obj0);

    [HideFromJava]
    public abstract float lastX();

    [HideFromJava]
    public abstract void lastX([In] float obj0);

    [HideFromJava]
    public abstract float lastY();

    [HideFromJava]
    public abstract void lastY([In] float obj0);

    [HideFromJava]
    public abstract float deltaX();

    [HideFromJava]
    public abstract void deltaX([In] float obj0);

    [HideFromJava]
    public abstract float deltaY();

    [HideFromJava]
    public abstract void deltaY([In] float obj0);

    [HideFromJava]
    public abstract void hitSize([In] float obj0);

    [HideFromJava]
    public abstract bool checkTarget([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract bool isGrounded();

    [HideFromJava]
    public abstract bool isFlying();

    [HideFromJava]
    public abstract bool canDrown();

    [HideFromJava]
    public abstract void landed();

    [HideFromJava]
    public abstract void wobble();

    [HideFromJava]
    public abstract void moveAt([In] Vec2 obj0, [In] float obj1);

    [HideFromJava]
    public abstract float floorSpeedMultiplier();

    [HideFromJava]
    public abstract float elevation();

    [HideFromJava]
    public abstract void elevation([In] float obj0);

    [HideFromJava]
    public abstract bool hovering();

    [HideFromJava]
    public abstract void hovering([In] bool obj0);

    [HideFromJava]
    public abstract float drownTime();

    [HideFromJava]
    public abstract void drownTime([In] float obj0);

    [HideFromJava]
    public abstract float splashTimer();

    [HideFromJava]
    public abstract void splashTimer([In] float obj0);

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract void clearStatuses();

    [HideFromJava]
    public abstract void unapply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract bool isBoss();

    [HideFromJava]
    public abstract bool isImmune([In] StatusEffect obj0);

    [HideFromJava]
    public abstract Color statusColor();

    [HideFromJava]
    public abstract void draw();

    [HideFromJava]
    public abstract bool hasEffect([In] StatusEffect obj0);

    [HideFromJava]
    public abstract float speedMultiplier();

    [HideFromJava]
    public abstract float damageMultiplier();

    [HideFromJava]
    public abstract float healthMultiplier();

    [HideFromJava]
    public abstract float reloadMultiplier();

    [HideFromJava]
    public abstract float buildSpeedMultiplier();

    [HideFromJava]
    public abstract float dragMultiplier();

    [HideFromJava]
    public abstract bool disarmed();

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatc
    {
      private readonly WeaponsComp arg\u00241;
      private readonly Weapon arg\u00242;
      private readonly WeaponMount arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;
      private readonly float arg\u00248;

      internal __\u003C\u003EAnon0(
        [In] WeaponsComp obj0,
        [In] Weapon obj1,
        [In] WeaponMount obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024shoot\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly WeaponsComp arg\u00241;
      private readonly WeaponMount arg\u00242;
      private readonly Weapon arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;

      internal __\u003C\u003EAnon1(
        [In] WeaponsComp obj0,
        [In] WeaponMount obj1,
        [In] Weapon obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024shoot\u00242(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly WeaponsComp arg\u00241;
      private readonly float arg\u00242;
      private readonly BulletType arg\u00243;
      private readonly Weapon arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly WeaponMount arg\u00247;

      internal __\u003C\u003EAnon2(
        [In] WeaponsComp obj0,
        [In] float obj1,
        [In] BulletType obj2,
        [In] Weapon obj3,
        [In] float obj4,
        [In] float obj5,
        [In] WeaponMount obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void run() => this.arg\u00241.lambda\u0024shoot\u00243(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly WeaponsComp arg\u00241;
      private readonly WeaponMount arg\u00242;
      private readonly Weapon arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;
      private readonly float arg\u00248;
      private readonly float arg\u00249;

      internal __\u003C\u003EAnon3(
        [In] WeaponsComp obj0,
        [In] WeaponMount obj1,
        [In] Weapon obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7,
        [In] float obj8)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
        this.arg\u00249 = obj8;
      }

      public void run() => this.arg\u00241.lambda\u0024shoot\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, this.arg\u00249);
    }
  }
}
