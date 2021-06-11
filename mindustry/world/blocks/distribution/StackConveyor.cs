// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.StackConveyor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.distribution
{
  [Implements(new string[] {"mindustry.world.blocks.Autotiler"})]
  public class StackConveyor : Block, Autotiler
  {
    protected internal const int stateMove = 0;
    protected internal const int stateLoad = 1;
    protected internal const int stateUnload = 2;
    public TextureRegion[] regions;
    public TextureRegion edgeRegion;
    public TextureRegion stackRegion;
    public float speed;
    public bool splitOut;
    public float recharge;
    public Effect loadEffect;
    public Effect unloadEffect;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

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
    public virtual bool facing([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4) => Autotiler.\u003Cdefault\u003Efacing((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

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
    public virtual int[] getTiling([In] BuildPlan obj0, [In] Eachable obj1) => Autotiler.\u003Cdefault\u003EgetTiling((Autotiler) this, obj0, obj1);

    [LineNumberTable(new byte[] {159, 180, 233, 56, 107, 135, 107, 107, 235, 69, 103, 103, 107, 103, 104, 135, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StackConveyor(string name)
      : base(name)
    {
      StackConveyor stackConveyor = this;
      this.speed = 0.0f;
      this.splitOut = true;
      this.recharge = 2f;
      this.loadEffect = Fx.__\u003C\u003Eplasticburn;
      this.unloadEffect = Fx.__\u003C\u003Eplasticburn;
      this.rotate = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.hasItems = true;
      this.itemCapacity = 10;
      this.conveyorPlacement = true;
      this.ambientSound = Sounds.conveyor;
      this.ambientSoundVolume = 0.004f;
    }

    [LineNumberTable(new byte[] {3, 134, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EitemsMoved, (float) Mathf.round((float) this.itemCapacity * this.speed * 60f), StatUnit.__\u003C\u003EitemsSecond);
    }

    [LineNumberTable(new byte[] {10, 127, 11, 103, 100, 127, 0, 199, 22, 127, 6, 106, 127, 23, 127, 40, 235, 59, 225, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool blends(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock)
    {
      Building build = tile.build;
      StackConveyor.StackConveyorBuild stackConveyorBuild1;
      if (build is StackConveyor.StackConveyorBuild && object.ReferenceEquals((object) (stackConveyorBuild1 = (StackConveyor.StackConveyorBuild) build), (object) (StackConveyor.StackConveyorBuild) build))
      {
        switch (stackConveyorBuild1.state)
        {
          case 1:
            return otherblock.outputsItems() && this.lookingAtEither(tile, rotation, otherx, othery, otherrot, otherblock);
          case 2:
            if (otherblock.acceptsItems && (this.notLookingAt(tile, rotation, otherx, othery, otherrot, otherblock) || otherblock is StackConveyor && this.facing(otherx, othery, otherrot, (int) tile.x, (int) tile.y)))
            {
              Building building1 = Vars.world.build(otherx, othery);
              StackConveyor.StackConveyorBuild stackConveyorBuild2;
              if (!(building1 is StackConveyor.StackConveyorBuild) || !object.ReferenceEquals((object) (stackConveyorBuild2 = (StackConveyor.StackConveyorBuild) building1), (object) (StackConveyor.StackConveyorBuild) building1) || stackConveyorBuild2.state != 2)
              {
                Building building2 = Vars.world.build(otherx, othery);
                StackConveyor.StackConveyorBuild stackConveyorBuild3;
                if (!(building2 is StackConveyor.StackConveyorBuild) || !object.ReferenceEquals((object) (stackConveyorBuild3 = (StackConveyor.StackConveyorBuild) building2), (object) (StackConveyor.StackConveyorBuild) building2) || (stackConveyorBuild3.state != 0 || this.facing(otherx, othery, otherrot, (int) tile.x, (int) tile.y)))
                  return true;
              }
            }
            return false;
        }
      }
      return otherblock.outputsItems() && this.blendsArmored(tile, rotation, otherx, othery, otherrot, otherblock) && otherblock is StackConveyor;
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {28, 137, 132, 105, 158, 102, 108, 31, 6, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      int[] tiling = this.getTiling(req, list);
      if (tiling == null)
        return;
      Draw.rect(this.regions[0], req.drawx(), req.drawy(), (float) (req.rotation * 90));
      for (int index = 0; index < 4; ++index)
      {
        if ((tiling[3] & 1 << index) == 0)
          Draw.rect(this.edgeRegion, req.drawx(), req.drawy(), (float) ((req.rotation - index) * 90));
      }
    }

    [LineNumberTable(new byte[] {44, 109, 127, 0, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool rotatedOutput(int x, int y)
    {
      Building building = Vars.world.build(x, y);
      StackConveyor.StackConveyorBuild stackConveyorBuild;
      return building is StackConveyor.StackConveyorBuild && object.ReferenceEquals((object) (stackConveyorBuild = (StackConveyor.StackConveyorBuild) building), (object) (StackConveyor.StackConveyorBuild) building) ? stackConveyorBuild.state != 2 : base.rotatedOutput(x, y);
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
    public virtual bool blends([In] Tile obj0, [In] int obj1, [In] BuildPlan[] obj2, [In] int obj3, [In] bool obj4) => Autotiler.\u003Cdefault\u003Eblends((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

    [HideFromJava]
    public virtual bool blends([In] Tile obj0, [In] int obj1, [In] int obj2) => Autotiler.\u003Cdefault\u003Eblends((Autotiler) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool lookingAt([In] Tile obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] Block obj4) => Autotiler.\u003Cdefault\u003ElookingAt((Autotiler) this, obj0, obj1, obj2, obj3, obj4);

    [HideFromJava]
    static StackConveyor() => Block.__\u003Cclinit\u003E();

    public class StackConveyorBuild : Building
    {
      public int state;
      public int blendprox;
      public int link;
      public float cooldown;
      public Item lastItem;
      internal bool proxUpdating;
      [Modifiers]
      internal StackConveyor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 160, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void poofOut()
      {
        this.this\u00240.unloadEffect.at((Position) this);
        this.link = -1;
      }

      [LineNumberTable(new byte[] {160, 179, 101, 123, 105, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleStack(Item item, int amount, Teamc source)
      {
        if (amount <= 0)
          return;
        if (this.items.empty() && this.tile != null)
          this.poofIn();
        base.handleStack(item, amount, source);
        this.lastItem = item;
      }

      [LineNumberTable(new byte[] {160, 155, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void poofIn()
      {
        this.link = this.tile.pos();
        this.this\u00240.loadEffect.at((Position) this);
      }

      [LineNumberTable(new byte[] {51, 175, 199})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StackConveyorBuild(StackConveyor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        StackConveyor.StackConveyorBuild stackConveyorBuild = this;
        this.link = -1;
        this.proxUpdating = false;
      }

      [LineNumberTable(new byte[] {62, 138, 159, 11, 102, 111, 31, 9, 230, 70, 138, 145, 149, 188, 121, 119, 191, 3, 113, 119, 127, 9, 191, 9, 191, 61, 127, 31, 127, 3, 127, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.z(29.8f);
        Draw.rect(this.this\u00240.regions[this.state], this.x, this.y, this.rotdeg());
        for (int index = 0; index < 4; ++index)
        {
          if ((this.blendprox & 1 << index) == 0)
            Draw.rect(this.this\u00240.edgeRegion, this.x, this.y, (float) ((this.rotation - index) * 90));
        }
        Draw.z(29.9f);
        Tile tile = Vars.world.tile(this.link);
        if (this.link == -1 || tile == null || this.lastItem == null)
          return;
        int num1 = tile.build != null ? tile.build.rotation : this.rotation;
        Tmp.__\u003C\u003Ev1.set(tile.worldx(), tile.worldy());
        Tmp.__\u003C\u003Ev2.set(this.x, this.y);
        Tmp.__\u003C\u003Ev1.interpolate(Tmp.__\u003C\u003Ev2, 1f - this.cooldown, Interp.linear);
        int num2 = num1;
        int num3 = 4;
        float fromValue = (float) ((num3 != -1 ? num2 % num3 : 0) * 90);
        int rotation1 = this.rotation;
        int num4 = 4;
        float toValue = (float) ((num4 != -1 ? rotation1 % num4 : 0) * 90);
        int num5 = num1;
        int num6 = 4;
        if ((num6 != -1 ? num5 % num6 : 0) == 3)
        {
          int rotation2 = this.rotation;
          int num7 = 4;
          if ((num7 != -1 ? rotation2 % num7 : 0) == 0)
            fromValue = -90f;
        }
        int num8 = num1;
        int num9 = 4;
        if ((num9 != -1 ? num8 % num9 : 0) == 0)
        {
          int rotation2 = this.rotation;
          int num7 = 4;
          if ((num7 != -1 ? rotation2 % num7 : 0) == 3)
            fromValue = 360f;
        }
        Draw.rect(this.this\u00240.stackRegion, Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, Mathf.lerp(fromValue, toValue, Interp.smooth.apply(1f - Mathf.clamp(this.cooldown * 2f, 0.0f, 1f))));
        float num10 = 5f * Mathf.lerp(Math.min((float) this.items.total() / (float) this.this\u00240.itemCapacity, 1f), 1f, 0.4f);
        Drawf.shadow(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, num10 * 1.2f);
        Draw.rect(this.lastItem.icon(Cicon.__\u003C\u003Emedium), Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, num10, num10, 0.0f);
      }

      [LineNumberTable(new byte[] {102, 106, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawCracks()
      {
        Draw.z(29.85f);
        base.drawCracks();
      }

      [LineNumberTable(new byte[] {108, 134, 135, 135, 122, 127, 33, 159, 33, 103, 135, 102, 122, 19, 230, 72, 105, 127, 2, 120, 103, 130, 194, 108, 103, 127, 2, 127, 25, 135, 98, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        int state = this.state;
        this.state = 0;
        int[] numArray = this.this\u00240.buildBlending(this.tile, this.rotation, (BuildPlan[]) null, true);
        if (numArray[0] == 0 && this.this\u00240.blends(this.tile, this.rotation, 0) && !this.this\u00240.blends(this.tile, this.rotation, 2))
          this.state = 1;
        if (numArray[0] == 0 && !this.this\u00240.blends(this.tile, this.rotation, 0) && this.this\u00240.blends(this.tile, this.rotation, 2))
          this.state = 2;
        if (!Vars.headless)
        {
          this.blendprox = 0;
          for (int index = 0; index < 4; ++index)
          {
            if (this.this\u00240.blends(this.tile, this.rotation, index))
              this.blendprox |= 1 << index;
          }
        }
        if (this.state == 1)
        {
          Iterator iterator = this.proximity.iterator();
          while (iterator.hasNext())
          {
            Building building = (Building) iterator.next();
            if (building is StackConveyor.StackConveyorBuild && object.ReferenceEquals((object) building.front(), (object) this))
            {
              this.state = 0;
              break;
            }
          }
        }
        if (this.state == state)
          return;
        this.proxUpdating = true;
        Iterator iterator1 = this.proximity.iterator();
        while (iterator1.hasNext())
        {
          Building building1 = (Building) iterator1.next();
          Building building2 = building1;
          StackConveyor.StackConveyorBuild stackConveyorBuild;
          if (!(building2 is StackConveyor.StackConveyorBuild) || !object.ReferenceEquals((object) (stackConveyorBuild = (StackConveyor.StackConveyorBuild) building2), (object) (StackConveyor.StackConveyorBuild) building2) || (!stackConveyorBuild.proxUpdating || stackConveyorBuild.state == 2))
            building1.onProximityUpdate();
        }
        this.proxUpdating = false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canUnload() => this.state != 1;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float efficiency() => 1f;

      [LineNumberTable(new byte[] {160, 99, 191, 38, 170, 174, 123, 209, 137, 105, 127, 29, 181, 127, 6, 159, 30, 105, 113, 108, 145, 103, 139, 113, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if ((double) this.cooldown > 0.0)
          this.cooldown = Mathf.clamp(this.cooldown - this.this\u00240.speed * this.edelta(), 0.0f, this.this\u00240.recharge);
        if (this.link == -1 || (double) this.cooldown > 0.0)
          return;
        if (this.lastItem == null || !this.items.has(this.lastItem))
          this.lastItem = this.items.first();
        if (!this.enabled)
          return;
        if (this.state == 2)
        {
          while (this.lastItem != null)
          {
            if (!this.this\u00240.splitOut)
            {
              if (!this.moveForward(this.lastItem))
                break;
            }
            else if (!this.dump(this.lastItem))
              break;
            if (this.items.empty())
              this.poofOut();
          }
        }
        else
        {
          if (this.state == 1 && this.items.total() < this.getMaximumAccepted(this.lastItem))
            return;
          Building building = this.front();
          StackConveyor.StackConveyorBuild stackConveyorBuild;
          if (!(building is StackConveyor.StackConveyorBuild) || !object.ReferenceEquals((object) (stackConveyorBuild = (StackConveyor.StackConveyorBuild) building), (object) (StackConveyor.StackConveyorBuild) building) || (!object.ReferenceEquals((object) stackConveyorBuild.team, (object) this.team) || stackConveyorBuild.link != -1))
            return;
          stackConveyorBuild.items.add(this.items);
          stackConveyorBuild.lastItem = this.lastItem;
          stackConveyorBuild.link = this.tile.pos();
          this.link = -1;
          this.items.clear();
          this.cooldown = this.this\u00240.recharge;
          stackConveyorBuild.cooldown = 1f;
        }
      }

      [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
      [LineNumberTable(new byte[] {160, 141, 127, 5, 108, 99, 180})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void overwrote(Seq builds)
      {
        object obj1 = builds.first();
        Conveyor.ConveyorBuild conveyorBuild;
        if (!(obj1 is Conveyor.ConveyorBuild) || !object.ReferenceEquals((object) (conveyorBuild = (Conveyor.ConveyorBuild) obj1), (object) (Conveyor.ConveyorBuild) obj1))
          return;
        Item obj2 = conveyorBuild.items.first();
        if (obj2 == null)
          return;
        this.handleStack(obj2, conveyorBuild.items.get(obj2), (Teamc) null);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => false;

      [LineNumberTable(new byte[] {160, 166, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int acceptStack(Item item, int amount, Teamc source) => this.items.any() && !this.items.has(item) ? 0 : base.acceptStack(item, amount, source);

      [LineNumberTable(new byte[] {160, 172, 123, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (this.items.empty() && this.tile != null)
          this.poofIn();
        base.handleItem(source, item);
        this.lastItem = item;
      }

      [LineNumberTable(new byte[] {160, 188, 141, 115, 35, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount)
      {
        try
        {
          return base.removeStack(item, amount);
        }
        finally
        {
          if (this.items.empty())
            this.poofOut();
        }
      }

      [LineNumberTable(new byte[] {160, 196, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void itemTaken(Item item)
      {
        if (!this.items.empty())
          return;
        this.poofOut();
      }

      [LineNumberTable(new byte[] {160, 201, 107, 124, 111, 123, 111, 241, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => object.ReferenceEquals((object) this, (object) source) || (double) this.cooldown <= (double) (this.this\u00240.recharge - 1f) && (this.state == 1 && (!this.items.any() || this.items.has(item)) && (this.items.total() < this.getMaximumAccepted(item) && !object.ReferenceEquals((object) this.front(), (object) source)));

      [LineNumberTable(new byte[] {160, 211, 135, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.link);
        write.f(this.cooldown);
      }

      [LineNumberTable(new byte[] {159, 59, 99, 136, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.link = read.i();
        this.cooldown = read.f();
      }

      [HideFromJava]
      static StackConveyorBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
