// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Fire
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.game;
using mindustry.io;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Syncc", "mindustry.gen.Posc", "mindustry.gen.Firec", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public class Fire : Object, Pool.Poolable, Syncc, Entityc, Posc, Position, Firec, Timedc, Scaled
  {
    public const float spreadChance = 0.04f;
    public const float fireballChance = 0.06f;
    [NonSerialized]
    public long lastUpdated;
    [NonSerialized]
    public long updateSpacing;
    public float x;
    [NonSerialized]
    private float x_TARGET_;
    [NonSerialized]
    private float x_LAST_;
    public float y;
    [NonSerialized]
    private float y_TARGET_;
    [NonSerialized]
    private float y_LAST_;
    public Tile tile;
    [NonSerialized]
    public Block block;
    [NonSerialized]
    public float baseFlammability;
    [NonSerialized]
    public float puddleFlammability;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public float time;
    public float lifetime;

    [LineNumberTable(513)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fire create() => (Fire) Pools.obtain((Class) ClassLiteral<Fire>.Value, (Prov) new Fire.__\u003C\u003EAnon2());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {161, 64, 106, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.sync.add((Entityc) this);
      Groups.fire.add((Entityc) this);
      this.added = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile() => this.tile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void time(float time) => this.time = time;

    [LineNumberTable(new byte[] {160, 72, 232, 52, 235, 70, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Fire()
    {
      Fire fire = this;
      this.baseFlammability = -1f;
      this.id = EntityGroup.nextId();
    }

    [LineNumberTable(494)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [LineNumberTable(new byte[] {161, 42, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterSync() => Fires.register(this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [LineNumberTable(359)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 111, 116, 109, 118, 121, 121, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void interpolate()
    {
      if (this.lastUpdated != 0L && this.updateSpacing != 0L)
      {
        float progress = Math.min((float) Time.timeSinceMillis(this.lastUpdated) / (float) this.updateSpacing, 2f);
        this.x = Mathf.lerp(this.x_LAST_, this.x_TARGET_, progress);
        this.y = Mathf.lerp(this.y_LAST_, this.y_TARGET_, progress);
      }
      else
      {
        if (this.lastUpdated == 0L)
          return;
        this.x = this.x_TARGET_;
        this.y = this.y_TARGET_;
      }
    }

    [LineNumberTable(new byte[] {160, 131, 105, 107, 107, 139, 108, 208, 171, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.sync.remove((Entityc) this);
      Groups.fire.remove((Entityc) this);
      if (Vars.net.client())
        Vars.netClient.addRemovedEntity(this.id());
      Fires.remove(this.tile);
      this.added = false;
      Groups.queueFree((Pool.Poolable) this);
    }

    [LineNumberTable(455)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(new byte[] {160, 254, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => Fires.register(this);

    [LineNumberTable(new byte[] {161, 47, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [Modifiers]
    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u00240([In] Unit obj0) => !obj0.isFlying() && !obj0.isImmune(StatusEffects.burning);

    [Modifiers]
    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00241([In] Unit obj0) => obj0.apply(StatusEffects.burning, 300f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => true;

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Fire#").append(this.id).toString();

    [LineNumberTable(new byte[] {160, 85, 123, 107, 103, 109, 108, 109, 99, 108, 143, 104, 108, 140, 99, 108, 143, 104, 108, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readSync(Reads read)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      int num1 = this.isLocal() ? 1 : 0;
      this.lifetime = read.f();
      this.tile = TypeIO.readTile(read);
      this.time = read.f();
      if (num1 == 0)
      {
        this.x_LAST_ = this.x;
        this.x_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.x_LAST_ = this.x;
        this.x_TARGET_ = this.x;
      }
      if (num1 == 0)
      {
        this.y_LAST_ = this.y;
        this.y_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.y_LAST_ = this.y;
        this.y_TARGET_ = this.y;
      }
      this.afterSync();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 150, 105, 107, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void snapSync()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x_TARGET_;
      this.x = this.x_TARGET_;
      this.y_LAST_ = this.y_TARGET_;
      this.y = this.y_TARGET_;
    }

    [LineNumberTable(new byte[] {160, 160, 124, 198, 120, 159, 17, 120, 159, 17, 103, 154, 127, 16, 127, 8, 108, 133, 118, 102, 133, 108, 104, 111, 107, 154, 127, 6, 127, 7, 145, 99, 159, 14, 127, 29, 110, 127, 19, 103, 127, 5, 191, 22, 123, 109, 127, 1, 99, 139, 223, 29, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Vars.net.client() && !this.isLocal() || this.isRemote())
        this.interpolate();
      if (Mathf.chance(0.09 * (double) Time.delta))
        Fx.__\u003C\u003Efire.at(this.x + Mathf.range(4f), this.y + Mathf.range(4f));
      if (Mathf.chance(0.05 * (double) Time.delta))
        Fx.__\u003C\u003EfireSmoke.at(this.x + Mathf.range(4f), this.y + Mathf.range(4f));
      if (!Vars.headless)
        Vars.control.sound.loop(Sounds.fire, (Position) this, 0.07f);
      float num1 = 1f + Math.max(Vars.state.envAttrs.get(mindustry.world.meta.Attribute.__\u003C\u003Ewater) * 10f, 0.0f);
      this.time = Mathf.clamp(this.time + Time.delta * num1, 0.0f, this.lifetime);
      if (!Vars.net.client())
      {
        if ((double) this.time >= (double) this.lifetime || this.tile == null)
        {
          this.remove();
        }
        else
        {
          Building build = this.tile.build;
          int num2 = build == null ? 0 : 1;
          float num3 = this.baseFlammability + this.puddleFlammability;
          if (num2 == 0 && (double) num3 <= 0.0)
            this.time += Time.delta * 8f;
          if ((double) this.baseFlammability < 0.0 || !object.ReferenceEquals((object) this.block, (object) this.tile.block()))
          {
            this.baseFlammability = this.tile.build != null ? this.tile.getFlammability() : 0.0f;
            this.block = this.tile.block();
          }
          if (num2 != 0)
            this.lifetime += Mathf.clamp(num3 / 8f, 0.0f, 0.6f) * Time.delta;
          if ((double) num3 > 1.0 && Mathf.chance((double) (0.04f * Time.delta * Mathf.clamp(num3 / 5f, 0.3f, 2f))))
          {
            Point2 point2 = Geometry.__\u003C\u003Ed4[Mathf.random(3)];
            Fires.create(Vars.world.tile((int) this.tile.x + point2.x, (int) this.tile.y + point2.y));
            if (Mathf.chance((double) (0.06f * Time.delta * Mathf.clamp(num3 / 10f))))
              Bullets.fireball.createNet(Team.__\u003C\u003Ederelict, this.x, this.y, Mathf.random(360f), -1f, 1f, 1f);
          }
          if (Mathf.chance(0.025 * (double) Time.delta))
          {
            Puddle puddle = Puddles.get(this.tile);
            this.puddleFlammability = puddle == null ? 0.0f : puddle.getFlammability() / 3f;
            if (num2 != 0)
              build.damage(1.6f);
            Damage.damageUnits((Team) null, this.tile.worldx(), this.tile.worldy(), 8f, 3f, (Boolf) new Fire.__\u003C\u003EAnon0(), (Cons) new Fire.__\u003C\u003EAnon1());
          }
        }
      }
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [LineNumberTable(new byte[] {160, 222, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSyncManual(FloatBuffer buffer)
    {
      buffer.put(this.x);
      buffer.put(this.y);
    }

    [LineNumberTable(new byte[] {160, 227, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 232, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(new byte[] {160, 237, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSync(Writes write)
    {
      write.f(this.lifetime);
      TypeIO.writeTile(write, this.tile);
      write.f(this.time);
      write.f(this.x);
      write.f(this.y);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {161, 4, 103, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.s(1);
      write.f(this.lifetime);
      TypeIO.writeTile(write, this.tile);
      write.f(this.time);
      write.f(this.x);
      write.f(this.y);
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {161, 18, 103, 99, 104, 118, 109, 104, 108, 109, 109, 114, 100, 109, 108, 109, 109, 143, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      int num1 = (int) read.s();
      switch (num1)
      {
        case 0:
          double num2 = (double) read.f();
          Vars.content.getByID(ContentType.__\u003C\u003Eblock, (int) read.s());
          this.lifetime = read.f();
          double num3 = (double) read.f();
          this.tile = TypeIO.readTile(read);
          this.time = read.f();
          this.x = read.f();
          this.y = read.f();
          break;
        case 1:
          this.lifetime = read.f();
          this.tile = TypeIO.readTile(read);
          this.time = read.f();
          this.x = read.f();
          this.y = read.f();
          break;
        default:
          string str = new StringBuilder().append("Unknown revision '").append(num1).append("' for entity type 'FireComp'").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.afterRead();
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(new byte[] {161, 55, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {161, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(447)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(451)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(new byte[] {161, 89, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 93, 123, 107, 108, 109, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readSyncManual(FloatBuffer buffer)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x;
      this.x_TARGET_ = buffer.get();
      this.y_LAST_ = this.y;
      this.y_TARGET_ = buffer.get();
    }

    [LineNumberTable(new byte[] {161, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {161, 111, 105, 107, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void snapInterpolation()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x;
      this.x_TARGET_ = this.x;
      this.y_LAST_ = this.y;
      this.y_TARGET_ = this.y;
    }

    [LineNumberTable(new byte[] {161, 128, 104, 104, 107, 107, 103, 103, 107, 107, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.lastUpdated = 0L;
      this.updateSpacing = 0L;
      this.x = 0.0f;
      this.y = 0.0f;
      this.tile = (Tile) null;
      this.block = (Block) null;
      this.baseFlammability = -1f;
      this.puddleFlammability = 0.0f;
      this.added = false;
      this.id = EntityGroup.nextId();
      this.time = 0.0f;
      this.lifetime = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 10;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long lastUpdated() => this.lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastUpdated(long lastUpdated) => this.lastUpdated = lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long updateSpacing() => this.updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSpacing(long updateSpacing) => this.updateSpacing = updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tile(Tile tile) => this.tile = tile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float time() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lifetime() => this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lifetime(float lifetime) => this.lifetime = lifetime;

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

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
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Fire.lambda\u0024update\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Fire.lambda\u0024update\u00241((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new Fire();
    }
  }
}
