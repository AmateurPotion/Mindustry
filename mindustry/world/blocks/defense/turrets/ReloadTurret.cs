// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.ReloadTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class ReloadTurret : BaseTurret
  {
    public float reloadTime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00240([In] Liquid obj0) => this.__\u003C\u003Econsumes.__\u003C\u003Eliquidfilters.get((int) obj0.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {159, 158, 233, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReloadTurret(string name)
      : base(name)
    {
      ReloadTurret reloadTurret = this;
      this.reloadTime = 10f;
    }

    [LineNumberTable(new byte[] {159, 163, 134, 104, 159, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      if (!this.acceptCoolant)
        return;
      this.stats.add(Stat.__\u003C\u003Ebooster, (StatValue) new BoosterListValue(this.reloadTime, ((ConsumeLiquidBase) this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eamount, this.coolantMultiplier, true, (Boolf) new ReloadTurret.__\u003C\u003EAnon0(this)));
    }

    [HideFromJava]
    static ReloadTurret() => BaseTurret.__\u003Cclinit\u003E();

    public class ReloadTurretBuild : BaseTurret.BaseTurretBuild
    {
      public float reload;
      [Modifiers]
      internal ReloadTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(46)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual float baseReloadSpeed() => this.efficiency();

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReloadTurretBuild(ReloadTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((BaseTurret) _param1);
      }

      [LineNumberTable(new byte[] {159, 174, 159, 1, 140, 127, 63, 127, 5, 141, 116, 159, 55})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void updateCooling()
      {
        float amount1 = ((ConsumeLiquidBase) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eamount;
        Liquid liquid = this.liquids.current();
        float amount2 = Math.min(Math.min(this.liquids.get(liquid), amount1 * Time.delta), Math.max(0.0f, (this.this\u00240.reloadTime - this.reload) / this.this\u00240.coolantMultiplier / liquid.heatCapacity)) * this.baseReloadSpeed();
        this.reload += amount2 * liquid.heatCapacity * this.this\u00240.coolantMultiplier;
        this.liquids.remove(liquid, amount2);
        if (!Mathf.chance(0.06 * (double) amount2))
          return;
        this.this\u00240.coolEffect.at(this.x + Mathf.range((float) (this.this\u00240.size * 8) / 2f), this.y + Mathf.range((float) (this.this\u00240.size * 8) / 2f));
      }

      [HideFromJava]
      static ReloadTurretBuild() => BaseTurret.BaseTurretBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly ReloadTurret arg\u00241;

      internal __\u003C\u003EAnon0([In] ReloadTurret obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00240((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
