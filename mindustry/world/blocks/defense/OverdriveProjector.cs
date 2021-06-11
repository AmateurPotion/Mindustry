// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.OverdriveProjector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
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
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class OverdriveProjector : Block
  {
    internal int __\u003C\u003EtimerUse;
    public TextureRegion topRegion;
    public float reload;
    public float range;
    public float speedBoost;
    public float speedBoostPhase;
    public float useTime;
    public float phaseRangeBoost;
    public bool hasBoost;
    public Color baseColor;
    public Color phaseColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024drawPlace\u00240([In] Building obj0) => obj0.block.canOverdrive;

    [Modifiers]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawPlace\u00241([In] Building obj0) => Drawf.selected(obj0, Tmp.__\u003C\u003Ec1.set(this.baseColor).a(Mathf.absin(4f, 1f)));

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00245([In] OverdriveProjector.OverdriveBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new OverdriveProjector.__\u003C\u003EAnon3(obj0), (Prov) new OverdriveProjector.__\u003C\u003EAnon4(), (Floatp) new OverdriveProjector.__\u003C\u003EAnon5(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00242([In] OverdriveProjector.OverdriveBuild obj0) => Core.bundle.format("bar.boost", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.realBoost() * 100f)));

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00243() => Pal.accent;

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00244([In] OverdriveProjector.OverdriveBuild obj0) => obj0.realBoost() / (!this.hasBoost ? this.speedBoost : this.speedBoost + this.speedBoostPhase);

    [LineNumberTable(new byte[] {159, 177, 233, 50, 185, 107, 107, 107, 107, 107, 107, 103, 112, 208, 103, 103, 107, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OverdriveProjector(string name)
      : base(name)
    {
      OverdriveProjector overdriveProjector1 = this;
      OverdriveProjector overdriveProjector2 = this;
      int timers = overdriveProjector2.timers;
      OverdriveProjector overdriveProjector3 = overdriveProjector2;
      int num = timers;
      overdriveProjector3.timers = timers + 1;
      this.__\u003C\u003EtimerUse = num;
      this.reload = 60f;
      this.range = 80f;
      this.speedBoost = 1.5f;
      this.speedBoostPhase = 0.75f;
      this.useTime = 400f;
      this.phaseRangeBoost = 20f;
      this.hasBoost = true;
      this.baseColor = Color.valueOf("feb380");
      this.phaseColor = Color.valueOf("ffd59e");
      this.solid = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Eprojectors;
      this.hasPower = true;
      this.hasItems = true;
      this.canOverdrive = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 130, 163, 138, 159, 10, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Drawf.dashCircle((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, this.baseColor);
      Vars.indexer.eachBlock(Vars.player.team(), (float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, (Boolf) new OverdriveProjector.__\u003C\u003EAnon0(), (Cons) new OverdriveProjector.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {10, 134, 127, 9, 127, 3, 159, 3, 104, 127, 3, 159, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EspeedIncrease, (float) ByteCodeHelper.f2i(100f * this.speedBoost), StatUnit.__\u003C\u003Epercent);
      this.stats.add(Stat.__\u003C\u003Erange, this.range / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.useTime / 60f, StatUnit.__\u003C\u003Eseconds);
      if (!this.hasBoost)
        return;
      this.stats.add(Stat.__\u003C\u003EboostEffect, this.phaseRangeBoost / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EboostEffect, (float) ByteCodeHelper.f2i((this.speedBoost + this.speedBoostPhase) * 100f), StatUnit.__\u003C\u003Epercent);
    }

    [LineNumberTable(new byte[] {24, 102, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("boost", (Func) new OverdriveProjector.__\u003C\u003EAnon2(this));
    }

    [HideFromJava]
    static OverdriveProjector() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerUse
    {
      [HideFromJava] get => this.__\u003C\u003EtimerUse;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerUse = value;
    }

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class OverdriveBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      internal float heat;
      internal float charge;
      internal float phaseHeat;
      internal float smoothEfficiency;
      [Modifiers]
      internal OverdriveProjector this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(117)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float realBoost() => this.consValid() ? (this.this\u00240.speedBoost + this.phaseHeat * this.this\u00240.speedBoostPhase) * this.efficiency() : 0.0f;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024updateTile\u00240([In] Building obj0) => true;

      [Modifiers]
      [LineNumberTable(108)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024updateTile\u00241([In] Building obj0) => obj0.applyBoost(this.realBoost(), this.this\u00240.reload + 1f);

      [Modifiers]
      [LineNumberTable(124)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024drawSelect\u00242([In] Building obj0) => obj0.block.canOverdrive;

      [Modifiers]
      [LineNumberTable(124)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024drawSelect\u00243([In] Building obj0) => Drawf.selected(obj0, Tmp.__\u003C\u003Ec1.set(this.this\u00240.baseColor).a(Mathf.absin(4f, 1f)));

      [LineNumberTable(new byte[] {28, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OverdriveBuild(OverdriveProjector _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        OverdriveProjector.OverdriveBuild overdriveBuild = this;
        this.charge = Mathf.random(this.this\u00240.reload);
      }

      [LineNumberTable(86)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.this\u00240.range;

      [LineNumberTable(new byte[] {41, 127, 29})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, 50f * this.smoothEfficiency, this.this\u00240.baseColor, 0.7f * this.smoothEfficiency);

      [LineNumberTable(new byte[] {46, 126, 127, 12, 155, 109, 191, 9, 115, 159, 2, 107, 191, 3, 127, 21, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.smoothEfficiency = Mathf.lerpDelta(this.smoothEfficiency, this.efficiency(), 0.08f);
        this.heat = Mathf.lerpDelta(this.heat, !this.consValid() ? 0.0f : 1f, 0.08f);
        this.charge += this.heat * Time.delta;
        if (this.this\u00240.hasBoost)
          this.phaseHeat = Mathf.lerpDelta(this.phaseHeat, (float) Mathf.num(this.cons.optionalValid()), 0.1f);
        if ((double) this.charge >= (double) this.this\u00240.reload)
        {
          float range = this.this\u00240.range + this.phaseHeat * this.this\u00240.phaseRangeBoost;
          this.charge = 0.0f;
          Vars.indexer.eachBlock((Teamc) this, range, (Boolf) new OverdriveProjector.OverdriveBuild.__\u003C\u003EAnon0(), (Cons) new OverdriveProjector.OverdriveBuild.__\u003C\u003EAnon1(this));
        }
        if (!this.timer(this.this\u00240.__\u003C\u003EtimerUse, this.this\u00240.useTime) || (double) this.efficiency() <= 0.0 || !this.consValid())
          return;
        this.consume();
      }

      [LineNumberTable(new byte[] {72, 159, 2, 159, 3, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        float num = this.this\u00240.range + this.phaseHeat * this.this\u00240.phaseRangeBoost;
        Vars.indexer.eachBlock((Teamc) this, num, (Boolf) new OverdriveProjector.OverdriveBuild.__\u003C\u003EAnon2(), (Cons) new OverdriveProjector.OverdriveBuild.__\u003C\u003EAnon3(this));
        Drawf.dashCircle(this.x, this.y, num, this.this\u00240.baseColor);
      }

      [LineNumberTable(new byte[] {81, 134, 155, 127, 2, 127, 10, 124, 106, 156, 127, 76, 101, 105, 127, 54, 31, 62, 201, 134, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        float num1 = 1f - Time.time / 100f % 1f;
        Draw.color(this.this\u00240.baseColor, this.this\u00240.phaseColor, this.phaseHeat);
        Draw.alpha(this.heat * Mathf.absin(Time.time, 10f, 1f) * 0.5f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        Draw.alpha(1f);
        Lines.stroke((2f * num1 + 0.1f) * this.heat);
        float num2 = Math.max(0.0f, Mathf.clamp(2f - num1 * 2f) * (float) this.this\u00240.size * 8f / 2f - num1 - 0.2f);
        float num3 = Mathf.clamp(0.5f - num1) * (float) this.this\u00240.size * 8f;
        Lines.beginLine();
        for (int i = 0; i < 4; ++i)
        {
          Lines.linePoint(this.x + (float) Geometry.d4(i).x * num2 + (float) Geometry.d4(i).y * num3, this.y + (float) Geometry.d4(i).y * num2 - (float) Geometry.d4(i).x * num3);
          if ((double) num1 < 0.5)
            Lines.linePoint(this.x + (float) Geometry.d4(i).x * num2 - (float) Geometry.d4(i).y * num3, this.y + (float) Geometry.d4(i).y * num2 + (float) Geometry.d4(i).x * num3);
        }
        Lines.endLine(true);
        Draw.reset();
      }

      [LineNumberTable(new byte[] {104, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.heat);
        write.f(this.phaseHeat);
      }

      [LineNumberTable(new byte[] {159, 102, 99, 104, 109, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.heat = read.f();
        this.phaseHeat = read.f();
      }

      [HideFromJava]
      public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

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
      static OverdriveBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (OverdriveProjector.OverdriveBuild.lambda\u0024updateTile\u00240((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly OverdriveProjector.OverdriveBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] OverdriveProjector.OverdriveBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateTile\u00241((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get([In] object obj0) => (OverdriveProjector.OverdriveBuild.lambda\u0024drawSelect\u00242((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly OverdriveProjector.OverdriveBuild arg\u00241;

        internal __\u003C\u003EAnon3([In] OverdriveProjector.OverdriveBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawSelect\u00243((Building) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (OverdriveProjector.lambda\u0024drawPlace\u00240((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly OverdriveProjector arg\u00241;

      internal __\u003C\u003EAnon1([In] OverdriveProjector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawPlace\u00241((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Func
    {
      private readonly OverdriveProjector arg\u00241;

      internal __\u003C\u003EAnon2([In] OverdriveProjector obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00245((OverdriveProjector.OverdriveBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Prov
    {
      private readonly OverdriveProjector.OverdriveBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] OverdriveProjector.OverdriveBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) OverdriveProjector.lambda\u0024setBars\u00242(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) OverdriveProjector.lambda\u0024setBars\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Floatp
    {
      private readonly OverdriveProjector arg\u00241;
      private readonly OverdriveProjector.OverdriveBuild arg\u00242;

      internal __\u003C\u003EAnon5([In] OverdriveProjector obj0, [In] OverdriveProjector.OverdriveBuild obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00244(this.arg\u00242);
    }
  }
}
