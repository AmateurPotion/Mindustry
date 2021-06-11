// Decompiled with JetBrains decompiler
// Type: arc.math.geom.QuadTree
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  [Signature("<T::Larc/math/geom/QuadTree$QuadTreeObject;>Ljava/lang/Object;")]
  public class QuadTree : Object
  {
    internal Rect __\u003C\u003Etmp;
    protected internal const int maxObjectsPerNode = 5;
    public Rect bounds;
    [Signature("Larc/struct/Seq<TT;>;")]
    public Seq objects;
    [Signature("Larc/math/geom/QuadTree<TT;>;")]
    public QuadTree botLeft;
    [Signature("Larc/math/geom/QuadTree<TT;>;")]
    public QuadTree botRight;
    [Signature("Larc/math/geom/QuadTree<TT;>;")]
    public QuadTree topLeft;
    [Signature("Larc/math/geom/QuadTree<TT;>;")]
    public QuadTree topRight;
    public bool leaf;

    [LineNumberTable(new byte[] {159, 169, 232, 56, 203, 140, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public QuadTree(Rect bounds)
    {
      QuadTree quadTree = this;
      this.__\u003C\u003Etmp = new Rect();
      this.objects = new Seq(false);
      this.leaf = true;
      this.bounds = bounds;
    }

    [LineNumberTable(new byte[] {69, 108, 104, 107, 107, 107, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.objects.clear();
      if (!this.leaf)
      {
        this.topLeft.clear();
        this.topRight.clear();
        this.botLeft.clear();
        this.botRight.clear();
      }
      this.leaf = true;
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {20, 103, 179, 161, 158, 136, 142, 135, 109, 99, 137, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(QuadTree.QuadTreeObject obj)
    {
      this.hitbox(obj);
      if (!this.bounds.overlaps(this.__\u003C\u003Etmp))
        return;
      if (this.leaf && this.objects.size + 1 > 5)
        this.split();
      if (this.leaf)
      {
        this.objects.add((object) obj);
      }
      else
      {
        this.hitbox(obj);
        QuadTree fittingChild = this.getFittingChild(this.__\u003C\u003Etmp);
        if (fittingChild != null)
          fittingChild.insert(obj);
        else
          this.objects.add((object) obj);
      }
    }

    [Signature("(Larc/math/geom/Rect;Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 82, 107, 127, 1, 127, 1, 127, 1, 191, 1, 135, 107, 110, 103, 110, 231, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void intersect(Rect toCheck, Seq @out)
    {
      if (!this.leaf)
      {
        if (this.topLeft.bounds.overlaps(toCheck))
          this.topLeft.intersect(toCheck, @out);
        if (this.topRight.bounds.overlaps(toCheck))
          this.topRight.intersect(toCheck, @out);
        if (this.botLeft.bounds.overlaps(toCheck))
          this.botLeft.intersect(toCheck, @out);
        if (this.botRight.bounds.overlaps(toCheck))
          this.botRight.intersect(toCheck, @out);
      }
      Seq objects = this.objects;
      for (int index = 0; index < objects.size; ++index)
      {
        QuadTree.QuadTreeObject t = (QuadTree.QuadTreeObject) objects.items[index];
        this.hitbox(t);
        if (this.__\u003C\u003Etmp.overlaps(toCheck))
          @out.add((object) t);
      }
    }

    [Signature("(FFFFLarc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {113, 107, 127, 18, 127, 18, 127, 18, 191, 18, 135, 107, 110, 103, 118, 232, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void intersect(float x, float y, float width, float height, Cons @out)
    {
      if (!this.leaf)
      {
        if (this.topLeft.bounds.overlaps(x, y, width, height))
          this.topLeft.intersect(x, y, width, height, @out);
        if (this.topRight.bounds.overlaps(x, y, width, height))
          this.topRight.intersect(x, y, width, height, @out);
        if (this.botLeft.bounds.overlaps(x, y, width, height))
          this.botLeft.intersect(x, y, width, height, @out);
        if (this.botRight.bounds.overlaps(x, y, width, height))
          this.botRight.intersect(x, y, width, height, @out);
      }
      Seq objects = this.objects;
      for (int index = 0; index < objects.size; ++index)
      {
        QuadTree.QuadTreeObject t = (QuadTree.QuadTreeObject) objects.items[index];
        this.hitbox(t);
        if (this.__\u003C\u003Etmp.overlaps(x, y, width, height))
          @out.get((object) t);
      }
    }

    [Signature("(Larc/math/geom/Rect;)Larc/math/geom/QuadTree<TT;>;")]
    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual QuadTree newChild(Rect rect) => new QuadTree(rect);

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {160, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void hitbox(QuadTree.QuadTreeObject t) => t.hitbox(this.__\u003C\u003Etmp);

    [Signature("(Larc/math/geom/Rect;)Larc/math/geom/QuadTree<TT;>;")]
    [LineNumberTable(new byte[] {80, 127, 1, 191, 1, 138, 191, 0, 122, 99, 103, 99, 135, 105, 99, 103, 99, 231, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private QuadTree getFittingChild([In] Rect obj0)
    {
      float num1 = this.bounds.x + this.bounds.width / 2f;
      float num2 = this.bounds.y + this.bounds.height / 2f;
      int num3 = (double) obj0.y > (double) num2 ? 1 : 0;
      int num4 = (double) obj0.y >= (double) num2 || (double) (obj0.y + obj0.height) >= (double) num2 ? 0 : 1;
      if ((double) obj0.x < (double) num1 && (double) (obj0.x + obj0.width) < (double) num1)
      {
        if (num3 != 0)
          return this.topLeft;
        if (num4 != 0)
          return this.botLeft;
      }
      else if ((double) obj0.x > (double) num1)
      {
        if (num3 != 0)
          return this.topRight;
        if (num4 != 0)
          return this.botRight;
      }
      return (QuadTree) null;
    }

    [LineNumberTable(new byte[] {159, 174, 137, 115, 147, 107, 127, 15, 127, 18, 127, 18, 159, 21, 167, 116, 108, 103, 110, 100, 104, 134, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void split()
    {
      if (!this.leaf)
        return;
      float width = this.bounds.width / 2f;
      float height = this.bounds.height / 2f;
      if (this.botLeft == null)
      {
        Rect.__\u003Cclinit\u003E();
        this.botLeft = this.newChild(new Rect(this.bounds.x, this.bounds.y, width, height));
        Rect.__\u003Cclinit\u003E();
        this.botRight = this.newChild(new Rect(this.bounds.x + width, this.bounds.y, width, height));
        Rect.__\u003Cclinit\u003E();
        this.topLeft = this.newChild(new Rect(this.bounds.x, this.bounds.y + height, width, height));
        Rect.__\u003Cclinit\u003E();
        this.topRight = this.newChild(new Rect(this.bounds.x + width, this.bounds.y + height, width, height));
      }
      this.leaf = false;
      Iterator iterator = this.objects.iterator();
      while (iterator.hasNext())
      {
        QuadTree.QuadTreeObject t = (QuadTree.QuadTreeObject) iterator.next();
        this.hitbox(t);
        QuadTree fittingChild = this.getFittingChild(this.__\u003C\u003Etmp);
        if (fittingChild != null)
        {
          fittingChild.insert(t);
          iterator.remove();
        }
      }
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {48, 136, 176, 103, 141, 99, 169, 174, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(QuadTree.QuadTreeObject obj)
    {
      if (this.leaf)
      {
        this.objects.remove((object) obj, true);
      }
      else
      {
        this.hitbox(obj);
        QuadTree fittingChild = this.getFittingChild(this.__\u003C\u003Etmp);
        if (fittingChild != null)
          fittingChild.remove(obj);
        else
          this.objects.remove((object) obj, true);
        if (this.getTotalObjectCount() > 5)
          return;
        this.unsplit();
      }
    }

    [LineNumberTable(new byte[] {160, 104, 108, 104, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTotalObjectCount()
    {
      int size = this.objects.size;
      if (!this.leaf)
        size += this.botLeft.getTotalObjectCount() + this.topRight.getTotalObjectCount() + this.topLeft.getTotalObjectCount() + this.botRight.getTotalObjectCount();
      return size;
    }

    [LineNumberTable(new byte[] {8, 105, 119, 119, 119, 119, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void unsplit()
    {
      if (this.leaf)
        return;
      this.objects.addAll(this.botLeft.objects);
      this.objects.addAll(this.botRight.objects);
      this.objects.addAll(this.topLeft.objects);
      this.objects.addAll(this.topRight.objects);
      this.leaf = true;
    }

    [Signature("(Larc/math/geom/Rect;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 73, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void intersect(Rect rect, Cons @out) => this.intersect(rect.x, rect.y, rect.width, rect.height, @out);

    [Modifiers]
    protected internal Rect tmp
    {
      [HideFromJava] get => this.__\u003C\u003Etmp;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etmp = value;
    }

    public interface QuadTreeObject
    {
      void hitbox(Rect r);
    }
  }
}
