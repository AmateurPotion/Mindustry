// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.ConstructBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.storage;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks
{
  public class ConstructBlock : Block
  {
    [Modifiers]
    private static ConstructBlock[] consBlocks;
    private static long lastTime;
    private static int pitchSeq;
    private static long lastPlayed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 180, 127, 3, 103, 103, 104, 103, 103, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConstructBlock(int size)
      : base(new StringBuilder().append("build").append(size).toString())
    {
      ConstructBlock constructBlock = this;
      this.size = size;
      this.update = true;
      this.health = 20;
      this.consumesTap = true;
      this.solidifes = true;
      ConstructBlock.consBlocks[size - 1] = this;
      this.sync = true;
    }

    [LineNumberTable(new byte[] {6, 103, 127, 0, 111, 102, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deconstructFinish(Tile tile, Block block, Unit builder)
    {
      Team team = tile.team();
      Fx.__\u003C\u003EbreakBlock.at(tile.drawx(), tile.drawy(), (float) block.size);
      Events.fire((object) new EventType.BlockBuildEndEvent(tile, builder, team, true, (object) null));
      tile.remove();
      if (!ConstructBlock.shouldPlay())
        return;
      Sounds.breaks.at((Position) tile, ConstructBlock.calcPitch(false));
    }

    [LineNumberTable(new byte[] {159, 126, 99, 132, 124, 159, 16, 138, 104, 149, 100, 174, 110, 173, 107, 241, 69, 127, 2, 173, 127, 0, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void constructFinish(
      Tile tile,
      Block block,
      [Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit builder,
      byte rotation,
      Team team,
      object config)
    {
      int rotation1 = (int) (sbyte) rotation;
      if (tile == null)
        return;
      float num = tile.build != null ? tile.build.healthf() : 1f;
      Building build = tile.build;
      ConstructBlock.ConstructBuild constructBuild;
      Seq previous = !(build is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build) ? (Seq) null : constructBuild.prevBuild;
      tile.setBlock(block, team, rotation1);
      if (tile.build != null)
      {
        tile.build.health = (float) block.health * num;
        if (config != null)
          tile.build.configured(builder, config);
        if (previous != null && previous.size > 0)
          tile.build.overwrote(previous);
        if (builder != null && builder.getControllerName() != null)
          tile.build.lastAccessed = builder.getControllerName();
      }
      if (tile.build != null && !Vars.headless && object.ReferenceEquals((object) builder, (object) Vars.player.unit()))
        tile.build.playerPlaced(config);
      Fx.__\u003C\u003EplaceBlock.at(tile.drawx(), tile.drawy(), (float) block.size);
      if (!ConstructBlock.shouldPlay())
        return;
      Sounds.place.at((Position) tile, ConstructBlock.calcPitch(true));
    }

    [LineNumberTable(new byte[] {0, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ConstructBlock get(int size)
    {
      if (size > 16)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("No. Don't place ConstructBlock of size greater than 16");
      }
      return ConstructBlock.consBlocks[size - 1];
    }

    [LineNumberTable(new byte[] {159, 112, 131, 109, 104, 171, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void constructed(
      Tile tile,
      Block block,
      Unit builder,
      byte rotation,
      Team team,
      object config)
    {
      int num = (int) (sbyte) rotation;
      Call.constructFinish(tile, block, builder, (byte) num, team, config);
      if (tile.build != null)
        tile.build.placed();
      Events.fire((object) new EventType.BlockBuildEndEvent(tile, builder, team, false, config));
    }

    [LineNumberTable(new byte[] {48, 111, 106, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool shouldPlay()
    {
      if (Time.timeSinceMillis(ConstructBlock.lastPlayed) < 32L)
        return false;
      ConstructBlock.lastPlayed = Time.millis();
      return true;
    }

    [LineNumberTable(new byte[] {159, 116, 162, 114, 106, 108, 105, 134, 159, 13, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float calcPitch([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      if (Time.timeSinceMillis(ConstructBlock.lastTime) < 480L)
      {
        ConstructBlock.lastTime = Time.millis();
        ++ConstructBlock.pitchSeq;
        if (ConstructBlock.pitchSeq > 30)
          ConstructBlock.pitchSeq = 0;
        return (float) (1.0 + (double) Mathf.clamp((float) ConstructBlock.pitchSeq / 30f) * (num == 0 ? -0.400000005960464 : 1.89999997615814));
      }
      ConstructBlock.pitchSeq = 0;
      ConstructBlock.lastTime = Time.millis();
      return Mathf.random(0.7f, 1.3f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => true;

    [LineNumberTable(new byte[] {159, 135, 178, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ConstructBlock()
    {
      Block.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.ConstructBlock"))
        return;
      ConstructBlock.consBlocks = new ConstructBlock[16];
      ConstructBlock.lastTime = 0L;
      ConstructBlock.pitchSeq = 0;
    }

    public class ConstructBuild : Building
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Block cblock;
      [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Seq prevBuild;
      public float progress;
      public float buildCost;
      public Block previous;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public object lastConfig;
      public bool wasConstructing;
      public bool activeDeconstruct;
      public float constructColor;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Unit lastBuilder;
      private float[] accumulator;
      private float[] totalAccumulator;
      [Modifiers]
      internal ConstructBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 155, 104, 112, 144, 103, 103, 144, 104, 167, 107, 108, 118, 204, 143, 106, 127, 2, 127, 23, 159, 5, 143, 115, 120, 159, 9, 117, 122, 98, 250, 50, 233, 84, 150, 127, 20, 111, 159, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void deconstruct(Unit builder, [Nullable(new object[] {64, "Larc/util/Nullable;"})] Building core, float amount)
      {
        if (this.wasConstructing)
        {
          Arrays.fill(this.accumulator, 0.0f);
          Arrays.fill(this.totalAccumulator, 0.0f);
        }
        this.wasConstructing = false;
        this.activeDeconstruct = true;
        float refundMultiplier = Vars.state.rules.deconstructRefundMultiplier;
        if (builder.isPlayer())
          this.lastBuilder = builder;
        if (this.cblock != null)
        {
          ItemStack[] requirements = this.cblock.requirements;
          if (requirements.Length != this.accumulator.Length || this.totalAccumulator.Length != requirements.Length)
            this.setDeconstruct(this.cblock);
          float num1 = Math.min(amount, this.progress);
          for (int index1 = 0; index1 < requirements.Length; ++index1)
          {
            int num2 = Math.round(Vars.state.rules.buildCostMultiplier * (float) requirements[index1].amount);
            float[] accumulator1 = this.accumulator;
            int index2 = index1;
            float[] numArray1 = accumulator1;
            numArray1[index2] = numArray1[index2] + Math.min(num1 * refundMultiplier * (float) num2, refundMultiplier * (float) num2 - this.totalAccumulator[index1]);
            this.totalAccumulator[index1] = Math.min(this.totalAccumulator[index1] + (float) num2 * num1 * refundMultiplier, (float) num2);
            int num3 = ByteCodeHelper.f2i(this.accumulator[index1]);
            if ((double) num1 > 0.0 && num3 > 0)
            {
              if (core != null && requirements[index1].item.unlockedNow())
              {
                int amount1 = Math.min(num3, ((CoreBlock.CoreBuild) core).storageCapacity - core.items.get(requirements[index1].item));
                core.items.add(requirements[index1].item, amount1);
                float[] accumulator2 = this.accumulator;
                int index3 = index1;
                float[] numArray2 = accumulator2;
                numArray2[index3] = numArray2[index3] - (float) amount1;
              }
              else
              {
                float[] accumulator2 = this.accumulator;
                int index3 = index1;
                float[] numArray2 = accumulator2;
                numArray2[index3] = numArray2[index3] - (float) num3;
              }
            }
          }
        }
        this.progress = Mathf.clamp(this.progress - amount);
        if ((double) this.progress > (this.previous != null ? (double) this.previous.deconstructThreshold : 0.0) && !Vars.state.rules.infiniteResources)
          return;
        if (this.lastBuilder == null)
          this.lastBuilder = builder;
        Call.deconstructFinish(this.tile, this.cblock != null ? this.cblock : this.previous, this.lastBuilder);
      }

      [LineNumberTable(new byte[] {160, 118, 103, 103, 104, 102, 161, 104, 167, 136, 127, 11, 178, 159, 11, 116, 127, 11, 127, 19, 255, 0, 61, 233, 70, 159, 9, 149, 126, 111, 159, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void construct(Unit builder, [Nullable(new object[] {64, "Larc/util/Nullable;"})] Building core, float amount, object config)
      {
        this.wasConstructing = true;
        this.activeDeconstruct = false;
        if (this.cblock == null)
        {
          this.kill();
        }
        else
        {
          if (builder.isPlayer())
            this.lastBuilder = builder;
          this.lastConfig = config;
          if (this.cblock.requirements.Length != this.accumulator.Length || this.totalAccumulator.Length != this.cblock.requirements.Length)
            this.setConstruct(this.previous, this.cblock);
          float num1 = core == null || this.team.rules().infiniteResources ? amount : this.checkRequired(core.items, amount, false);
          for (int index1 = 0; index1 < this.cblock.requirements.Length; ++index1)
          {
            int num2 = Math.round(Vars.state.rules.buildCostMultiplier * (float) this.cblock.requirements[index1].amount);
            float[] accumulator = this.accumulator;
            int index2 = index1;
            float[] numArray = accumulator;
            numArray[index2] = numArray[index2] + Math.min((float) num2 * num1, (float) num2 - this.totalAccumulator[index1] + 1E-05f);
            this.totalAccumulator[index1] = Math.min(this.totalAccumulator[index1] + (float) num2 * num1, (float) num2);
          }
          this.progress = Mathf.clamp(this.progress + (core == null || this.team.rules().infiniteResources ? num1 : this.checkRequired(core.items, num1, true)));
          if ((double) this.progress < 1.0 && !Vars.state.rules.infiniteResources)
            return;
          if (this.lastBuilder == null)
            this.lastBuilder = builder;
          ConstructBlock.constructed(this.tile, this.cblock, this.lastBuilder, (byte) this.rotation, builder.team, config);
        }
      }

      [LineNumberTable(new byte[] {160, 250, 132, 107, 103, 103, 107, 109, 103, 159, 0, 139, 114, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setDeconstruct(Block previous)
      {
        if (previous == null)
          return;
        this.constructColor = 1f;
        this.wasConstructing = false;
        this.previous = previous;
        this.progress = 1f;
        if ((double) previous.buildCost >= 0.00999999977648258)
        {
          this.cblock = previous;
          this.buildCost = previous.buildCost * Vars.state.rules.buildCostMultiplier;
        }
        else
          this.buildCost = 20f;
        this.accumulator = new float[previous.requirements.Length];
        this.totalAccumulator = new float[previous.requirements.Length];
      }

      [LineNumberTable(new byte[] {160, 240, 107, 103, 103, 103, 114, 114, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setConstruct(Block previous, Block block)
      {
        this.constructColor = 0.0f;
        this.wasConstructing = true;
        this.cblock = block;
        this.previous = previous;
        this.accumulator = new float[block.requirements.Length];
        this.totalAccumulator = new float[block.requirements.Length];
        this.buildCost = block.buildCost * Vars.state.rules.buildCostMultiplier;
      }

      [LineNumberTable(new byte[] {159, 63, 162, 131, 116, 127, 11, 143, 125, 107, 136, 159, 2, 170, 141, 186, 99, 250, 45, 233, 89})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float checkRequired([In] ItemModule obj0, [In] float obj1, [In] bool obj2)
      {
        int num1 = obj2 ? 1 : 0;
        float num2 = obj1;
        for (int index1 = 0; index1 < this.cblock.requirements.Length; ++index1)
        {
          int num3 = Math.round(Vars.state.rules.buildCostMultiplier * (float) this.cblock.requirements[index1].amount);
          int num4 = ByteCodeHelper.f2i(this.accumulator[index1]);
          if (obj0.get(this.cblock.requirements[index1].item) == 0 && num3 != 0)
            num2 = 0.0f;
          else if (num4 > 0)
          {
            int amount = Math.min(num4, obj0.get(this.cblock.requirements[index1].item));
            float num5 = (float) amount / (float) num4;
            num2 = Math.min(num2, num2 * num5);
            float[] accumulator = this.accumulator;
            int index2 = index1;
            float[] numArray = accumulator;
            numArray[index2] = numArray[index2] - (float) amount;
            if (num1 != 0)
              obj0.remove(this.cblock.requirements[index1].item, amount);
          }
        }
        return num2;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 99, 149, 151, 102, 117, 108, 144, 127, 10, 229, 59, 230, 73, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00240()
      {
        Draw.color(Pal.accent, Pal.remove, this.constructColor);
        Block block = this.cblock != null ? this.cblock : this.previous;
        if (block != null)
        {
          TextureRegion[] generatedIcons = block.getGeneratedIcons();
          int length = generatedIcons.Length;
          for (int index = 0; index < length; ++index)
          {
            TextureRegion region = generatedIcons[index];
            Shaders.blockbuild.region = region;
            Shaders.blockbuild.progress = this.progress;
            Draw.rect(region, this.x, this.y, !block.rotate ? 0.0f : this.rotdeg());
            Draw.flush();
          }
        }
        Draw.color();
      }

      [LineNumberTable(new byte[] {85, 239, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConstructBuild(ConstructBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ConstructBlock.ConstructBuild constructBuild = this;
        this.progress = 0.0f;
      }

      [LineNumberTable(162)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string getDisplayName() => Core.bundle.format("block.constructing", this.cblock != null ? (object) this.cblock.localizedName : (object) this.previous.localizedName);

      [LineNumberTable(167)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override TextureRegion getDisplayIcon() => (this.cblock != null ? (UnlockableContent) this.cblock : (UnlockableContent) this.previous).icon(Cicon.__\u003C\u003Efull);

      [LineNumberTable(172)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool checkSolid() => this.cblock != null && this.cblock.solid || (this.previous == null || this.previous.solid);

      [LineNumberTable(177)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Graphics.Cursor getCursor() => this.interactable(Vars.player.team()) ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand : (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;

      [LineNumberTable(new byte[] {160, 69, 107, 127, 15, 144, 159, 30})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void tapped()
      {
        if (this.cblock == null)
          return;
        if (Vars.control.input.buildWasAutoPaused && !Vars.control.input.isBuilding && Vars.player.isBuilder())
          Vars.control.input.isBuilding = true;
        Vars.player.unit().addBuild(new BuildPlan((int) this.tile.x, (int) this.tile.y, this.rotation, this.cblock, this.lastConfig), false);
      }

      [LineNumberTable(new byte[] {160, 79, 144, 127, 5, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onDestroyed()
      {
        Fx.__\u003C\u003EblockExplosionSmoke.at((Position) this.tile);
        if (this.tile.floor().solid || !this.tile.floor().hasSurface())
          return;
        Effect.rubble(this.x, this.y, this.this\u00240.size);
      }

      [LineNumberTable(new byte[] {160, 88, 127, 12, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.constructColor = Mathf.lerpDelta(this.constructColor, !this.activeDeconstruct ? 0.0f : 1f, 0.2f);
        this.activeDeconstruct = false;
      }

      [LineNumberTable(new byte[] {160, 94, 127, 35, 191, 29, 245, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        if (this.previous != null && this.cblock != null && (!object.ReferenceEquals((object) this.previous, (object) this.cblock) && Core.atlas.isFound(this.previous.icon(Cicon.__\u003C\u003Efull))))
          Draw.rect(this.previous.icon(Cicon.__\u003C\u003Efull), this.x, this.y, !this.previous.rotate ? 0.0f : this.rotdeg());
        Draw.draw(40f, (Runnable) new ConstructBlock.ConstructBuild.__\u003C\u003EAnon0(this));
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float progress() => this.progress;

      [LineNumberTable(new byte[] {161, 12, 103, 108, 124, 156, 104, 137, 109, 108, 110, 14, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
        write.s(this.previous != null ? (int) this.previous.__\u003C\u003Eid : -1);
        write.s(this.cblock != null ? (int) this.cblock.__\u003C\u003Eid : -1);
        if (this.accumulator == null)
        {
          write.b(-1);
        }
        else
        {
          write.b(this.accumulator.Length);
          for (int index = 0; index < this.accumulator.Length; ++index)
          {
            write.f(this.accumulator[index]);
            write.f(this.totalAccumulator[index]);
          }
        }
      }

      [LineNumberTable(new byte[] {159, 42, 67, 104, 109, 103, 103, 136, 100, 108, 108, 104, 112, 16, 232, 70, 117, 149, 104, 159, 5, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.progress = read.f();
        int id1 = (int) read.s();
        int id2 = (int) read.s();
        int length = (int) (sbyte) read.b();
        if (length != -1)
        {
          this.accumulator = new float[length];
          this.totalAccumulator = new float[length];
          for (int index = 0; index < length; ++index)
          {
            this.accumulator[index] = read.f();
            this.totalAccumulator[index] = read.f();
          }
        }
        if (id1 != -1)
          this.previous = Vars.content.block(id1);
        if (id2 != -1)
          this.cblock = Vars.content.block(id2);
        if (this.cblock != null)
          this.buildCost = this.cblock.buildCost * Vars.state.rules.buildCostMultiplier;
        else
          this.buildCost = 20f;
      }

      [HideFromJava]
      static ConstructBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly ConstructBlock.ConstructBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ConstructBlock.ConstructBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00240();
      }
    }
  }
}
