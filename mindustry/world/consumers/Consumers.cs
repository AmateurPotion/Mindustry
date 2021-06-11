// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.Consumers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using mindustry.world.blocks.power;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class Consumers : Object
  {
    private Consume[] map;
    private Consume[] results;
    private Consume[] optionalResults;
    internal Bits __\u003C\u003EitemFilters;
    internal Bits __\u003C\u003Eliquidfilters;

    [LineNumberTable(new byte[] {159, 154, 104, 177, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Consumers()
    {
      Consumers consumers = this;
      this.map = new Consume[ConsumeType.values().Length];
      this.__\u003C\u003EitemFilters = new Bits(Vars.content.items().size);
      this.__\u003C\u003Eliquidfilters = new Bits(Vars.content.liquids().size);
    }

    [LineNumberTable(new byte[] {72, 116, 99, 7, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Stats stats)
    {
      Consume[] map = this.map;
      int length = map.Length;
      for (int index = 0; index < length; ++index)
        map[index]?.display(stats);
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(ConsumeType type) => this.map[type.ordinal()] != null;

    [Signature("<T:Lmindustry/world/consumers/Consume;>(Lmindustry/world/consumers/ConsumeType;)TT;")]
    [LineNumberTable(new byte[] {56, 111, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume get(ConsumeType type)
    {
      if (this.map[type.ordinal()] == null)
      {
        string str = new StringBuilder().append("Block does not contain consumer of type '").append((object) type).append("'!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return this.map[type.ordinal()];
    }

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasPower() => this.has(ConsumeType.__\u003C\u003Epower);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumePower getPower() => (ConsumePower) this.get(ConsumeType.__\u003C\u003Epower);

    [Signature("(Larc/func/Cons<Lmindustry/world/consumers/Consume;>;)V")]
    [LineNumberTable(new byte[] {159, 166, 116, 99, 7, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons c)
    {
      Consume[] map = this.map;
      int length = map.Length;
      for (int index = 0; index < length; ++index)
      {
        Consume consume = map[index];
        if (consume != null)
          c.get((object) consume);
      }
    }

    [LineNumberTable(new byte[] {159, 174, 127, 6, 159, 6, 116, 108, 12, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.results = (Consume[]) Structs.filter((Class) ClassLiteral<Consume>.Value, (object[]) this.map, (Boolf) new Consumers.__\u003C\u003EAnon0());
      this.optionalResults = (Consume[]) Structs.filter((Class) ClassLiteral<Consume>.Value, (object[]) this.map, (Boolf) new Consumers.__\u003C\u003EAnon1());
      Consume[] results = this.results;
      int length = results.Length;
      for (int index = 0; index < length; ++index)
      {
        Consume consume = results[index];
        consume.applyItemFilter(this.__\u003C\u003EitemFilters);
        consume.applyLiquidFilter(this.__\u003C\u003Eliquidfilters);
      }
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumePower power(float powerPerTick) => (ConsumePower) this.add((Consume) new ConsumePower(powerPerTick, 0.0f, false));

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeItems item(Item item) => this.item(item, 1);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeItems items(params ItemStack[] items) => (ConsumeItems) this.add((Consume) new ConsumeItems(items));

    [Signature("<T:Lmindustry/world/consumers/Consume;>(TT;)TT;")]
    [LineNumberTable(new byte[] {42, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume add(Consume consume)
    {
      this.map[consume.type().ordinal()] = consume;
      return consume;
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumePower powerBuffered(float powerCapacity) => (ConsumePower) this.add((Consume) new ConsumePower(0.0f, powerCapacity, true));

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeLiquid liquid(Liquid liquid, float amount) => (ConsumeLiquid) this.add((Consume) new ConsumeLiquid(liquid, amount));

    [Signature("<T:Lmindustry/gen/Building;>(FLarc/func/Boolf<TT;>;)Lmindustry/world/consumers/ConsumePower;")]
    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumePower powerCond(float usage, Boolf cons) => (ConsumePower) this.add((Consume) new ConditionalConsumePower(usage, cons));

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeItems item(Item item, int amount) => (ConsumeItems) this.add((Consume) new ConsumeItems(new ItemStack[1]
    {
      new ItemStack(item, amount)
    }));

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool any() => this.results != null && this.results.Length > 0;

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume[] all() => this.results;

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeItems getItem() => (ConsumeItems) this.get(ConsumeType.__\u003C\u003Eitem);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00240([In] Consume obj0) => obj0 != null;

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00241([In] Consume obj0) => obj0 != null && obj0.isOptional();

    [LineNumberTable(new byte[] {47, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(ConsumeType type) => this.map[type.ordinal()] = (Consume) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume[] optionals() => this.optionalResults;

    [Modifiers]
    public Bits itemFilters
    {
      [HideFromJava] get => this.__\u003C\u003EitemFilters;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EitemFilters = value;
    }

    [Modifiers]
    public Bits liquidfilters
    {
      [HideFromJava] get => this.__\u003C\u003Eliquidfilters;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eliquidfilters = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Consumers.lambda\u0024init\u00240((Consume) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (Consumers.lambda\u0024init\u00241((Consume) obj0) ? 1 : 0) != 0;
    }
  }
}
