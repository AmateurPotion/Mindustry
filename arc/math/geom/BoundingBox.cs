// Decompiled with JetBrains decompiler
// Type: arc.math.geom.BoundingBox
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class BoundingBox : Object
  {
    internal Vec3 __\u003C\u003Emin;
    internal Vec3 __\u003C\u003Emax;
    [Modifiers]
    private Vec3 cnt;
    [Modifiers]
    private Vec3 dim;

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox clr() => this.set(this.__\u003C\u003Emin.set(0.0f, 0.0f, 0.0f), this.__\u003C\u003Emax.set(0.0f, 0.0f, 0.0f));

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox set(BoundingBox bounds) => this.set(bounds.__\u003C\u003Emin, bounds.__\u003C\u003Emax);

    [LineNumberTable(new byte[] {101, 127, 31, 60, 134, 127, 31, 60, 134, 127, 8, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox set(Vec3 minimum, Vec3 maximum)
    {
      this.__\u003C\u003Emin.set((double) minimum.x >= (double) maximum.x ? maximum.x : minimum.x, (double) minimum.y >= (double) maximum.y ? maximum.y : minimum.y, (double) minimum.z >= (double) maximum.z ? maximum.z : minimum.z);
      this.__\u003C\u003Emax.set((double) minimum.x <= (double) maximum.x ? maximum.x : minimum.x, (double) minimum.y <= (double) maximum.y ? maximum.y : minimum.y, (double) minimum.z <= (double) maximum.z ? maximum.z : minimum.z);
      this.cnt.set(this.__\u003C\u003Emin).add(this.__\u003C\u003Emax).scl(0.5f);
      this.dim.set(this.__\u003C\u003Emax).sub(this.__\u003C\u003Emin);
      return this;
    }

    [LineNumberTable(new byte[] {160, 75, 123, 123, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox inf()
    {
      this.__\u003C\u003Emin.set(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
      this.__\u003C\u003Emax.set(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
      this.cnt.set(0.0f, 0.0f, 0.0f);
      this.dim.set(0.0f, 0.0f, 0.0f);
      return this;
    }

    [LineNumberTable(new byte[] {160, 88, 127, 73, 63, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox ext(Vec3 point) => this.set(this.__\u003C\u003Emin.set(BoundingBox.min(this.__\u003C\u003Emin.x, point.x), BoundingBox.min(this.__\u003C\u003Emin.y, point.y), BoundingBox.min(this.__\u003C\u003Emin.z, point.z)), this.__\u003C\u003Emax.set(Math.max(this.__\u003C\u003Emax.x, point.x), Math.max(this.__\u003C\u003Emax.y, point.y), Math.max(this.__\u003C\u003Emax.z, point.z)));

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float min([In] float obj0, [In] float obj1) => (double) obj0 > (double) obj1 ? obj1 : obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float max([In] float obj0, [In] float obj1) => (double) obj0 > (double) obj1 ? obj0 : obj1;

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => (double) this.__\u003C\u003Emin.x <= (double) this.__\u003C\u003Emax.x && (double) this.__\u003C\u003Emin.y <= (double) this.__\u003C\u003Emax.y && (double) this.__\u003C\u003Emin.z <= (double) this.__\u003C\u003Emax.z;

    [LineNumberTable(new byte[] {159, 160, 232, 57, 107, 139, 107, 203, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoundingBox()
    {
      BoundingBox boundingBox = this;
      this.__\u003C\u003Emin = new Vec3();
      this.__\u003C\u003Emax = new Vec3();
      this.cnt = new Vec3();
      this.dim = new Vec3();
      this.clr();
    }

    [LineNumberTable(new byte[] {159, 168, 232, 49, 107, 139, 107, 235, 76, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoundingBox(BoundingBox bounds)
    {
      BoundingBox boundingBox = this;
      this.__\u003C\u003Emin = new Vec3();
      this.__\u003C\u003Emax = new Vec3();
      this.cnt = new Vec3();
      this.dim = new Vec3();
      this.set(bounds);
    }

    [LineNumberTable(new byte[] {159, 177, 232, 40, 107, 139, 107, 235, 85, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoundingBox(Vec3 minimum, Vec3 maximum)
    {
      BoundingBox boundingBox = this;
      this.__\u003C\u003Emin = new Vec3();
      this.__\u003C\u003Emax = new Vec3();
      this.cnt = new Vec3();
      this.dim = new Vec3();
      this.set(minimum, maximum);
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCenter(Vec3 @out) => @out.set(this.cnt);

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCenterX() => this.cnt.x;

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCenterY() => this.cnt.y;

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCenterZ() => this.cnt.z;

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner000(Vec3 @out) => @out.set(this.__\u003C\u003Emin.x, this.__\u003C\u003Emin.y, this.__\u003C\u003Emin.z);

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner001(Vec3 @out) => @out.set(this.__\u003C\u003Emin.x, this.__\u003C\u003Emin.y, this.__\u003C\u003Emax.z);

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner010(Vec3 @out) => @out.set(this.__\u003C\u003Emin.x, this.__\u003C\u003Emax.y, this.__\u003C\u003Emin.z);

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner011(Vec3 @out) => @out.set(this.__\u003C\u003Emin.x, this.__\u003C\u003Emax.y, this.__\u003C\u003Emax.z);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner100(Vec3 @out) => @out.set(this.__\u003C\u003Emax.x, this.__\u003C\u003Emin.y, this.__\u003C\u003Emin.z);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner101(Vec3 @out) => @out.set(this.__\u003C\u003Emax.x, this.__\u003C\u003Emin.y, this.__\u003C\u003Emax.z);

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner110(Vec3 @out) => @out.set(this.__\u003C\u003Emax.x, this.__\u003C\u003Emax.y, this.__\u003C\u003Emin.z);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getCorner111(Vec3 @out) => @out.set(this.__\u003C\u003Emax.x, this.__\u003C\u003Emax.y, this.__\u003C\u003Emax.z);

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getDimensions(Vec3 @out) => @out.set(this.dim);

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWidth() => this.dim.x;

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getHeight() => this.dim.y;

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDepth() => this.dim.z;

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getMin(Vec3 @out) => @out.set(this.__\u003C\u003Emin);

    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getMax(Vec3 @out) => @out.set(this.__\u003C\u003Emax);

    [LineNumberTable(new byte[] {116, 103, 111, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox set(Vec3[] points)
    {
      this.inf();
      Vec3[] vec3Array = points;
      int length = vec3Array.Length;
      for (int index = 0; index < length; ++index)
        this.ext(vec3Array[index]);
      return this;
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Vec3;>;)Larc/math/geom/BoundingBox;")]
    [LineNumberTable(new byte[] {160, 64, 103, 123, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox set(Seq points)
    {
      this.inf();
      Iterator iterator = points.iterator();
      while (iterator.hasNext())
        this.ext((Vec3) iterator.next());
      return this;
    }

    [LineNumberTable(new byte[] {160, 114, 127, 93, 63, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox ext(BoundingBox a_bounds) => this.set(this.__\u003C\u003Emin.set(BoundingBox.min(this.__\u003C\u003Emin.x, a_bounds.__\u003C\u003Emin.x), BoundingBox.min(this.__\u003C\u003Emin.y, a_bounds.__\u003C\u003Emin.y), BoundingBox.min(this.__\u003C\u003Emin.z, a_bounds.__\u003C\u003Emin.z)), this.__\u003C\u003Emax.set(BoundingBox.max(this.__\u003C\u003Emax.x, a_bounds.__\u003C\u003Emax.x), BoundingBox.max(this.__\u003C\u003Emax.y, a_bounds.__\u003C\u003Emax.y), BoundingBox.max(this.__\u003C\u003Emax.z, a_bounds.__\u003C\u003Emax.z)));

    [LineNumberTable(new byte[] {160, 125, 127, 89, 63, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox ext(Vec3 center, float radius) => this.set(this.__\u003C\u003Emin.set(BoundingBox.min(this.__\u003C\u003Emin.x, center.x - radius), BoundingBox.min(this.__\u003C\u003Emin.y, center.y - radius), BoundingBox.min(this.__\u003C\u003Emin.z, center.z - radius)), this.__\u003C\u003Emax.set(BoundingBox.max(this.__\u003C\u003Emax.x, center.x + radius), BoundingBox.max(this.__\u003C\u003Emax.y, center.y + radius), BoundingBox.max(this.__\u003C\u003Emax.z, center.z + radius)));

    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(BoundingBox b) => !this.isValid() || (double) this.__\u003C\u003Emin.x <= (double) b.__\u003C\u003Emin.x && (double) this.__\u003C\u003Emin.y <= (double) b.__\u003C\u003Emin.y && ((double) this.__\u003C\u003Emin.z <= (double) b.__\u003C\u003Emin.z && (double) this.__\u003C\u003Emax.x >= (double) b.__\u003C\u003Emax.x) && ((double) this.__\u003C\u003Emax.y >= (double) b.__\u003C\u003Emax.y && (double) this.__\u003C\u003Emax.z >= (double) b.__\u003C\u003Emax.z);

    [LineNumberTable(new byte[] {160, 145, 202, 127, 0, 159, 8, 127, 0, 159, 8, 127, 1, 159, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool intersects(BoundingBox b)
    {
      if (!this.isValid())
        return false;
      float num1 = Math.abs(this.cnt.x - b.cnt.x);
      float num2 = this.dim.x / 2f + b.dim.x / 2f;
      float num3 = Math.abs(this.cnt.y - b.cnt.y);
      float num4 = this.dim.y / 2f + b.dim.y / 2f;
      float num5 = Math.abs(this.cnt.z - b.cnt.z);
      float num6 = this.dim.z / 2f + b.dim.z / 2f;
      return (double) num1 <= (double) num2 && (double) num3 <= (double) num4 && (double) num5 <= (double) num6;
    }

    [LineNumberTable(282)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec3 v) => (double) this.__\u003C\u003Emin.x <= (double) v.x && (double) this.__\u003C\u003Emax.x >= (double) v.x && ((double) this.__\u003C\u003Emin.y <= (double) v.y && (double) this.__\u003C\u003Emax.y >= (double) v.y) && ((double) this.__\u003C\u003Emin.z <= (double) v.z && (double) this.__\u003C\u003Emax.z >= (double) v.z);

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[").append((object) this.__\u003C\u003Emin).append("|").append((object) this.__\u003C\u003Emax).append("]").toString();

    [LineNumberTable(298)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BoundingBox ext(float x, float y, float z) => this.set(this.__\u003C\u003Emin.set(BoundingBox.min(this.__\u003C\u003Emin.x, x), BoundingBox.min(this.__\u003C\u003Emin.y, y), BoundingBox.min(this.__\u003C\u003Emin.z, z)), this.__\u003C\u003Emax.set(BoundingBox.max(this.__\u003C\u003Emax.x, x), BoundingBox.max(this.__\u003C\u003Emax.y, y), BoundingBox.max(this.__\u003C\u003Emax.z, z)));

    [Modifiers]
    public Vec3 min
    {
      [HideFromJava] get => this.__\u003C\u003Emin;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emin = value;
    }

    [Modifiers]
    public Vec3 max
    {
      [HideFromJava] get => this.__\u003C\u003Emax;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emax = value;
    }
  }
}
