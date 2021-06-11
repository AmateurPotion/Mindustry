// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.GenericCrafter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.type;
using mindustry.world.draw;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class GenericCrafter : Block
  {
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public ItemStack outputItem;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public LiquidStack outputLiquid;
    public float craftTime;
    public Effect craftEffect;
    public Effect updateEffect;
    public float updateEffectChance;
    public DrawBlock drawer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 233, 56, 107, 107, 107, 139, 203, 103, 103, 103, 107, 103, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GenericCrafter(string name)
      : base(name)
    {
      GenericCrafter genericCrafter = this;
      this.craftTime = 80f;
      this.craftEffect = Fx.__\u003C\u003Enone;
      this.updateEffect = Fx.__\u003C\u003Enone;
      this.updateEffectChance = 0.04f;
      this.drawer = new DrawBlock();
      this.update = true;
      this.solid = true;
      this.hasItems = true;
      this.ambientSound = Sounds.machine;
      this.sync = true;
      this.ambientSoundVolume = 0.03f;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Efactory
      });
    }

    [LineNumberTable(new byte[] {159, 182, 102, 159, 3, 104, 182, 104, 159, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.craftTime / 60f, StatUnit.__\u003C\u003Eseconds);
      if (this.outputItem != null)
        this.stats.add(Stat.__\u003C\u003Eoutput, this.outputItem);
      if (this.outputLiquid == null)
        return;
      this.stats.add(Stat.__\u003C\u003Eoutput, this.outputLiquid.liquid, this.outputLiquid.amount * (60f / this.craftTime), true);
    }

    [LineNumberTable(new byte[] {4, 134, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      this.drawer.load((Block) this);
    }

    [LineNumberTable(new byte[] {11, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.outputsLiquid = this.outputLiquid != null;
      base.init();
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => this.drawer.icons((Block) this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => this.outputItem != null;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024000([In] GenericCrafter obj0) => obj0.__\u003C\u003EtimerDump;

    [HideFromJava]
    static GenericCrafter() => Block.__\u003Cclinit\u003E();

    public class GenericCrafterBuild : Building
    {
      public float progress;
      public float totalProgress;
      public float warmup;
      [Modifiers]
      internal GenericCrafter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(75)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GenericCrafterBuild(GenericCrafter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {32, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw() => this.this\u00240.drawer.draw(this);

      [LineNumberTable(new byte[] {37, 127, 22, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => (this.this\u00240.outputItem == null || this.items.get(this.this\u00240.outputItem.item) < this.this\u00240.itemCapacity) && ((this.this\u00240.outputLiquid == null || (double) this.liquids.get(this.this\u00240.outputLiquid.liquid) < (double) (this.this\u00240.liquidCapacity - 1f / 1000f)) && this.enabled);

      [LineNumberTable(new byte[] {45, 139, 127, 1, 117, 156, 115, 191, 49, 188, 112, 134, 109, 117, 54, 230, 69, 109, 191, 8, 124, 179, 127, 6, 183, 109, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.consValid())
        {
          this.progress += this.getProgressIncrease(this.this\u00240.craftTime);
          this.totalProgress += this.delta();
          this.warmup = Mathf.lerpDelta(this.warmup, 1f, 0.02f);
          if (Mathf.chanceDelta((double) this.this\u00240.updateEffectChance))
            this.this\u00240.updateEffect.at(this.getX() + Mathf.range((float) this.this\u00240.size * 4f), this.getY() + (float) Mathf.range(this.this\u00240.size * 4));
        }
        else
          this.warmup = Mathf.lerp(this.warmup, 0.0f, 0.02f);
        if ((double) this.progress >= 1.0)
        {
          this.consume();
          if (this.this\u00240.outputItem != null)
          {
            for (int index = 0; index < this.this\u00240.outputItem.amount; ++index)
              this.offload(this.this\u00240.outputItem.item);
          }
          if (this.this\u00240.outputLiquid != null)
            this.handleLiquid((Building) this, this.this\u00240.outputLiquid.liquid, this.this\u00240.outputLiquid.amount);
          this.this\u00240.craftEffect.at(this.x, this.y);
          this.progress %= 1f;
        }
        if (this.this\u00240.outputItem != null && this.timer(GenericCrafter.access\u0024000(this.this\u00240), 5f))
          this.dump(this.this\u00240.outputItem.item);
        if (this.this\u00240.outputLiquid == null)
          return;
        this.dumpLiquid(this.this\u00240.outputLiquid.liquid);
      }

      [LineNumberTable(136)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => this.this\u00240.itemCapacity;

      [LineNumberTable(141)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => this.cons.valid();

      [LineNumberTable(new byte[] {96, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
        write.f(this.warmup);
      }

      [LineNumberTable(new byte[] {159, 104, 99, 104, 109, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.progress = read.f();
        this.warmup = read.f();
      }

      [HideFromJava]
      static GenericCrafterBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
