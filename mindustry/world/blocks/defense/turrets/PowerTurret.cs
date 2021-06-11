// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.PowerTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.entities.bullet;
using mindustry.logic;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class PowerTurret : Turret
  {
    public BulletType shootType;
    public float powerUse;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 233, 61, 203, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerTurret(string name)
      : base(name)
    {
      PowerTurret powerTurret = this;
      this.powerUse = 1f;
      this.hasPower = true;
    }

    [LineNumberTable(new byte[] {159, 162, 102, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eammo, (StatValue) new AmmoListValue((ObjectMap) OrderedMap.of(new object[2]
      {
        (object) this,
        (object) this.shootType
      })));
    }

    [LineNumberTable(new byte[] {159, 168, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.__\u003C\u003Econsumes.powerCond(this.powerUse, (Boolf) new PowerTurret.__\u003C\u003EAnon0());
      base.init();
    }

    [HideFromJava]
    static PowerTurret() => Turret.__\u003Cclinit\u003E();

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal new class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.defense.turrets.PowerTurret$1"))
          return;
        PowerTurret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          PowerTurret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eammo.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          PowerTurret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EammoCapacity.ordinal()] = 2;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    public class PowerTurretBuild : Turret.TurretBuild
    {
      [Modifiers]
      internal PowerTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(30)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerTurretBuild(PowerTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Turret) _param1);
      }

      [LineNumberTable(new byte[] {159, 176, 159, 10, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.unit.ammo(this.power.status * (float) this.unit.type().ammoCapacity);
        base.updateTile();
      }

      [LineNumberTable(new byte[] {159, 183, 125, 110, 103, 232, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor)
      {
        switch (PowerTurret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
        {
          case 1:
            return (double) this.power.status;
          case 2:
            return 1.0;
          default:
            return base.sense(sensor);
        }
      }

      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BulletType useAmmo() => this.this\u00240.shootType;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasAmmo() => true;

      [LineNumberTable(62)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BulletType peekAmmo() => this.this\u00240.shootType;

      [HideFromJava]
      static PowerTurretBuild() => Turret.TurretBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (((Turret.TurretBuild) obj0).isActive() ? 1 : 0) != 0;
    }
  }
}
