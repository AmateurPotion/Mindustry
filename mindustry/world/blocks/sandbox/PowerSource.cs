// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.PowerSource
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.world.blocks.power;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.sandbox
{
  public class PowerSource : PowerNode
  {
    public float powerProduction;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 233, 61, 203, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerSource(string name)
      : base(name)
    {
      PowerSource powerSource = this;
      this.powerProduction = 10000f;
      this.maxNodes = 100;
      this.outputsPower = true;
      this.consumesPower = false;
    }

    [HideFromJava]
    static PowerSource() => PowerNode.__\u003Cclinit\u003E();

    public class PowerSourceBuild : PowerNode.PowerNodeBuild
    {
      [Modifiers]
      internal PowerSource this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(16)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerSourceBuild(PowerSource _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerNode) _param1);
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPowerProduction() => this.enabled ? this.this\u00240.powerProduction : 0.0f;

      [HideFromJava]
      static PowerSourceBuild() => PowerNode.PowerNodeBuild.__\u003Cclinit\u003E();
    }
  }
}
