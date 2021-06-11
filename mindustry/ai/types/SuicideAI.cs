// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.SuicideAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.liquid;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.types
{
  public class SuicideAI : GroundAI
  {
    internal static bool blockedByBlock;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Teamc target(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      return Units.closestTarget(this.unit.team, x, y, range, (Boolf) new SuicideAI.__\u003C\u003EAnon1(num1 != 0, num2 != 0), (Boolf) new SuicideAI.__\u003C\u003EAnon2(num2 != 0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 118, 124, 122, 127, 12, 102, 130, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024updateUnit\u00240([In] int obj0, [In] int obj1)
    {
      Point2[] d4c = Geometry.__\u003C\u003Ed4c;
      int length = d4c.Length;
      int index = 0;
      if (index >= length)
        return false;
      Point2 point2 = d4c[index];
      Tile tile = Vars.world.tile(obj0 + point2.x, obj1 + point2.y);
      if (tile != null && object.ReferenceEquals((object) tile.build, (object) this.target))
        return false;
      if (tile != null && tile.build != null && !object.ReferenceEquals((object) tile.build.team, (object) this.unit.team()))
      {
        SuicideAI.blockedByBlock = true;
        return true;
      }
      return tile == null || tile.solid();
    }

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024target\u00241([In] bool obj0, [In] bool obj1, [In] Unit obj2)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      return obj2.checkTarget(num1 != 0, num2 != 0);
    }

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024target\u00242([In] bool obj0, [In] Building obj1) => obj0 && !(obj1.block is Conveyor) && !(obj1.block is Conduit);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SuicideAI()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 127, 20, 167, 104, 191, 47, 140, 134, 127, 19, 98, 127, 18, 63, 60, 166, 114, 223, 33, 255, 91, 69, 166, 255, 36, 79, 103, 162, 100, 130, 255, 24, 69, 102, 114, 159, 5, 120, 135, 119, 167, 191, 10, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateUnit()
    {
      if (Units.invalidateTarget((Posc) this.target, this.unit.team, this.unit.x, this.unit.y, float.MaxValue))
        this.target = (Teamc) null;
      if (this.retarget())
        this.target = this.target(this.unit.x, this.unit.y, this.unit.range(), this.unit.type.targetAir, this.unit.type.targetGround);
      Building building1 = this.unit.closestEnemyCore();
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (!Units.invalidateTarget(this.target, this.unit, this.unit.range()) && this.unit.hasWeapons())
      {
        num1 = 1;
        Unit unit = this.unit;
        Teamc target1 = this.target;
        double num4 = (double) ((Weapon) this.unit.type.weapons.first()).bullet.range();
        Teamc target2 = this.target;
        Building building2;
        double num5 = !(target2 is Building) || !object.ReferenceEquals((object) (building2 = (Building) target2), (object) (Building) target2) ? (double) (((Hitboxc) this.target).hitSize() / 2f) : (double) ((float) (building2.block.size * 8) / 2f);
        double num6 = num4 + num5;
        num2 = unit.within((Position) target1, (float) num6) ? 1 : 0;
        if (this.unit.type.hasWeapons())
          this.unit.aimLook((Position) Predict.intercept((Position) this.unit, (Position) this.target, ((Weapon) this.unit.type.weapons.first()).bullet.speed));
        Teamc target3 = this.target;
        Building building3;
        if (!(target3 is Building) || !object.ReferenceEquals((object) (building3 = (Building) target3), (object) (Building) target3) || !object.ReferenceEquals((object) building3.block.group, (object) BlockGroup.__\u003C\u003Ewalls) && !object.ReferenceEquals((object) building3.block.group, (object) BlockGroup.__\u003C\u003Eliquids) && !object.ReferenceEquals((object) building3.block.group, (object) BlockGroup.__\u003C\u003Etransportation))
        {
          SuicideAI.blockedByBlock = false;
          int num7 = Vars.world.raycast(this.unit.tileX(), this.unit.tileY(), this.target.tileX(), this.target.tileY(), (Geometry.Raycaster) new SuicideAI.__\u003C\u003EAnon0(this)) ? 1 : 0;
          if (SuicideAI.blockedByBlock)
            num2 = 1;
          if (num7 == 0)
          {
            num3 = 1;
            this.unit.moveAt(AIController.__\u003C\u003Evec.set((Position) this.target).sub((Position) this.unit).limit(this.unit.speed()));
          }
        }
      }
      if (num3 == 0)
      {
        if (object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Erally))
        {
          Teamc teamc = this.targetFlag(this.unit.x, this.unit.y, BlockFlag.__\u003C\u003Erally, false);
          if (teamc != null && !this.unit.within((Position) teamc, 70f))
            this.pathfind(1);
        }
        else if (object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Eattack) && building1 != null)
          this.pathfind(0);
        if (this.unit.moving())
          this.unit.lookAt(this.unit.vel().angle());
      }
      this.unit.controlWeapons(num1 != 0, num2 != 0);
    }

    [HideFromJava]
    static SuicideAI() => GroundAI.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Geometry.Raycaster
    {
      private readonly SuicideAI arg\u00241;

      internal __\u003C\u003EAnon0([In] SuicideAI obj0) => this.arg\u00241 = obj0;

      public bool accept([In] int obj0, [In] int obj1) => (this.arg\u00241.lambda\u0024updateUnit\u00240(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly bool arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon1([In] bool obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (SuicideAI.lambda\u0024target\u00241(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly bool arg\u00241;

      internal __\u003C\u003EAnon2([In] bool obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (SuicideAI.lambda\u0024target\u00242(this.arg\u00241, (Building) obj0) ? 1 : 0) != 0;
    }
  }
}
