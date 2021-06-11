// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumePower
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumePower : Consume
  {
    internal float __\u003C\u003Eusage;
    internal float __\u003C\u003Ecapacity;
    internal bool __\u003C\u003Ebuffered;

    [LineNumberTable(new byte[] {21, 115, 104, 187, 127, 14, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float requestedPower(Building entity)
    {
      if (entity.tile().build == null)
        return 0.0f;
      if (this.__\u003C\u003Ebuffered)
        return (1f - entity.power.status) * this.__\u003C\u003Ecapacity;
      float num;
      try
      {
        num = this.__\u003C\u003Eusage * (float) Mathf.num(entity.shouldConsume());
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return num;
label_8:
      return 0.0f;
    }

    [LineNumberTable(new byte[] {159, 138, 98, 104, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumePower(float usage, float capacity, bool buffered)
    {
      int num = buffered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ConsumePower consumePower = this;
      this.__\u003C\u003Eusage = usage;
      this.__\u003C\u003Ecapacity = capacity;
      this.__\u003C\u003Ebuffered = num != 0;
    }

    [LineNumberTable(new byte[] {159, 166, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ConsumePower()
      : this(0.0f, 0.0f, false)
    {
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ConsumeType type() => ConsumeType.__\u003C\u003Epower;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building tile, Table table)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-power";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity)
    {
    }

    [LineNumberTable(new byte[] {159, 191, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity) => this.__\u003C\u003Ebuffered || (double) entity.power.status > 0.0;

    [LineNumberTable(new byte[] {8, 104, 152, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats)
    {
      if (this.__\u003C\u003Ebuffered)
        stats.add(Stat.__\u003C\u003EpowerCapacity, this.__\u003C\u003Ecapacity, StatUnit.__\u003C\u003Enone);
      else
        stats.add(Stat.__\u003C\u003EpowerUse, this.__\u003C\u003Eusage * 60f, StatUnit.__\u003C\u003EpowerSecond);
    }

    [Modifiers]
    public float usage
    {
      [HideFromJava] get => this.__\u003C\u003Eusage;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eusage = value;
    }

    [Modifiers]
    public float capacity
    {
      [HideFromJava] get => this.__\u003C\u003Ecapacity;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecapacity = value;
    }

    [Modifiers]
    public bool buffered
    {
      [HideFromJava] get => this.__\u003C\u003Ebuffered;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuffered = value;
    }
  }
}
