// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.experimental.BlockLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.experimental
{
  public class BlockLoader : PayloadAcceptor
  {
    internal int __\u003C\u003EtimerLoad;
    public float loadTime;
    public int itemsLoaded;
    public float liquidsLoaded;
    public int maxBlockSize;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00242([In] BlockLoader.BlockLoaderBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Prov name = (Prov) new BlockLoader.__\u003C\u003EAnon1(obj0);
      Prov color = (Prov) new BlockLoader.__\u003C\u003EAnon2();
      BlockLoader.BlockLoaderBuild blockLoaderBuild = obj0;
      Objects.requireNonNull((object) blockLoaderBuild);
      Floatp fraction = (Floatp) new BlockLoader.__\u003C\u003EAnon3(blockLoaderBuild);
      return new mindustry.ui.Bar(name, color, fraction);
    }

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] BlockLoader.BlockLoaderBuild obj0) => Core.bundle.format("bar.items", (object) Integer.valueOf(obj0.payload != null ? ((BuildPayload) obj0.payload).build.items.total() : 0));

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.items;

    [LineNumberTable(new byte[] {159, 167, 233, 56, 153, 107, 103, 107, 231, 69, 103, 136, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockLoader(string name)
      : base(name)
    {
      BlockLoader blockLoader1 = this;
      BlockLoader blockLoader2 = this;
      int timers = blockLoader2.timers;
      BlockLoader blockLoader3 = blockLoader2;
      int num = timers;
      blockLoader3.timers = timers + 1;
      this.__\u003C\u003EtimerLoad = num;
      this.loadTime = 2f;
      this.itemsLoaded = 5;
      this.liquidsLoaded = 5f;
      this.maxBlockSize = 2;
      this.hasItems = true;
      this.itemCapacity = 25;
      this.update = true;
      this.outputsPayload = true;
      this.size = 3;
      this.rotate = true;
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[4]
    {
      this.region,
      this.inRegion,
      this.outRegion,
      this.topRegion
    };

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 190, 134, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("progress", (Func) new BlockLoader.__\u003C\u003EAnon0());
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {5, 121, 127, 4, 127, 4, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.region, req.drawx(), req.drawy());
      Draw.rect(this.inRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.rect(this.outRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.rect(this.topRegion, req.drawx(), req.drawy());
    }

    [HideFromJava]
    static BlockLoader() => PayloadAcceptor.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerLoad
    {
      [HideFromJava] get => this.__\u003C\u003EtimerLoad;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerLoad = value;
    }

    [Signature("Lmindustry/world/blocks/production/PayloadAcceptor$PayloadAcceptorBuild<Lmindustry/world/blocks/payloads/BuildPayload;>;")]
    public class BlockLoaderBuild : PayloadAcceptor.PayloadAcceptorBuild
    {
      [Modifiers]
      internal BlockLoader this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(141)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float fraction() => this.payload == null ? 0.0f : (float) ((BuildPayload) this.payload).build.items.total() / (float) ((BuildPayload) this.payload).build.block.itemCapacity;

      [LineNumberTable(new byte[] {95, 118, 127, 49, 31, 34})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool shouldExport() => this.payload != null && (((BuildPayload) this.payload).block().hasLiquids && (double) ((BuildPayload) this.payload).build.liquids.total() >= (double) (((BuildPayload) this.payload).block().liquidCapacity - 1f / 1000f) || ((BuildPayload) this.payload).block().hasItems && ((BuildPayload) this.payload).build.items.total() >= ((BuildPayload) this.payload).block().itemCapacity);

      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockLoaderBuild(BlockLoader _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PayloadAcceptor) _param1);
      }

      [LineNumberTable(new byte[] {16, 35, 106, 127, 22, 31, 24})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload)
      {
        if (base.acceptPayload(source, payload))
        {
          Payload payload1 = payload;
          BuildPayload buildPayload;
          if (payload1 is BuildPayload && object.ReferenceEquals((object) (buildPayload = (BuildPayload) payload1), (object) (BuildPayload) payload1) && (buildPayload.build.block.hasItems && buildPayload.block().unloadable) && (buildPayload.block().itemCapacity >= 10 && buildPayload.block().size <= this.this\u00240.maxBlockSize))
            return true;
        }
        return false;
      }

      [LineNumberTable(73)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.total() < this.this\u00240.itemCapacity;

      [LineNumberTable(new byte[] {28, 188, 98, 102, 114, 127, 8, 226, 61, 230, 70, 159, 10, 159, 4, 106, 109, 134, 106, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        int num = 1;
        for (int direction = 0; direction < 4; ++direction)
        {
          if (this.blends(direction) && direction != this.rotation)
          {
            Draw.rect(this.this\u00240.inRegion, this.x, this.y, (float) (direction * 90 - 180));
            num = 0;
          }
        }
        if (num != 0)
          Draw.rect(this.this\u00240.inRegion, this.x, this.y, (float) (this.rotation * 90));
        Draw.rect(this.this\u00240.outRegion, this.x, this.y, this.rotdeg());
        Draw.z(35f);
        this.payRotation = this.rotdeg();
        this.drawPayload();
        Draw.z(35.1f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(new byte[] {52, 104, 107, 171, 127, 11, 159, 28, 159, 4, 115, 114, 108, 127, 9, 127, 7, 109, 226, 58, 9, 233, 92})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.shouldExport())
        {
          this.moveOutPayload();
        }
        else
        {
          if (!this.moveInPayload() || !((BuildPayload) this.payload).block().hasItems || (!this.items.any() || (double) this.efficiency() <= 0.00999999977648258) || !this.timer(this.this\u00240.__\u003C\u003EtimerLoad, this.this\u00240.loadTime / this.efficiency()))
            return;
          for (int index = 0; index < this.this\u00240.itemsLoaded && this.items.any(); ++index)
          {
            for (int id = 0; id < this.items.length(); ++id)
            {
              if (this.items.get(id) > 0)
              {
                Item obj = Vars.content.item(id);
                if (((BuildPayload) this.payload).build.acceptItem(((BuildPayload) this.payload).build, obj))
                {
                  ((BuildPayload) this.payload).build.handleItem(((BuildPayload) this.payload).build, obj);
                  this.items.remove(obj, 1);
                  break;
                }
              }
            }
          }
        }
      }

      [HideFromJava]
      static BlockLoaderBuild() => PayloadAcceptor.PayloadAcceptorBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) BlockLoader.lambda\u0024setBars\u00242((BlockLoader.BlockLoaderBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly BlockLoader.BlockLoaderBuild arg\u00241;

      internal __\u003C\u003EAnon1([In] BlockLoader.BlockLoaderBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) BlockLoader.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) BlockLoader.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly BlockLoader.BlockLoaderBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] BlockLoader.BlockLoaderBuild obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.fraction();
    }
  }
}
