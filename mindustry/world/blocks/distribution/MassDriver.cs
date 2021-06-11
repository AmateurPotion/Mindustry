// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.MassDriver
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.distribution
{
  public class MassDriver : Block
  {
    public float range;
    public float rotateSpeed;
    public float translation;
    public int minDistribute;
    public float knockback;
    public float reloadTime;
    public float bulletSpeed;
    public float bulletLifetime;
    public Effect shootEffect;
    public Effect smokeEffect;
    public Effect receiveEffect;
    public Sound shootSound;
    public float shake;
    public TextureRegion baseRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] MassDriver.MassDriverBuild obj0, [In] Point2 obj1) => obj0.link = Point2.pack(obj1.x + obj0.tileX(), obj1.y + obj0.tileY());

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] MassDriver.MassDriverBuild obj0, [In] Integer obj1) => obj0.link = obj1.intValue();

    [LineNumberTable(new byte[] {159, 181, 233, 49, 107, 107, 104, 107, 107, 107, 107, 107, 107, 107, 107, 235, 69, 103, 103, 103, 103, 103, 103, 167, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MassDriver(string name)
      : base(name)
    {
      MassDriver massDriver = this;
      this.rotateSpeed = 0.04f;
      this.translation = 7f;
      this.minDistribute = 10;
      this.knockback = 4f;
      this.reloadTime = 100f;
      this.bulletSpeed = 5.5f;
      this.bulletLifetime = 200f;
      this.shootEffect = Fx.__\u003C\u003EshootBig2;
      this.smokeEffect = Fx.__\u003C\u003EshootBigSmoke2;
      this.receiveEffect = Fx.__\u003C\u003EmineBig;
      this.shootSound = Sounds.shootBig;
      this.shake = 3f;
      this.update = true;
      this.solid = true;
      this.configurable = true;
      this.hasItems = true;
      this.hasPower = true;
      this.outlineIcon = true;
      this.sync = true;
      this.config((Class) ClassLiteral<Point2>.Value, (Cons2) new MassDriver.__\u003C\u003EAnon0());
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new MassDriver.__\u003C\u003EAnon1());
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.baseRegion,
      this.region
    };

    [LineNumberTable(new byte[] {159, 127, 67, 138, 184, 124, 122, 191, 8, 118, 127, 64, 127, 4, 127, 9, 157, 111, 110, 111, 110, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num1 != 0);
      Drawf.dashCircle((float) (x * 8), (float) (y * 8), this.range, Pal.accent);
      if (!Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown())
        return;
      Building selectedTile = Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile();
      if (selectedTile == null || !(selectedTile.block is MassDriver) || !selectedTile.within((float) (x * 8), (float) (y * 8), this.range))
        return;
      float num2 = Mathf.absin(Time.time, 6f, 1f);
      Tmp.__\u003C\u003Ev1.set((float) (x * 8) + this.offset, (float) (y * 8) + this.offset).sub(selectedTile.x, selectedTile.y).limit(((float) this.size / 2f + 1f) * 8f + num2 + 0.5f);
      float x2 = (float) (x * 8) - Tmp.__\u003C\u003Ev1.x;
      float y2 = (float) (y * 8) - Tmp.__\u003C\u003Ev1.y;
      float x1 = selectedTile.x + Tmp.__\u003C\u003Ev1.x;
      float y1 = selectedTile.y + Tmp.__\u003C\u003Ev1.y;
      int divisions = ByteCodeHelper.f2i(selectedTile.dst((float) (x * 8), (float) (y * 8)) / 8f);
      Lines.stroke(4f, Pal.gray);
      Lines.dashLine(x1, y1, x2, y2, divisions);
      Lines.stroke(2f, Pal.placing);
      Lines.dashLine(x1, y1, x2, y2, divisions);
      Draw.reset();
    }

    [HideFromJava]
    static MassDriver() => Block.__\u003Cclinit\u003E();

    public class DriverBulletData : Object, Pool.Poolable
    {
      public MassDriver.MassDriverBuild from;
      public MassDriver.MassDriverBuild to;
      public int[] items;
      [Modifiers]
      internal MassDriver this\u00240;

      [LineNumberTable(new byte[] {33, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DriverBulletData(MassDriver _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MassDriver.DriverBulletData driverBulletData = this;
        this.items = new int[Vars.content.items().size];
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.from = (MassDriver.MassDriverBuild) null;
        this.to = (MassDriver.MassDriverBuild) null;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/world/blocks/distribution/MassDriver$DriverState;>;")]
    [Modifiers]
    [Serializable]
    public sealed class DriverState : Enum
    {
      [Modifiers]
      internal static MassDriver.DriverState __\u003C\u003Eidle;
      [Modifiers]
      internal static MassDriver.DriverState __\u003C\u003Eaccepting;
      [Modifiers]
      internal static MassDriver.DriverState __\u003C\u003Eshooting;
      [Modifiers]
      internal static MassDriver.DriverState __\u003C\u003Eunloading;
      internal static MassDriver.DriverState[] __\u003C\u003Eall;
      [Modifiers]
      private static MassDriver.DriverState[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(342)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DriverState([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(342)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MassDriver.DriverState[] values() => (MassDriver.DriverState[]) MassDriver.DriverState.\u0024VALUES.Clone();

      [LineNumberTable(342)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MassDriver.DriverState valueOf(string name) => (MassDriver.DriverState) Enum.valueOf((Class) ClassLiteral<MassDriver.DriverState>.Value, name);

      [LineNumberTable(new byte[] {159, 57, 173, 112, 112, 112, 240, 60, 255, 12, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static DriverState()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.distribution.MassDriver$DriverState"))
          return;
        MassDriver.DriverState.__\u003C\u003Eidle = new MassDriver.DriverState(nameof (idle), 0);
        MassDriver.DriverState.__\u003C\u003Eaccepting = new MassDriver.DriverState(nameof (accepting), 1);
        MassDriver.DriverState.__\u003C\u003Eshooting = new MassDriver.DriverState(nameof (shooting), 2);
        MassDriver.DriverState.__\u003C\u003Eunloading = new MassDriver.DriverState(nameof (unloading), 3);
        MassDriver.DriverState.\u0024VALUES = new MassDriver.DriverState[4]
        {
          MassDriver.DriverState.__\u003C\u003Eidle,
          MassDriver.DriverState.__\u003C\u003Eaccepting,
          MassDriver.DriverState.__\u003C\u003Eshooting,
          MassDriver.DriverState.__\u003C\u003Eunloading
        };
        MassDriver.DriverState.__\u003C\u003Eall = MassDriver.DriverState.values();
      }

      [Modifiers]
      public static MassDriver.DriverState idle
      {
        [HideFromJava] get => MassDriver.DriverState.__\u003C\u003Eidle;
      }

      [Modifiers]
      public static MassDriver.DriverState accepting
      {
        [HideFromJava] get => MassDriver.DriverState.__\u003C\u003Eaccepting;
      }

      [Modifiers]
      public static MassDriver.DriverState shooting
      {
        [HideFromJava] get => MassDriver.DriverState.__\u003C\u003Eshooting;
      }

      [Modifiers]
      public static MassDriver.DriverState unloading
      {
        [HideFromJava] get => MassDriver.DriverState.__\u003C\u003Eunloading;
      }

      [Modifiers]
      public static MassDriver.DriverState[] all
      {
        [HideFromJava] get => MassDriver.DriverState.__\u003C\u003Eall;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        idle,
        accepting,
        shooting,
        unloading,
      }
    }

    public class MassDriverBuild : Building
    {
      public int link;
      public float rotation;
      public float reload;
      public MassDriver.DriverState state;
      [Signature("Larc/struct/OrderedSet<Lmindustry/world/Tile;>;")]
      public OrderedSet waitingShooters;
      [Modifiers]
      internal MassDriver this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 173, 172, 111, 125, 119, 116, 132, 112, 226, 57, 233, 75, 124, 145, 107, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void handlePayload(Bullet bullet, MassDriver.DriverBulletData data)
      {
        int num = this.items.total();
        for (int id = 0; id < data.items.Length; ++id)
        {
          int amount = Math.min(data.items[id], this.this\u00240.itemCapacity * 2 - num);
          this.items.add(Vars.content.item(id), amount);
          int[] items = data.items;
          int index = id;
          int[] numArray = items;
          numArray[index] = numArray[index] - amount;
          num += amount;
          if (num >= this.this\u00240.itemCapacity * 2)
            break;
        }
        Effect.shake(this.this\u00240.shake, this.this\u00240.shake, (Position) this);
        this.this\u00240.receiveEffect.at((Position) bullet);
        this.reload = 1f;
        bullet.remove();
      }

      [LineNumberTable(new byte[] {160, 201, 107, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool linkValid()
      {
        if (this.link == -1)
          return false;
        Building building = Vars.world.build(this.link);
        return building is MassDriver.MassDriverBuild && object.ReferenceEquals((object) building.team, (object) this.team) && this.within((Position) building, this.this\u00240.range);
      }

      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile currentShooter() => this.waitingShooters.isEmpty() ? (Tile) null : (Tile) this.waitingShooters.first();

      [LineNumberTable(new byte[] {160, 195, 101, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool shooterValid(Tile other)
      {
        if (other == null)
          return true;
        Building build = other.build;
        MassDriver.MassDriverBuild massDriverBuild;
        return build is MassDriver.MassDriverBuild && object.ReferenceEquals((object) (massDriverBuild = (MassDriver.MassDriverBuild) build), (object) (MassDriver.MassDriverBuild) build) && (massDriverBuild.link == this.tile.pos() && (double) this.tile.dst((Position) other) <= (double) this.this\u00240.range);
      }

      [LineNumberTable(new byte[] {160, 142, 139, 123, 103, 103, 98, 119, 127, 15, 105, 100, 247, 60, 233, 71, 143, 127, 0, 63, 34, 198, 127, 26, 42, 165, 127, 26, 42, 165, 156, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void fire(MassDriver.MassDriverBuild target)
      {
        this.reload = 1f;
        MassDriver.DriverBulletData driverBulletData = (MassDriver.DriverBulletData) Pools.obtain((Class) ClassLiteral<MassDriver.DriverBulletData>.Value, (Prov) new MassDriver.MassDriverBuild.__\u003C\u003EAnon1(this));
        driverBulletData.from = this;
        driverBulletData.to = target;
        int num1 = 0;
        for (int id = 0; id < Vars.content.items().size; ++id)
        {
          int amount = Math.min(this.items.get(Vars.content.item(id)), this.tile.block().itemCapacity - num1);
          driverBulletData.items[id] = amount;
          num1 += amount;
          this.items.remove(Vars.content.item(id), amount);
        }
        float num2 = this.tile.angleTo((Position) target);
        Bullets.driverBolt.create((Entityc) this, this.team, this.x + Angles.trnsx(num2, this.this\u00240.translation), this.y + Angles.trnsy(num2, this.this\u00240.translation), num2, -1f, this.this\u00240.bulletSpeed, this.this\u00240.bulletLifetime, (object) driverBulletData);
        this.this\u00240.shootEffect.at(this.x + Angles.trnsx(num2, this.this\u00240.translation), this.y + Angles.trnsy(num2, this.this\u00240.translation), num2);
        this.this\u00240.smokeEffect.at(this.x + Angles.trnsx(num2, this.this\u00240.translation), this.y + Angles.trnsy(num2, this.this\u00240.translation), num2);
        Effect.shake(this.this\u00240.shake, this.this\u00240.shake, (Position) this);
        this.this\u00240.shootSound.at((Position) this.tile, Mathf.random(0.9f, 1.1f));
      }

      [LineNumberTable(322)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Point2 config() => Point2.unpack(this.link).sub((int) this.tile.x, (int) this.tile.y);

      [Modifiers]
      [LineNumberTable(new byte[] {160, 69, 114, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024updateTile\u00240([In] MassDriver.MassDriverBuild obj0)
      {
        obj0.waitingShooters.remove((object) this.tile);
        obj0.state = MassDriver.DriverState.__\u003C\u003Eidle;
      }

      [Modifiers]
      [LineNumberTable(258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private MassDriver.DriverBulletData lambda\u0024fire\u00241() => new MassDriver.DriverBulletData(this.this\u00240);

      [LineNumberTable(new byte[] {44, 111, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MassDriverBuild(MassDriver _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MassDriver.MassDriverBuild massDriverBuild = this;
        this.link = -1;
        this.rotation = 90f;
        this.reload = 0.0f;
        this.state = MassDriver.DriverState.__\u003C\u003Eidle;
        this.waitingShooters = new OrderedSet();
      }

      [LineNumberTable(new byte[] {57, 113, 135, 99, 204, 109, 223, 9, 110, 210, 146, 127, 18, 109, 99, 235, 69, 127, 5, 199, 104, 161, 146, 127, 13, 107, 193, 127, 30, 149, 127, 21, 107, 161, 142, 102, 127, 7, 150, 103, 146, 176, 191, 8, 159, 24, 159, 5, 103, 127, 9, 243, 70, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        Building building = Vars.world.build(this.link);
        int num1 = this.linkValid() ? 1 : 0;
        if (num1 != 0)
          this.link = building.pos();
        if ((double) this.reload > 0.0)
          this.reload = Mathf.clamp(this.reload - this.edelta() / this.this\u00240.reloadTime);
        if (!this.shooterValid(this.currentShooter()))
          this.waitingShooters.remove((object) this.currentShooter());
        if (object.ReferenceEquals((object) this.state, (object) MassDriver.DriverState.__\u003C\u003Eidle))
        {
          if (!this.waitingShooters.isEmpty() && this.this\u00240.itemCapacity - this.items.total() >= this.this\u00240.minDistribute)
            this.state = MassDriver.DriverState.__\u003C\u003Eaccepting;
          else if (num1 != 0)
            this.state = MassDriver.DriverState.__\u003C\u003Eshooting;
        }
        if (object.ReferenceEquals((object) this.state, (object) MassDriver.DriverState.__\u003C\u003Eidle) || object.ReferenceEquals((object) this.state, (object) MassDriver.DriverState.__\u003C\u003Eaccepting))
          this.dump();
        if (!this.consValid())
          return;
        if (object.ReferenceEquals((object) this.state, (object) MassDriver.DriverState.__\u003C\u003Eaccepting))
        {
          if (this.currentShooter() == null || this.this\u00240.itemCapacity - this.items.total() < this.this\u00240.minDistribute)
            this.state = MassDriver.DriverState.__\u003C\u003Eidle;
          else
            this.rotation = Mathf.slerpDelta(this.rotation, this.tile.angleTo((Position) this.currentShooter()), this.this\u00240.rotateSpeed * this.efficiency());
        }
        else
        {
          if (!object.ReferenceEquals((object) this.state, (object) MassDriver.DriverState.__\u003C\u003Eshooting))
            return;
          if (num1 == 0 || !this.waitingShooters.isEmpty() && this.this\u00240.itemCapacity - this.items.total() >= this.this\u00240.minDistribute)
          {
            this.state = MassDriver.DriverState.__\u003C\u003Eidle;
          }
          else
          {
            float num2 = this.tile.angleTo((Position) building);
            if (this.items.total() < this.this\u00240.minDistribute || building.block.itemCapacity - building.items.total() < this.this\u00240.minDistribute)
              return;
            MassDriver.MassDriverBuild target = (MassDriver.MassDriverBuild) building;
            target.waitingShooters.add((object) this.tile);
            if ((double) this.reload > 9.99999974737875E-05)
              return;
            this.rotation = Mathf.slerpDelta(this.rotation, num2, this.this\u00240.rotateSpeed * this.efficiency());
            if (!object.ReferenceEquals((object) target.currentShooter(), (object) this.tile) || !object.ReferenceEquals((object) target.state, (object) MassDriver.DriverState.__\u003C\u003Eaccepting) || (!Angles.near(this.rotation, num2, 2f) || !Angles.near(target.rotation, num2 + 180f, 2f)))
              return;
            this.fire(target);
            Time.run(Math.min(this.this\u00240.bulletLifetime, this.dst((Position) target) / this.this\u00240.bulletSpeed), (Runnable) new MassDriver.MassDriverBuild.__\u003C\u003EAnon0(this, target));
            this.state = MassDriver.DriverState.__\u003C\u003Eidle;
          }
        }
      }

      [LineNumberTable(new byte[] {160, 82, 156, 138, 127, 18, 127, 31, 31, 6, 165, 127, 18, 127, 15, 21, 165})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.baseRegion, this.x, this.y);
        Draw.z(50f);
        Drawf.shadow(this.this\u00240.region, this.x + Angles.trnsx(this.rotation + 180f, this.reload * this.this\u00240.knockback) - (float) (this.this\u00240.size / 2), this.y + Angles.trnsy(this.rotation + 180f, this.reload * this.this\u00240.knockback) - (float) (this.this\u00240.size / 2), this.rotation - 90f);
        Draw.rect(this.this\u00240.region, this.x + Angles.trnsx(this.rotation + 180f, this.reload * this.this\u00240.knockback), this.y + Angles.trnsy(this.rotation + 180f, this.reload * this.this\u00240.knockback), this.rotation - 90f);
      }

      [LineNumberTable(new byte[] {160, 96, 150, 106, 106, 159, 39, 127, 4, 127, 41, 127, 30, 133, 107, 113, 127, 34, 191, 23, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawConfigure()
      {
        float num = Mathf.absin(Time.time, 6f, 1f);
        Draw.color(Pal.accent);
        Lines.stroke(1f);
        Drawf.circles(this.x, this.y, ((float) this.tile.block().size / 2f + 1f) * 8f + num - 2f, Pal.accent);
        OrderedSet.OrderedSetIterator orderedSetIterator = this.waitingShooters.iterator();
        while (((Iterator) orderedSetIterator).hasNext())
        {
          Tile tile = (Tile) ((Iterator) orderedSetIterator).next();
          Drawf.circles(tile.drawx(), tile.drawy(), ((float) this.tile.block().size / 2f + 1f) * 8f + num - 2f, Pal.place);
          Drawf.arrow(tile.drawx(), tile.drawy(), this.x, this.y, (float) (this.this\u00240.size * 8) + num, 4f + num, Pal.place);
        }
        if (this.linkValid())
        {
          Building building = Vars.world.build(this.link);
          Drawf.circles(building.x, building.y, ((float) building.block().size / 2f + 1f) * 8f + num - 2f, Pal.place);
          Drawf.arrow(this.x, this.y, building.x, building.y, (float) (this.this\u00240.size * 8) + num, 4f + num);
        }
        Drawf.dashCircle(this.x, this.y, this.this\u00240.range, Pal.accent);
      }

      [LineNumberTable(new byte[] {160, 118, 105, 108, 162, 110, 108, 98, 127, 27, 113, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (object.ReferenceEquals((object) this, (object) other))
        {
          this.configure((object) Integer.valueOf(-1));
          return false;
        }
        if (this.link == other.pos())
        {
          this.configure((object) Integer.valueOf(-1));
          return false;
        }
        if (!(other.block is MassDriver) || (double) other.dst((Position) this.tile) > (double) this.this\u00240.range || !object.ReferenceEquals((object) other.team, (object) this.team))
          return true;
        this.configure((object) Integer.valueOf(other.pos()));
        return false;
      }

      [LineNumberTable(251)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.total() < this.this\u00240.itemCapacity && this.linkValid();

      [LineNumberTable(new byte[] {160, 213, 103, 108, 108, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.link);
        write.f(this.rotation);
        write.b((int) (sbyte) this.state.ordinal());
      }

      [LineNumberTable(new byte[] {159, 59, 163, 104, 108, 109, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.link = read.i();
        this.rotation = read.f();
        this.state = MassDriver.DriverState.__\u003C\u003Eall[(int) (sbyte) read.b()];
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static MassDriverBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly MassDriver.MassDriverBuild arg\u00241;
        private readonly MassDriver.MassDriverBuild arg\u00242;

        internal __\u003C\u003EAnon0(
          [In] MassDriver.MassDriverBuild obj0,
          [In] MassDriver.MassDriverBuild obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024updateTile\u00240(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Prov
      {
        private readonly MassDriver.MassDriverBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] MassDriver.MassDriverBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024fire\u00241();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => MassDriver.lambda\u0024new\u00240((MassDriver.MassDriverBuild) obj0, (Point2) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons2
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0, [In] object obj1) => MassDriver.lambda\u0024new\u00241((MassDriver.MassDriverBuild) obj0, (Integer) obj1);
    }
  }
}
