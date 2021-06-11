// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.SolarGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using java.lang;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class SolarGenerator : PowerGenerator
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 137, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SolarGenerator(string name)
      : base(name)
    {
      SolarGenerator solarGenerator = this;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[0]);
    }

    [LineNumberTable(new byte[] {159, 161, 102, 113, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(this.generationType);
      this.stats.add(this.generationType, this.powerProduction * 60f, StatUnit.__\u003C\u003EpowerSecond);
    }

    [HideFromJava]
    static SolarGenerator() => PowerGenerator.__\u003Cclinit\u003E();

    public class SolarGeneratorBuild : PowerGenerator.GeneratorBuild
    {
      [Modifiers]
      internal SolarGenerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SolarGeneratorBuild(SolarGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerGenerator) _param1);
      }

      [LineNumberTable(new byte[] {159, 169, 105, 107, 113, 125, 231, 61, 200, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile() => this.productionEfficiency = !this.enabled ? 0.0f : Mathf.maxZero(Attribute.__\u003C\u003Elight.env() + (!Vars.state.rules.lighting ? 1f : 1f - Vars.state.rules.ambientLight.a));

      [HideFromJava]
      static SolarGeneratorBuild() => PowerGenerator.GeneratorBuild.__\u003Cclinit\u003E();
    }
  }
}
