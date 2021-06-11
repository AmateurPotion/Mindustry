// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.Conduit
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.world.blocks.distribution;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.liquid
{
  [Implements(new string[] {"mindustry.world.blocks.Autotiler"})]
  public class Conduit : LiquidBlock, Autotiler
  {
    internal int __\u003C\u003EtimerFlow;
    public Color botColor;
    public TextureRegion[] topRegions;
    public TextureRegion[] botRegions;
    public bool leaks;

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
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getReplacement\u00241([In] Seq obj0, [In] BuildPlan obj1, [In] Point2 obj2) => obj0.contains((Boolf) new Conduit.__\u003C\u003EAnon1(obj1, obj2));

    [Modifiers]
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getReplacement\u00240(
      [In] BuildPlan obj0,
      [In] Point2 obj1,
      [In] BuildPlan obj2)
    {
      return obj2.x == obj0.x + obj1.x && obj2.y == obj0.y + obj1.y && obj2.rotation == obj0.rotation && (obj0.block is Conduit || obj0.block is LiquidJunction);
    }

    [LineNumberTable(new byte[] {159, 177, 233, 54, 153, 240, 69, 199, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Conduit(string name)
      : base(name)
    {
      Conduit conduit1 = this;
      Conduit conduit2 = this;
      int timers = conduit2.timers;
      Conduit conduit3 = conduit2;
      int num = timers;
      conduit3.timers = timers + 1;
      this.__\u003C\u003EtimerFlow = num;
      this.botColor = Color.valueOf("565656");
      this.leaks = true;
      this.rotate = true;
      this.solid = false;
      this.floating = true;
      this.conveyorPlacement = true;
      this.noUpdateDisabled = true;
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 187, 137, 132, 109, 107, 106, 127, 8, 101, 127, 8, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      int[] tiling = this.getTiling(req, list);
      if (tiling == null)
        return;
      Draw.scl((float) tiling[1], (float) tiling[2]);
      Draw.color(this.botColor);
      Draw.alpha(0.5f);
      Draw.rect(this.botRegions[tiling[0]], req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.color();
      Draw.rect(this.topRegions[tiling[0]], req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.scl();
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)Lmindustry/world/Block;")]
    [LineNumberTable(new byte[] {10, 205, 231, 61, 117, 109, 104, 114, 255, 3, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Block getReplacement(BuildPlan req, Seq requests)
    {
      Boolf boolf = (Boolf) new Conduit.__\u003C\u003EAnon0(requests, req);
      return boolf.get((object) Geometry.d4(req.rotation)) && boolf.get((object) Geometry.d4(req.rotation - 2)) && (req.tile() != null && req.tile().block() is Conduit) && Mathf.mod(req.build().rotation - req.rotation, 2) == 1 ? Blocks.liquidJunction : (Block) this;
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool blends(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock)
    {
      return otherblock.hasLiquids && (otherblock.outputsLiquid || this.lookingAt(tile, rotation, otherx, othery, otherblock)) && this.lookingAtEither(tile, rotation, otherx, othery, otherrot, otherblock);
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {25, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void handlePlacementLine(Seq plans) => Placement.calculateBridges(plans, (ItemBridge) Blocks.bridgeConduit);

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      (TextureRegion) Core.atlas.find("conduit-bottom"),
      this.topRegions[0]
    };

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
    static Conduit() => LiquidBlock.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerFlow
    {
      [HideFromJava] get => this.__\u003C\u003EtimerFlow;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerFlow = value;
    }

    [Implements(new string[] {"mindustry.world.blocks.distribution.ChainedBuilding"})]
    public class ConduitBuild : LiquidBlock.LiquidBuild, ChainedBuilding
    {
      public float smoothLiquid;
      public int blendbits;
      public int xscl;
      public int yscl;
      public int blending;
      [Modifiers]
      internal Conduit this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {60, 112, 159, 7, 159, 29, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void drawAt(
        float x,
        float y,
        int bits,
        float rotation,
        Autotiler.SliceMode slice)
      {
        Draw.color(this.this\u00240.botColor);
        Draw.rect(this.this\u00240.sliced(this.this\u00240.botRegions[bits], slice), x, y, rotation);
        Drawf.liquid(this.this\u00240.sliced(this.this\u00240.botRegions[bits], slice), x, y, this.smoothLiquid, this.liquids.current().color, rotation);
        Draw.rect(this.this\u00240.sliced(this.this\u00240.topRegions[bits], slice), x, y, rotation);
      }

      [LineNumberTable(83)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConduitBuild(Conduit _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((LiquidBlock) _param1);
      }

      [LineNumberTable(new byte[] {39, 104, 167, 106, 105, 114, 100, 109, 255, 41, 60, 233, 72, 138, 115, 126, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        float rotation1 = this.rotdeg();
        int rotation2 = this.rotation;
        Draw.z(29.5f);
        for (int index = 0; index < 4; ++index)
        {
          if ((this.blending & 1 << index) != 0)
          {
            int i = rotation2 - index;
            float rotation3 = index != 0 ? (float) (i * 90) : rotation1;
            this.drawAt(this.x + (float) (Geometry.d4x(i) * 8) * 0.75f, this.y + (float) (Geometry.d4y(i) * 8) * 0.75f, 0, rotation3, index == 0 ? Autotiler.SliceMode.__\u003C\u003Etop : Autotiler.SliceMode.__\u003C\u003Ebottom);
          }
        }
        Draw.z(30f);
        Draw.scl((float) this.xscl, (float) this.yscl);
        this.drawAt(this.x, this.y, this.blendbits, rotation1, Autotiler.SliceMode.__\u003C\u003Enone);
        Draw.reset();
      }

      [LineNumberTable(new byte[] {70, 134, 122, 105, 105, 105, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        int[] numArray = this.this\u00240.buildBlending(this.tile, this.rotation, (BuildPlan[]) null, true);
        this.blendbits = numArray[0];
        this.xscl = numArray[1];
        this.yscl = numArray[2];
        this.blending = numArray[4];
      }

      [LineNumberTable(new byte[] {81, 102, 127, 30, 63, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid)
      {
        this.noSleep();
        if (object.ReferenceEquals((object) this.liquids.current(), (object) liquid) || (double) this.liquids.currentAmount() < 0.200000002980232)
        {
          int num1 = (int) (sbyte) source.relativeTo((int) this.tile.x, (int) this.tile.y) + 2;
          int num2 = 4;
          if ((num2 != -1 ? num1 % num2 : 0) != this.rotation)
            return true;
        }
        return false;
      }

      [LineNumberTable(new byte[] {88, 159, 17, 127, 12, 126, 136, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.smoothLiquid = Mathf.lerpDelta(this.smoothLiquid, this.liquids.currentAmount() / this.this\u00240.liquidCapacity, 0.05f);
        if ((double) this.liquids.total() > 1.0 / 1000.0 && this.timer(this.this\u00240.__\u003C\u003EtimerFlow, 1f))
        {
          double num = (double) this.moveLiquidForward(this.this\u00240.leaks, this.liquids.current());
          this.noSleep();
        }
        else
          this.sleep();
      }

      [LineNumberTable(new byte[] {101, 114, 112, 135})]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Building next()
      {
        Tile tile = this.tile.nearby(this.rotation);
        return tile != null && tile.build is Conduit.ConduitBuild ? tile.build : (Building) null;
      }

      [HideFromJava]
      static ConduitBuild() => LiquidBlock.LiquidBuild.__\u003Cclinit\u003E();
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

      public bool get([In] object obj0) => (Conduit.lambda\u0024getReplacement\u00241(this.arg\u00241, this.arg\u00242, (Point2) obj0) ? 1 : 0) != 0;
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

      public bool get([In] object obj0) => (Conduit.lambda\u0024getReplacement\u00240(this.arg\u00241, this.arg\u00242, (BuildPlan) obj0) ? 1 : 0) != 0;
    }
  }
}
