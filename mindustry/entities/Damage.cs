// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Damage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Damage : Object
  {
    private static Tile furthest;
    private static Rect rect;
    private static Rect hitrect;
    private static Vec2 tr;
    private static Vec2 seg1;
    private static Vec2 seg2;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    private static Seq units;
    private static IntSet collidedBlocks;
    private static Building tmpBuilding;
    private static Unit tmpUnit;
    private static IntFloatMap damages;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 59, 163, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damage(
      Team team,
      float x,
      float y,
      float radius,
      float damage,
      bool complete)
    {
      int num = complete ? 1 : 0;
      Damage.damage(team, x, y, radius, damage, num != 0, true, true);
    }

    [LineNumberTable(new byte[] {26, 102, 109, 109, 109, 99, 230, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createIncend(float x, float y, float range, int amount)
    {
      for (int index = 0; index < amount; ++index)
      {
        float x1 = x + Mathf.range(range);
        float y1 = y + Mathf.range(range);
        Tile tile = Vars.world.tileWorld(x1, y1);
        if (tile != null)
          Fires.create(tile);
      }
    }

    [LineNumberTable(new byte[] {159, 64, 70, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damage(
      Team team,
      float x,
      float y,
      float radius,
      float damage,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      Damage.damage(team, x, y, radius, damage, false, num1 != 0, num2 != 0);
    }

    [LineNumberTable(new byte[] {159, 63, 102, 249, 72, 125, 99, 142, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void status(
      Team team,
      float x,
      float y,
      float radius,
      StatusEffect effect,
      float duration,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      Cons cons = (Cons) new Damage.__\u003C\u003EAnon12(team, x, y, radius, num1 != 0, num2 != 0, effect, duration);
      Damage.rect.setSize(radius * 2f).setCenter(x, y);
      if (team != null)
        Units.nearbyEnemies(team, Damage.rect, cons);
      else
        Units.nearby(Damage.rect, cons);
    }

    [LineNumberTable(new byte[] {159, 118, 162, 138, 159, 13, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float collideLaser(Bullet b, float length, bool large)
    {
      int num = large ? 1 : 0;
      float laserLength = Damage.findLaserLength(b, length);
      Damage.collideLine(b, b.team, b.type.hitEffect, b.x, b.y, b.rotation(), laserLength, num != 0);
      b.fdata = laserLength;
      return laserLength;
    }

    [LineNumberTable(new byte[] {159, 113, 99, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void collideLine(
      Bullet hitter,
      Team team,
      Effect effect,
      float x,
      float y,
      float angle,
      float length,
      bool large)
    {
      int num = large ? 1 : 0;
      Damage.collideLine(hitter, team, effect, x, y, angle, length, num != 0, true);
    }

    [LineNumberTable(new byte[] {37, 148, 134, 191, 49})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float findLaserLength(Bullet b, float length)
    {
      Tmp.__\u003C\u003Ev1.trns(b.rotation(), length);
      Damage.furthest = (Tile) null;
      return Vars.world.raycast(b.tileX(), b.tileY(), World.toTile(b.x + Tmp.__\u003C\u003Ev1.x), World.toTile(b.y + Tmp.__\u003C\u003Ev1.y), (Geometry.Raycaster) new Damage.__\u003C\u003EAnon3(b)) && Damage.furthest != null ? Math.max(6f, b.dst(Damage.furthest.worldx(), Damage.furthest.worldy())) : length;
    }

    [LineNumberTable(new byte[] {160, 100, 144, 134, 109, 255, 22, 74, 127, 9, 158, 113, 124, 183, 113, 124, 183, 134, 115, 115, 122, 154, 134, 255, 3, 81, 110, 127, 35, 134, 103, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Healthc linecast(
      Bullet hitter,
      float x,
      float y,
      float angle,
      float length)
    {
      Damage.tr.trns(angle, length);
      Damage.tmpBuilding = (Building) null;
      if (hitter.type.collidesGround)
        Vars.world.raycastEachWorld(x, y, x + Damage.tr.x, y + Damage.tr.y, (Geometry.Raycaster) new Damage.__\u003C\u003EAnon9(hitter));
      Damage.rect.setPosition(x, y).setSize(Damage.tr.x, Damage.tr.y);
      float num1 = Damage.tr.x + x;
      float num2 = Damage.tr.y + y;
      if ((double) Damage.rect.width < 0.0)
      {
        Damage.rect.x += Damage.rect.width;
        Damage.rect.width *= -1f;
      }
      if ((double) Damage.rect.height < 0.0)
      {
        Damage.rect.y += Damage.rect.height;
        Damage.rect.height *= -1f;
      }
      float num3 = 3f;
      Damage.rect.y -= num3;
      Damage.rect.x -= num3;
      Damage.rect.width += num3 * 2f;
      Damage.rect.height += num3 * 2f;
      Damage.tmpUnit = (Unit) null;
      Units.nearbyEnemies(hitter.team, Damage.rect, (Cons) new Damage.__\u003C\u003EAnon10(x, y, hitter, num3, num1, num2));
      if (Damage.tmpBuilding != null && Damage.tmpUnit != null)
      {
        if ((double) Mathf.dst2(x, y, Damage.tmpUnit.getX(), Damage.tmpUnit.getY()) <= (double) Mathf.dst2(x, y, Damage.tmpBuilding.getX(), Damage.tmpBuilding.getY()))
          return (Healthc) Damage.tmpUnit;
      }
      else if (Damage.tmpBuilding != null)
        return (Healthc) Damage.tmpBuilding;
      return (Healthc) Damage.tmpUnit;
    }

    [LineNumberTable(new byte[] {159, 111, 102, 143, 106, 145, 237, 83, 109, 112, 122, 255, 16, 77, 127, 10, 159, 1, 113, 124, 183, 113, 124, 183, 135, 116, 116, 123, 155, 248, 76, 139, 246, 70, 118, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void collideLine(
      Bullet hitter,
      Team team,
      Effect effect,
      float x,
      float y,
      float angle,
      float length,
      bool large,
      bool laser)
    {
      int num1 = laser ? 1 : 0;
      int num2 = large ? 1 : 0;
      if (num1 != 0)
        length = Damage.findLaserLength(hitter, length);
      Damage.collidedBlocks.clear();
      Damage.tr.trns(angle, length);
      Intc2 ntc2 = (Intc2) new Damage.__\u003C\u003EAnon4(hitter, team);
      if (hitter.type.collidesGround)
      {
        Damage.seg1.set(x, y);
        Damage.seg2.set(Damage.seg1).add(Damage.tr);
        Vars.world.raycastEachWorld(x, y, Damage.seg2.x, Damage.seg2.y, (Geometry.Raycaster) new Damage.__\u003C\u003EAnon5(ntc2, num2 != 0));
      }
      Damage.rect.setPosition(x, y).setSize(Damage.tr.x, Damage.tr.y);
      float num3 = Damage.tr.x + x;
      float num4 = Damage.tr.y + y;
      if ((double) Damage.rect.width < 0.0)
      {
        Damage.rect.x += Damage.rect.width;
        Damage.rect.width *= -1f;
      }
      if ((double) Damage.rect.height < 0.0)
      {
        Damage.rect.y += Damage.rect.height;
        Damage.rect.height *= -1f;
      }
      float num5 = 3f;
      Damage.rect.y -= num5;
      Damage.rect.x -= num5;
      Damage.rect.width += num5 * 2f;
      Damage.rect.height += num5 * 2f;
      Cons consumer = (Cons) new Damage.__\u003C\u003EAnon6(x, y, num3, num4, num5, hitter, effect);
      Damage.units.clear();
      Units.nearbyEnemies(team, Damage.rect, (Cons) new Damage.__\u003C\u003EAnon7(hitter));
      Damage.units.sort((Floatf) new Damage.__\u003C\u003EAnon8(hitter));
      Damage.units.each(consumer);
    }

    [LineNumberTable(new byte[] {159, 133, 166, 102, 127, 1, 122, 31, 11, 230, 69, 99, 127, 0, 60, 230, 69, 151, 102, 99, 31, 7, 230, 73, 105, 174, 105, 174, 125, 109, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dynamicExplosion(
      float x,
      float y,
      float flammability,
      float explosiveness,
      float power,
      float radius,
      bool damage,
      bool fire,
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Team ignoreTeam)
    {
      int num1 = damage ? 1 : 0;
      int num2 = fire ? 1 : 0;
      if (num1 != 0)
      {
        for (int index = 0; (double) index < (double) Mathf.clamp(power / 700f, 0.0f, 8f); ++index)
        {
          int num3 = 5 + Mathf.clamp(ByteCodeHelper.f2i(power / 500f), 1, 20);
          Time.run((float) index * 0.8f + Mathf.random(4f), (Runnable) new Damage.__\u003C\u003EAnon0(x, y, num3));
        }
        if (num2 != 0)
        {
          for (int index = 0; (double) index < (double) Mathf.clamp(flammability / 4f, 0.0f, 30f); ++index)
            Time.run((float) index / 2f, (Runnable) new Damage.__\u003C\u003EAnon1(x, y));
        }
        int num4 = Mathf.clamp(ByteCodeHelper.f2i(explosiveness / 4f), 0, 30);
        for (int index = 0; index < num4; ++index)
        {
          int num3 = index;
          Time.run((float) index * 2f, (Runnable) new Damage.__\u003C\u003EAnon2(ignoreTeam, x, y, radius, explosiveness, num3, num4));
        }
      }
      if ((double) explosiveness > 15.0)
        Fx.__\u003C\u003Eshockwave.at(x, y);
      if ((double) explosiveness > 30.0)
        Fx.__\u003C\u003EbigShockwave.at(x, y);
      float num5 = Math.min(explosiveness / 4f + 3f, 9f);
      Effect.shake(num5, num5, x, y);
      Fx.__\u003C\u003EdynamicExplosion.at(x, y, radius / 8f);
    }

    [LineNumberTable(new byte[] {159, 57, 73, 248, 79, 125, 99, 142, 171, 99, 99, 159, 3, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damage(
      Team team,
      float x,
      float y,
      float radius,
      float damage,
      bool complete,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      int num3 = complete ? 1 : 0;
      Cons cons = (Cons) new Damage.__\u003C\u003EAnon13(team, x, y, radius, num1 != 0, num2 != 0, damage, num3 != 0);
      Damage.rect.setSize(radius * 2f).setCenter(x, y);
      if (team != null)
        Units.nearbyEnemies(team, Damage.rect, cons);
      else
        Units.nearby(Damage.rect, cons);
      if (num2 == 0)
        return;
      if (num3 == 0)
        Damage.tileDamage(team, World.toTile(x), World.toTile(y), radius / 8f, damage);
      else
        Damage.completeDamage(team, x, y, radius, damage);
    }

    [LineNumberTable(new byte[] {161, 3, 252, 160, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileDamage(Team team, int x, int y, float baseRadius, float damage) => Core.app.post((Runnable) new Damage.__\u003C\u003EAnon14(x, y, team, damage, baseRadius));

    [LineNumberTable(new byte[] {161, 75, 111, 106, 106, 127, 12, 127, 11, 238, 61, 41, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void completeDamage([In] Team obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      int num = ByteCodeHelper.f2i(obj3 / 8f);
      for (int index1 = -num; index1 <= num; ++index1)
      {
        for (int index2 = -num; index2 <= num; ++index2)
        {
          Tile tile = Vars.world.tile(Math.round(obj1 / 8f) + index1, Math.round(obj2 / 8f) + index2);
          if (tile != null && tile.build != null && (obj0 == null || obj0.isEnemy(tile.team())) && (double) Mathf.dst((float) index1, (float) index2) <= (double) num)
            tile.build.damage(obj4);
        }
      }
    }

    [LineNumberTable(new byte[] {161, 87, 111, 102, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float calculateDamage(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      float num1 = Mathf.dst(obj0, obj1, obj2, obj3);
      float progress = 0.4f;
      float num2 = Mathf.lerp(1f - num1 / obj4, 1f, progress);
      return obj5 * num2;
    }

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024dynamicExplosion\u00240([In] float obj0, [In] float obj1, [In] int obj2) => Lightning.create(Team.__\u003C\u003Ederelict, Pal.power, 3f, obj0, obj1, Mathf.random(360f), obj2 + Mathf.range(2));

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024dynamicExplosion\u00241([In] float obj0, [In] float obj1) => Call.createBullet(Bullets.fireball, Team.__\u003C\u003Ederelict, obj0, obj1, Mathf.random(360f), Bullets.fireball.damage, 1f, 1f);

    [Modifiers]
    [LineNumberTable(new byte[] {6, 127, 30, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024dynamicExplosion\u00242(
      [In] Team obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] int obj5,
      [In] int obj6)
    {
      Damage.damage(obj0, obj1, obj2, Mathf.clamp(obj3 + obj4, 0.0f, 50f) * (((float) obj5 + 1f) / (float) obj6), obj4 / 2f, false);
      Fx.__\u003C\u003EblockExplosionSmoke.at(obj1 + Mathf.range(obj3), obj2 + Mathf.range(obj3));
    }

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024findLaserLength\u00243([In] Bullet obj0, [In] int obj1, [In] int obj2) => (Damage.furthest = Vars.world.tile(obj1, obj2)) != null && !object.ReferenceEquals((object) Damage.furthest.team(), (object) obj0.team) && Damage.furthest.block().absorbLasers;

    [Modifiers]
    [LineNumberTable(new byte[] {81, 109, 154, 112, 145, 122, 104, 216, 114, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024collideLine\u00244([In] Bullet obj0, [In] Team obj1, [In] int obj2, [In] int obj3)
    {
      Building building = Vars.world.build(obj2, obj3);
      int num = building == null || !Damage.collidedBlocks.add(building.pos()) ? 0 : 1;
      if ((double) obj0.damage <= 0.0)
        return;
      float initialHealth = num != 0 ? building.health : 0.0f;
      if (num != 0 && !object.ReferenceEquals((object) building.team, (object) obj1) && building.collide(obj0))
      {
        building.collision(obj0);
        obj0.type.hit(obj0, building.x, building.y);
      }
      if (num == 0 || !obj0.type.testCollision(obj0, building))
        return;
      obj0.type.hitTile(obj0, building, initialHealth, false);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 104, 98, 136, 119, 126, 127, 5, 248, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024collideLine\u00245([In] Intc2 obj0, [In] bool obj1, [In] int obj2, [In] int obj3)
    {
      int num = obj1 ? 1 : 0;
      obj0.get(obj2, obj3);
      Point2[] d4 = Geometry.__\u003C\u003Ed4;
      int length = d4.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = d4[index];
        Tile tile = Vars.world.tile(point2.x + obj2, point2.y + obj3);
        if (tile != null && (num != 0 || Intersector.intersectSegmentRectangle(Damage.seg1, Damage.seg2, tile.getBounds(Tmp.__\u003C\u003Er1))))
          obj0.get(obj2 + point2.x, obj3 + point2.y);
      }
      return false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 140, 159, 3, 113, 115, 117, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024collideLine\u00246(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] Bullet obj5,
      [In] Effect obj6,
      [In] Unit obj7)
    {
      obj7.hitbox(Damage.hitrect);
      Vec2 vec2 = Geometry.raycastRect(obj0, obj1, obj2, obj3, Damage.hitrect.grow(obj4 * 2f));
      if (vec2 == null || (double) obj5.damage <= 0.0)
        return;
      obj6.at(vec2.x, vec2.y);
      obj7.collision((Hitboxc) obj5, vec2.x, vec2.y);
      obj5.collision((Hitboxc) obj7, vec2.x, vec2.y);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 86, 126, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024collideLine\u00247([In] Bullet obj0, [In] Unit obj1)
    {
      if (!obj1.checkTarget(obj0.type.collidesAir, obj0.type.collidesGround))
        return;
      Damage.units.add((object) obj1);
    }

    [Modifiers]
    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024collideLine\u00248([In] Bullet obj0, [In] Unit obj1) => obj1.dst2((Position) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 106, 109, 118, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024linecast\u00249([In] Bullet obj0, [In] int obj1, [In] int obj2)
    {
      Building building = Vars.world.build(obj1, obj2);
      if (building == null || object.ReferenceEquals((object) building.team, (object) obj0.team))
        return false;
      Damage.tmpBuilding = building;
      return true;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 138, 159, 37, 108, 102, 112, 112, 119, 151, 145, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024linecast\u002410(
      [In] float obj0,
      [In] float obj1,
      [In] Bullet obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] Unit obj6)
    {
      if (Damage.tmpUnit != null && (double) obj6.dst2(obj0, obj1) > (double) Damage.tmpUnit.dst2(obj0, obj1) || !obj6.checkTarget(obj2.type.collidesAir, obj2.type.collidesGround))
        return;
      obj6.hitbox(Damage.hitrect);
      Rect hitrect = Damage.hitrect;
      hitrect.y -= obj3;
      hitrect.x -= obj3;
      hitrect.width += obj3 * 2f;
      hitrect.height += obj3 * 2f;
      if (Geometry.raycastRect(obj0, obj1, obj4, obj5, hitrect) == null)
        return;
      Damage.tmpUnit = obj6;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 168, 138, 107, 113, 129, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024damageUnits\u002411(
      [In] Boolf obj0,
      [In] float obj1,
      [In] Cons obj2,
      [In] Unit obj3)
    {
      if (!obj0.get((object) obj3))
        return;
      obj3.hitbox(Damage.hitrect);
      if (!Damage.hitrect.overlaps(Damage.rect))
        return;
      obj3.damage(obj1);
      obj2.get((object) obj3);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 63, 134, 127, 23, 161, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024status\u002412(
      [In] Team obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] bool obj4,
      [In] bool obj5,
      [In] StatusEffect obj6,
      [In] float obj7,
      [In] Unit obj8)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = obj5 ? 1 : 0;
      if (object.ReferenceEquals((object) obj8.team, (object) obj0) || !obj8.within(obj1, obj2, obj3) || obj8.isFlying() && num1 == 0 || obj8.isGrounded() && num2 == 0)
        return;
      obj8.apply(obj6, obj7);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 57, 105, 127, 23, 129, 127, 1, 136, 127, 11, 159, 22, 118, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024damage\u002413(
      [In] Team obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] bool obj4,
      [In] bool obj5,
      [In] float obj6,
      [In] bool obj7,
      [In] Unit obj8)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = obj5 ? 1 : 0;
      int num3 = obj7 ? 1 : 0;
      if (object.ReferenceEquals((object) obj8.team, (object) obj0) || !obj8.within(obj1, obj2, obj3) || obj8.isFlying() && num1 == 0 || obj8.isGrounded() && num2 == 0)
        return;
      float damage = Damage.calculateDamage(obj1, obj2, obj8.getX(), obj8.getY(), obj3, obj6);
      obj8.damage(damage);
      float num4 = Damage.tr.set(obj8.getX() - obj1, obj8.getY() - obj2).len();
      obj8.vel.add(Damage.tr.setLength((1f - num4 / obj3) * 2f / obj8.mass()));
      if (num3 == 0 || (double) obj6 < 9999999.0 || !obj8.isPlayer())
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EexclusionDeath);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 5, 205, 159, 10, 159, 7, 193, 116, 117, 112, 170, 107, 103, 99, 99, 159, 21, 108, 109, 108, 108, 135, 111, 112, 153, 103, 127, 12, 140, 107, 159, 2, 141, 109, 194, 112, 103, 137, 103, 135, 229, 27, 235, 105, 127, 4, 124, 112, 100, 142, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tileDamage\u002414(
      [In] int obj0,
      [In] int obj1,
      [In] Team obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Building building1 = Vars.world.build(obj0, obj1);
      if (building1 != null && !object.ReferenceEquals((object) building1.team, (object) obj2) && (building1.block.size > 1 && (double) building1.health > (double) obj3))
      {
        building1.damage(obj3 * Math.min((float) building1.block.size, obj4 * 0.45f));
      }
      else
      {
        float num1 = Math.min(obj4, 30f);
        float num2 = num1 * num1;
        int num3 = Mathf.ceil(num1 * 2f * 3.141593f);
        double num4 = 2.0 * Math.PI / (double) num3;
        Damage.damages.clear();
        for (int index = 0; index <= num3; ++index)
        {
          float num5 = 0.0f;
          int x = obj0;
          int y = obj1;
          int num6 = obj0 + ByteCodeHelper.d2i(Math.cos(num4 * (double) index) * (double) num1);
          int num7 = obj1 + ByteCodeHelper.d2i(Math.sin(num4 * (double) index) * (double) num1);
          int num8 = Math.abs(num6 - x);
          int num9 = -Math.abs(num7 - y);
          int num10 = x >= num6 ? -1 : 1;
          int num11 = y >= num7 ? -1 : 1;
          int num12 = num8 + num9;
          while (x != num6 || y != num7)
          {
            Building building2 = Vars.world.build(x, y);
            if (building2 != null && !object.ReferenceEquals((object) building2.team, (object) obj2))
            {
              float num13 = 0.6f;
              float num14 = (1f - Mathf.dst2((float) x, (float) y, (float) obj0, (float) obj1) / num2 + num13) / (1f + num13);
              float num15 = obj3 * num14 - num5;
              int key = Point2.pack(x, y);
              Damage.damages.put(key, Math.max(Damage.damages.get(key), num15));
              num5 += building2.health;
              if ((double) (num15 - num5) <= 0.0)
                break;
            }
            if (2 * num12 - num9 > num8 - 2 * num12)
            {
              num12 += num9;
              x += num10;
            }
            else
            {
              num12 += num8;
              y += num11;
            }
          }
        }
        Iterator iterator = Damage.damages.iterator();
        while (iterator.hasNext())
        {
          IntFloatMap.Entry entry = (IntFloatMap.Entry) iterator.next();
          int x = (int) Point2.x(entry.key);
          int y = (int) Point2.y(entry.key);
          Vars.world.build(x, y)?.damage(entry.value);
        }
      }
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Damage()
    {
    }

    [LineNumberTable(new byte[] {159, 134, 131, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dynamicExplosion(
      float x,
      float y,
      float flammability,
      float explosiveness,
      float power,
      float radius,
      bool damage)
    {
      int num = damage ? 1 : 0;
      Damage.dynamicExplosion(x, y, flammability, explosiveness, power, radius, num != 0, true, (Team) null);
    }

    [LineNumberTable(new byte[] {59, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void collideLine(
      Bullet hitter,
      Team team,
      Effect effect,
      float x,
      float y,
      float angle,
      float length)
    {
      Damage.collideLine(hitter, team, effect, x, y, angle, length, false);
    }

    [Signature("(Lmindustry/game/Team;FFFFLarc/func/Boolf<Lmindustry/gen/Unit;>;Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 167, 242, 75, 125, 99, 142, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damageUnits(
      Team team,
      float x,
      float y,
      float size,
      float damage,
      Boolf predicate,
      Cons acceptor)
    {
      Cons cons = (Cons) new Damage.__\u003C\u003EAnon11(predicate, damage, acceptor);
      Damage.rect.setSize(size * 2f).setCenter(x, y);
      if (team != null)
        Units.nearbyEnemies(team, Damage.rect, cons);
      else
        Units.nearby(Damage.rect, cons);
    }

    [LineNumberTable(new byte[] {160, 188, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damage(float x, float y, float radius, float damage) => Damage.damage((Team) null, x, y, radius, damage, false);

    [LineNumberTable(new byte[] {160, 193, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void damage(Team team, float x, float y, float radius, float damage) => Damage.damage(team, x, y, radius, damage, false);

    [LineNumberTable(new byte[] {159, 137, 173, 106, 106, 126, 106, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Damage()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Damage"))
        return;
      Damage.rect = new Rect();
      Damage.hitrect = new Rect();
      Damage.tr = new Vec2();
      Damage.seg1 = new Vec2();
      Damage.seg2 = new Vec2();
      Damage.units = new Seq();
      Damage.collidedBlocks = new IntSet();
      Damage.damages = new IntFloatMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon0([In] float obj0, [In] float obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Damage.lambda\u0024dynamicExplosion\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon1([In] float obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Damage.lambda\u0024dynamicExplosion\u00241(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Team arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly int arg\u00246;
      private readonly int arg\u00247;

      internal __\u003C\u003EAnon2(
        [In] Team obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] int obj5,
        [In] int obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void run() => Damage.lambda\u0024dynamicExplosion\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Geometry.Raycaster
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon3([In] Bullet obj0) => this.arg\u00241 = obj0;

      public bool accept([In] int obj0, [In] int obj1) => (Damage.lambda\u0024findLaserLength\u00243(this.arg\u00241, obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Intc2
    {
      private readonly Bullet arg\u00241;
      private readonly Team arg\u00242;

      internal __\u003C\u003EAnon4([In] Bullet obj0, [In] Team obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => Damage.lambda\u0024collideLine\u00244(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Geometry.Raycaster
    {
      private readonly Intc2 arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon5([In] Intc2 obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool accept([In] int obj0, [In] int obj1) => (Damage.lambda\u0024collideLine\u00245(this.arg\u00241, this.arg\u00242, obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly Bullet arg\u00246;
      private readonly Effect arg\u00247;

      internal __\u003C\u003EAnon6(
        [In] float obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] Bullet obj5,
        [In] Effect obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void get([In] object obj0) => Damage.lambda\u0024collideLine\u00246(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon7([In] Bullet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Damage.lambda\u0024collideLine\u00247(this.arg\u00241, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatf
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon8([In] Bullet obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => Damage.lambda\u0024collideLine\u00248(this.arg\u00241, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Geometry.Raycaster
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon9([In] Bullet obj0) => this.arg\u00241 = obj0;

      public bool accept([In] int obj0, [In] int obj1) => (Damage.lambda\u0024linecast\u00249(this.arg\u00241, obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly Bullet arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;

      internal __\u003C\u003EAnon10(
        [In] float obj0,
        [In] float obj1,
        [In] Bullet obj2,
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

      public void get([In] object obj0) => Damage.lambda\u0024linecast\u002410(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly float arg\u00242;
      private readonly Cons arg\u00243;

      internal __\u003C\u003EAnon11([In] Boolf obj0, [In] float obj1, [In] Cons obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Damage.lambda\u0024damageUnits\u002411(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly Team arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly bool arg\u00245;
      private readonly bool arg\u00246;
      private readonly StatusEffect arg\u00247;
      private readonly float arg\u00248;

      internal __\u003C\u003EAnon12(
        [In] Team obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] bool obj4,
        [In] bool obj5,
        [In] StatusEffect obj6,
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

      public void get([In] object obj0) => Damage.lambda\u0024status\u002412(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly Team arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly bool arg\u00245;
      private readonly bool arg\u00246;
      private readonly float arg\u00247;
      private readonly bool arg\u00248;

      internal __\u003C\u003EAnon13(
        [In] Team obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] bool obj4,
        [In] bool obj5,
        [In] float obj6,
        [In] bool obj7)
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

      public void get([In] object obj0) => Damage.lambda\u0024damage\u002413(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly Team arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;

      internal __\u003C\u003EAnon14([In] int obj0, [In] int obj1, [In] Team obj2, [In] float obj3, [In] float obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => Damage.lambda\u0024tileDamage\u002414(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }
  }
}
