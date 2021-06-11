// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.ThermalGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.math;
using IKVM.Attributes;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class ThermalGenerator : PowerGenerator
  {
    public Effect generateEffect;
    public Attribute attribute;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024canPlaceOn\u00240([In] Tile obj0) => obj0.floor().attributes.get(this.attribute);

    [LineNumberTable(new byte[] {159, 160, 233, 60, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThermalGenerator(string name)
      : base(name)
    {
      ThermalGenerator thermalGenerator = this;
      this.generateEffect = Fx.__\u003C\u003Enone;
      this.attribute = Attribute.__\u003C\u003Eheat;
    }

    [LineNumberTable(new byte[] {159, 165, 134, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Etiles, this.attribute, this.floating);
    }

    [LineNumberTable(new byte[] {159, 135, 131, 138, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num1 != 0);
      double num2 = (double) this.drawPlaceText(Core.bundle.formatFloat("bar.efficiency", this.sumAttribute(this.attribute, x, y) * 100f, 1), x, y, num1 != 0);
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPlaceOn(Tile tile, Team team) => (double) tile.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).sumf((Floatf) new ThermalGenerator.__\u003C\u003EAnon0(this)) > 0.00999999977648258;

    [HideFromJava]
    static ThermalGenerator() => PowerGenerator.__\u003Cclinit\u003E();

    public class ThermalGeneratorBuild : PowerGenerator.GeneratorBuild
    {
      public float sum;
      [Modifiers]
      internal ThermalGenerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ThermalGeneratorBuild(ThermalGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerGenerator) _param1);
      }

      [LineNumberTable(new byte[] {159, 188, 159, 0, 127, 8, 159, 23})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.productionEfficiency = this.sum + this.this\u00240.attribute.env();
        if ((double) this.productionEfficiency <= 0.100000001490116 || !Mathf.chance(0.05 * (double) this.delta()))
          return;
        this.this\u00240.generateEffect.at(this.x + Mathf.range(3f), this.y + Mathf.range(3f));
      }

      [LineNumberTable(new byte[] {5, 127, 47})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, (40f + Mathf.absin(10f, 5f)) * this.productionEfficiency * (float) this.this\u00240.size, Color.__\u003C\u003Escarlet, 0.4f);

      [LineNumberTable(new byte[] {10, 134, 127, 20})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityAdded()
      {
        base.onProximityAdded();
        this.sum = this.this\u00240.sumAttribute(this.this\u00240.attribute, (int) this.tile.x, (int) this.tile.y);
      }

      [HideFromJava]
      static ThermalGeneratorBuild() => PowerGenerator.GeneratorBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Floatf
    {
      private readonly ThermalGenerator arg\u00241;

      internal __\u003C\u003EAnon0([In] ThermalGenerator obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024canPlaceOn\u00240((Tile) obj0);
    }
  }
}
