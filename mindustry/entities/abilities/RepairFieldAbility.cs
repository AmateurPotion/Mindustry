// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.RepairFieldAbility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public class RepairFieldAbility : Ability
  {
    public float amount;
    public float reload;
    public float range;
    public Effect healEffect;
    public Effect activeEffect;
    protected internal float timer;
    protected internal bool wasHealed;

    [LineNumberTable(new byte[] {159, 160, 232, 55, 127, 2, 107, 171, 231, 69, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RepairFieldAbility(float amount, float reload, float range)
    {
      RepairFieldAbility repairFieldAbility = this;
      this.amount = 1f;
      this.reload = 100f;
      this.range = 60f;
      this.healEffect = Fx.__\u003C\u003Eheal;
      this.activeEffect = Fx.__\u003C\u003EhealWaveDynamic;
      this.wasHealed = false;
      this.amount = amount;
      this.reload = reload;
      this.range = range;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 104, 108, 135, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00240([In] Unit obj0)
    {
      if (obj0.damaged())
      {
        this.healEffect.at((Position) obj0);
        this.wasHealed = true;
      }
      obj0.heal(this.amount);
    }

    [LineNumberTable(new byte[] {159, 158, 232, 57, 127, 2, 107, 171, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RepairFieldAbility()
    {
      RepairFieldAbility repairFieldAbility = this;
      this.amount = 1f;
      this.reload = 100f;
      this.range = 60f;
      this.healEffect = Fx.__\u003C\u003Eheal;
      this.activeEffect = Fx.__\u003C\u003EhealWaveDynamic;
      this.wasHealed = false;
    }

    [LineNumberTable(new byte[] {159, 168, 147, 110, 135, 255, 9, 72, 104, 178, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      this.timer += Time.delta;
      if ((double) this.timer < (double) this.reload)
        return;
      this.wasHealed = false;
      Units.nearby(unit.team, unit.x, unit.y, this.range, (Cons) new RepairFieldAbility.__\u003C\u003EAnon0(this));
      if (this.wasHealed)
        this.activeEffect.at((Position) unit, this.range);
      this.timer = 0.0f;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly RepairFieldAbility arg\u00241;

      internal __\u003C\u003EAnon0([In] RepairFieldAbility obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00240((Unit) obj0);
    }
  }
}
