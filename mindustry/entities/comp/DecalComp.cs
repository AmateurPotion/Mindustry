// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.DecalComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Timedc", "mindustry.gen.Rotc", "mindustry.gen.Posc"})]
  internal abstract class DecalComp : Object, Drawc, Posc, Position, Entityc, Timedc, Scaled, Rotc
  {
    internal float x;
    internal float y;
    internal float rotation;
    internal Color color;
    internal TextureRegion region;

    [HideFromJava]
    public abstract float fin();

    [LineNumberTable(new byte[] {159, 154, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal DecalComp()
    {
      DecalComp decalComp = this;
      this.color = new Color(1f, 1f, 1f, 1f);
    }

    [LineNumberTable(new byte[] {159, 162, 138, 118, 126, 125, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(10f);
      Draw.mixcol(this.color, this.color.a);
      Draw.alpha(1f - Mathf.curve(this.fin(), 0.98f));
      Draw.rect(this.region, this.x, this.y, this.rotation);
      Draw.reset();
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => (float) (this.region.width * 2);

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
    public abstract void update();

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
    public abstract int id();

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
    public abstract float time();

    [HideFromJava]
    public abstract void time([In] float obj0);

    [HideFromJava]
    public abstract float lifetime();

    [HideFromJava]
    public abstract void lifetime([In] float obj0);

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);
  }
}
