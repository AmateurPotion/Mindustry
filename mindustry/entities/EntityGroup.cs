// Decompiled with JetBrains decompiler
// Type: mindustry.entities.EntityGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using ikvm.lang;
using java.lang;
using java.util;
using java.util.function;
using mindustry.gen;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  [Signature("<T::Lmindustry/gen/Entityc;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class EntityGroup : Object, Iterable, IEnumerable
  {
    private static int lastId;
    [Modifiers]
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq array;
    [Modifiers]
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq intersectArray;
    [Modifiers]
    private Rect viewport;
    [Modifiers]
    private Rect intersectRect;
    [Signature("Larc/struct/IntMap<TT;>;")]
    private IntMap map;
    private QuadTree tree;
    private bool clearing;
    private int index;

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.array.size;

    [Signature("(Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int count(Boolf pred) => this.array.count(pred);

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => this.array.iterator();

    [Signature("(Larc/func/Boolf<TT;>;)TT;")]
    [LineNumberTable(197)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc find(Boolf pred) => (Entityc) this.array.find(pred);

    [Signature("(Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {19, 122, 61, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons cons)
    {
      for (this.index = 0; this.index < this.array.size; ++this.index)
        cons.get((object) ((Entityc[]) this.array.items)[this.index]);
    }

    [LineNumberTable(new byte[] {160, 72, 135, 117, 108, 147, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.clearing = true;
      this.array.each((Cons) new EntityGroup.__\u003C\u003EAnon1());
      this.array.clear();
      if (this.map != null)
        this.map.clear();
      this.clearing = false;
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {51, 127, 24})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc getByID(int id)
    {
      if (this.map == null)
      {
        string str = new StringBuilder().append("Mapping is not enabled for group ").append(id).append("!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      return (Entityc) this.map.get(id);
    }

    [LineNumberTable(new byte[] {56, 127, 24, 114, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeByID(int id)
    {
      if (this.map == null)
      {
        string str = new StringBuilder().append("Mapping is not enabled for group ").append(id).append("!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      ((Entityc) this.map.get(id))?.remove();
    }

    [Signature("(Larc/func/Boolf<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {25, 122, 63, 29, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Boolf filter, Cons cons)
    {
      for (this.index = 0; this.index < this.array.size; ++this.index)
      {
        if (filter.get((object) ((Entityc[]) this.array.items)[this.index]))
          cons.get((object) ((Entityc[]) this.array.items)[this.index]);
      }
    }

    [Signature("(Larc/func/Boolf<TT;>;)Z")]
    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Boolf pred) => this.array.contains(pred);

    [Signature("(Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {31, 145, 242, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Cons cons)
    {
      Core.camera.bounds(this.viewport);
      this.each((Cons) new EntityGroup.__\u003C\u003EAnon0(this, cons));
    }

    [LineNumberTable(new byte[] {78, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual QuadTree tree()
    {
      if (this.tree == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("This group does not support quadtrees! Enable quadtrees when creating it.");
      }
      return this.tree;
    }

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.array.size == 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool mappingEnabled() => this.map != null;

    [Modifiers]
    [LineNumberTable(new byte[] {34, 103, 127, 42, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00240([In] Cons obj0, [In] Entityc obj1)
    {
      Drawc drawc = (Drawc) obj1;
      if (!this.viewport.overlaps(drawc.x() - drawc.clipSize() / 2f, drawc.y() - drawc.clipSize() / 2f, drawc.clipSize(), drawc.clipSize()))
        return;
      obj0.get((object) obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int nextId() => EntityGroup.lastId++;

    [Signature("(Ljava/lang/Class<TT;>;ZZ)V")]
    [LineNumberTable(new byte[] {159, 134, 100, 232, 51, 107, 107, 235, 76, 143, 99, 191, 5, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EntityGroup(Class type, bool spatial, bool mapping)
    {
      int num1 = spatial ? 1 : 0;
      int num2 = mapping ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      EntityGroup entityGroup = this;
      this.intersectArray = new Seq();
      this.viewport = new Rect();
      this.intersectRect = new Rect();
      this.array = new Seq(false, 32, type);
      if (num1 != 0)
        this.tree = new QuadTree(new Rect(0.0f, 0.0f, 0.0f, 0.0f));
      if (num2 == 0)
        return;
      this.map = new IntMap();
    }

    [Signature("(Ljava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {159, 188, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(Comparator comp) => this.array.sort(comp);

    [LineNumberTable(new byte[] {0, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collide() => Vars.collisions.collide(this);

    [LineNumberTable(new byte[] {4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePhysics() => Vars.collisions.updatePhysics(this);

    [LineNumberTable(new byte[] {8, 122, 60, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      for (this.index = 0; this.index < this.array.size; ++this.index)
        ((Entityc[]) this.array.items)[this.index].update();
    }

    [Signature("(Larc/struct/Seq<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {14, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq copy(Seq arr)
    {
      arr.addAll(this.array);
      return arr;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useTree() => this.map != null;

    [Signature("(FFFFLarc/func/Cons<-TT;>;)V")]
    [LineNumberTable(new byte[] {65, 105, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void intersect(float x, float y, float width, float height, Cons @out)
    {
      if (this.isEmpty())
        return;
      this.tree.intersect(x, y, width, height, @out);
    }

    [Signature("(FFFF)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {70, 140, 111, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq intersect(float x, float y, float width, float height)
    {
      this.intersectArray.clear();
      if (this.isEmpty())
        return this.intersectArray;
      this.tree.intersect(this.intersectRect.set(x, y, width, height), this.intersectArray);
      return this.intersectArray;
    }

    [LineNumberTable(new byte[] {84, 104, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(float x, float y, float w, float h)
    {
      if (this.tree == null)
        return;
      this.tree = new QuadTree(new Rect(x, y, w, h));
    }

    [Signature("(I)TT;")]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc index(int i) => (Entityc) this.array.get(i);

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {110, 115, 140, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Entityc type)
    {
      if (type == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Cannot add a null entity!");
      }
      this.array.add((object) type);
      if (!this.mappingEnabled())
        return;
      this.map.put(type.id(), (object) type);
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {119, 105, 115, 110, 100, 109, 104, 210, 105, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Entityc type)
    {
      if (this.clearing)
        return;
      if (type == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Cannot remove a null entity!");
      }
      int index = this.array.indexOf((object) type, true);
      if (index == -1)
        return;
      this.array.remove(index);
      if (this.map != null)
        this.map.remove(type.id());
      if (this.index < index)
        return;
      --this.index;
    }

    [Signature("()TT;")]
    [LineNumberTable(202)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc first() => (Entityc) this.array.first();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly EntityGroup arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon0([In] EntityGroup obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024draw\u00240(this.arg\u00242, (Entityc) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ((Entityc) obj0).remove();
    }
  }
}
