// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerDiode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class PowerDiode : Block
  {
    public TextureRegion arrow;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float bar(Building tile) => tile != null && tile.block.hasPower ? tile.power.graph.getLastPowerStored() / tile.power.graph.getTotalBatteryCapacity() : 0.0f;

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00241([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar("bar.input", Pal.powerBar, (Floatp) new PowerDiode.__\u003C\u003EAnon3(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00243([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar("bar.output", Pal.powerBar, (Floatp) new PowerDiode.__\u003C\u003EAnon2(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00242([In] Building obj0) => this.bar(obj0.front());

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00240([In] Building obj0) => this.bar(obj0.back());

    [LineNumberTable(new byte[] {159, 160, 105, 103, 103, 103, 103, 107, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerDiode(string name)
      : base(name)
    {
      PowerDiode powerDiode = this;
      this.rotate = true;
      this.update = true;
      this.solid = true;
      this.insulated = true;
      this.group = BlockGroup.__\u003C\u003Epower;
      this.noUpdateDisabled = true;
      this.schematicPriority = 10;
    }

    [LineNumberTable(new byte[] {159, 172, 134, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("back", (Func) new PowerDiode.__\u003C\u003EAnon0(this));
      this.__\u003C\u003Ebars.add("front", (Func) new PowerDiode.__\u003C\u003EAnon1(this));
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 180, 126, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.icon(Cicon.__\u003C\u003Efull), req.drawx(), req.drawy());
      Draw.rect(this.arrow, req.drawx(), req.drawy(), this.rotate ? (float) (req.rotation * 90) : 0.0f);
    }

    [HideFromJava]
    static PowerDiode() => Block.__\u003Cclinit\u003E();

    public class PowerDiodeBuild : Building
    {
      [Modifiers]
      internal PowerDiode this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerDiodeBuild(PowerDiode _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {0, 127, 2, 127, 24})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y, 0.0f);
        Draw.rect(this.this\u00240.arrow, this.x, this.y, !this.this\u00240.rotate ? 0.0f : this.rotdeg());
      }

      [LineNumberTable(new byte[] {6, 134, 159, 51, 113, 113, 170, 113, 177, 132, 150, 159, 1, 105, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        base.updateTile();
        if (this.front() == null || this.back() == null || (!this.back().block.hasPower || !this.front().block.hasPower) || !object.ReferenceEquals((object) this.back().team, (object) this.front().team))
          return;
        PowerGraph graph1 = this.back().power.graph;
        PowerGraph graph2 = this.front().power.graph;
        if (object.ReferenceEquals((object) graph1, (object) graph2))
          return;
        float num1 = graph1.getBatteryStored() / graph1.getTotalBatteryCapacity();
        float num2 = graph2.getBatteryStored() / graph2.getTotalBatteryCapacity();
        if ((double) num1 <= (double) num2)
          return;
        float amount = Mathf.clamp(graph1.getBatteryStored() * (num1 - num2) / 2f, 0.0f, graph2.getTotalBatteryCapacity() * (1f - num2));
        graph1.transferPower(-amount);
        graph2.transferPower(amount);
      }

      [HideFromJava]
      static PowerDiodeBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly PowerDiode arg\u00241;

      internal __\u003C\u003EAnon0([In] PowerDiode obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00241((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Func
    {
      private readonly PowerDiode arg\u00241;

      internal __\u003C\u003EAnon1([In] PowerDiode obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00243((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly PowerDiode arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon2([In] PowerDiode obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly PowerDiode arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon3([In] PowerDiode obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00240(this.arg\u00242);
    }
  }
}
