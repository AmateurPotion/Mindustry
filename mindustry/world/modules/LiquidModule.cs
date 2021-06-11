// Decompiled with JetBrains decompiler
// Type: mindustry.world.modules.LiquidModule
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.modules
{
  public class LiquidModule : BlockModule
  {
    private const int windowSize = 3;
    private const int updateInterval = 60;
    [Modifiers]
    private static Interval flowTimer;
    private const float pollScl = 20f;
    private float[] liquids;
    private float total;
    private Liquid current;
    private float smoothLiquid;
    private bool hadFlow;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private WindowedMean flow;
    private float lastAdded;
    private float currentFlowRate;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(Liquid liquid) => this.liquids[(int) liquid.__\u003C\u003Eid];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Liquid current() => this.current;

    [LineNumberTable(new byte[] {63, 102, 108, 111, 30, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sum(LiquidModule.LiquidCalculator calc)
    {
      float num = 0.0f;
      for (int id = 0; id < this.liquids.Length; ++id)
      {
        if ((double) this.liquids[id] > 0.0)
          num += calc.get(Vars.content.liquid(id), this.liquids[id]);
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 154, 232, 69, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidModule()
    {
      LiquidModule liquidModule = this;
      this.liquids = new float[Vars.content.liquids().size];
      this.current = Vars.content.liquid(0);
    }

    [LineNumberTable(new byte[] {74, 98, 117, 45, 198, 135, 110, 112, 104, 239, 61, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(Writes write)
    {
      int i1 = 0;
      float[] liquids = this.liquids;
      int length = liquids.Length;
      for (int index = 0; index < length; ++index)
      {
        if ((double) liquids[index] > 0.0)
          ++i1;
      }
      write.s(i1);
      for (int i2 = 0; i2 < this.liquids.Length; ++i2)
      {
        if ((double) this.liquids[i2] > 0.0)
        {
          write.s(i2);
          write.f(this.liquids[i2]);
        }
      }
    }

    [LineNumberTable(new byte[] {159, 107, 98, 112, 107, 146, 102, 114, 105, 106, 105, 145, 240, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(Reads read, bool legacy)
    {
      int num1 = legacy ? 1 : 0;
      Arrays.fill(this.liquids, 0.0f);
      this.total = 0.0f;
      int num2 = num1 == 0 ? (int) read.s() : read.ub();
      for (int index = 0; index < num2; ++index)
      {
        int id = num1 == 0 ? (int) read.s() : read.ub();
        float num3 = read.f();
        this.liquids[id] = num3;
        if ((double) num3 > 0.0)
          this.current = Vars.content.liquid(id);
        this.total += num3;
      }
    }

    [LineNumberTable(new byte[] {41, 120, 112, 135, 104, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Liquid liquid, float amount)
    {
      float[] liquids = this.liquids;
      int id = (int) liquid.__\u003C\u003Eid;
      float[] numArray = liquids;
      numArray[id] = numArray[id] + amount;
      this.total += amount;
      this.current = liquid;
      if (this.flow == null)
        return;
      this.lastAdded += Math.max(amount, 0.0f);
    }

    [LineNumberTable(new byte[] {51, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Liquid liquid, float amount) => this.add(liquid, -amount);

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float currentAmount() => this.liquids[(int) this.current.__\u003C\u003Eid];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float smoothAmount() => this.smoothLiquid;

    [LineNumberTable(new byte[] {55, 108, 111, 25, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(LiquidModule.LiquidConsumer cons)
    {
      for (int id = 0; id < this.liquids.Length; ++id)
      {
        if ((double) this.liquids[id] > 0.0)
          cons.accept(Vars.content.liquid(id), this.liquids[id]);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float total() => this.total;

    [LineNumberTable(new byte[] {159, 136, 162, 126, 102, 149, 116, 148, 113, 107, 126, 223, 16, 107, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(bool showFlow)
    {
      int num = showFlow ? 1 : 0;
      this.smoothLiquid = Mathf.lerpDelta(this.smoothLiquid, this.currentAmount(), 0.1f);
      if (num != 0)
      {
        if (!LiquidModule.flowTimer.get(1, 20f))
          return;
        if (this.flow == null)
          this.flow = new WindowedMean(3);
        if ((double) this.lastAdded > 9.99999974737875E-05)
          this.hadFlow = true;
        this.flow.add(this.lastAdded);
        this.lastAdded = 0.0f;
        if ((double) this.currentFlowRate >= 0.0 && !LiquidModule.flowTimer.get(60f))
          return;
        this.currentFlowRate = !this.flow.hasEnoughData() ? -1f : this.flow.mean() / 20f;
      }
      else
      {
        this.currentFlowRate = -1f;
        this.flow = (WindowedMean) null;
        this.hadFlow = false;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hadFlow() => this.hadFlow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFlowRate() => this.currentFlowRate * 60f;

    [LineNumberTable(new byte[] {36, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.total = 0.0f;
      Arrays.fill(this.liquids, 0.0f);
    }

    [LineNumberTable(new byte[] {21, 112, 111, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(Liquid liquid, float amount)
    {
      Arrays.fill(this.liquids, 0.0f);
      this.liquids[(int) liquid.__\u003C\u003Eid] = amount;
      this.total = amount;
      this.current = liquid;
    }

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LiquidModule()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.modules.LiquidModule"))
        return;
      LiquidModule.flowTimer = new Interval(2);
    }

    public interface LiquidCalculator
    {
      float get(Liquid l, float f);
    }

    public interface LiquidConsumer
    {
      void accept(Liquid l, float f);
    }
  }
}
