// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.ShieldRegenFieldAbility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public class ShieldRegenFieldAbility : Ability
  {
    public float amount;
    public float max;
    public float reload;
    public float range;
    public Effect applyEffect;
    public Effect activeEffect;
    protected internal float timer;
    protected internal bool applied;

    [LineNumberTable(new byte[] {159, 160, 232, 55, 127, 13, 107, 171, 231, 69, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShieldRegenFieldAbility(float amount, float max, float reload, float range)
    {
      ShieldRegenFieldAbility regenFieldAbility = this;
      this.amount = 1f;
      this.max = 100f;
      this.reload = 100f;
      this.range = 60f;
      this.applyEffect = Fx.__\u003C\u003EshieldApply;
      this.activeEffect = Fx.__\u003C\u003EshieldWave;
      this.applied = false;
      this.amount = amount;
      this.max = max;
      this.reload = reload;
      this.range = range;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 110, 127, 1, 107, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00240([In] Unit obj0, [In] Unit obj1)
    {
      if ((double) obj1.shield >= (double) this.max)
        return;
      obj1.shield = Math.max(obj1.shield + this.amount, this.max);
      obj1.shieldAlpha = 1f;
      this.applyEffect.at((Position) obj0);
      this.applied = true;
    }

    [LineNumberTable(new byte[] {159, 158, 232, 57, 127, 13, 107, 171, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ShieldRegenFieldAbility()
    {
      ShieldRegenFieldAbility regenFieldAbility = this;
      this.amount = 1f;
      this.max = 100f;
      this.reload = 100f;
      this.range = 60f;
      this.applyEffect = Fx.__\u003C\u003EshieldApply;
      this.activeEffect = Fx.__\u003C\u003EshieldWave;
      this.applied = false;
    }

    [LineNumberTable(new byte[] {159, 169, 147, 110, 135, 255, 10, 73, 104, 172, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      this.timer += Time.delta;
      if ((double) this.timer < (double) this.reload)
        return;
      this.applied = false;
      Units.nearby(unit.team, unit.x, unit.y, this.range, (Cons) new ShieldRegenFieldAbility.__\u003C\u003EAnon0(this, unit));
      if (this.applied)
        this.activeEffect.at((Position) unit);
      this.timer = 0.0f;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ShieldRegenFieldAbility arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon0([In] ShieldRegenFieldAbility obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00240(this.arg\u00242, (Unit) obj0);
    }
  }
}
