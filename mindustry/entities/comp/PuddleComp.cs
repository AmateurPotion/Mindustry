// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.PuddleComp
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
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Puddlec", "mindustry.gen.Drawc"})]
  internal abstract class PuddleComp : Object, Posc, Position, Entityc, Puddlec, Drawc
  {
    private const int maxGeneration = 2;
    [Modifiers]
    private static Color tmp;
    [Modifiers]
    private static Rect rect;
    [Modifiers]
    private static Rect rect2;
    private static int seeds;
    internal float x;
    internal float y;
    [NonSerialized]
    internal float accepting;
    [NonSerialized]
    internal float updateTime;
    [NonSerialized]
    internal float lastRipple;
    internal float amount;
    internal int generation;
    internal Tile tile;
    internal Liquid liquid;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {74, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => Puddles.remove(this.tile);

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract Entityc self();

    [Modifiers]
    [LineNumberTable(new byte[] {19, 115, 107, 113, 150, 120, 223, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00240([In] Unit obj0)
    {
      if (!obj0.isGrounded() || obj0.hovering)
        return;
      obj0.hitbox(PuddleComp.rect2);
      if (!PuddleComp.rect.overlaps(PuddleComp.rect2))
        return;
      obj0.apply(this.liquid.effect, 120f);
      if ((double) obj0.vel.len() <= 0.1)
        return;
      Fx.__\u003C\u003Eripple.at(obj0.x, obj0.y, obj0.type.rippleScale, this.liquid.color);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {54, 127, 42, 49, 133, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00241(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Fill.circle(this.x + obj3 + Mathf.sin(Time.time + (float) (PuddleComp.seeds * 532), obj0, obj1), this.y + obj4 + Mathf.sin(Time.time + (float) (PuddleComp.seeds * 53), obj0, obj1), obj2 * 5f);
      ++PuddleComp.seeds;
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal PuddleComp()
    {
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFlammability() => this.liquid.flammability * this.amount;

    [LineNumberTable(new byte[] {159, 185, 154, 127, 18, 116, 139, 124, 127, 8, 122, 127, 19, 119, 124, 246, 60, 235, 73, 156, 109, 198, 127, 1, 255, 38, 77, 127, 16, 171, 171, 115})]
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
        Units.nearby(PuddleComp.rect.setSize(Mathf.clamp(this.amount / 46.66667f) * 10f).setCenter(this.x, this.y), (Cons) new PuddleComp.__\u003C\u003EAnon0(this));
        if ((double) this.liquid.temperature > 0.699999988079071 && this.tile.build != null && Mathf.chance(0.5))
          Fires.create(this.tile);
        this.updateTime = 40f;
      }
      this.updateTime -= Time.delta;
    }

    [LineNumberTable(new byte[] {43, 138, 107, 113, 116, 112, 134, 127, 5, 127, 49, 255, 4, 69, 133, 127, 0, 109, 108, 159, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(19f);
      PuddleComp.seeds = this.id();
      int num1 = this.tile.floor().isLiquid ? 1 : 0;
      float num2 = Mathf.clamp(this.amount / 46.66667f);
      float mag = num1 == 0 ? 0.0f : 0.8f;
      float scl = 25f;
      Draw.color(PuddleComp.tmp.set(this.liquid.color).shiftValue(-0.05f));
      Fill.circle(this.x + Mathf.sin(Time.time + (float) (PuddleComp.seeds * 532), scl, mag), this.y + Mathf.sin(Time.time + (float) (PuddleComp.seeds * 53), scl, mag), num2 * 8f);
      Angles.randLenVectors((long) this.id(), 3, num2 * 6f, (Floatc2) new PuddleComp.__\u003C\u003EAnon1(this, scl, mag, num2));
      Draw.color();
      if ((double) this.liquid.lightColor.a <= 1.0 / 1000.0 || (double) num2 <= 0.0)
        return;
      Color lightColor = this.liquid.lightColor;
      float num3 = lightColor.a * num2;
      Drawf.light(Team.__\u003C\u003Ederelict, this.tile.drawx(), this.tile.drawy(), 30f * num2, lightColor, num3 * 0.8f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => 20f;

    [LineNumberTable(new byte[] {79, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => Puddles.register((Puddle) this.self());

    [LineNumberTable(new byte[] {159, 136, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PuddleComp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.PuddleComp"))
        return;
      PuddleComp.tmp = new Color();
      PuddleComp.rect = new Rect();
      PuddleComp.rect2 = new Rect();
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

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
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

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
    public abstract float accepting();

    [HideFromJava]
    public abstract void accepting([In] float obj0);

    [HideFromJava]
    public abstract float updateTime();

    [HideFromJava]
    public abstract void updateTime([In] float obj0);

    [HideFromJava]
    public abstract float lastRipple();

    [HideFromJava]
    public abstract void lastRipple([In] float obj0);

    [HideFromJava]
    public abstract float amount();

    [HideFromJava]
    public abstract void amount([In] float obj0);

    [HideFromJava]
    public abstract int generation();

    [HideFromJava]
    public abstract void generation([In] int obj0);

    [HideFromJava]
    public abstract Tile tile();

    [HideFromJava]
    public abstract void tile([In] Tile obj0);

    [HideFromJava]
    public abstract Liquid liquid();

    [HideFromJava]
    public abstract void liquid([In] Liquid obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly PuddleComp arg\u00241;

      internal __\u003C\u003EAnon0([In] PuddleComp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00240((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc2
    {
      private readonly PuddleComp arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon1([In] PuddleComp obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024draw\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1);
    }
  }
}
