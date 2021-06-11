// Decompiled with JetBrains decompiler
// Type: mindustry.type.UnitType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai.types;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.abilities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.units;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class UnitType : UnlockableContent
  {
    public const float shadowTX = -12f;
    public const float shadowTY = -13f;
    public const float outlineSpace = 0.01f;
    [Modifiers]
    private static Vec2 legOffset;
    public bool flying;
    [Signature("Larc/func/Prov<+Lmindustry/gen/Unit;>;")]
    public Prov constructor;
    [Signature("Larc/func/Prov<+Lmindustry/entities/units/UnitController;>;")]
    public Prov defaultController;
    public float speed;
    public float boostMultiplier;
    public float rotateSpeed;
    public float baseRotateSpeed;
    public float drag;
    public float accel;
    public float landShake;
    public float rippleScale;
    public float riseSpeed;
    public float fallSpeed;
    public float health;
    public float range;
    public float armor;
    public float maxRange;
    public float crashDamageMultiplier;
    public bool targetAir;
    public bool targetGround;
    public bool faceTarget;
    public bool rotateShooting;
    public bool isCounted;
    public bool lowAltitude;
    public bool circleTarget;
    public bool canBoost;
    public bool destructibleWreck;
    public float groundLayer;
    public float payloadCapacity;
    public float aimDst;
    public float buildBeamOffset;
    public int commandLimit;
    public float visualElevation;
    public bool allowLegStep;
    public bool hovering;
    public bool omniMovement;
    public Effect fallEffect;
    public Effect fallThrusterEffect;
    [Signature("Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;")]
    public Seq abilities;
    public BlockFlag targetFlag;
    public int legCount;
    public int legGroupSize;
    public float legLength;
    public float legSpeed;
    public float legTrns;
    public float legBaseOffset;
    public float legMoveSpace;
    public float legExtension;
    public float legPairOffset;
    public float legLengthScl;
    public float kinematicScl;
    public float maxStretch;
    public float legSplashDamage;
    public float legSplashRange;
    public bool flipBackLegs;
    public int ammoResupplyAmount;
    public float ammoResupplyRange;
    public float mechSideSway;
    public float mechFrontSway;
    public float mechStride;
    public float mechStepShake;
    public bool mechStepParticles;
    public Color mechLegColor;
    public int itemCapacity;
    public int ammoCapacity;
    public AmmoType ammoType;
    public int mineTier;
    public float buildSpeed;
    public float mineSpeed;
    public Sound mineSound;
    public float mineSoundVolume;
    public float dpsEstimate;
    public float clipSize;
    public bool canDrown;
    public float engineOffset;
    public float engineSize;
    public float strafePenalty;
    public float hitSize;
    public float itemOffsetY;
    public float lightRadius;
    public float lightOpacity;
    public Color lightColor;
    public bool drawCell;
    public bool drawItems;
    public bool drawShields;
    public int trailLength;
    public float trailX;
    public float trailY;
    public float trailScl;
    public bool canHeal;
    public bool singleTarget;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/StatusEffect;>;")]
    public ObjectSet immunities;
    public Sound deathSound;
    [Signature("Larc/struct/Seq<Lmindustry/type/Weapon;>;")]
    public Seq weapons;
    public TextureRegion baseRegion;
    public TextureRegion legRegion;
    public TextureRegion region;
    public TextureRegion shadowRegion;
    public TextureRegion cellRegion;
    public TextureRegion softShadowRegion;
    public TextureRegion jointRegion;
    public TextureRegion footRegion;
    public TextureRegion legBaseRegion;
    public TextureRegion baseJointRegion;
    public TextureRegion outlineRegion;
    public TextureRegion[] wreckRegions;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    protected internal ItemStack[] cachedRequirements;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {77, 113, 103, 103, 109, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit create(Team team)
    {
      Unit unit = (Unit) this.constructor.get();
      unit.team = team;
      unit.setType(this);
      unit.ammo = (float) this.ammoCapacity;
      unit.elevation = !this.flying ? 0.0f : 1f;
      unit.heal();
      return unit;
    }

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasWeapons() => this.weapons.size > 0;

    [LineNumberTable(new byte[] {87, 104, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit spawn(Team team, float x, float y)
    {
      Unit unit = this.create(team);
      unit.set(x, y);
      unit.add();
      return unit;
    }

    [LineNumberTable(new byte[] {161, 21, 104, 167, 162, 159, 1, 127, 36, 137, 127, 2, 100, 223, 3, 102, 105, 106, 63, 39, 200, 136, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ItemStack[] researchRequirements()
    {
      if (this.cachedRequirements != null)
        return this.cachedRequirements;
      ItemStack[] itemStackArray1 = (ItemStack[]) null;
      Block block = (Block) Vars.content.blocks().find((Boolf) new UnitType.__\u003C\u003EAnon11(this));
      if (block != null && block.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eitem))
      {
        Consume consume = block.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem);
        ConsumeItems consumeItems;
        if (consume is ConsumeItems && object.ReferenceEquals((object) (consumeItems = (ConsumeItems) consume), (object) (ConsumeItems) consume))
        {
          itemStackArray1 = consumeItems.__\u003C\u003Eitems;
          goto label_7;
        }
      }
      UnitFactory unitFactory = (UnitFactory) Vars.content.blocks().find((Boolf) new UnitType.__\u003C\u003EAnon12(this));
      if (unitFactory != null)
        itemStackArray1 = ((UnitFactory.UnitPlan) unitFactory.plans.find((Boolf) new UnitType.__\u003C\u003EAnon13(this))).requirements;
label_7:
      if (itemStackArray1 == null)
        return base.researchRequirements();
      ItemStack[] itemStackArray2 = new ItemStack[itemStackArray1.Length];
      for (int index1 = 0; index1 < itemStackArray2.Length; ++index1)
      {
        ItemStack[] itemStackArray3 = itemStackArray2;
        int index2 = index1;
        ItemStack.__\u003Cclinit\u003E();
        ItemStack itemStack = new ItemStack(itemStackArray1[index1].item, UI.roundAmount(ByteCodeHelper.d2i(Math.pow((double) itemStackArray1[index1].amount, 1.1) * 50.0)));
        itemStackArray3[index2] = itemStack;
      }
      this.cachedRequirements = itemStackArray2;
      return itemStackArray2;
    }

    [LineNumberTable(new byte[] {161, 144, 138, 127, 0, 159, 0, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawControl(Unit unit)
    {
      Draw.z(58f);
      Draw.color(Pal.accent, Color.__\u003C\u003Ewhite, Mathf.absin(4f, 0.3f));
      Lines.poly(unit.x, unit.y, 4, unit.hitSize + 1.5f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {161, 153, 106, 115, 127, 25, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawShadow(Unit unit)
    {
      Draw.color(Pal.shadow);
      float num = Math.max(unit.elevation, this.visualElevation);
      Draw.rect(this.shadowRegion, unit.x + -12f * num, unit.y + -13f * num, unit.rotation - 90f);
      Draw.color();
    }

    [LineNumberTable(new byte[] {162, 112, 135, 133, 135, 127, 6, 117, 138, 156, 105, 182, 127, 0, 159, 49, 109, 127, 8, 159, 54, 127, 6, 252, 59, 229, 61, 235, 75, 144, 105, 159, 2, 170, 154, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawMech(Mechc mech)
    {
      Unit unit = (Unit) mech;
      Draw.reset();
      float elevation = unit.elevation;
      float num1 = Mathf.lerp(Mathf.sin(mech.walkExtend(true), 0.6366197f, 1f), 0.0f, elevation);
      float num2 = Mathf.lerp(mech.walkExtend(false), 0.0f, elevation);
      float num3 = elevation * 2f;
      Floor floor = !unit.isFlying() ? unit.floorOn() : Blocks.air.asFloor();
      if (floor.isLiquid)
        Draw.color(Color.__\u003C\u003Ewhite, floor.mapColor, 0.5f);
      int[] signs = Mathf.__\u003C\u003Esigns;
      int length = signs.Length;
      for (int index = 0; index < length; ++index)
      {
        int num4 = signs[index];
        Draw.mixcol(Tmp.__\u003C\u003Ec1.set(this.mechLegColor).lerp(Color.__\u003C\u003Ewhite, Mathf.clamp(unit.hitTime)), Math.max(Math.max(0.0f, (float) num4 * num2 / this.mechStride), unit.hitTime));
        Draw.rect(this.legRegion, unit.x + Angles.trnsx(mech.baseRotation(), num2 * (float) num4 - num3, -num3 * (float) num4), unit.y + Angles.trnsy(mech.baseRotation(), num2 * (float) num4 - num3, -num3 * (float) num4), (float) (this.legRegion.width * num4) * Draw.scl, (float) this.legRegion.height * Draw.scl - Math.max(-num1 * (float) num4, 0.0f) * (float) this.legRegion.height * 0.5f * Draw.scl, mech.baseRotation() - 90f + 35f * (float) num4 * elevation);
      }
      Draw.mixcol(Color.__\u003C\u003Ewhite, unit.hitTime);
      if (floor.isLiquid)
        Draw.color(Color.__\u003C\u003Ewhite, floor.mapColor, unit.drownTime() * 0.4f);
      else
        Draw.color(Color.__\u003C\u003Ewhite);
      Draw.rect(this.baseRegion, (Position) unit, mech.baseRotation() - 90f);
      Draw.mixcol();
    }

    [Signature("<T:Lmindustry/gen/Unit;:Lmindustry/gen/Legsc;>(TT;)V")]
    [LineNumberTable(new byte[] {162, 56, 135, 140, 123, 141, 117, 62, 232, 69, 110, 127, 1, 102, 113, 116, 137, 154, 159, 15, 124, 104, 122, 106, 127, 41, 165, 159, 19, 125, 159, 19, 125, 159, 53, 109, 191, 4, 109, 250, 32, 235, 100, 109, 191, 0, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLegs(Unit unit)
    {
      this.applyColor(unit);
      Leg[] legArray1 = ((Legsc) unit).legs();
      float rad = (float) this.footRegion.width * Draw.scl * 1.5f;
      float num1 = ((Legsc) unit).baseRotation();
      Leg[] legArray2 = legArray1;
      int length = legArray2.Length;
      for (int index = 0; index < length; ++index)
      {
        Leg leg = legArray2[index];
        Drawf.shadow(leg.__\u003C\u003Ebase.x, leg.__\u003C\u003Ebase.y, rad);
      }
      for (int index = legArray1.Length - 1; index >= 0; index += -1)
      {
        int num2 = index;
        int num3 = 2;
        int i = (num3 != -1 ? num2 % num3 : 0) != 0 ? legArray1.Length - 1 - index / 2 : index / 2;
        Leg leg = legArray1[i];
        float angle = ((Legsc) unit).legAngle(num1, i);
        int num4 = Mathf.sign((double) i >= (double) ((float) legArray1.Length / 2f));
        Vec2 vec2 = UnitType.legOffset.trns(angle, this.legBaseOffset).add((Position) unit);
        Tmp.__\u003C\u003Ev1.set(leg.__\u003C\u003Ebase).sub(leg.__\u003C\u003Ejoint).inv().setLength(this.legExtension);
        if (leg.moving && (double) this.visualElevation > 0.0)
        {
          float visualElevation = this.visualElevation;
          float num5 = Mathf.slope(1f - leg.stage) * visualElevation;
          Draw.color(Pal.shadow);
          Draw.rect(this.footRegion, leg.__\u003C\u003Ebase.x + -12f * num5, leg.__\u003C\u003Ebase.y + -13f * num5, vec2.angleTo((Position) leg.__\u003C\u003Ebase));
          Draw.color();
        }
        Draw.rect(this.footRegion, leg.__\u003C\u003Ebase.x, leg.__\u003C\u003Ebase.y, vec2.angleTo((Position) leg.__\u003C\u003Ebase));
        Lines.stroke((float) this.legRegion.height * Draw.scl * (float) num4);
        Lines.line(this.legRegion, vec2.x, vec2.y, leg.__\u003C\u003Ejoint.x, leg.__\u003C\u003Ejoint.y, false);
        Lines.stroke((float) this.legBaseRegion.height * Draw.scl * (float) num4);
        Lines.line(this.legBaseRegion, leg.__\u003C\u003Ejoint.x + Tmp.__\u003C\u003Ev1.x, leg.__\u003C\u003Ejoint.y + Tmp.__\u003C\u003Ev1.y, leg.__\u003C\u003Ebase.x, leg.__\u003C\u003Ebase.y, false);
        if (this.jointRegion.found())
          Draw.rect(this.jointRegion, leg.__\u003C\u003Ejoint.x, leg.__\u003C\u003Ejoint.y);
        if (this.baseJointRegion.found())
          Draw.rect(this.baseJointRegion, vec2.x, vec2.y, num1);
      }
      if (this.baseRegion.found())
        Draw.rect(this.baseRegion, unit.x, unit.y, num1 - 90f);
      Draw.reset();
    }

    [Signature("<T:Lmindustry/gen/Unit;:Lmindustry/gen/Payloadc;>(TT;)V")]
    [LineNumberTable(new byte[] {161, 130, 109, 118, 120, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPayload(Unit unit)
    {
      if (!((Payloadc) unit).hasPayload())
        return;
      Payload payload = (Payload) ((Payloadc) unit).payloads().first();
      payload.set(unit.x, unit.y, unit.rotation);
      payload.draw();
    }

    [LineNumberTable(new byte[] {161, 160, 121, 102, 127, 5, 116, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSoftShadow(Unit unit)
    {
      Draw.color(0.0f, 0.0f, 0.0f, 0.4f);
      float num1 = 1.6f;
      float num2 = (float) Math.max(this.region.width, this.region.height) * Draw.scl;
      Draw.rect(this.softShadowRegion, (Position) unit, num2 * num1, num2 * num1);
      Draw.color();
    }

    [LineNumberTable(new byte[] {162, 22, 133, 114, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawOutline(Unit unit)
    {
      Draw.reset();
      if (!Core.atlas.isFound(this.outlineRegion))
        return;
      Draw.rect(this.outlineRegion, unit.x, unit.y, unit.rotation - 90f);
    }

    [LineNumberTable(new byte[] {161, 201, 137, 103, 159, 1, 104, 108, 191, 34, 112, 116, 124, 127, 6, 235, 61, 229, 69, 106, 123, 127, 4, 127, 6, 242, 61, 229, 69, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawEngine(Unit unit)
    {
      if (!unit.isFlying())
        return;
      float elevation = unit.elevation;
      float len = this.engineOffset / 2f + this.engineOffset / 2f * elevation;
      if (unit is Trailc)
        ((Trailc) unit).trail().draw(unit.team.__\u003C\u003Ecolor, (this.engineSize + Mathf.absin(Time.time, 2f, this.engineSize / 4f) * elevation) * this.trailScl);
      Draw.color(unit.team.__\u003C\u003Ecolor);
      Fill.circle(unit.x + Angles.trnsx(unit.rotation + 180f, len), unit.y + Angles.trnsy(unit.rotation + 180f, len), (this.engineSize + Mathf.absin(Time.time, 2f, this.engineSize / 4f)) * elevation);
      Draw.color(Color.__\u003C\u003Ewhite);
      Fill.circle(unit.x + Angles.trnsx(unit.rotation + 180f, len - 1f), unit.y + Angles.trnsy(unit.rotation + 180f, len - 1f), (this.engineSize + Mathf.absin(Time.time, 2f, this.engineSize / 4f)) / 2f * elevation);
      Draw.color();
    }

    [LineNumberTable(new byte[] {162, 30, 135, 159, 5, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBody(Unit unit)
    {
      this.applyColor(unit);
      Draw.rect(this.region, unit.x, unit.y, unit.rotation - 90f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {162, 38, 135, 108, 127, 5, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCell(Unit unit)
    {
      this.applyColor(unit);
      Draw.color(this.cellColor(unit));
      Draw.rect(this.cellRegion, unit.x, unit.y, unit.rotation - 90f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {161, 227, 135, 119, 136, 111, 124, 123, 127, 18, 159, 18, 110, 176, 113, 104, 151, 159, 7, 31, 0, 229, 70, 167, 159, 7, 31, 0, 229, 70, 127, 2, 114, 106, 159, 7, 31, 0, 229, 69, 101, 229, 23, 233, 109, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawWeapons(Unit unit)
    {
      this.applyColor(unit);
      WeaponMount[] mounts = unit.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        Weapon weapon = weaponMount.__\u003C\u003Eweapon;
        float angle = unit.rotation - 90f;
        float num = angle + (!weapon.rotate ? 0.0f : weaponMount.rotation);
        float y1 = -(weaponMount.reload / weapon.reload * weapon.recoil);
        float x = unit.x + Angles.trnsx(angle, weapon.x, weapon.y) + Angles.trnsx(num, 0.0f, y1);
        float y2 = unit.y + Angles.trnsy(angle, weapon.x, weapon.y) + Angles.trnsy(num, 0.0f, y1);
        if ((double) weapon.shadow > 0.0)
          Drawf.shadow(x, y2, weapon.shadow);
        if (weapon.outlineRegion.found())
        {
          float z = Draw.z();
          if (!weapon.top)
            Draw.z(z - 0.01f);
          Draw.rect(weapon.outlineRegion, x, y2, (float) weapon.outlineRegion.width * Draw.scl * (float) -Mathf.sign(weapon.flipSprite), (float) weapon.region.height * Draw.scl, num);
          Draw.z(z);
        }
        Draw.rect(weapon.region, x, y2, (float) weapon.region.width * Draw.scl * (float) -Mathf.sign(weapon.flipSprite), (float) weapon.region.height * Draw.scl, num);
        if (weapon.heatRegion.found() && (double) weaponMount.heat > 0.0)
        {
          Draw.color(weapon.heatColor, weaponMount.heat);
          Draw.blend(Blending.__\u003C\u003Eadditive);
          Draw.rect(weapon.heatRegion, x, y2, (float) weapon.heatRegion.width * Draw.scl * (float) -Mathf.sign(weapon.flipSprite), (float) weapon.heatRegion.height * Draw.scl, num);
          Draw.blend();
          Draw.color();
        }
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {161, 168, 167, 123, 159, 6, 127, 0, 127, 10, 127, 2, 16, 229, 69, 133, 111, 121, 127, 2, 124, 240, 61, 229, 69, 127, 0, 127, 35, 127, 2, 127, 7, 234, 61, 255, 11, 71, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawItems(Unit unit)
    {
      this.applyColor(unit);
      if (unit.item() == null || (double) unit.itemTime <= 0.00999999977648258)
        return;
      float num1 = (5f + Mathf.absin(Time.time, 5f, 1f)) * unit.itemTime;
      Draw.mixcol(Pal.accent, Mathf.absin(Time.time, 5f, 0.5f));
      Draw.rect(unit.item().icon(Cicon.__\u003C\u003Emedium), unit.x + Angles.trnsx(unit.rotation + 180f, this.itemOffsetY), unit.y + Angles.trnsy(unit.rotation + 180f, this.itemOffsetY), num1, num1, unit.rotation);
      Draw.mixcol();
      Lines.stroke(1f, Pal.accent);
      Lines.circle(unit.x + Angles.trnsx(unit.rotation + 180f, this.itemOffsetY), unit.y + Angles.trnsy(unit.rotation + 180f, this.itemOffsetY), (3f + Mathf.absin(Time.time, 5f, 1f)) * unit.itemTime);
      if (unit.isLocal() && !Vars.renderer.__\u003C\u003Epixelator.enabled())
      {
        Font outline = Fonts.outline;
        string str1 = new StringBuilder().append(unit.stack.amount).append("").toString();
        double num2 = (double) (unit.x + Angles.trnsx(unit.rotation + 180f, this.itemOffsetY));
        double num3 = (double) (unit.y + Angles.trnsy(unit.rotation + 180f, this.itemOffsetY) - 3f);
        Color accent = Pal.accent;
        double num4 = (double) (0.25f * unit.itemTime / Scl.scl(1f));
        int num5 = 1;
        bool flag = false;
        float num6 = (float) num4;
        Color color1 = accent;
        float num7 = (float) num3;
        float num8 = (float) num2;
        object obj = (object) str1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str2 = charSequence;
        double num9 = (double) num8;
        double num10 = (double) num7;
        Color color2 = color1;
        double num11 = (double) num6;
        int num12 = flag ? 1 : 0;
        int halign = num5;
        outline.draw(str2, (float) num9, (float) num10, color2, (float) num11, num12 != 0, halign);
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {162, 50, 109, 159, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLight(Unit unit)
    {
      if ((double) this.lightRadius <= 0.0)
        return;
      Drawf.light(unit.team, unit.x, unit.y, this.lightRadius, this.lightColor, this.lightOpacity);
    }

    [LineNumberTable(new byte[] {161, 138, 104, 111, 127, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawShield(Unit unit)
    {
      float num1 = unit.shieldAlpha();
      float num2 = unit.hitSize() * 1.3f;
      Fill.light(unit.x, unit.y, Lines.circleVertices(num2), num2, Tmp.__\u003C\u003Ec1.set(Pal.shieldIn), Tmp.__\u003C\u003Ec2.set(Pal.shield).lerp(Color.__\u003C\u003Ewhite, Mathf.clamp(unit.hitTime() / 2f)).a(Pal.shield.a * num1));
    }

    [LineNumberTable(new byte[] {162, 153, 101, 112, 122, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyColor(Unit unit)
    {
      Draw.color();
      Draw.mixcol(Color.__\u003C\u003Ewhite, unit.hitTime);
      if ((double) unit.drownTime <= 0.0 || !unit.floorOn().isDeep())
        return;
      Draw.mixcol(unit.floorOn().mapColor, unit.drownTime * 0.8f);
    }

    [LineNumberTable(672)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color cellColor(Unit unit) => Tmp.__\u003C\u003Ec1.set(Color.__\u003C\u003Eblack).lerp(unit.team.__\u003C\u003Ecolor, unit.healthf() + Mathf.absin(Time.time, Math.max(unit.healthf() * 5f, 1f), 1f - unit.healthf()));

    [Modifiers]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private UnitController lambda\u0024new\u00240() => !this.flying ? (UnitController) new GroundAI() : (UnitController) new FlyingAI();

    [Modifiers]
    [LineNumberTable(new byte[] {109, 103, 127, 12, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00241([In] Table obj0)
    {
      obj0.left();
      obj0.add((Element) new Image(this.icon(Cicon.__\u003C\u003Emedium))).size(32f).scaling(Scaling.__\u003C\u003Efit);
      obj0.labelWrap(this.localizedName).left().width(190f).padLeft(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {116, 159, 1, 127, 24, 135, 113, 127, 65, 167, 127, 1, 104, 130, 127, 6, 127, 8, 135, 112, 248, 69, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00245([In] Unit obj0, [In] Table obj1)
    {
      obj1.defaults().growX().height(20f).pad(4f);
      Table table1 = obj1;
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Color health = Pal.health;
      Unit unit1 = obj0;
      Objects.requireNonNull((object) unit1);
      Floatp fraction = (Floatp) new UnitType.__\u003C\u003EAnon16(unit1);
      mindustry.ui.Bar bar1 = new mindustry.ui.Bar("stat.health", health, fraction).blink(Color.__\u003C\u003Ewhite);
      table1.add((Element) bar1);
      obj1.row();
      if (Vars.state.rules.unitAmmo)
      {
        Table table2 = obj1;
        mindustry.ui.Bar.__\u003Cclinit\u003E();
        mindustry.ui.Bar bar2 = new mindustry.ui.Bar(new StringBuilder().append(this.ammoType.icon).append(" ").append(Core.bundle.get("stat.ammo")).toString(), this.ammoType.barColor, (Floatp) new UnitType.__\u003C\u003EAnon17(this, obj0));
        table2.add((Element) bar2);
        obj1.row();
      }
      Iterator iterator = obj0.abilities.iterator();
      while (iterator.hasNext())
        ((Ability) iterator.next()).displayBars(obj0, obj1);
      Unit unit2 = obj0;
      Payloadc payloadc;
      if (!(unit2 is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit2), (object) (Payloadc) unit2))
        return;
      Table table3 = obj1;
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      mindustry.ui.Bar bar3 = new mindustry.ui.Bar("stat.payloadcapacity", Pal.items, (Floatp) new UnitType.__\u003C\u003EAnon18(payloadc, obj0));
      table3.add((Element) bar3);
      obj1.row();
      float[] numArray = new float[1]{ -1f };
      obj1.table().update((Cons) new UnitType.__\u003C\u003EAnon19(numArray, payloadc)).growX().left().height(0.0f).pad(0.0f);
    }

    [Modifiers]
    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024display\u00246([In] Unit obj0)
    {
      object obj = (object) new StringBuilder().append("\uE87C ").append(ByteCodeHelper.d2l(obj0.flag)).append("").toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(252)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00247([In] Block obj0)
    {
      Block block = obj0;
      Floor floor;
      return block is Floor && object.ReferenceEquals((object) (floor = (Floor) block), (object) (Floor) block) && (floor.itemDrop != null && floor.itemDrop.hardness <= this.mineTier) && !floor.playerUnmineable;
    }

    [Modifiers]
    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00248([In] Weapon obj0) => !obj0.rotate;

    [Modifiers]
    [LineNumberTable(321)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00249([In] Weapon obj0) => (double) obj0.bullet.healPercent > 0.0;

    [Modifiers]
    [LineNumberTable(348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024init\u002410([In] Weapon obj0) => 60f / obj0.reload;

    [Modifiers]
    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024init\u002411([In] Weapon obj0) => obj0.bullet.estimateDPS() / obj0.reload * (float) obj0.shots * 60f;

    [Modifiers]
    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u002412([In] Weapon obj0) => obj0.bullet.killShooter;

    [Modifiers]
    [LineNumberTable(398)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024researchRequirements\u002414([In] Block obj0)
    {
      Block block = obj0;
      Reconstructor reconstructor;
      return block is Reconstructor && object.ReferenceEquals((object) (reconstructor = (Reconstructor) block), (object) (Reconstructor) block) && reconstructor.upgrades.contains((Boolf) new UnitType.__\u003C\u003EAnon15(this));
    }

    [Modifiers]
    [LineNumberTable(403)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024researchRequirements\u002416([In] Block obj0)
    {
      Block block = obj0;
      UnitFactory unitFactory;
      return block is UnitFactory && object.ReferenceEquals((object) (unitFactory = (UnitFactory) block), (object) (UnitFactory) block) && unitFactory.plans.contains((Boolf) new UnitType.__\u003C\u003EAnon14(this));
    }

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024researchRequirements\u002417([In] UnitFactory.UnitPlan obj0) => object.ReferenceEquals((object) obj0.unit, (object) this);

    [Modifiers]
    [LineNumberTable(403)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024researchRequirements\u002415([In] UnitFactory.UnitPlan obj0) => object.ReferenceEquals((object) obj0.unit, (object) this);

    [Modifiers]
    [LineNumberTable(398)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024researchRequirements\u002413([In] UnitType[] obj0) => object.ReferenceEquals((object) obj0[1], (object) this);

    [Modifiers]
    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024display\u00242([In] Unit obj0) => obj0.ammo / (float) this.ammoCapacity;

    [Modifiers]
    [LineNumberTable(181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024display\u00243([In] Payloadc obj0, [In] Unit obj1) => obj0.payloadUsed() / obj1.type().payloadCapacity;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 108, 113, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024display\u00244([In] float[] obj0, [In] Payloadc obj1, [In] Table obj2)
    {
      if ((double) obj0[0] == (double) obj1.payloadUsed())
        return;
      obj1.contentInfo(obj2, 16f, 270f);
      obj0[0] = obj1.payloadUsed();
    }

    [LineNumberTable(new byte[] {67, 233, 159, 183, 113, 127, 13, 127, 35, 127, 13, 107, 110, 127, 4, 103, 103, 107, 107, 107, 107, 103, 107, 103, 103, 103, 107, 107, 107, 139, 110, 127, 79, 118, 135, 104, 139, 118, 107, 107, 103, 139, 103, 103, 107, 103, 118, 107, 171, 107, 107, 103, 118, 107, 107, 107, 118, 107, 117, 103, 159, 2, 103, 135, 107, 139, 235, 74, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitType(string name)
      : base(name)
    {
      UnitType unitType = this;
      this.defaultController = (Prov) new UnitType.__\u003C\u003EAnon0(this);
      this.speed = 1.1f;
      this.boostMultiplier = 1f;
      this.rotateSpeed = 5f;
      this.baseRotateSpeed = 5f;
      this.drag = 0.3f;
      this.accel = 0.5f;
      this.landShake = 0.0f;
      this.rippleScale = 1f;
      this.riseSpeed = 0.08f;
      this.fallSpeed = 0.018f;
      this.health = 200f;
      this.range = -1f;
      this.armor = 0.0f;
      this.maxRange = -1f;
      this.crashDamageMultiplier = 1f;
      this.targetAir = true;
      this.targetGround = true;
      this.faceTarget = true;
      this.rotateShooting = true;
      this.isCounted = true;
      this.lowAltitude = false;
      this.circleTarget = false;
      this.canBoost = false;
      this.destructibleWreck = true;
      this.groundLayer = 60f;
      this.payloadCapacity = 8f;
      this.aimDst = -1f;
      this.buildBeamOffset = 3.8f;
      this.commandLimit = 8;
      this.visualElevation = -1f;
      this.allowLegStep = false;
      this.hovering = false;
      this.omniMovement = true;
      this.fallEffect = Fx.__\u003C\u003EfallSmoke;
      this.fallThrusterEffect = Fx.__\u003C\u003EfallSmoke;
      this.abilities = new Seq();
      this.targetFlag = BlockFlag.__\u003C\u003Egenerator;
      this.legCount = 4;
      this.legGroupSize = 2;
      this.legLength = 10f;
      this.legSpeed = 0.1f;
      this.legTrns = 1f;
      this.legBaseOffset = 0.0f;
      this.legMoveSpace = 1f;
      this.legExtension = 0.0f;
      this.legPairOffset = 0.0f;
      this.legLengthScl = 1f;
      this.kinematicScl = 1f;
      this.maxStretch = 1.75f;
      this.legSplashDamage = 0.0f;
      this.legSplashRange = 5f;
      this.flipBackLegs = true;
      this.ammoResupplyAmount = 10;
      this.ammoResupplyRange = 100f;
      this.mechSideSway = 0.54f;
      this.mechFrontSway = 0.1f;
      this.mechStride = -1f;
      this.mechStepShake = -1f;
      this.mechStepParticles = false;
      this.mechLegColor = Pal.darkMetal;
      this.itemCapacity = -1;
      this.ammoCapacity = -1;
      this.ammoType = AmmoTypes.copper;
      this.mineTier = -1;
      this.buildSpeed = -1f;
      this.mineSpeed = 1f;
      this.mineSound = Sounds.minebeam;
      this.mineSoundVolume = 0.6f;
      this.dpsEstimate = -1f;
      this.clipSize = -1f;
      this.canDrown = true;
      this.engineOffset = 5f;
      this.engineSize = 2.5f;
      this.strafePenalty = 0.5f;
      this.hitSize = 6f;
      this.itemOffsetY = 3f;
      this.lightRadius = 60f;
      this.lightOpacity = 0.6f;
      this.lightColor = Pal.powerLight;
      this.drawCell = true;
      this.drawItems = true;
      this.drawShields = true;
      this.trailLength = 3;
      this.trailX = 4f;
      this.trailY = -3f;
      this.trailScl = 1f;
      this.canHeal = false;
      this.singleTarget = false;
      this.immunities = new ObjectSet();
      this.deathSound = Sounds.bang;
      this.weapons = new Seq();
      this.constructor = EntityMapping.map(name);
    }

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UnitController createController() => (UnitController) this.defaultController.get();

    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit spawn(float x, float y) => this.spawn(Vars.state.rules.defaultTeam, x, y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(Unit unit)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void landed(Unit unit)
    {
    }

    [LineNumberTable(new byte[] {108, 209, 107, 135, 242, 91, 134, 112, 103, 127, 62, 103, 191, 12, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Unit unit, Table table)
    {
      table.table((Cons) new UnitType.__\u003C\u003EAnon1(this)).growX().left();
      table.row();
      table.table((Cons) new UnitType.__\u003C\u003EAnon2(this, unit)).growX();
      if (unit.controller() is LogicAI)
      {
        table.row();
        Table table1 = table;
        object obj = (object) new StringBuilder().append(Blocks.microProcessor.emoji()).append(" ").append(Core.bundle.get("units.processorcontrol")).toString();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text).growX().wrap().left();
        table.row();
        table.label((Prov) new UnitType.__\u003C\u003EAnon3(unit)).color(Color.__\u003C\u003ElightGray).growX().wrap().left();
      }
      table.row();
    }

    [Signature("(Larc/func/Cons<Lmindustry/ctype/UnlockableContent;>;)V")]
    [LineNumberTable(new byte[] {160, 93, 127, 8, 127, 0, 159, 5, 108, 135, 130, 133, 125, 45, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void getDependencies(Cons cons)
    {
      Iterator iterator1 = Vars.content.blocks().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Block block1 = (Block) iterator1.next();
        Block block2 = block1;
        Reconstructor reconstructor;
        if (block2 is Reconstructor && object.ReferenceEquals((object) (reconstructor = (Reconstructor) block2), (object) (Reconstructor) block2))
        {
          Iterator iterator2 = reconstructor.upgrades.iterator();
          while (true)
          {
            do
            {
              if (!iterator2.hasNext())
                goto label_1;
            }
            while (!object.ReferenceEquals((object) ((UnitType[]) iterator2.next())[1], (object) this));
            cons.get((object) block1);
          }
        }
      }
      ItemStack[] itemStackArray = this.researchRequirements();
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = itemStackArray[index];
        cons.get((object) itemStack.item);
      }
    }

    [LineNumberTable(new byte[] {160, 111, 145, 118, 118, 118, 119, 127, 9, 151, 109, 134, 127, 1, 110, 156, 162, 150, 104, 182, 105, 118, 159, 1, 109, 150, 104, 191, 3, 109, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      Unit unit = (Unit) this.constructor.get();
      this.stats.add(Stat.__\u003C\u003Ehealth, this.health);
      this.stats.add(Stat.__\u003C\u003Earmor, this.armor);
      this.stats.add(Stat.__\u003C\u003Espeed, this.speed);
      this.stats.add(Stat.__\u003C\u003EitemCapacity, (float) this.itemCapacity);
      this.stats.add(Stat.__\u003C\u003Erange, (float) ByteCodeHelper.f2i(this.maxRange / 8f), StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EcommandLimit, (float) this.commandLimit);
      if (this.abilities.any())
      {
        ObjectSet objectSet = new ObjectSet();
        Iterator iterator = this.abilities.iterator();
        while (iterator.hasNext())
        {
          Ability ability = (Ability) iterator.next();
          if (objectSet.add((object) ability.localized()))
            this.stats.add(Stat.__\u003C\u003Eabilities, ability.localized());
        }
      }
      this.stats.add(Stat.__\u003C\u003Eflying, this.flying);
      if (!this.flying)
        this.stats.add(Stat.__\u003C\u003EcanBoost, this.canBoost);
      if (this.mineTier >= 1)
      {
        this.stats.addPercent(Stat.__\u003C\u003EmineSpeed, this.mineSpeed);
        this.stats.add(Stat.__\u003C\u003EmineTier, (StatValue) new BlockFilterValue((Boolf) new UnitType.__\u003C\u003EAnon4(this)));
      }
      if ((double) this.buildSpeed > 0.0)
        this.stats.addPercent(Stat.__\u003C\u003EbuildSpeed, this.buildSpeed);
      if (unit is Payloadc)
        this.stats.add(Stat.__\u003C\u003EpayloadCapacity, this.payloadCapacity / 64f, StatUnit.__\u003C\u003EblocksSquared);
      if (!this.weapons.any())
        return;
      this.stats.add(Stat.__\u003C\u003Eweapons, (StatValue) new WeaponListValue(this, this.weapons));
    }

    [LineNumberTable(new byte[] {160, 155, 159, 29, 177, 104, 103, 103, 177, 151, 105, 223, 12, 112, 107, 127, 1, 127, 14, 127, 14, 165, 112, 107, 152, 127, 1, 127, 14, 162, 109, 182, 109, 191, 2, 109, 191, 26, 109, 127, 1, 179, 187, 103, 127, 8, 169, 108, 105, 116, 116, 116, 169, 116, 148, 112, 144, 101, 168, 105, 152, 135, 215, 109, 188, 151, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (this.constructor == null)
      {
        string str = new StringBuilder().append("no constructor set up for unit '").append(this.__\u003C\u003Ename).append("'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if ((Unit) this.constructor.get() is WaterMovec)
      {
        this.canDrown = false;
        this.omniMovement = false;
        this.immunities.add((object) StatusEffects.wet);
      }
      this.singleTarget = this.weapons.size <= 1;
      if (this.itemCapacity < 0)
        this.itemCapacity = Math.max(Mathf.round(ByteCodeHelper.d2i((double) this.hitSize * 4.3), 10), 10);
      if ((double) this.range < 0.0)
      {
        this.range = float.MaxValue;
        Iterator iterator = this.weapons.iterator();
        while (iterator.hasNext())
        {
          Weapon weapon = (Weapon) iterator.next();
          this.range = Math.min(this.range, weapon.bullet.range() + this.hitSize / 2f);
          this.maxRange = Math.max(this.maxRange, weapon.bullet.range() + this.hitSize / 2f);
        }
      }
      if ((double) this.maxRange < 0.0)
      {
        this.maxRange = 0.0f;
        this.maxRange = Math.max(this.maxRange, this.range);
        Iterator iterator = this.weapons.iterator();
        while (iterator.hasNext())
          this.maxRange = Math.max(this.maxRange, ((Weapon) iterator.next()).bullet.range() + this.hitSize / 2f);
      }
      if (this.weapons.isEmpty())
      {
        UnitType unitType = this;
        float num1 = 70f;
        double num2 = (double) num1;
        this.maxRange = num1;
        this.range = (float) num2;
      }
      if ((double) this.mechStride < 0.0)
        this.mechStride = 4f + (this.hitSize - 8f) / 2.1f;
      if ((double) this.aimDst < 0.0)
        this.aimDst = !this.weapons.contains((Boolf) new UnitType.__\u003C\u003EAnon5()) ? this.hitSize / 2f : this.hitSize * 2f;
      if ((double) this.mechStepShake < 0.0)
      {
        this.mechStepShake = (float) Mathf.round((this.hitSize - 11f) / 9f);
        this.mechStepParticles = (double) this.hitSize > 15.0;
      }
      this.canHeal = this.weapons.contains((Boolf) new UnitType.__\u003C\u003EAnon6());
      Seq seq = new Seq();
      Iterator iterator1 = this.weapons.iterator();
      while (iterator1.hasNext())
      {
        Weapon weapon1 = (Weapon) iterator1.next();
        seq.add((object) weapon1);
        if (weapon1.mirror)
        {
          Weapon weapon2 = weapon1.copy();
          weapon2.x *= -1f;
          weapon2.shootX *= -1f;
          weapon2.flipSprite = !weapon2.flipSprite;
          seq.add((object) weapon2);
          weapon1.reload *= 2f;
          weapon2.reload *= 2f;
          weapon1.otherSide = seq.size - 1;
          weapon2.otherSide = seq.size - 2;
        }
      }
      this.weapons = seq;
      if (this.ammoCapacity < 0)
        this.ammoCapacity = Math.max(1, ByteCodeHelper.f2i(this.weapons.sumf((Floatf) new UnitType.__\u003C\u003EAnon7()) * 30f));
      if ((double) this.dpsEstimate >= 0.0)
        return;
      this.dpsEstimate = this.weapons.sumf((Floatf) new UnitType.__\u003C\u003EAnon8());
      if (!this.weapons.contains((Boolf) new UnitType.__\u003C\u003EAnon9()))
        return;
      this.dpsEstimate /= 25f;
    }

    [LineNumberTable(new byte[] {161, 0, 117, 118, 127, 16, 127, 16, 127, 16, 127, 16, 127, 47, 127, 16, 127, 31, 117, 127, 16, 145, 108, 108, 63, 24, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      this.weapons.each((Cons) new UnitType.__\u003C\u003EAnon10());
      this.region = (TextureRegion) Core.atlas.find(this.__\u003C\u003Ename);
      this.legRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-leg").toString());
      this.jointRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-joint").toString());
      this.baseJointRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-joint-base").toString());
      this.footRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-foot").toString());
      this.legBaseRegion = Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-leg-base").toString(), new StringBuilder().append(this.__\u003C\u003Ename).append("-leg").toString());
      this.baseRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-base").toString());
      this.cellRegion = Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-cell").toString(), (TextureRegion) Core.atlas.find("power-cell"));
      this.softShadowRegion = (TextureRegion) Core.atlas.find("circle-shadow");
      this.outlineRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-outline").toString());
      this.shadowRegion = this.icon(Cicon.__\u003C\u003Efull);
      this.wreckRegions = new TextureRegion[3];
      for (int index = 0; index < this.wreckRegions.Length; ++index)
        this.wreckRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-wreck").append(index).toString());
    }

    [LineNumberTable(425)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eunit;

    [LineNumberTable(new byte[] {161, 61, 114, 159, 42, 119, 167, 117, 120, 167, 141, 102, 167, 191, 41, 159, 58, 186, 104, 177, 152, 104, 177, 135, 141, 135, 102, 116, 103, 111, 103, 111, 135, 117, 167, 99, 188, 110, 127, 1, 101, 103, 130, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Unit unit)
    {
      Mechc mech = !(unit is Mechc) ? (Mechc) null : (Mechc) unit;
      float z = (double) unit.elevation <= 0.5 ? this.groundLayer + Mathf.clamp(this.hitSize / 4000f, 0.0f, 0.01f) : (!this.lowAltitude ? 115f : 90f);
      if (unit.controller().isBeingControlled(Vars.player.unit()))
        this.drawControl(unit);
      if (unit.isFlying() || (double) this.visualElevation > 0.0)
      {
        Draw.z(Math.min(80f, z - 1f));
        this.drawShadow(unit);
      }
      Draw.z(z - 0.02f);
      if (mech != null)
      {
        this.drawMech(mech);
        UnitType.legOffset.trns(mech.baseRotation(), 0.0f, Mathf.lerp(Mathf.sin(mech.walkExtend(true), 0.6366197f, 1f) * this.mechSideSway, 0.0f, unit.elevation));
        UnitType.legOffset.add(Tmp.__\u003C\u003Ev1.trns(mech.baseRotation() + 90f, 0.0f, Mathf.lerp(Mathf.sin(mech.walkExtend(true), 0.3183099f, 1f) * this.mechFrontSway, 0.0f, unit.elevation)));
        unit.trns(UnitType.legOffset.x, UnitType.legOffset.y);
      }
      if (unit is Legsc)
        this.drawLegs(unit);
      Draw.z(Math.min(z - 0.01f, 99f));
      if (unit is Payloadc)
        this.drawPayload(unit);
      this.drawSoftShadow(unit);
      Draw.z(z - 0.01f);
      this.drawOutline(unit);
      Draw.z(z);
      if ((double) this.engineSize > 0.0)
        this.drawEngine(unit);
      this.drawBody(unit);
      if (this.drawCell)
        this.drawCell(unit);
      this.drawWeapons(unit);
      if (this.drawItems)
        this.drawItems(unit);
      this.drawLight(unit);
      if ((double) unit.shieldAlpha > 0.0 && this.drawShields)
        this.drawShield(unit);
      if (mech != null)
        unit.trns(-UnitType.legOffset.x, -UnitType.legOffset.y);
      if (unit.abilities.size <= 0)
        return;
      Iterator iterator = unit.abilities.iterator();
      while (iterator.hasNext())
      {
        Ability ability = (Ability) iterator.next();
        Draw.reset();
        ability.draw(unit);
      }
      Draw.reset();
    }

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static UnitType()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.type.UnitType"))
        return;
      UnitType.legOffset = new Vec2();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon0([In] UnitType obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon1([In] UnitType obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00241((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly UnitType arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon2([In] UnitType obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00245(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon3([In] Unit obj0) => this.arg\u00241 = obj0;

      public object get() => (object) UnitType.lambda\u0024display\u00246(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon4([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00247((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] object obj0) => (UnitType.lambda\u0024init\u00248((Weapon) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (UnitType.lambda\u0024init\u00249((Weapon) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public float get([In] object obj0) => UnitType.lambda\u0024init\u002410((Weapon) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public float get([In] object obj0) => UnitType.lambda\u0024init\u002411((Weapon) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolf
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get([In] object obj0) => (UnitType.lambda\u0024init\u002412((Weapon) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => ((Weapon) obj0).load();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon11([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024researchRequirements\u002414((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon12([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024researchRequirements\u002416((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon13([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024researchRequirements\u002417((UnitFactory.UnitPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon14([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024researchRequirements\u002415((UnitFactory.UnitPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon15([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024researchRequirements\u002413((UnitType[]) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Floatp
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon16([In] Unit obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.healthf();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Floatp
    {
      private readonly UnitType arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon17([In] UnitType obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024display\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Floatp
    {
      private readonly Payloadc arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon18([In] Payloadc obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => UnitType.lambda\u0024display\u00243(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly float[] arg\u00241;
      private readonly Payloadc arg\u00242;

      internal __\u003C\u003EAnon19([In] float[] obj0, [In] Payloadc obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => UnitType.lambda\u0024display\u00244(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }
  }
}
