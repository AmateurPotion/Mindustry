// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.StatusFieldAbility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public class StatusFieldAbility : Ability
  {
    public StatusEffect effect;
    public float duration;
    public float reload;
    public float range;
    public Effect applyEffect;
    public Effect activeEffect;
    protected internal float timer;

    [LineNumberTable(new byte[] {159, 161, 232, 56, 127, 2, 107, 235, 71, 104, 104, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StatusFieldAbility(StatusEffect effect, float duration, float reload, float range)
    {
      StatusFieldAbility statusFieldAbility = this;
      this.duration = 60f;
      this.reload = 100f;
      this.range = 20f;
      this.applyEffect = Fx.__\u003C\u003Eheal;
      this.activeEffect = Fx.__\u003C\u003EoverdriveWave;
      this.duration = duration;
      this.reload = reload;
      this.range = range;
      this.effect = effect;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00240([In] Unit obj0) => obj0.apply(this.effect, this.duration);

    [LineNumberTable(new byte[] {159, 159, 232, 58, 127, 2, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StatusFieldAbility()
    {
      StatusFieldAbility statusFieldAbility = this;
      this.duration = 60f;
      this.reload = 100f;
      this.range = 20f;
      this.applyEffect = Fx.__\u003C\u003Eheal;
      this.activeEffect = Fx.__\u003C\u003EoverdriveWave;
    }

    [LineNumberTable(new byte[] {159, 170, 147, 110, 223, 9, 140, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      this.timer += Time.delta;
      if ((double) this.timer < (double) this.reload)
        return;
      Units.nearby(unit.team, unit.x, unit.y, this.range, (Cons) new StatusFieldAbility.__\u003C\u003EAnon0(this));
      this.activeEffect.at((Position) unit);
      this.timer = 0.0f;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly StatusFieldAbility arg\u00241;

      internal __\u003C\u003EAnon0([In] StatusFieldAbility obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00240((Unit) obj0);
    }
  }
}
