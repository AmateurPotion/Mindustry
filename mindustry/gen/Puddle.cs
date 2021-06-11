// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Puddle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.game;
using mindustry.graphics;
using mindustry.io;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Puddlec", "mindustry.gen.Entityc"})]
  public class Puddle : Object, Pool.Poolable, Drawc, Posc, Position, Entityc, Puddlec
  {
    public const int maxGeneration = 2;
    internal static Color __\u003C\u003Etmp;
    internal static Rect __\u003C\u003Erect;
    internal static Rect __\u003C\u003Erect2;
    public static int seeds;
    public float x;
    public float y;
    [NonSerialized]
    public float accepting;
    [NonSerialized]
    public float updateTime;
    [NonSerialized]
    public float lastRipple;
    public float amount;
    public int generation;
    public Tile tile;
    public Liquid liquid;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(417)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Puddle create() => (Puddle) Pools.obtain((Class) ClassLiteral<Puddle>.Value, (Prov) new Puddle.__\u003C\u003EAnon2());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tile(Tile tile) => this.tile = tile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void liquid(Liquid liquid) => this.liquid = liquid;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void amount(float amount) => this.amount = amount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generation(int generation) => this.generation = generation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {160, 229, 106, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      Groups.puddle.add((Entityc) this);
      this.added = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Liquid liquid() => this.liquid;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float accepting() => this.accepting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void accepting(float accepting) => this.accepting = accepting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float amount() => this.amount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile() => this.tile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [LineNumberTable(new byte[] {160, 68, 8, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Puddle()
    {
      Puddle puddle = this;
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [LineNumberTable(new byte[] {160, 254, 105, 107, 107, 139, 171, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      Groups.puddle.remove((Entityc) this);
      Puddles.remove(this.tile);
      this.added = false;
      Groups.queueFree((Pool.Poolable) this);
    }

    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(399)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [LineNumberTable(new byte[] {160, 180, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => Puddles.register(this);

    [LineNumberTable(new byte[] {160, 220, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 127, 64, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00240(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Fill.circle(this.x + obj3 + Mathf.sin(Time.time + (float) (Puddle.seeds * 532), obj0, obj1), this.y + obj4 + Mathf.sin(Time.time + (float) (Puddle.seeds * 53), obj0, obj1), obj2 * 5f);
      ++Puddle.seeds;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 137, 115, 107, 113, 118, 120, 223, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00241([In] Unit obj0)
    {
      if (!obj0.isGrounded() || obj0.hovering)
        return;
      obj0.hitbox(Puddle.__\u003C\u003Erect2);
      if (!Puddle.__\u003C\u003Erect.overlaps(Puddle.__\u003C\u003Erect2))
        return;
      obj0.apply(this.liquid.effect, 120f);
      if ((double) obj0.vel.len() <= 0.1)
        return;
      Fx.__\u003C\u003Eripple.at(obj0.x, obj0.y, obj0.type.rippleScale, this.liquid.color);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => true;

    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Puddle#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 90, 106, 107, 113, 116, 112, 102, 127, 5, 127, 49, 223, 4, 101, 127, 0, 109, 108, 191, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(19f);
      Puddle.seeds = this.id();
      int num1 = this.tile.floor().isLiquid ? 1 : 0;
      float num2 = Mathf.clamp(this.amount / 46.66667f);
      float mag = num1 == 0 ? 0.0f : 0.8f;
      float scl = 25f;
      Draw.color(Puddle.__\u003C\u003Etmp.set(this.liquid.color).shiftValue(-0.05f));
      Fill.circle(this.x + Mathf.sin(Time.time + (float) (Puddle.seeds * 532), scl, mag), this.y + Mathf.sin(Time.time + (float) (Puddle.seeds * 53), scl, mag), num2 * 8f);
      Angles.randLenVectors((long) this.id(), 3, num2 * 6f, (Floatc2) new Puddle.__\u003C\u003EAnon0(this, scl, mag, num2));
      Draw.color();
      if ((double) this.liquid.lightColor.a <= 1.0 / 1000.0 || (double) num2 <= 0.0)
        return;
      Color lightColor = this.liquid.lightColor;
      float num3 = lightColor.a * num2;
      Drawf.light(Team.__\u003C\u003Ederelict, this.tile.drawx(), this.tile.drawy(), 30f * num2, lightColor, num3 * 0.8f);
    }

    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFlammability() => this.liquid.flammability * this.amount;

    [LineNumberTable(new byte[] {160, 117, 122, 127, 18, 116, 107, 124, 127, 8, 122, 127, 19, 119, 124, 246, 60, 235, 72, 124, 109, 134, 127, 1, 255, 38, 75, 127, 16, 139, 139, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      float num = (double) this.accepting <= 0.0 ? 0.0f : 3f;
      this.amount -= Time.delta * (1f - this.liquid.viscosity) / (5f + num);
      this.amount += this.accepting;
      this.accepting = 0.0f;
      if ((double) this.amount >= 46.6666679382324 && this.generation < 2)
      {
        float amount = Math.min((this.amount - 46.66667f) / 4f, 0.3f) * Time.delta;
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = d4[index];
          Tile tile = Vars.world.tile((int) this.tile.x + point2.x, (int) this.tile.y + point2.y);
          if (tile != null && object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
          {
            Puddles.deposit(tile, this.tile, this.liquid, amount, this.generation + 1);
            this.amount -= amount / 2f;
          }
        }
      }
      this.amount = Mathf.clamp(this.amount, 0.0f, 70f);
      if ((double) this.amount <= 0.0)
        this.remove();
      if ((double) this.amount >= 35.0 && (double) this.updateTime <= 0.0)
      {
        Units.nearby(Puddle.__\u003C\u003Erect.setSize(Mathf.clamp(this.amount / 46.66667f) * 10f).setCenter(this.x, this.y), (Cons) new Puddle.__\u003C\u003EAnon1(this));
        if ((double) this.liquid.temperature > 0.699999988079071 && this.tile.build != null && Mathf.chance(0.5))
          Fires.create(this.tile);
        this.updateTime = 40f;
      }
      this.updateTime -= Time.delta;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 175, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {160, 186, 103, 108, 108, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.s(0);
      write.f(this.amount);
      write.i(this.generation);
      write.s((int) this.liquid.__\u003C\u003Eid);
      TypeIO.writeTile(write, this.tile);
      write.f(this.x);
      write.f(this.y);
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 201, 103, 99, 109, 108, 127, 1, 108, 109, 143, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      int num = (int) read.s();
      if (num == 0)
      {
        this.amount = read.f();
        this.generation = read.i();
        this.liquid = (Liquid) Vars.content.getByID(ContentType.__\u003C\u003Eliquid, (int) read.s());
        this.tile = TypeIO.readTile(read);
        this.x = read.f();
        this.y = read.f();
        this.afterRead();
      }
      else
      {
        string str = new StringBuilder().append("Unknown revision '").append(num).append("' for entity type 'PuddleComp'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 237, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(356)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => 20f;

    [LineNumberTable(new byte[] {161, 16, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {161, 24, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {161, 33, 107, 107, 107, 107, 107, 107, 103, 103, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      this.accepting = 0.0f;
      this.updateTime = 0.0f;
      this.lastRipple = 0.0f;
      this.amount = 0.0f;
      this.generation = 0;
      this.tile = (Tile) null;
      this.liquid = (Liquid) null;
      this.added = false;
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 13;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float updateTime() => this.updateTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTime(float updateTime) => this.updateTime = updateTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lastRipple() => this.lastRipple;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastRipple(float lastRipple) => this.lastRipple = lastRipple;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int generation() => this.generation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [LineNumberTable(new byte[] {159, 105, 77, 138, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Puddle()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Puddle"))
        return;
      Puddle.__\u003C\u003Etmp = new Color();
      Puddle.__\u003C\u003Erect = new Rect();
      Puddle.__\u003C\u003Erect2 = new Rect();
    }

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

    [Modifiers]
    public static Color tmp
    {
      [HideFromJava] get => Puddle.__\u003C\u003Etmp;
    }

    [Modifiers]
    public static Rect rect
    {
      [HideFromJava] get => Puddle.__\u003C\u003Erect;
    }

    [Modifiers]
    public static Rect rect2
    {
      [HideFromJava] get => Puddle.__\u003C\u003Erect2;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatc2
    {
      private readonly Puddle arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon0([In] Puddle obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024draw\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Puddle arg\u00241;

      internal __\u003C\u003EAnon1([In] Puddle obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00241((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new Puddle();
    }
  }
}
