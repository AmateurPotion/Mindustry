// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.experimental.BlockForge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.production;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.experimental
{
  public class BlockForge : PayloadAcceptor
  {
    public float buildSpeed;
    public int minBlockSize;
    public int maxBlockSize;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 121, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] BlockForge.BlockForgeBuild obj0, [In] Block obj1)
    {
      if (!object.ReferenceEquals((object) obj0.recipe, (object) obj1))
        obj0.progress = 0.0f;
      obj0.recipe = obj1;
    }

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ItemStack[] lambda\u0024new\u00241([In] BlockForge.BlockForgeBuild obj0) => obj0.recipe != null ? obj0.recipe.requirements : ItemStack.__\u003C\u003Eempty;

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00243([In] BlockForge.BlockForgeBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar("bar.progress", Pal.ammo, (Floatp) new BlockForge.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] BlockForge.BlockForgeBuild obj0) => obj0.recipe == null ? 0.0f : obj0.progress / obj0.recipe.buildCost;

    [LineNumberTable(new byte[] {159, 172, 233, 60, 107, 238, 69, 103, 103, 103, 103, 103, 103, 135, 245, 69, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockForge(string name)
      : base(name)
    {
      BlockForge blockForge = this;
      this.buildSpeed = 0.4f;
      this.minBlockSize = 1;
      this.maxBlockSize = 2;
      this.size = 3;
      this.update = true;
      this.outputsPayload = true;
      this.hasItems = true;
      this.configurable = true;
      this.hasPower = true;
      this.rotate = true;
      this.config((Class) ClassLiteral<Block>.Value, (Cons2) new BlockForge.__\u003C\u003EAnon0());
      this.__\u003C\u003Econsumes.add((Consume) new ConsumeItemDynamic((Func) new BlockForge.__\u003C\u003EAnon1()));
    }

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.region,
      this.outRegion
    };

    [LineNumberTable(new byte[] {5, 134, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("progress", (Func) new BlockForge.__\u003C\u003EAnon2());
    }

    [LineNumberTable(new byte[] {12, 134, 127, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eoutput, "@x@ ~ @x@", (object) Integer.valueOf(this.minBlockSize), (object) Integer.valueOf(this.minBlockSize), (object) Integer.valueOf(this.maxBlockSize), (object) Integer.valueOf(this.maxBlockSize));
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {20, 121, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.region, req.drawx(), req.drawy());
      Draw.rect(this.outRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
    }

    [HideFromJava]
    static BlockForge() => PayloadAcceptor.__\u003Cclinit\u003E();

    [Signature("Lmindustry/world/blocks/production/PayloadAcceptor$PayloadAcceptorBuild<Lmindustry/world/blocks/payloads/BuildPayload;>;")]
    public class BlockForgeBuild : PayloadAcceptor.PayloadAcceptorBuild
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Block recipe;
      public float progress;
      public float time;
      public float heat;
      [Modifiers]
      internal BlockForge this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {35, 106, 121, 55, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item)
      {
        if (this.recipe == null)
          return 0;
        ItemStack[] requirements = this.recipe.requirements;
        int length = requirements.Length;
        for (int index = 0; index < length; ++index)
        {
          ItemStack itemStack = requirements[index];
          if (object.ReferenceEquals((object) itemStack.item, (object) item))
            return itemStack.amount * 2;
        }
        return 0;
      }

      [Modifiers]
      [LineNumberTable(120)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024buildConfiguration\u00240([In] Block obj0) => obj0.isVisible() && obj0.size >= this.this\u00240.minBlockSize && obj0.size <= this.this\u00240.maxBlockSize;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Block lambda\u0024buildConfiguration\u00241() => this.recipe;

      [Modifiers]
      [LineNumberTable(136)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00242() => Drawf.construct((Building) this, (UnlockableContent) this.recipe, 0.0f, this.progress / this.recipe.buildCost, this.heat, this.time);

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockForgeBuild(BlockForge _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PayloadAcceptor) _param1);
      }

      [LineNumberTable(80)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.get(item) < this.getMaximumAccepted(item);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload) => false;

      [LineNumberTable(new byte[] {49, 157, 99, 159, 3, 115, 102, 119, 108, 211, 126, 157, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        int num = this.recipe == null || !this.consValid() || this.payload != null ? 0 : 1;
        if (num != 0)
        {
          this.progress += this.this\u00240.buildSpeed * this.edelta();
          if ((double) this.progress >= (double) this.recipe.buildCost)
          {
            this.consume();
            this.payload = (Payload) new BuildPayload(this.recipe, this.team);
            this.payVector.setZero();
            this.progress %= 1f;
          }
        }
        this.heat = Mathf.lerpDelta(this.heat, (float) Mathf.num(num != 0), 0.3f);
        this.time += this.heat * this.delta();
        this.moveOutPayload();
      }

      [LineNumberTable(new byte[] {70, 155, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table)
      {
        Seq items = Vars.content.blocks().select((Boolf) new BlockForge.BlockForgeBuild.__\u003C\u003EAnon0(this));
        ItemSelection.buildTable(table, items, (Prov) new BlockForge.BlockForgeBuild.__\u003C\u003EAnon1(this), (Cons) new BlockForge.BlockForgeBuild.__\u003C\u003EAnon2(this));
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object config() => (object) this.recipe;

      [LineNumberTable(new byte[] {82, 124, 159, 4, 104, 181, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Draw.rect(this.this\u00240.outRegion, this.x, this.y, this.rotdeg());
        if (this.recipe != null)
          Draw.draw(35f, (Runnable) new BlockForge.BlockForgeBuild.__\u003C\u003EAnon3(this));
        this.drawPayload();
      }

      [LineNumberTable(new byte[] {94, 107, 127, 29, 113, 143, 127, 29, 101, 159, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        if (this.recipe == null)
          return;
        float x = this.x - (float) (this.this\u00240.size * 8) / 2f;
        float y = this.y + (float) (this.this\u00240.size * 8) / 2f;
        TextureRegion region = this.recipe.icon(Cicon.__\u003C\u003Emedium);
        Draw.mixcol(Color.__\u003C\u003EdarkGray, 1f);
        Draw.rect(region, x - 0.7f, y - 1f, Draw.scl * Draw.xscl * 24f, Draw.scl * Draw.yscl * 24f);
        Draw.reset();
        Draw.rect(region, x, y, Draw.scl * Draw.xscl * 24f, Draw.scl * Draw.yscl * 24f);
      }

      [LineNumberTable(new byte[] {107, 103, 124, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.s(this.recipe != null ? (int) this.recipe.__\u003C\u003Eid : -1);
        write.f(this.progress);
      }

      [LineNumberTable(new byte[] {159, 101, 67, 104, 118, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.recipe = Vars.content.block((int) read.s());
        this.progress = read.f();
      }

      [HideFromJava]
      static BlockForgeBuild() => PayloadAcceptor.PayloadAcceptorBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly BlockForge.BlockForgeBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] BlockForge.BlockForgeBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024buildConfiguration\u00240((Block) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Prov
      {
        private readonly BlockForge.BlockForgeBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] BlockForge.BlockForgeBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly BlockForge.BlockForgeBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] BlockForge.BlockForgeBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.configure((object) (Block) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly BlockForge.BlockForgeBuild arg\u00241;

        internal __\u003C\u003EAnon3([In] BlockForge.BlockForgeBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00242();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => BlockForge.lambda\u0024new\u00240((BlockForge.BlockForgeBuild) obj0, (Block) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Func
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get([In] object obj0) => (object) BlockForge.lambda\u0024new\u00241((BlockForge.BlockForgeBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Func
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get([In] object obj0) => (object) BlockForge.lambda\u0024setBars\u00243((BlockForge.BlockForgeBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly BlockForge.BlockForgeBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] BlockForge.BlockForgeBuild obj0) => this.arg\u00241 = obj0;

      public float get() => BlockForge.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
