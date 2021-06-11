// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Lightning
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities.bullet;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Lightning : Object
  {
    [Modifiers]
    private static Rand random;
    [Modifiers]
    private static Rect rect;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unitc;>;")]
    private static Seq entities;
    [Modifiers]
    private static IntSet hit;
    private const int maxChain = 8;
    private const float hitRange = 30f;
    private static bool bhit;
    private static int lastSeed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void create(
      Bullet bullet,
      Color color,
      float damage,
      float x,
      float y,
      float targetAngle,
      int length)
    {
      Lightning.createLightningInternal(bullet, Lightning.lastSeed++, bullet.team, color, damage, x, y, targetAngle, length);
    }

    [LineNumberTable(new byte[] {159, 171, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void create(
      Team team,
      Color color,
      float damage,
      float x,
      float y,
      float targetAngle,
      int length)
    {
      Lightning.createLightningInternal((Bullet) null, Lightning.lastSeed++, team, color, damage, x, y, targetAngle, length);
    }

    [LineNumberTable(new byte[] {159, 180, 108, 138, 127, 4, 102, 134, 108, 127, 3, 159, 17, 108, 102, 116, 117, 255, 41, 75, 172, 123, 107, 109, 246, 71, 151, 100, 114, 106, 140, 119, 117, 245, 23, 233, 109, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void createLightningInternal(
      [Nullable(new object[] {64, "Larc/util/Nullable;"})] Bullet _param0,
      int _param1,
      Team _param2,
      Color _param3,
      float _param4,
      float _param5,
      float _param6,
      float _param7,
      int _param8)
    {
      Lightning.random.setSeed((long) _param1);
      Lightning.hit.clear();
      BulletType bulletType = _param0 == null || _param0.type.lightningType == null ? Bullets.damageLightning : _param0.type.lightningType;
      Seq seq1 = new Seq();
      Lightning.bhit = false;
      for (int index = 0; index < _param8 / 2; ++index)
      {
        bulletType.create((Entityc) null, _param2, _param5, _param6, 0.0f, _param4, 1f, 1f, (object) _param0);
        Seq seq2 = seq1;
        Vec2.__\u003Cclinit\u003E();
        Vec2 vec2_1 = new Vec2(_param5 + Mathf.range(3f), _param6 + Mathf.range(3f));
        seq2.add((object) vec2_1);
        if (seq1.size > 1)
        {
          Lightning.bhit = false;
          Vec2 vec2_2 = (Vec2) seq1.get(seq1.size - 2);
          Vec2 vec2_3 = (Vec2) seq1.get(seq1.size - 1);
          Vars.world.raycastEach(World.toTile(vec2_2.getX()), World.toTile(vec2_2.getY()), World.toTile(vec2_3.getX()), World.toTile(vec2_3.getY()), (Geometry.Raycaster) new Lightning.__\u003C\u003EAnon0(_param2, seq1));
          if (Lightning.bhit)
            break;
        }
        Lightning.rect.setSize(30f).setCenter(_param5, _param6);
        Lightning.entities.clear();
        if (Lightning.hit.size < 8)
          Units.nearbyEnemies(_param2, Lightning.rect, (Cons) new Lightning.__\u003C\u003EAnon1(_param0));
        Unitc furthest = (Unitc) Geometry.findFurthest(_param5, _param6, (Iterable) Lightning.entities);
        if (furthest != null)
        {
          Lightning.hit.add(furthest.id());
          _param5 = furthest.x();
          _param6 = furthest.y();
        }
        else
        {
          _param7 += Lightning.random.range(20f);
          _param5 += Angles.trnsx(_param7, 15f);
          _param6 += Angles.trnsy(_param7, 15f);
        }
      }
      Fx.__\u003C\u003Elightning.at(_param5, _param6, _param7, _param3, (object) seq1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {5, 109, 126, 134, 127, 2, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024createLightningInternal\u00240(
      [In] Team obj0,
      [In] Seq obj1,
      [In] int obj2,
      [In] int obj3)
    {
      Tile tile = Vars.world.tile(obj2, obj3);
      if (tile == null || !tile.block().insulated || object.ReferenceEquals((object) tile.team(), (object) obj0))
        return false;
      Lightning.bhit = true;
      ((Vec2) obj1.get(obj1.size - 1)).set((float) (obj2 * 8), (float) (obj3 * 8));
      return true;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {21, 127, 20, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024createLightningInternal\u00241([In] Bullet obj0, [In] Unit obj1)
    {
      if (Lightning.hit.contains(obj1.id()) || obj0 != null && !obj1.checkTarget(obj0.type.collidesAir, obj0.type.collidesGround))
        return;
      Lightning.entities.add((object) obj1);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Lightning()
    {
    }

    [LineNumberTable(new byte[] {159, 138, 141, 106, 106, 106, 170, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Lightning()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Lightning"))
        return;
      Lightning.random = new Rand();
      Lightning.rect = new Rect();
      Lightning.entities = new Seq();
      Lightning.hit = new IntSet();
      Lightning.bhit = false;
      Lightning.lastSeed = 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Geometry.Raycaster
    {
      private readonly Team arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon0([In] Team obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool accept([In] int obj0, [In] int obj1) => (Lightning.lambda\u0024createLightningInternal\u00240(this.arg\u00241, this.arg\u00242, obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon1([In] Bullet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Lightning.lambda\u0024createLightningInternal\u00241(this.arg\u00241, (Unit) obj0);
    }
  }
}
