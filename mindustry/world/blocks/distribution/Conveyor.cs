// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.Conveyor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.input;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.distribution
{
  [Implements(new string[] {"mindustry.world.blocks.Autotiler"})]
  public class Conveyor : Block, Autotiler
  {
    private const float itemSpace = 0.4f;
    private const int capacity = 4;
    [Modifiers]
    internal Vec2 tr1;
    [Modifiers]
    internal Vec2 tr2;
    public TextureRegion[][] regions;
    public float speed;
    public float displayedSpeed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [HideFromJava]
    public virtual int[] getTiling([In] BuildPlan obj0, [In] Eachable obj1) => Autotiler.\u003Cdefault\u003EgetTiling((Autotiler) this, obj0, obj1);

    [HideFromJava]
    public virtual bool lookingAt([In] Tile obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] Block obj4) => Autotiler.\u003Cdefault\u003ElookingAt((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

    [HideFromJava]
    public virtual bool lookingAtEither(
      [In] Tile obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Block obj5)
    {
      return Autotiler.\u003Cdefault\u003ElookingAtEither((Autotiler) this, obj0, obj1, obj2, obj3, obj4, obj5);
    }

    [Modifiers]
    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getReplacement\u00241([In] Seq obj0, [In] BuildPlan obj1, [In] Point2 obj2) => obj0.contains((Boolf) new Conveyor.__\u003C\u003EAnon1(obj1, obj2));

    [Modifiers]
    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getReplacement\u00240(
      [In] BuildPlan obj0,
      [In] Point2 obj1,
      [In] BuildPlan obj2)
    {
      return obj2.x == obj0.x + obj1.x && obj2.y == obj0.y + obj1.y && (obj0.block is Conveyor || obj0.block is Junction);
    }

    [LineNumberTable(new byte[] {159, 179, 233, 55, 107, 203, 107, 203, 103, 103, 107, 103, 103, 135, 107, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Conveyor(string name)
      : base(name)
    {
      Conveyor conveyor = this;
      this.tr1 = new Vec2();
      this.tr2 = new Vec2();
      this.speed = 0.0f;
      this.displayedSpeed = 0.0f;
      this.rotate = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.hasItems = true;
      this.itemCapacity = 4;
      this.conveyorPlacement = true;
      this.ambientSound = Sounds.conveyor;
      this.ambientSoundVolume = 0.0022f;
      this.unloadable = false;
      this.noUpdateDisabled = false;
    }

    [LineNumberTable(new byte[] {3, 166, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EitemsMoved, this.displayedSpeed, StatUnit.__\u003C\u003EitemsSecond);
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {11, 137, 132, 109, 127, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      int[] tiling = this.getTiling(req, list);
      if (tiling == null)
        return;
      TextureRegion region = this.regions[tiling[0]][0];
      Draw.rect(region, req.drawx(), req.drawy(), (float) (region.width * tiling[1]) * Draw.scl, (float) (region.height * tiling[2]) * Draw.scl, (float) (req.rotation * 90));
    }

    [LineNumberTable(new byte[] {21, 127, 12, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool blends(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock)
    {
      return (otherblock.outputsItems() || this.lookingAt(tile, rotation, otherx, othery, otherblock) && otherblock.hasItems) && this.lookingAtEither(tile, rotation, otherx, othery, otherrot, otherblock);
    }

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canReplace(Block other) => base.canReplace(other) && !(other is StackConveyor);

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {33, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void handlePlacementLine(Seq plans) => Placement.calculateBridges(plans, (ItemBridge) Blocks.itemBridge);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[1]
    {
      this.regions[0][0]
    };

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isAccessible() => true;

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)Lmindustry/world/Block;")]
    [LineNumberTable(new byte[] {48, 205, 231, 61, 117, 109, 104, 114, 255, 8, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Block getReplacement(BuildPlan req, Seq requests)
    {
      Boolf boolf = (Boolf) new Conveyor.__\u003C\u003EAnon0(requests, req);
      return boolf.get((object) Geometry.d4(req.rotation)) && boolf.get((object) Geometry.d4(req.rotation - 2)) && (req.tile() != null && req.tile().block() is Conveyor) && Mathf.mod(req.tile().build.rotation - req.rotation, 2) == 1 ? Blocks.junction : (Block) this;
    }

    [HideFromJava]
    public virtual TextureRegion sliced([In] TextureRegion obj0, [In] Autotiler.SliceMode obj1) => Autotiler.\u003Cdefault\u003Esliced((Autotiler) this, obj0, obj1);

    [HideFromJava]
    public virtual TextureRegion topHalf([In] TextureRegion obj0) => Autotiler.\u003Cdefault\u003EtopHalf((Autotiler) this, obj0);

    [HideFromJava]
    public virtual TextureRegion botHalf([In] TextureRegion obj0) => Autotiler.\u003Cdefault\u003EbotHalf((Autotiler) this, obj0);

    [HideFromJava]
    public virtual int[] buildBlending([In] Tile obj0, [In] int obj1, [In] BuildPlan[] obj2, [In] bool obj3) => Autotiler.\u003Cdefault\u003EbuildBlending((Autotiler) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual void transformCase([In] int obj0, [In] int[] obj1) => Autotiler.\u003Cdefault\u003EtransformCase((Autotiler) this, obj0, obj1);

    [HideFromJava]
    public virtual bool facing([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4) => Autotiler.\u003Cdefault\u003Efacing((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

    [HideFromJava]
    public virtual bool blends([In] Tile obj0, [In] int obj1, [In] BuildPlan[] obj2, [In] int obj3, [In] bool obj4) => Autotiler.\u003Cdefault\u003Eblends((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

    [HideFromJava]
    public virtual bool blends([In] Tile obj0, [In] int obj1, [In] int obj2) => Autotiler.\u003Cdefault\u003Eblends((Autotiler) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool blendsArmored(
      [In] Tile obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Block obj5)
    {
      return Autotiler.\u003Cdefault\u003EblendsArmored((Autotiler) this, obj0, obj1, obj2, obj3, obj4, obj5);
    }

    [HideFromJava]
    public virtual bool notLookingAt(
      [In] Tile obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Block obj5)
    {
      return Autotiler.\u003Cdefault\u003EnotLookingAt((Autotiler) this, obj0, obj1, obj2, obj3, obj4, obj5);
    }

    [HideFromJava]
    static Conveyor() => Block.__\u003Cclinit\u003E();

    [Implements(new string[] {"mindustry.world.blocks.distribution.ChainedBuilding"})]
    public class ConveyorBuild : Building, ChainedBuilding
    {
      public Item[] ids;
      public float[] xs;
      public float[] ys;
      public int len;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Building next;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Conveyor.ConveyorBuild nextc;
      public bool aligned;
      public int lastInserted;
      public int mid;
      public float minitem;
      public int blendbits;
      public int blending;
      public int blendsclx;
      public int blendscly;
      public float clogHeat;
      [Modifiers]
      internal Conveyor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 162, 127, 19, 109, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool pass(Item item)
      {
        if (item == null || this.next == null || (!object.ReferenceEquals((object) this.next.team, (object) this.team) || !this.next.acceptItem((Building) this, item)))
          return false;
        this.next.handleItem((Building) this, item);
        return true;
      }

      [LineNumberTable(new byte[] {161, 34, 109, 114, 114, 242, 61, 230, 70, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public void remove(int o)
      {
        for (int index = o; index < this.len - 1; ++index)
        {
          this.ids[index] = this.ids[index + 1];
          this.xs[index] = this.xs[index + 1];
          this.ys[index] = this.ys[index + 1];
        }
        --this.len;
      }

      [LineNumberTable(new byte[] {161, 24, 115, 114, 114, 242, 61, 230, 70, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public void add(int o)
      {
        for (int index = Math.max(o + 1, this.len); index > o; index += -1)
        {
          this.ids[index] = this.ids[index - 1];
          this.xs[index] = this.xs[index - 1];
          this.ys[index] = this.ys[index - 1];
        }
        ++this.len;
      }

      [LineNumberTable(new byte[] {160, 116, 107, 167, 104, 107, 102, 161, 127, 21, 149, 112, 127, 5, 153, 153, 116, 127, 2, 159, 14, 159, 3, 104, 191, 0, 123, 116, 112, 238, 45, 233, 87, 127, 5, 158, 171, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.minitem = 1f;
        this.mid = 0;
        if (this.len == 0)
        {
          this.clogHeat = 0.0f;
          this.sleep();
        }
        else
        {
          float num1 = !this.aligned ? 1f : 1f - Math.max(0.4f - this.nextc.minitem, 0.0f);
          float max = this.this\u00240.speed * this.edelta();
          for (int index1 = this.len - 1; index1 >= 0; index1 += -1)
          {
            float num2 = Mathf.clamp((float) ((index1 != this.len - 1 ? (double) this.ys[index1 + 1] : 100.0) - 0.400000005960464) - this.ys[index1], 0.0f, max);
            float[] ys = this.ys;
            int index2 = index1;
            float[] numArray = ys;
            numArray[index2] = numArray[index2] + num2;
            if ((double) this.ys[index1] > (double) num1)
              this.ys[index1] = num1;
            if ((double) this.ys[index1] > 0.5 && index1 > 0)
              this.mid = index1 - 1;
            this.xs[index1] = Mathf.approachDelta(this.xs[index1], 0.0f, this.this\u00240.speed * 2f);
            if ((double) this.ys[index1] >= 1.0 && this.pass(this.ids[index1]))
            {
              if (this.aligned)
                this.nextc.xs[this.nextc.lastInserted] = this.xs[index1];
              this.items.remove(this.ids[index1], this.len - index1);
              this.len = Math.min(index1, this.len);
            }
            else if ((double) this.ys[index1] < (double) this.minitem)
              this.minitem = this.ys[index1];
          }
          this.clogHeat = (double) this.minitem >= 0.400000005960464 + (this.blendbits != 1 ? 0.0 : 0.300000011920929) ? 0.0f : Mathf.lerpDelta(this.clogHeat, 1f, 0.02f);
          this.noSleep();
        }
      }

      [LineNumberTable(new byte[] {56, 143, 108, 108, 140, 231, 72, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConveyorBuild(Conveyor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Conveyor.ConveyorBuild conveyorBuild = this;
        this.ids = new Item[4];
        this.xs = new float[4];
        this.ys = new float[4];
        this.len = 0;
        this.minitem = 1f;
        this.clogHeat = 0.0f;
      }

      [LineNumberTable(new byte[] {79, 191, 39, 106, 105, 114, 105, 149, 255, 64, 59, 233, 73, 138, 159, 34, 138, 110, 106, 127, 6, 159, 23, 255, 116, 59, 233, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        int index1 = !this.enabled || (double) this.clogHeat > 0.5 ? 0 : ByteCodeHelper.f2i(Time.time * this.this\u00240.speed * 8f * this.timeScale % 4f);
        Draw.z(29.5f);
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if ((this.blending & 1 << index2) != 0)
          {
            int i = this.rotation - index2;
            float rotation = index2 != 0 ? (float) (i * 90) : (float) (this.rotation * 90);
            Draw.rect(this.this\u00240.sliced(this.this\u00240.regions[0][index1], index2 == 0 ? Autotiler.SliceMode.__\u003C\u003Etop : Autotiler.SliceMode.__\u003C\u003Ebottom), this.x + (float) (Geometry.d4x(i) * 8) * 0.75f, this.y + (float) (Geometry.d4y(i) * 8) * 0.75f, rotation);
          }
        }
        Draw.z(29.8f);
        Draw.rect(this.this\u00240.regions[this.blendbits][index1], this.x, this.y, (float) (8 * this.blendsclx), (float) (8 * this.blendscly), (float) (this.rotation * 90));
        Draw.z(29.9f);
        for (int index2 = 0; index2 < this.len; ++index2)
        {
          Item id = this.ids[index2];
          this.this\u00240.tr1.trns((float) (this.rotation * 90), 8f, 0.0f);
          this.this\u00240.tr2.trns((float) (this.rotation * 90), -4f, this.xs[index2] * 8f / 2f);
          Draw.rect(id.icon(Cicon.__\u003C\u003Emedium), (float) ((int) this.tile.x * 8) + this.this\u00240.tr1.x * this.ys[index2] + this.this\u00240.tr2.x, (float) ((int) this.tile.y * 8) + this.this\u00240.tr1.y * this.ys[index2] + this.this\u00240.tr2.y, 5f, 5f);
        }
      }

      [LineNumberTable(new byte[] {112, 106, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawCracks()
      {
        Draw.z(29.85f);
        base.drawCracks();
      }

      [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
      [LineNumberTable(new byte[] {118, 127, 11, 118, 118, 118, 108, 108, 108, 108, 108, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void overwrote(Seq builds)
      {
        object obj = builds.first();
        Conveyor.ConveyorBuild conveyorBuild;
        if (!(obj is Conveyor.ConveyorBuild) || !object.ReferenceEquals((object) (conveyorBuild = (Conveyor.ConveyorBuild) obj), (object) (Conveyor.ConveyorBuild) obj))
          return;
        this.ids = (Item[]) conveyorBuild.ids.Clone();
        this.xs = (float[]) conveyorBuild.xs.Clone();
        this.ys = (float[]) conveyorBuild.ys.Clone();
        this.len = conveyorBuild.len;
        this.clogHeat = conveyorBuild.clogHeat;
        this.lastInserted = conveyorBuild.lastInserted;
        this.mid = conveyorBuild.mid;
        this.minitem = conveyorBuild.minitem;
        this.items.add(conveyorBuild.items);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => (double) this.clogHeat <= 0.5;

      [LineNumberTable(new byte[] {160, 74, 134, 122, 105, 105, 105, 137, 108, 127, 26, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        int[] numArray = this.this\u00240.buildBlending(this.tile, this.rotation, (BuildPlan[]) null, true);
        this.blendbits = numArray[0];
        this.blendsclx = numArray[1];
        this.blendscly = numArray[2];
        this.blending = numArray[4];
        this.next = this.front();
        this.nextc = !(this.next is Conveyor.ConveyorBuild) || !object.ReferenceEquals((object) this.next.team, (object) this.team) ? (Conveyor.ConveyorBuild) null : (Conveyor.ConveyorBuild) this.next;
        this.aligned = this.nextc != null && this.rotation == this.next.rotation;
      }

      [LineNumberTable(new byte[] {160, 90, 150, 134, 122, 102, 102, 155, 142, 113, 125, 159, 6, 125, 191, 4, 117, 159, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void unitOn(Unit unit)
      {
        if ((double) this.clogHeat > 0.5 || !this.enabled)
          return;
        this.noSleep();
        float num1 = this.this\u00240.speed * 8f * 55f;
        float max = 0.1f;
        float num2 = 3f;
        float num3 = (float) Geometry.d4x(this.rotation);
        float num4 = (float) Geometry.d4y(this.rotation);
        float num5 = 0.0f;
        float num6 = 0.0f;
        if ((double) Math.abs(num3) > (double) Math.abs(num4))
        {
          num6 = Mathf.clamp((this.y - unit.y()) / num2, -max, max);
          if ((double) Math.abs(this.y - unit.y()) < 1.0)
            num6 = 0.0f;
        }
        else
        {
          num5 = Mathf.clamp((this.x - unit.x()) / num2, -max, max);
          if ((double) Math.abs(this.x - unit.x()) < 1.0)
            num5 = 0.0f;
        }
        if ((double) ((float) this.len * 0.4f) >= 0.899999976158142)
          return;
        unit.impulse((num3 * num1 + num5) * this.delta(), (num4 * num1 + num6) * this.delta());
      }

      [LineNumberTable(new byte[] {160, 171, 102, 130, 102, 107, 112, 103, 100, 226, 60, 38, 230, 74, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount)
      {
        this.noSleep();
        int amount1 = 0;
        for (int index = 0; index < amount; ++index)
        {
          for (int o = 0; o < this.len; ++o)
          {
            if (object.ReferenceEquals((object) this.ids[o], (object) item))
            {
              this.remove(o);
              ++amount1;
              break;
            }
          }
        }
        this.items.remove(item, amount1);
        return amount1;
      }

      [LineNumberTable(new byte[] {160, 190, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void getStackOffset(Item item, Vec2 trns) => trns.trns(this.rotdeg() + 180f, 4f);

      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int acceptStack(Item item, int amount, Teamc source) => Math.min(ByteCodeHelper.f2i(this.minitem / 0.4f), amount);

      [LineNumberTable(new byte[] {160, 200, 154, 104, 103, 109, 113, 105, 237, 59, 230, 72, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleStack(Item item, int amount, Teamc source)
      {
        amount = Math.min(amount, this.this\u00240.itemCapacity - this.len);
        for (int index = amount - 1; index >= 0; index += -1)
        {
          this.add(0);
          this.xs[0] = 0.0f;
          this.ys[0] = (float) index * 0.4f;
          this.ids[0] = item;
          this.items.add(item, 1);
        }
        this.noSleep();
      }

      [LineNumberTable(new byte[] {160, 215, 107, 114, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        if (this.len >= 4)
          return false;
        int num1 = Math.abs((int) (sbyte) Edges.getFacingEdge(source.tile, this.tile).relativeTo((int) this.tile.x, (int) this.tile.y) - this.rotation);
        if (num1 != 0 || (double) this.minitem < 0.400000005960464)
        {
          int num2 = num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) != 1 || (double) this.minitem <= 0.699999988079071)
            goto label_6;
        }
        if (!source.block.rotate || !object.ReferenceEquals((object) this.next, (object) source))
          return true;
label_6:
        return false;
      }

      [LineNumberTable(new byte[] {160, 223, 138, 103, 114, 127, 1, 159, 6, 102, 141, 127, 7, 103, 105, 109, 139, 108, 110, 114, 142})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (this.len >= 4)
          return;
        int rotation = this.rotation;
        Tile facingEdge = Edges.getFacingEdge(source.tile, this.tile);
        double num1;
        switch ((int) (sbyte) facingEdge.relativeTo((int) this.tile.x, (int) this.tile.y) - rotation)
        {
          case -3:
          case 1:
            num1 = -1.0;
            break;
          case -1:
          case 3:
            num1 = 1.0;
            break;
          default:
            num1 = 0.0;
            break;
        }
        float num2 = (float) num1;
        this.noSleep();
        this.items.add(item, 1);
        if (Math.abs((int) (sbyte) facingEdge.relativeTo((int) this.tile.x, (int) this.tile.y) - rotation) == 0)
        {
          this.add(0);
          this.xs[0] = num2;
          this.ys[0] = 0.0f;
          this.ids[0] = item;
        }
        else
        {
          this.add(this.mid);
          this.xs[this.mid] = num2;
          this.ys[this.mid] = 0.5f;
          this.ids[this.mid] = item;
        }
      }

      [LineNumberTable(new byte[] {160, 248, 103, 140, 107, 63, 44, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.len);
        for (int index = 0; index < this.len; ++index)
          write.i(Pack.intBytes((byte) this.ids[index].__\u003C\u003Eid, (byte) ByteCodeHelper.f2i(this.xs[index] * (float) sbyte.MaxValue), (byte) ByteCodeHelper.f2i(this.ys[index] * (float) byte.MaxValue - 128f), (byte) 0));
      }

      [LineNumberTable(new byte[] {159, 49, 67, 104, 103, 141, 105, 103, 110, 111, 117, 100, 116, 106, 234, 56, 233, 77, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        int num2 = read.i();
        this.len = Math.min(num2, 4);
        for (int index = 0; index < num2; ++index)
        {
          int num3 = read.i();
          int id = (int) (short) ((int) (sbyte) (num3 >> 24) & (int) byte.MaxValue);
          float num4 = (float) (sbyte) (num3 >> 16) / (float) sbyte.MaxValue;
          float num5 = ((float) (sbyte) (num3 >> 8) + 128f) / (float) byte.MaxValue;
          if (index < 4)
          {
            this.ids[index] = Vars.content.item(id);
            this.xs[index] = num4;
            this.ys[index] = num5;
          }
        }
        this.updateTile();
      }

      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Building next() => (Building) this.nextc;

      [HideFromJava]
      static ConveyorBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly Seq arg\u00241;
      private readonly BuildPlan arg\u00242;

      internal __\u003C\u003EAnon0([In] Seq obj0, [In] BuildPlan obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (Conveyor.lambda\u0024getReplacement\u00241(this.arg\u00241, this.arg\u00242, (Point2) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly BuildPlan arg\u00241;
      private readonly Point2 arg\u00242;

      internal __\u003C\u003EAnon1([In] BuildPlan obj0, [In] Point2 obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (Conveyor.lambda\u0024getReplacement\u00240(this.arg\u00241, this.arg\u00242, (BuildPlan) obj0) ? 1 : 0) != 0;
    }
  }
}
