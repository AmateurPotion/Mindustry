// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.RepairPoint
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.units
{
  public class RepairPoint : Block
  {
    [Modifiers]
    internal static Rect rect;
    public int timerTarget;
    public float repairRadius;
    public float repairSpeed;
    public float powerUse;
    public TextureRegion baseRegion;
    public TextureRegion laser;
    public TextureRegion laserEnd;
    public Color laserColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00240([In] Building obj0) => ((RepairPoint.RepairPointBuild) obj0).target != null;

    [LineNumberTable(new byte[] {159, 178, 233, 51, 153, 107, 235, 71, 208, 103, 103, 121, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RepairPoint(string name)
      : base(name)
    {
      RepairPoint repairPoint1 = this;
      RepairPoint repairPoint2 = this;
      int timers = repairPoint2.timers;
      RepairPoint repairPoint3 = repairPoint2;
      int num = timers;
      repairPoint3.timers = timers + 1;
      this.timerTarget = num;
      this.repairRadius = 50f;
      this.repairSpeed = 0.3f;
      this.laserColor = Color.valueOf("e8ffd7");
      this.update = true;
      this.solid = true;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Erepair
      });
      this.hasPower = true;
      this.outlineIcon = true;
      this.expanded = true;
    }

    [LineNumberTable(new byte[] {159, 189, 102, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Erange, this.repairRadius / 8f, StatUnit.__\u003C\u003Eblocks);
    }

    [LineNumberTable(new byte[] {3, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.__\u003C\u003Econsumes.powerCond(this.powerUse, (Boolf) new RepairPoint.__\u003C\u003EAnon0());
      base.init();
    }

    [LineNumberTable(new byte[] {159, 128, 163, 138, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Drawf.dashCircle((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.repairRadius, Pal.accent);
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.baseRegion,
      this.region
    };

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static RepairPoint()
    {
      Block.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.units.RepairPoint"))
        return;
      RepairPoint.rect = new Rect();
    }

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class RepairPointBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      public Unit target;
      public float strength;
      public float rotation;
      [Modifiers]
      internal RepairPoint this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [HideFromJava]
      public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

      [LineNumberTable(new byte[] {19, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RepairPointBuild(RepairPoint _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        RepairPoint.RepairPointBuild repairPointBuild = this;
        this.rotation = 90f;
      }

      [LineNumberTable(new byte[] {25, 156, 106, 127, 52, 159, 10, 127, 15, 106, 110, 134, 112, 127, 5, 126, 24, 165, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.baseRegion, this.x, this.y);
        Draw.z(50f);
        Drawf.shadow(this.this\u00240.region, this.x - (float) this.this\u00240.size / 2f, this.y - (float) this.this\u00240.size / 2f, this.rotation - 90f);
        Draw.rect(this.this\u00240.region, this.x, this.y, this.rotation - 90f);
        if (this.target == null || (double) Angles.angleDist(this.angleTo((Position) this.target), this.rotation) >= 30.0)
          return;
        Draw.z(116f);
        float angle = this.angleTo((Position) this.target);
        float len = 5f;
        Draw.color(this.this\u00240.laserColor);
        Drawf.laser(this.team, this.this\u00240.laser, this.this\u00240.laserEnd, this.x + Angles.trnsx(angle, len), this.y + Angles.trnsy(angle, len), this.target.x(), this.target.y(), this.strength);
        Draw.color();
      }

      [LineNumberTable(new byte[] {46, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect() => Drawf.dashCircle(this.x, this.y, this.this\u00240.repairRadius, Pal.accent);

      [LineNumberTable(new byte[] {51, 98, 127, 67, 105, 112, 127, 8, 127, 22, 162, 107, 159, 6, 191, 4, 120, 127, 15, 159, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        int num = 0;
        if (this.target != null && (this.target.dead() || (double) (this.target.dst((Position) this.tile) - this.target.hitSize / 2f) > (double) this.this\u00240.repairRadius || (double) this.target.health() >= (double) this.target.maxHealth()))
          this.target = (Unit) null;
        else if (this.target != null && this.consValid())
        {
          this.target.heal(this.this\u00240.repairSpeed * this.strength * this.edelta());
          this.rotation = Mathf.slerpDelta(this.rotation, this.angleTo((Position) this.target), 0.5f * this.efficiency() * this.timeScale);
          num = 1;
        }
        this.strength = this.target == null || num == 0 ? Mathf.lerpDelta(this.strength, 0.0f, 0.07f * Time.delta) : Mathf.lerpDelta(this.strength, 1f, 0.08f * Time.delta);
        if (!this.timer(this.this\u00240.timerTarget, 20f))
          return;
        RepairPoint.rect.setSize(this.this\u00240.repairRadius * 2f).setCenter(this.x, this.y);
        this.target = Units.closest(this.team, this.x, this.y, this.this\u00240.repairRadius, (Boolf) new RepairPoint.RepairPointBuild.__\u003C\u003EAnon0());
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.target != null && this.enabled;

      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BlockStatus status() => Mathf.equal(this.efficiency(), 0.0f, 0.01f) ? BlockStatus.__\u003C\u003EnoInput : this.cons.status();

      [LineNumberTable(134)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.this\u00240.repairRadius;

      [LineNumberTable(new byte[] {89, 135, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.rotation);
      }

      [LineNumberTable(new byte[] {159, 106, 131, 136, 100, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        if (num < 1)
          return;
        this.rotation = read.f();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [HideFromJava]
      public override float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

      [HideFromJava]
      static RepairPointBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (((Healthc) obj0).damaged() ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (RepairPoint.lambda\u0024init\u00240((Building) obj0) ? 1 : 0) != 0;
    }
  }
}
