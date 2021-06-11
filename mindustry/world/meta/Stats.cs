// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.Stats
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.type;
using mindustry.world.blocks.environment;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta
{
  public class Stats : Object
  {
    public bool useCategories;
    public bool intialized;
    [Signature("Larc/struct/OrderedMap<Lmindustry/world/meta/StatCat;Larc/struct/OrderedMap<Lmindustry/world/meta/Stat;Larc/struct/Seq<Lmindustry/world/meta/StatValue;>;>;>;")]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private OrderedMap map;
    private bool dirty;

    [LineNumberTable(new byte[] {159, 154, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Stats()
    {
      Stats stats = this;
      this.useCategories = false;
      this.intialized = false;
    }

    [LineNumberTable(new byte[] {29, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, string format, params object[] args) => this.add(stat, (StatValue) new StringValue(format, args));

    [LineNumberTable(new byte[] {159, 166, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, float value, StatUnit unit) => this.add(stat, (StatValue) new NumberValue(value, unit));

    [LineNumberTable(new byte[] {34, 147, 115, 183, 159, 18, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, StatValue value)
    {
      if (this.map == null)
        this.map = new OrderedMap();
      if (!this.map.containsKey((object) stat.__\u003C\u003Ecategory))
        this.map.put((object) stat.__\u003C\u003Ecategory, (object) new OrderedMap());
      ((Seq) ((ObjectMap) this.map.get((object) stat.__\u003C\u003Ecategory)).get((object) stat, (Prov) new Stats.__\u003C\u003EAnon2())).add((object) value);
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {47, 147, 127, 18, 191, 16, 157, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Stat stat)
    {
      if (this.map == null)
        this.map = new OrderedMap();
      if (!this.map.containsKey((object) stat.__\u003C\u003Ecategory) || !((ObjectMap) this.map.get((object) stat.__\u003C\u003Ecategory)).containsKey((object) stat))
      {
        string str = new StringBuilder().append("No stat entry found: \"").append((object) stat).append("\" in block.").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      ((OrderedMap) this.map.get((object) stat.__\u003C\u003Ecategory)).remove((object) stat);
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {159, 126, 130, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, Attribute attr, bool floating)
    {
      int num = floating ? 1 : 0;
      this.add(stat, attr, num != 0, 1f, false);
    }

    [LineNumberTable(new byte[] {159, 129, 131, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, Liquid liquid, float amount, bool perSecond)
    {
      int num = perSecond ? 1 : 0;
      this.add(stat, (StatValue) new LiquidValue(liquid, amount, num != 0));
    }

    [LineNumberTable(new byte[] {159, 125, 133, 118, 101, 21, 186, 127, 1, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(
      Stat stat,
      Attribute attr,
      bool floating,
      float scale,
      bool startZero)
    {
      int num1 = floating ? 1 : 0;
      int num2 = startZero ? 1 : 0;
      Iterator iterator = Vars.content.blocks().select((Boolf) new Stats.__\u003C\u003EAnon0(attr, num1 != 0)).@as().with((Cons) new Stats.__\u003C\u003EAnon1(attr)).iterator();
      while (iterator.hasNext())
      {
        Floor floor = (Floor) iterator.next();
        this.add(stat, (StatValue) new FloorEfficiencyValue(floor, floor.attributes.get(attr) * scale, num2 != 0));
      }
    }

    [LineNumberTable(new byte[] {159, 191, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, ItemStack item) => this.add(stat, (StatValue) new ItemListValue(new ItemStack[1]
    {
      item
    }));

    [LineNumberTable(new byte[] {8, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, Attribute attr) => this.add(stat, attr, false, 1f, false);

    [LineNumberTable(new byte[] {159, 133, 162, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, bool value)
    {
      int num = value ? 1 : 0;
      this.add(stat, (StatValue) new BooleanValue(num != 0));
    }

    [LineNumberTable(new byte[] {12, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, Attribute attr, float scale) => this.add(stat, attr, false, scale, false);

    [LineNumberTable(new byte[] {159, 176, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPercent(Stat stat, float value) => this.add(stat, (StatValue) new NumberValue((float) ByteCodeHelper.f2i(value * 100f), StatUnit.__\u003C\u003Epercent));

    [LineNumberTable(new byte[] {159, 171, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, float value) => this.add(stat, value, StatUnit.__\u003C\u003Enone);

    [Signature("()Larc/struct/OrderedMap<Lmindustry/world/meta/StatCat;Larc/struct/OrderedMap<Lmindustry/world/meta/Stat;Larc/struct/Seq<Lmindustry/world/meta/StatValue;>;>;>;")]
    [LineNumberTable(new byte[] {59, 179, 104, 113, 127, 6, 118, 130, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OrderedMap toMap()
    {
      if (this.map == null)
        this.map = new OrderedMap();
      if (this.dirty)
      {
        this.map.orderedKeys().sort();
        ObjectMap.Entries entries = this.map.entries().iterator();
        while (((Iterator) entries).hasNext())
          ((OrderedMap) ((ObjectMap.Entry) ((Iterator) entries).next()).value).orderedKeys().sort();
        this.dirty = false;
      }
      return this.map;
    }

    [Modifiers]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024add\u00240([In] Attribute obj0, [In] bool obj1, [In] Block obj2)
    {
      int num = obj1 ? 1 : 0;
      Block block = obj2;
      Floor floor;
      return block is Floor && object.ReferenceEquals((object) (floor = (Floor) block), (object) (Floor) block) && (double) floor.attributes.get(obj0) != 0.0 && (!floor.isLiquid || num != 0);
    }

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00242([In] Attribute obj0, [In] Seq obj1) => obj1.sort((Floatf) new Stats.__\u003C\u003EAnon3(obj0));

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024add\u00241([In] Attribute obj0, [In] Floor obj1) => obj1.attributes.get(obj0);

    [LineNumberTable(new byte[] {159, 186, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Stat stat, Item item) => this.add(stat, (StatValue) new ItemListValue(new ItemStack[1]
    {
      new ItemStack(item, 1)
    }));

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly Attribute arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon0([In] Attribute obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (Stats.lambda\u0024add\u00240(this.arg\u00241, this.arg\u00242, (Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Attribute arg\u00241;

      internal __\u003C\u003EAnon1([In] Attribute obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Stats.lambda\u0024add\u00242(this.arg\u00241, (Seq) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      private readonly Attribute arg\u00241;

      internal __\u003C\u003EAnon3([In] Attribute obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => Stats.lambda\u0024add\u00241(this.arg\u00241, (Floor) obj0);
    }
  }
}
