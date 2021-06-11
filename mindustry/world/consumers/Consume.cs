// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.Consume
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.consumers
{
  public abstract class Consume : Object
  {
    protected internal bool optional;
    protected internal bool booster;
    protected internal bool update;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOptional() => this.optional;

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume boost() => this.optional(true, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume update(bool update)
    {
      this.update = update;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Consume optional(bool optional, bool boost)
    {
      int num1 = optional ? 1 : 0;
      int num2 = boost ? 1 : 0;
      this.optional = num1 != 0;
      this.booster = num2 != 0;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBoost() => this.booster;

    public abstract void build(Building b, Table t);

    public abstract bool valid(Building b);

    public abstract void update(Building b);

    [LineNumberTable(new byte[] {159, 151, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Consume()
    {
      Consume consume = this;
      this.update = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyItemFilter(Bits filter)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyLiquidFilter(Bits filter)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUpdate() => this.update;

    public abstract ConsumeType type();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trigger(Building entity)
    {
    }

    public abstract string getIcon();

    public abstract void display(Stats s);
  }
}
