// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.MendProjector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

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
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class MendProjector : Block
  {
    internal int __\u003C\u003EtimerUse;
    public Color baseColor;
    public Color phaseColor;
    public TextureRegion topRegion;
    public float reload;
    public float range;
    public float healPercent;
    public float phaseBoost;
    public float phaseRangeBoost;
    public float useTime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024drawPlace\u00240([In] Building obj0) => true;

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawPlace\u00241([In] Building obj0) => Drawf.selected(obj0, Tmp.__\u003C\u003Ec1.set(this.baseColor).a(Mathf.absin(4f, 1f)));

    [LineNumberTable(new byte[] {159, 173, 233, 52, 121, 112, 144, 107, 107, 107, 107, 107, 203, 103, 103, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MendProjector(string name)
      : base(name)
    {
      MendProjector mendProjector1 = this;
      MendProjector mendProjector2 = this;
      int timers = mendProjector2.timers;
      MendProjector mendProjector3 = mendProjector2;
      int num = timers;
      mendProjector3.timers = timers + 1;
      this.__\u003C\u003EtimerUse = num;
      this.baseColor = Color.valueOf("84f491");
      this.phaseColor = Color.valueOf("ffd59e");
      this.reload = 250f;
      this.range = 60f;
      this.healPercent = 12f;
      this.phaseBoost = 12f;
      this.phaseRangeBoost = 50f;
      this.useTime = 400f;
      this.solid = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Eprojectors;
      this.hasPower = true;
      this.hasItems = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 188, 134, 127, 24, 159, 3, 127, 3, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003ErepairTime, (float) ByteCodeHelper.f2i(100f / this.healPercent * this.reload / 60f), StatUnit.__\u003C\u003Eseconds);
      this.stats.add(Stat.__\u003C\u003Erange, this.range / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EboostEffect, this.phaseRangeBoost / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EboostEffect, (this.phaseBoost + this.healPercent) / this.healPercent, StatUnit.__\u003C\u003EtimesSpeed);
    }

    [LineNumberTable(new byte[] {159, 128, 99, 138, 159, 10, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Drawf.dashCircle((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, this.baseColor);
      Vars.indexer.eachBlock(Vars.player.team(), (float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, (Boolf) new MendProjector.__\u003C\u003EAnon0(), (Cons) new MendProjector.__\u003C\u003EAnon1(this));
    }

    [HideFromJava]
    static MendProjector() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerUse
    {
      [HideFromJava] get => this.__\u003C\u003EtimerUse;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerUse = value;
    }

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class MendBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      internal float heat;
      internal float charge;
      internal float phaseHeat;
      internal float smoothEfficiency;
      [Modifiers]
      internal MendProjector this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(91)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024updateTile\u00240([In] Building obj0) => obj0.damaged();

      [Modifiers]
      [LineNumberTable(new byte[] {42, 127, 32, 127, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024updateTile\u00241([In] Building obj0)
      {
        obj0.heal(obj0.maxHealth() * (this.this\u00240.healPercent + this.phaseHeat * this.this\u00240.phaseBoost) / 100f * this.efficiency());
        Fx.__\u003C\u003EhealBlockFull.at(obj0.x, obj0.y, (float) obj0.block.size, Tmp.__\u003C\u003Ec1.set(this.this\u00240.baseColor).lerp(this.this\u00240.phaseColor, this.phaseHeat));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024drawSelect\u00242([In] Building obj0) => true;

      [Modifiers]
      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024drawSelect\u00243([In] Building obj0) => Drawf.selected(obj0, Tmp.__\u003C\u003Ec1.set(this.this\u00240.baseColor).a(Mathf.absin(4f, 1f)));

      [LineNumberTable(new byte[] {14, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MendBuild(MendProjector _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MendProjector.MendBuild mendBuild = this;
        this.charge = Mathf.random(this.this\u00240.reload);
      }

      [LineNumberTable(72)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.this\u00240.range;

      [LineNumberTable(new byte[] {27, 126, 127, 20, 157, 159, 9, 127, 26, 166, 115, 127, 2, 139, 255, 3, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.smoothEfficiency = Mathf.lerpDelta(this.smoothEfficiency, this.efficiency(), 0.08f);
        this.heat = Mathf.lerpDelta(this.heat, this.consValid() || this.cheating() ? 1f : 0.0f, 0.08f);
        this.charge += this.heat * this.delta();
        this.phaseHeat = Mathf.lerpDelta(this.phaseHeat, (float) Mathf.num(this.cons.optionalValid()), 0.1f);
        if (this.cons.optionalValid() && this.timer(this.this\u00240.__\u003C\u003EtimerUse, this.this\u00240.useTime) && (double) this.efficiency() > 0.0)
          this.consume();
        if ((double) this.charge < (double) this.this\u00240.reload)
          return;
        float range = this.this\u00240.range + this.phaseHeat * this.this\u00240.phaseRangeBoost;
        this.charge = 0.0f;
        Vars.indexer.eachBlock((Teamc) this, range, (Boolf) new MendProjector.MendBuild.__\u003C\u003EAnon0(), (Cons) new MendProjector.MendBuild.__\u003C\u003EAnon1(this));
      }

      [LineNumberTable(new byte[] {50, 159, 2, 159, 3, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        float num = this.this\u00240.range + this.phaseHeat * this.this\u00240.phaseRangeBoost;
        Vars.indexer.eachBlock((Teamc) this, num, (Boolf) new MendProjector.MendBuild.__\u003C\u003EAnon2(), (Cons) new MendProjector.MendBuild.__\u003C\u003EAnon3(this));
        Drawf.dashCircle(this.x, this.y, num, this.this\u00240.baseColor);
      }

      [LineNumberTable(new byte[] {59, 134, 155, 127, 2, 127, 10, 124, 106, 124, 159, 56, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        float num = 1f - Time.time / 100f % 1f;
        Draw.color(this.this\u00240.baseColor, this.this\u00240.phaseColor, this.phaseHeat);
        Draw.alpha(this.heat * Mathf.absin(Time.time, 10f, 1f) * 0.5f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        Draw.alpha(1f);
        Lines.stroke((2f * num + 0.2f) * this.heat);
        Lines.square(this.x, this.y, Math.min(1f + (1f - num) * (float) this.this\u00240.size * 8f / 2f, (float) (this.this\u00240.size * 8) / 2f));
        Draw.reset();
      }

      [LineNumberTable(new byte[] {75, 127, 29})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, 50f * this.smoothEfficiency, this.this\u00240.baseColor, 0.7f * this.smoothEfficiency);

      [LineNumberTable(new byte[] {80, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.heat);
        write.f(this.phaseHeat);
      }

      [LineNumberTable(new byte[] {159, 108, 99, 104, 109, 109})]
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
      static MendBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (MendProjector.MendBuild.lambda\u0024updateTile\u00240((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly MendProjector.MendBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] MendProjector.MendBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateTile\u00241((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get([In] object obj0) => (MendProjector.MendBuild.lambda\u0024drawSelect\u00242((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly MendProjector.MendBuild arg\u00241;

        internal __\u003C\u003EAnon3([In] MendProjector.MendBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawSelect\u00243((Building) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (MendProjector.lambda\u0024drawPlace\u00240((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly MendProjector arg\u00241;

      internal __\u003C\u003EAnon1([In] MendProjector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawPlace\u00241((Building) obj0);
    }
  }
}
