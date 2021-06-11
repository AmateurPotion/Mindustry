// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.DefenderAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.entities;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.types
{
  public class DefenderAI : AIController
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 146, 127, 24, 197, 127, 4, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Teamc findTarget(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      if (!object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Erally))
      {
        Unit unit = Units.closest(this.unit.team, x, y, Math.max(range, 400f), (Boolf) new DefenderAI.__\u003C\u003EAnon0(this), (Units.Sortf) new DefenderAI.__\u003C\u003EAnon1());
        if (unit != null)
          return (Teamc) unit;
      }
      return this.targetFlag(this.unit.x, this.unit.y, BlockFlag.__\u003C\u003Erally, false) ?? (Teamc) this.unit.closestCore();
    }

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024findTarget\u00240([In] Unit obj0) => !obj0.dead() && !object.ReferenceEquals((object) obj0.type, (object) this.unit.type);

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024findTarget\u00241([In] Unit obj0, [In] float obj1, [In] float obj2) => -obj0.maxHealth + Mathf.dst2(obj0.x, obj0.y, obj1, obj2) / 800f;

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefenderAI()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 107, 127, 77, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateMovement()
    {
      if (this.target == null)
        return;
      Teamc target1 = this.target;
      Teamc target2 = this.target;
      Sized sized;
      double num = (double) ((!(target2 is Sized) || !object.ReferenceEquals((object) (sized = (Sized) target2), (object) (Sized) target2) ? 0.0f : sized.hitSize() / 2f * 1.1f) + this.unit.hitSize / 2f + 15f);
      this.moveTo((Position) target1, (float) num, 50f);
      this.unit.lookAt((Position) this.target);
    }

    [LineNumberTable(new byte[] {159, 164, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateTargeting()
    {
      if (!this.retarget())
        return;
      this.target = this.findTarget(this.unit.x, this.unit.y, this.unit.range(), true, true);
    }

    [HideFromJava]
    static DefenderAI() => AIController.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly DefenderAI arg\u00241;

      internal __\u003C\u003EAnon0([In] DefenderAI obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024findTarget\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Units.Sortf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float cost([In] Unit obj0, [In] float obj1, [In] float obj2) => DefenderAI.lambda\u0024findTarget\u00241(obj0, obj1, obj2);
    }
  }
}
