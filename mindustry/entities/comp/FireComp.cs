// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.FireComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Timedc", "mindustry.gen.Posc", "mindustry.gen.Firec", "mindustry.gen.Syncc"})]
  internal abstract class FireComp : Object, Timedc, Scaled, Entityc, Posc, Position, Firec, Syncc
  {
    private const float spreadChance = 0.04f;
    private const float fireballChance = 0.06f;
    internal float time;
    internal float lifetime;
    internal float x;
    internal float y;
    internal Tile tile;
    [NonSerialized]
    private Block block;
    [NonSerialized]
    private float baseFlammability;
    [NonSerialized]
    private float puddleFlammability;

    [LineNumberTable(new byte[] {48, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => Fires.remove(this.tile);

    [HideFromJava]
    public abstract Entityc self();

    [Modifiers]
    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u00240([In] Unit obj0) => !obj0.isFlying() && !obj0.isImmune(StatusEffects.burning);

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00241([In] Unit obj0) => obj0.apply(StatusEffects.burning, 300f);

    [LineNumberTable(new byte[] {159, 161, 232, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FireComp()
    {
      FireComp fireComp = this;
      this.baseFlammability = -1f;
    }

    [LineNumberTable(new byte[] {159, 172, 120, 191, 17, 120, 191, 17, 103, 218, 127, 16, 159, 8, 108, 161, 118, 102, 161, 108, 136, 143, 107, 186, 127, 6, 127, 7, 177, 99, 191, 14, 127, 29, 110, 127, 19, 135, 127, 5, 223, 22, 123, 109, 159, 1, 99, 139, 223, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Mathf.chance(0.09 * (double) Time.delta))
        Fx.__\u003C\u003Efire.at(this.x + Mathf.range(4f), this.y + Mathf.range(4f));
      if (Mathf.chance(0.05 * (double) Time.delta))
        Fx.__\u003C\u003EfireSmoke.at(this.x + Mathf.range(4f), this.y + Mathf.range(4f));
      if (!Vars.headless)
        Vars.control.sound.loop(Sounds.fire, (Position) this, 0.07f);
      float num1 = 1f + Math.max(Vars.state.envAttrs.get(mindustry.world.meta.Attribute.__\u003C\u003Ewater) * 10f, 0.0f);
      this.time = Mathf.clamp(this.time + Time.delta * num1, 0.0f, this.lifetime);
      if (Vars.net.client())
        return;
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
        if (!Mathf.chance(0.025 * (double) Time.delta))
          return;
        Puddle puddle = Puddles.get(this.tile);
        this.puddleFlammability = puddle == null ? 0.0f : puddle.getFlammability() / 3f;
        if (num2 != 0)
          build.damage(1.6f);
        Damage.damageUnits((Team) null, this.tile.worldx(), this.tile.worldy(), 8f, 3f, (Boolf) new FireComp.__\u003C\u003EAnon0(), (Cons) new FireComp.__\u003C\u003EAnon1());
      }
    }

    [LineNumberTable(new byte[] {53, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => Fires.register((Fire) this.self());

    [LineNumberTable(new byte[] {58, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterSync() => Fires.register((Fire) this.self());

    [HideFromJava]
    public abstract float fin();

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
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract float time();

    [HideFromJava]
    public abstract void time([In] float obj0);

    [HideFromJava]
    public abstract float lifetime();

    [HideFromJava]
    public abstract void lifetime([In] float obj0);

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
    public abstract void snapSync();

    [HideFromJava]
    public abstract void snapInterpolation();

    [HideFromJava]
    public abstract void readSync([In] Reads obj0);

    [HideFromJava]
    public abstract void writeSync([In] Writes obj0);

    [HideFromJava]
    public abstract void readSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void writeSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void interpolate();

    [HideFromJava]
    public abstract long lastUpdated();

    [HideFromJava]
    public abstract void lastUpdated([In] long obj0);

    [HideFromJava]
    public abstract long updateSpacing();

    [HideFromJava]
    public abstract void updateSpacing([In] long obj0);

    [HideFromJava]
    public abstract Tile tile();

    [HideFromJava]
    public abstract void tile([In] Tile obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (FireComp.lambda\u0024update\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => FireComp.lambda\u0024update\u00241((Unit) obj0);
    }
  }
}
