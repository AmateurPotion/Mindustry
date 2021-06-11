// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.UnitSpawnAbility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public class UnitSpawnAbility : Ability
  {
    public UnitType unit;
    public float spawnTime;
    public float spawnX;
    public float spawnY;
    public Effect spawnEffect;
    protected internal float timer;

    [LineNumberTable(new byte[] {159, 166, 232, 59, 107, 235, 69, 103, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitSpawnAbility(UnitType unit, float spawnTime, float spawnX, float spawnY)
    {
      UnitSpawnAbility unitSpawnAbility = this;
      this.spawnTime = 60f;
      this.spawnEffect = Fx.__\u003C\u003Espawn;
      this.unit = unit;
      this.spawnTime = spawnTime;
      this.spawnX = spawnX;
      this.spawnY = spawnY;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {6, 127, 35, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00240([In] Unit obj0) => Drawf.construct(obj0.x + Angles.trnsx(obj0.rotation, this.spawnY, this.spawnX), obj0.y + Angles.trnsy(obj0.rotation, this.spawnY, this.spawnX), this.unit.icon(Cicon.__\u003C\u003Efull), obj0.rotation - 90f, this.timer / this.spawnTime, 1f, this.timer);

    [LineNumberTable(new byte[] {159, 173, 232, 52, 107, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitSpawnAbility()
    {
      UnitSpawnAbility unitSpawnAbility = this;
      this.spawnTime = 60f;
      this.spawnEffect = Fx.__\u003C\u003Espawn;
    }

    [LineNumberTable(new byte[] {159, 178, 159, 5, 127, 8, 127, 35, 109, 114, 104, 108, 108, 166, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      this.timer += Time.delta * Vars.state.rules.unitBuildSpeedMultiplier;
      if ((double) this.timer < (double) this.spawnTime || !Units.canCreate(unit.team, this.unit))
        return;
      float x = unit.x + Angles.trnsx(unit.rotation, this.spawnY, this.spawnX);
      float y = unit.y + Angles.trnsy(unit.rotation, this.spawnY, this.spawnX);
      this.spawnEffect.at(x, y);
      Unit unit1 = this.unit.create(unit.team);
      unit1.set(x, y);
      unit1.rotation = unit.rotation;
      if (!Vars.net.client())
        unit1.add();
      this.timer = 0.0f;
    }

    [LineNumberTable(new byte[] {4, 115, 247, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Unit unit)
    {
      if (!Units.canCreate(unit.team, this.unit))
        return;
      Draw.draw(Draw.z(), (Runnable) new UnitSpawnAbility.__\u003C\u003EAnon0(this, unit));
    }

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string localized() => Core.bundle.format("ability.unitspawn", (object) this.unit.localizedName);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly UnitSpawnAbility arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon0([In] UnitSpawnAbility obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024draw\u00240(this.arg\u00242);
    }
  }
}
