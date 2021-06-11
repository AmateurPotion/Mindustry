// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class PowerGenerator : PowerDistributor
  {
    public float powerProduction;
    public Stat generationType;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00243([In] PowerGenerator.GeneratorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new PowerGenerator.__\u003C\u003EAnon1(obj0), (Prov) new PowerGenerator.__\u003C\u003EAnon2(), (Floatp) new PowerGenerator.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 115, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] PowerGenerator.GeneratorBuild obj0) => Core.bundle.format("bar.poweroutput", (object) Strings.@fixed(obj0.getPowerProduction() * 60f * obj0.timeScale(), 1));

    [Modifiers]
    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.powerBar;

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] PowerGenerator.GeneratorBuild obj0) => obj0.productionEfficiency;

    [LineNumberTable(new byte[] {159, 161, 233, 61, 203, 103, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerGenerator(string name)
      : base(name)
    {
      PowerGenerator powerGenerator = this;
      this.generationType = Stat.__\u003C\u003EbasePowerGeneration;
      this.sync = true;
      this.baseExplosiveness = 5f;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Egenerator
      });
    }

    [LineNumberTable(new byte[] {159, 169, 102, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(this.generationType, this.powerProduction * 60f, StatUnit.__\u003C\u003EpowerSecond);
    }

    [LineNumberTable(new byte[] {159, 175, 134, 125, 250, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      if (!this.hasPower || !this.outputsPower || this.__\u003C\u003Econsumes.hasPower())
        return;
      this.__\u003C\u003Ebars.add("power", (Func) new PowerGenerator.__\u003C\u003EAnon0());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [HideFromJava]
    static PowerGenerator() => PowerDistributor.__\u003Cclinit\u003E();

    public class GeneratorBuild : Building
    {
      public float generateTime;
      public float productionEfficiency;
      [Modifiers]
      internal PowerGenerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPowerProduction() => this.this\u00240.powerProduction * this.productionEfficiency;

      [LineNumberTable(new byte[] {159, 191, 175})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GeneratorBuild(PowerGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        PowerGenerator.GeneratorBuild generatorBuild = this;
        this.productionEfficiency = 0.0f;
      }

      [LineNumberTable(56)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float ambientVolume() => Mathf.clamp(this.productionEfficiency);

      [LineNumberTable(new byte[] {16, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.productionEfficiency);
      }

      [LineNumberTable(new byte[] {159, 124, 67, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.productionEfficiency = read.f();
      }

      [HideFromJava]
      static GeneratorBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) PowerGenerator.lambda\u0024setBars\u00243((PowerGenerator.GeneratorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly PowerGenerator.GeneratorBuild arg\u00241;

      internal __\u003C\u003EAnon1([In] PowerGenerator.GeneratorBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) PowerGenerator.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) PowerGenerator.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly PowerGenerator.GeneratorBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] PowerGenerator.GeneratorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => PowerGenerator.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
