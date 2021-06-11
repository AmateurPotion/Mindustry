// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.LaunchCoreComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Timedc"})]
  internal abstract class LaunchCoreComp : Object, Drawc, Posc, Position, Entityc, Timedc, Scaled
  {
    internal float x;
    internal float y;
    [NonSerialized]
    internal Interval @in;
    internal Block block;

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float cx() => this.x + this.fin((Interp) Interp.pow2In) * (12f + Mathf.randomSeedRange((long) (this.id() + 3), 4f));

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float cy() => this.y + this.fin((Interp) Interp.pow5In) * (100f + Mathf.randomSeedRange((long) (this.id() + 2), 30f));

    [HideFromJava]
    public abstract float fin();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [LineNumberTable(new byte[] {159, 157, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LaunchCoreComp()
    {
      LaunchCoreComp launchCoreComp = this;
      this.@in = new Interval();
    }

    [LineNumberTable(new byte[] {159, 165, 109, 119, 112, 159, 5, 138, 138, 112, 151, 159, 47, 102, 104, 63, 22, 200, 133, 138, 114, 159, 9, 102, 150, 159, 4, 106, 124, 159, 15, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      float num1 = this.fout((Interp) Interp.pow5Out);
      float num2 = (1f - num1) * 1.4f + 1f;
      float x = this.cx();
      float y = this.cy();
      float num3 = this.fin() * (140f + Mathf.randomSeedRange((long) this.id(), 50f));
      Draw.z(110.001f);
      Draw.color(Pal.engine);
      float num4 = 0.2f + this.fslope();
      float num5 = (float) (this.block.size - 1) * 0.85f;
      Fill.light(x, y, 10, 25f * (num4 + num2 - 1f) * num5, Tmp.__\u003C\u003Ec2.set(Pal.engine).a(num1), Tmp.__\u003C\u003Ec1.set(Pal.engine).a(0.0f));
      Draw.alpha(num1);
      for (int index = 0; index < 4; ++index)
        Drawf.tri(x, y, 6f * num5, 40f * (num4 + num2 - 1f) * num5, (float) index * 90f + num3);
      Draw.color();
      Draw.z(129f);
      TextureRegion region = this.block.icon(Cicon.__\u003C\u003Efull);
      float w = (float) region.width * Draw.scl * num2;
      float h = (float) region.height * Draw.scl * num2;
      Draw.alpha(num1);
      Draw.rect(region, x, y, w, h, num3 - 45f);
      Tmp.__\u003C\u003Ev1.trns(225f, this.fin((Interp) Interp.pow3In) * 250f);
      Draw.z(116f);
      Draw.color(0.0f, 0.0f, 0.0f, 0.22f * num1);
      Draw.rect(region, x + Tmp.__\u003C\u003Ev1.x, y + Tmp.__\u003C\u003Ev1.y, w, h, num3 - 45f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {21, 102, 127, 3, 159, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      float range = 4f;
      if (!this.@in.get(3f - this.fin() * 2f))
        return;
      Fx.__\u003C\u003ErocketSmokeLarge.at(this.cx() + Mathf.range(range), this.cy() + Mathf.range(range), this.fin());
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
    public abstract void remove();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isLocal();

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
    public abstract float clipSize();

    [HideFromJava]
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

    [HideFromJava]
    public abstract float time();

    [HideFromJava]
    public abstract void time([In] float obj0);

    [HideFromJava]
    public abstract float lifetime();

    [HideFromJava]
    public abstract void lifetime([In] float obj0);
  }
}
