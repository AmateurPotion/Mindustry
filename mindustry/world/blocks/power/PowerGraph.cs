// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerGraph
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.world.consumers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class PowerGraph : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Queue<Lmindustry/gen/Building;>;")]
    private static Queue queue;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private static Seq outArray1;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private static Seq outArray2;
    [Modifiers]
    private static IntSet closedSet;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq producers;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq consumers;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq batteries;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq all;
    [Modifiers]
    private WindowedMean powerBalance;
    private float lastPowerProduced;
    private float lastPowerNeeded;
    private float lastPowerStored;
    private float lastScaledPowerIn;
    private float lastScaledPowerOut;
    private float lastCapacity;
    private float energyDelta;
    private long lastFrameUpdated;
    [Modifiers]
    private int graphID;
    private static int lastGraphID;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {41, 102, 127, 1, 116, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPowerProduced()
    {
      float num = 0.0f;
      Iterator iterator = this.producers.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        num += building.getPowerProduction() * building.delta();
      }
      return num;
    }

    [LineNumberTable(new byte[] {63, 102, 127, 1, 108, 112, 156, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getBatteryStored()
    {
      float num = 0.0f;
      Iterator iterator = this.batteries.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        Consumers consumes = building.block.__\u003C\u003Econsumes;
        if (building.enabled && consumes.hasPower())
          num += building.power.status * consumes.getPower().__\u003C\u003Ecapacity;
      }
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastPowerStored() => this.lastPowerStored;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastCapacity() => this.lastCapacity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastPowerProduced() => this.lastPowerProduced;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastPowerNeeded() => this.lastPowerNeeded;

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPowerBalance() => this.powerBalance.mean();

    [LineNumberTable(new byte[] {159, 152, 232, 70, 108, 108, 108, 140, 205, 139, 232, 69, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerGraph()
    {
      PowerGraph powerGraph = this;
      this.producers = new Seq(false);
      this.consumers = new Seq(false);
      this.batteries = new Seq(false);
      this.all = new Seq(false);
      this.powerBalance = new WindowedMean(60);
      this.energyDelta = 0.0f;
      this.lastFrameUpdated = -1L;
      this.graphID = PowerGraph.lastGraphID++;
    }

    [LineNumberTable(new byte[] {160, 167, 106, 107, 106, 112, 112, 103, 127, 6, 114, 139, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reflow(Building tile)
    {
      PowerGraph.queue.clear();
      PowerGraph.queue.addLast((object) tile);
      PowerGraph.closedSet.clear();
label_1:
      while (PowerGraph.queue.size > 0)
      {
        Building build = (Building) PowerGraph.queue.removeFirst();
        this.add(build);
        Iterator iterator = build.getPowerConnections(PowerGraph.outArray2).iterator();
        while (true)
        {
          Building building;
          do
          {
            if (iterator.hasNext())
              building = (Building) iterator.next();
            else
              goto label_1;
          }
          while (!PowerGraph.closedSet.add(building.pos()));
          PowerGraph.queue.addLast((object) building);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 138, 138, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addGraph(PowerGraph graph)
    {
      if (object.ReferenceEquals((object) graph, (object) this))
        return;
      Iterator iterator = graph.all.iterator();
      while (iterator.hasNext())
        this.add((Building) iterator.next());
    }

    [LineNumberTable(new byte[] {85, 102, 127, 1, 122, 153, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTotalBatteryCapacity()
    {
      float num = 0.0f;
      Iterator iterator = this.batteries.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building.enabled && building.block.__\u003C\u003Econsumes.hasPower())
          num += building.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity;
      }
      return num;
    }

    [LineNumberTable(new byte[] {160, 146, 140, 127, 4, 108, 108, 140, 127, 18, 108, 110, 122, 110, 109, 110, 109, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Building build)
    {
      if (build == null || build.power == null || object.ReferenceEquals((object) build.power.graph, (object) this) && build.power.init)
        return;
      build.power.graph = this;
      build.power.init = true;
      this.all.add((object) build);
      if (build.block.outputsPower && build.block.consumesPower && !build.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
      {
        this.producers.add((object) build);
        this.consumers.add((object) build);
      }
      else if (build.block.outputsPower && build.block.consumesPower)
        this.batteries.add((object) build);
      else if (build.block.outputsPower)
      {
        this.producers.add((object) build);
      }
      else
      {
        if (!build.block.consumesPower)
          return;
        this.consumers.add((object) build);
      }
    }

    [LineNumberTable(new byte[] {160, 194, 159, 9, 181, 102, 135, 106, 107, 144, 144, 135, 191, 10, 126, 104, 140, 98, 133, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Building tile)
    {
      Iterator iterator1 = tile.getPowerConnections(PowerGraph.outArray1).iterator();
      while (iterator1.hasNext())
      {
        Building build1 = (Building) iterator1.next();
        if (object.ReferenceEquals((object) build1.power.graph, (object) this))
        {
          PowerGraph powerGraph = new PowerGraph();
          powerGraph.add(build1);
          PowerGraph.queue.clear();
          PowerGraph.queue.addLast((object) build1);
label_4:
          while (PowerGraph.queue.size > 0)
          {
            Building build2 = (Building) PowerGraph.queue.removeFirst();
            powerGraph.add(build2);
            Iterator iterator2 = build2.getPowerConnections(PowerGraph.outArray2).iterator();
            while (true)
            {
              Building build3;
              do
              {
                if (iterator2.hasNext())
                  build3 = (Building) iterator2.next();
                else
                  goto label_4;
              }
              while (object.ReferenceEquals((object) build3, (object) tile) || object.ReferenceEquals((object) build3.power.graph, (object) powerGraph));
              powerGraph.add(build3);
              PowerGraph.queue.addLast((object) build3);
            }
          }
          powerGraph.update();
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastScaledPowerIn() => this.lastScaledPowerIn;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLastScaledPowerOut() => this.lastScaledPowerOut;

    [LineNumberTable(new byte[] {160, 93, 114, 97, 159, 8, 127, 1, 112, 130, 118, 161, 144, 104, 137, 103, 136, 119, 110, 109, 141, 127, 9, 139, 159, 11, 106, 101, 110, 104, 112, 103, 210, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Core.graphics.getFrameId() == this.lastFrameUpdated)
        return;
      if (!this.consumers.isEmpty() && ((Building) this.consumers.first()).cheating())
      {
        Iterator iterator = this.consumers.iterator();
        while (iterator.hasNext())
          ((Building) iterator.next()).power.status = 1f;
        PowerGraph powerGraph = this;
        float num1 = 1f;
        double num2 = (double) num1;
        this.lastPowerProduced = num1;
        this.lastPowerNeeded = (float) num2;
      }
      else
      {
        this.lastFrameUpdated = Core.graphics.getFrameId();
        float powerNeeded = this.getPowerNeeded();
        float powerProduced = this.getPowerProduced();
        this.lastPowerNeeded = powerNeeded;
        this.lastPowerProduced = powerProduced;
        this.lastScaledPowerIn = (powerProduced + this.energyDelta) / Time.delta;
        this.lastScaledPowerOut = powerNeeded / Time.delta;
        this.lastCapacity = this.getTotalBatteryCapacity();
        this.lastPowerStored = this.getBatteryStored();
        this.powerBalance.add((this.lastPowerProduced - this.lastPowerNeeded + this.energyDelta) / Time.delta);
        this.energyDelta = 0.0f;
        if (this.consumers.size == 0 && this.producers.size == 0 && this.batteries.size == 0)
          return;
        if (!Mathf.equal(powerNeeded, powerProduced))
        {
          if ((double) powerNeeded > (double) powerProduced)
          {
            float num = this.useBatteries(powerNeeded - powerProduced);
            powerProduced += num;
            this.lastPowerProduced += num;
          }
          else if ((double) powerProduced > (double) powerNeeded)
            powerProduced -= this.chargeBatteries(powerProduced - powerNeeded);
        }
        this.distributePower(powerNeeded, powerProduced);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getUsageFraction() => 1f;

    [LineNumberTable(new byte[] {18, 105, 140, 139, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void transferPower(float amount)
    {
      if ((double) amount > 0.0)
      {
        double num1 = (double) this.chargeBatteries(amount);
      }
      else
      {
        double num2 = (double) this.useBatteries(-amount);
      }
      this.energyDelta += amount;
    }

    [LineNumberTable(new byte[] {110, 136, 113, 147, 127, 4, 109, 113, 105, 110, 191, 9, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float chargeBatteries(float excess)
    {
      float batteryCapacity = this.getBatteryCapacity();
      float num = Math.min(excess / batteryCapacity, 1f);
      if (Mathf.equal(batteryCapacity, 0.0f))
        return 0.0f;
      Iterator iterator = this.batteries.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        Consumers consumes = building.block.__\u003C\u003Econsumes;
        if (building.enabled && consumes.hasPower() && (double) consumes.getPower().__\u003C\u003Ecapacity > 0.0)
          building.power.status += (1f - building.power.status) * num;
      }
      return Math.min(excess, batteryCapacity);
    }

    [LineNumberTable(new byte[] {95, 104, 147, 106, 113, 127, 2, 110, 114, 156, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float useBatteries(float needed)
    {
      float batteryStored = this.getBatteryStored();
      if (Mathf.equal(batteryStored, 0.0f))
        return 0.0f;
      float num1 = Math.min(batteryStored, needed);
      float num2 = Math.min(1f, needed / batteryStored);
      Iterator iterator = this.batteries.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        Consumers consumes = building.block.__\u003C\u003Econsumes;
        if (building.enabled && consumes.hasPower())
          building.power.status *= 1f - num2;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {160, 225, 126, 122, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool otherConsumersAreValid([In] Building obj0, [In] Consume obj1)
    {
      Consume[] consumeArray = obj0.block.__\u003C\u003Econsumes.all();
      int length = consumeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Consume consume = consumeArray[index];
        if (!object.ReferenceEquals((object) consume, (object) obj1) && !consume.isOptional() && !consume.valid(obj0))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {74, 102, 127, 4, 122, 113, 158, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getBatteryCapacity()
    {
      float num = 0.0f;
      Iterator iterator = this.batteries.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building.enabled && building.block.__\u003C\u003Econsumes.hasPower())
        {
          ConsumePower power = building.block.__\u003C\u003Econsumes.getPower();
          num += (1f - building.power.status) * power.__\u003C\u003Ecapacity;
        }
      }
      return num;
    }

    [LineNumberTable(new byte[] {49, 102, 127, 1, 108, 104, 104, 107, 182, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPowerNeeded()
    {
      float num = 0.0f;
      Iterator iterator = this.consumers.iterator();
      while (iterator.hasNext())
      {
        Building entity = (Building) iterator.next();
        Consumers consumes = entity.block.__\u003C\u003Econsumes;
        if (consumes.hasPower())
        {
          ConsumePower power = consumes.getPower();
          if (this.otherConsumersAreValid(entity, (Consume) power))
            num += power.requestedPower(entity) * entity.delta();
        }
      }
      return num;
    }

    [LineNumberTable(new byte[] {160, 65, 127, 28, 127, 4, 108, 107, 104, 105, 145, 119, 127, 10, 165, 107, 142, 159, 15, 114, 240, 69, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void distributePower(float needed, float produced)
    {
      float num1 = !Mathf.zero(needed) || !Mathf.zero(produced) ? (!Mathf.zero(needed) ? Math.min(1f, produced / needed) : 1f) : 0.0f;
      Iterator iterator = this.consumers.iterator();
      while (iterator.hasNext())
      {
        Building entity = (Building) iterator.next();
        Consumers consumes = entity.block.__\u003C\u003Econsumes;
        if (consumes.hasPower())
        {
          ConsumePower power = consumes.getPower();
          if (power.__\u003C\u003Ebuffered)
          {
            if (!Mathf.zero(power.__\u003C\u003Ecapacity))
            {
              float num2 = power.requestedPower(entity) * num1 * entity.delta();
              entity.power.status = Mathf.clamp(entity.power.status + num2 / power.__\u003C\u003Ecapacity);
            }
          }
          else if (this.otherConsumersAreValid(entity, (Consume) power))
          {
            entity.power.status = num1;
          }
          else
          {
            entity.power.status = Math.min(1f, produced / (needed + power.__\u003C\u003Eusage * entity.delta()));
            if (Float.isNaN(entity.power.status))
              entity.power.status = 0.0f;
          }
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getID() => this.graphID;

    [LineNumberTable(new byte[] {27, 109, 102, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getSatisfaction()
    {
      if (Mathf.zero(this.lastPowerProduced))
        return 0.0f;
      return Mathf.zero(this.lastPowerNeeded) ? 1f : Mathf.clamp(this.lastPowerProduced / this.lastPowerNeeded);
    }

    [LineNumberTable(new byte[] {160, 183, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeList(Building build)
    {
      this.all.remove((object) build);
      this.producers.remove((object) build);
      this.consumers.remove((object) build);
      this.batteries.remove((object) build);
    }

    [LineNumberTable(349)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("PowerGraph{producers=").append((object) this.producers).append(", consumers=").append((object) this.consumers).append(", batteries=").append((object) this.batteries).append(", all=").append((object) this.all).append(", lastFrameUpdated=").append(this.lastFrameUpdated).append(", graphID=").append(this.graphID).append('}').toString();

    [LineNumberTable(new byte[] {159, 140, 173, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PowerGraph()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.power.PowerGraph"))
        return;
      PowerGraph.queue = new Queue();
      PowerGraph.outArray1 = new Seq();
      PowerGraph.outArray2 = new Seq();
      PowerGraph.closedSet = new IntSet();
    }
  }
}
