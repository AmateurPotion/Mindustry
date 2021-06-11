// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Bullet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.entities.comp;
using mindustry.game;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Damagec", "mindustry.gen.Ownerc", "mindustry.gen.Teamc", "mindustry.gen.Drawc", "mindustry.gen.Shielderc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Timerc", "mindustry.gen.Entityc", "mindustry.gen.Bulletc", "mindustry.gen.Velc", "mindustry.gen.Timedc"})]
  public class Bullet : 
    Object,
    Pool.Poolable,
    Damagec,
    Entityc,
    Ownerc,
    Teamc,
    Posc,
    Position,
    Drawc,
    Shielderc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Timerc,
    Bulletc,
    Velc,
    Timedc,
    Scaled
  {
    public float damage;
    public Entityc owner;
    public Team team;
    public float x;
    public float y;
    [NonSerialized]
    public float lastX;
    [NonSerialized]
    public float lastY;
    [NonSerialized]
    public float deltaX;
    [NonSerialized]
    public float deltaY;
    [NonSerialized]
    public float hitSize;
    [NonSerialized]
    public Interval timer;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public IntSeq collided;
    public object data;
    public BulletType type;
    public float fdata;
    [NonSerialized]
    public bool absorbed;
    [NonSerialized]
    public bool hit;
    [NonSerialized]
    public Vec2 vel;
    [NonSerialized]
    public float drag;
    public float time;
    public float lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [LineNumberTable(new byte[] {161, 131, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void absorb()
    {
      this.absorbed = true;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float damage() => this.damage;

    [LineNumberTable(new byte[] {161, 163, 127, 5, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotation()
    {
      float num = Mathf.atan2(this.vel().x, this.vel().y) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [LineNumberTable(new byte[] {160, 181, 127, 17, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float damageMultiplier()
    {
      if (this.owner is Unit)
        return ((Unit) this.owner).damageMultiplier() * Vars.state.rules.unitDamageMultiplier;
      return this.owner is Building ? Vars.state.rules.blockDamageMultiplier : 1f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc owner() => this.owner;

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [LineNumberTable(561)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Bullet create() => (Bullet) Pools.obtain((Class) ClassLiteral<Bullet>.Value, (Prov) new Bullet.__\u003C\u003EAnon1());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {161, 33, 106, 107, 107, 139, 166, 167, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.bullet.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.updateLastPosition();
      this.added = true;
      this.type.init(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [HideFromJava]
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 208, 112, 102, 127, 0, 104, 140, 127, 3, 127, 31, 156, 109, 136, 145, 110, 127, 51, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collision(Hitboxc other, float x, float y)
    {
      this.type.hit(this, x, y);
      float initialHealth = 0.0f;
      Hitboxc hitboxc1 = other;
      Healthc healthc;
      if (hitboxc1 is Healthc && object.ReferenceEquals((object) (healthc = (Healthc) hitboxc1), (object) (Healthc) hitboxc1))
      {
        initialHealth = healthc.health();
        healthc.damage(this.damage);
      }
      Hitboxc hitboxc2 = other;
      Unit unit1;
      if (hitboxc2 is Unit && object.ReferenceEquals((object) (unit1 = (Unit) hitboxc2), (object) (Unit) hitboxc2))
      {
        unit1.impulse(Tmp.__\u003C\u003Ev3.set((Position) unit1).sub(this.x, this.y).nor().scl(this.type.knockback * 80f));
        unit1.apply(this.type.status, this.type.statusDuration);
      }
      if (!this.type.pierce)
        this.remove();
      else
        this.collided.add(other.id());
      this.type.hitEntity(this, other, initialHealth);
      if (!(this.owner is Wall.WallBuild) || Vars.player == null || !object.ReferenceEquals((object) this.team, (object) Vars.player.team()))
        return;
      Hitboxc hitboxc3 = other;
      Unit unit2;
      if (!(hitboxc3 is Unit) || !object.ReferenceEquals((object) (unit2 = (Unit) hitboxc3), (object) (Unit) hitboxc3) || !unit2.dead)
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EphaseDeflectHit);
    }

    [LineNumberTable(new byte[] {160, 104, 105, 107, 107, 139, 167, 108, 139, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.bullet.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      this.added = false;
      this.type.despawned(this);
      this.collided.clear();
      Groups.queueFree((Pool.Poolable) this);
    }

    [LineNumberTable(new byte[] {161, 125, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool timer(int index, float time) => !Float.isInfinite(time) && this.timer.get(index, time);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object data() => this.data;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void data(object data) => this.data = data;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lifetime() => this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void time(float time) => this.time = time;

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [LineNumberTable(491)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(379)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BulletType type() => this.type;

    [LineNumberTable(new byte[] {161, 29, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotation(float angle) => this.vel().setAngle(angle);

    [LineNumberTable(new byte[] {160, 197, 103, 99, 146, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void move(float cx, float cy)
    {
      EntityCollisions.SolidPred solidCheck = this.solidity();
      if (solidCheck != null)
      {
        Vars.collisions.move((Hitboxc) this, cx, cy, solidCheck);
      }
      else
      {
        this.x += cx;
        this.y += cy;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lastX() => this.lastX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lastY() => this.lastY;

    [LineNumberTable(427)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateLastPosition()
    {
      this.deltaX = this.x - this.lastX;
      this.deltaY = this.y - this.lastY;
      this.lastX = this.x;
      this.lastY = this.y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EntityCollisions.SolidPred solidity() => (EntityCollisions.SolidPred) null;

    [LineNumberTable(new byte[] {160, 192, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => this.updateLastPosition();

    [LineNumberTable(361)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 vel() => this.vel;

    [LineNumberTable(new byte[] {161, 158, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canPass(int tileX, int tileY)
    {
      EntityCollisions.SolidPred solidPred = this.solidity();
      return solidPred == null || !solidPred.solid(tileX, tileY);
    }

    [LineNumberTable(new byte[] {161, 105, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 138, 109, 109, 127, 80, 98, 103, 115, 136, 112, 109, 136, 177, 111, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00240([In] int obj0, [In] int obj1)
    {
      Building building = Vars.world.build(obj0, obj1);
      if (building == null || !this.isAdded() || (!building.collide(this) || !this.type.testCollision(this, building)) || (building.dead() || !this.type.collidesTeam && object.ReferenceEquals((object) building.team, (object) this.team)) || this.type.pierceBuilding && this.collided.contains(building.id))
        return false;
      int num = 0;
      float health = building.health;
      if (!object.ReferenceEquals((object) building.team, (object) this.team))
        num = building.collision(this) ? 1 : 0;
      if (num != 0 || this.type.collidesTeam)
      {
        if (!this.type.pierceBuilding)
          this.remove();
        else
          this.collided.add(building.id);
      }
      this.type.hitTile(this, building, health, true);
      return !this.type.pierceBuilding;
    }

    [LineNumberTable(new byte[] {160, 87, 232, 18, 235, 84, 204, 139, 236, 76, 139, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Bullet()
    {
      Bullet bullet = this;
      this.team = Team.__\u003C\u003Ederelict;
      this.timer = new Interval(6);
      this.id = EntityGroup.nextId();
      this.collided = new IntSeq(6);
      this.vel = new Vec2();
      this.drag = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Bullet#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [LineNumberTable(new byte[] {160, 120, 112, 107, 127, 0, 24, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getCollisions(Cons consumer)
    {
      Seq present = Vars.state.teams.present;
      for (int index = 0; index < present.size; ++index)
      {
        if (!object.ReferenceEquals((object) ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam, (object) this.team))
          consumer.get((object) ((Teams.TeamData[]) present.items)[index].tree());
      }
    }

    [LineNumberTable(new byte[] {160, 131, 127, 11, 191, 12, 108, 127, 8, 255, 26, 86, 127, 7, 198, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.move(this.vel.x * Time.delta, this.vel.y * Time.delta);
      this.vel.scl(Math.max(1f - this.drag * Time.delta, 0.0f));
      this.type.update(this);
      if (this.type.collidesTiles && this.type.collides && this.type.collidesGround)
        Vars.world.raycastEach(World.toTile(this.lastX()), World.toTile(this.lastY()), this.tileX(), this.tileY(), (Geometry.Raycaster) new Bullet.__\u003C\u003EAnon0(this));
      if (this.type.pierceCap != -1 && this.collided.size >= this.type.pierceCap)
        this.remove();
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [LineNumberTable(new byte[] {160, 172, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {160, 177, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBullets() => this.type.draw(this);

    [LineNumberTable(new byte[] {160, 187, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitbox(Rect rect) => rect.setCentered(this.x, this.y, this.hitSize, this.hitSize);

    [LineNumberTable(new byte[] {160, 231, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [LineNumberTable(new byte[] {160, 235, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestCore() => (Building) Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {161, 0, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(387)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float deltaAngle() => Mathf.angle(this.deltaX, this.deltaY);

    [LineNumberTable(391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => this.type.drawSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hitSize() => this.hitSize;

    [LineNumberTable(419)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canPassOn() => this.canPass(this.tileX(), this.tileY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [LineNumberTable(new byte[] {161, 62, 106, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(100f);
      this.type.draw(this);
      this.type.drawLight(this);
    }

    [LineNumberTable(new byte[] {161, 76, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {161, 81, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(456)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool moving() => !this.vel.isZero(0.01f);

    [LineNumberTable(460)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collides(Hitboxc other) => this.type.collides && other is Teamc && !object.ReferenceEquals((object) ((Teamc) other).team(), (object) this.team) && ((!(other is Flyingc) || ((Flyingc) other).checkTarget(this.type.collidesAir, this.type.collidesGround)) && (!this.type.pierce || !this.collided.contains(other.id())));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(471)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building core() => (Building) this.team.core();

    [LineNumberTable(483)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float deltaLen() => Mathf.len(this.deltaX, this.deltaY);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(507)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestEnemyCore() => (Building) Vars.state.teams.closestEnemyCore(this.x, this.y, this.team);

    [LineNumberTable(511)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool cheating() => this.team.rules().cheat;

    [LineNumberTable(new byte[] {161, 145, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 153, 121, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitboxTile(Rect rect)
    {
      float num = Math.min(this.hitSize * 0.66f, 7.9f);
      rect.setCentered(this.x, this.y, num, num);
    }

    [LineNumberTable(new byte[] {161, 169, 107, 103, 107, 107, 107, 107, 107, 107, 107, 103, 107, 103, 103, 107, 103, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.damage = 0.0f;
      this.owner = (Entityc) null;
      this.x = 0.0f;
      this.y = 0.0f;
      this.lastX = 0.0f;
      this.lastY = 0.0f;
      this.deltaX = 0.0f;
      this.deltaY = 0.0f;
      this.hitSize = 0.0f;
      this.added = false;
      this.id = EntityGroup.nextId();
      this.data = (object) null;
      this.type = (BulletType) null;
      this.fdata = 0.0f;
      this.absorbed = false;
      this.hit = false;
      this.drag = 0.0f;
      this.time = 0.0f;
      this.lifetime = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 7;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damage(float damage) => this.damage = damage;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void owner(Entityc owner) => this.owner = owner;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team(Team team) => this.team = team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastX(float lastX) => this.lastX = lastX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastY(float lastY) => this.lastY = lastY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float deltaX() => this.deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deltaX(float deltaX) => this.deltaX = deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float deltaY() => this.deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deltaY(float deltaY) => this.deltaY = deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitSize(float hitSize) => this.hitSize = hitSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interval timer() => this.timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void timer(Interval timer) => this.timer = timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSeq collided() => this.collided;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collided(IntSeq collided) => this.collided = collided;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void type(BulletType type) => this.type = type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fdata() => this.fdata;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fdata(float fdata) => this.fdata = fdata;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool absorbed() => this.absorbed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void absorbed(bool absorbed) => this.absorbed = absorbed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hit() => this.hit;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hit(bool hit) => this.hit = hit;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drag() => this.drag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drag(float drag) => this.drag = drag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float time() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lifetime(float lifetime) => this.lifetime = lifetime;

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Geometry.Raycaster
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon0([In] Bullet obj0) => this.arg\u00241 = obj0;

      public bool accept([In] int obj0, [In] int obj1) => (this.arg\u00241.lambda\u0024update\u00240(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new Bullet();
    }
  }
}
