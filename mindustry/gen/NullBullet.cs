// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullBullet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.entities.comp;
using mindustry.game;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Bulletc"})]
  internal sealed class NullBullet : 
    Bullet,
    Bulletc,
    Damagec,
    Entityc,
    Ownerc,
    Drawc,
    Posc,
    Position,
    Shielderc,
    Teamc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Timerc,
    Velc,
    Timedc,
    Scaled
  {
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullBullet()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object with([In] Cons obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void absorb()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool absorbed() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void absorbed([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canPass([In] int obj0, [In] int obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canPassOn() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool cheating() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float clipSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestEnemyCore() => (Building) null;

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed IntSeq collided() => new IntSeq(6);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void collided([In] IntSeq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool collides([In] Hitboxc obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building core() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float damage() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damage([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float damageMultiplier() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object data() => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void data([In] object obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaAngle() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaLen() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deltaX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deltaY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float drag() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drag([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawBullets()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fdata() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void fdata([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fin() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fin([In] Interp obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float finpow() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fout() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fout([In] Interp obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fout([In] float obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float fslope() => 0.0f;

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void getCollisions([In] Cons obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool hit() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hit([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float hitSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitSize([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitbox([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitboxTile([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float lastX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float lastY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float lifetime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lifetime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void move([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool moving() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Entityc owner() => (Entityc) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void owner([In] Entityc obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float rotation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void rotation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed EntityCollisions.SolidPred solidity() => (EntityCollisions.SolidPred) null;

    [LineNumberTable(511)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Team team() => Team.__\u003C\u003Ederelict;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void team([In] Team obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float time() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void time([In] float obj0)
    {
    }

    [LineNumberTable(551)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Interval timer() => new Interval(6);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void timer([In] Interval obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool timer([In] int obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed BulletType type() => (BulletType) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void type([In] BulletType obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateLastPosition()
    {
    }

    [LineNumberTable(599)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Vec2 vel() => new Vec2();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void y([In] float obj0)
    {
    }
  }
}
