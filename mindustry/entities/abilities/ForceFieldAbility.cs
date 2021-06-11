// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.ForceFieldAbility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public class ForceFieldAbility : Ability
  {
    public float radius;
    public float regen;
    public float max;
    public float cooldown;
    protected internal float radiusScale;
    protected internal float alpha;
    private static float realRad;
    private static Unit paramUnit;
    private static ForceFieldAbility paramField;
    [Modifiers]
    [Signature("Larc/func/Cons<Lmindustry/gen/Bullet;>;")]
    private static Cons shieldConsumer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 191, 232, 33, 139, 139, 139, 235, 90, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForceFieldAbility(float radius, float regen, float max, float cooldown)
    {
      ForceFieldAbility forceFieldAbility = this;
      this.radius = 60f;
      this.regen = 0.1f;
      this.max = 200f;
      this.cooldown = 300f;
      this.radius = radius;
      this.regen = regen;
      this.max = max;
      this.cooldown = cooldown;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkRadius(Unit unit) => ForceFieldAbility.realRad = this.radiusScale * this.radius;

    [Modifiers]
    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024displayBars\u00241([In] Unit obj0) => obj0.shield / this.max;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 127, 87, 102, 171, 115, 159, 9, 191, 24, 121, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Bullet obj0)
    {
      if (object.ReferenceEquals((object) obj0.team, (object) ForceFieldAbility.paramUnit.team) || !obj0.type.absorbable || (!Intersector.isInsideHexagon(ForceFieldAbility.paramUnit.x, ForceFieldAbility.paramUnit.y, ForceFieldAbility.realRad * 2f, obj0.x(), obj0.y()) || (double) ForceFieldAbility.paramUnit.shield <= 0.0))
        return;
      obj0.absorb();
      Fx.__\u003C\u003Eabsorb.at((Position) obj0);
      if ((double) ForceFieldAbility.paramUnit.shield <= (double) obj0.damage())
      {
        ForceFieldAbility.paramUnit.shield -= ForceFieldAbility.paramField.cooldown * ForceFieldAbility.paramField.regen;
        Fx.__\u003C\u003EshieldBreak.at(ForceFieldAbility.paramUnit.x, ForceFieldAbility.paramUnit.y, ForceFieldAbility.paramField.radius, ForceFieldAbility.paramUnit.team.__\u003C\u003Ecolor);
      }
      ForceFieldAbility.paramUnit.shield -= obj0.damage();
      ForceFieldAbility.paramField.alpha = 1f;
    }

    [LineNumberTable(new byte[] {6, 232, 26, 139, 139, 139, 235, 96})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ForceFieldAbility()
    {
      ForceFieldAbility forceFieldAbility = this;
      this.radius = 60f;
      this.regen = 0.1f;
      this.max = 200f;
      this.cooldown = 300f;
    }

    [LineNumberTable(new byte[] {10, 110, 187, 159, 6, 109, 124, 102, 102, 135, 159, 36, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      if ((double) unit.shield < (double) this.max)
        unit.shield += Time.delta * this.regen;
      this.alpha = Math.max(this.alpha - Time.delta / 10f, 0.0f);
      if ((double) unit.shield > 0.0)
      {
        this.radiusScale = Mathf.lerpDelta(this.radiusScale, 1f, 0.06f);
        ForceFieldAbility.paramUnit = unit;
        ForceFieldAbility.paramField = this;
        this.checkRadius(unit);
        Groups.bullet.intersect(unit.x - ForceFieldAbility.realRad, unit.y - ForceFieldAbility.realRad, ForceFieldAbility.realRad * 2f, ForceFieldAbility.realRad * 2f, ForceFieldAbility.shieldConsumer);
      }
      else
        this.radiusScale = 0.0f;
    }

    [LineNumberTable(new byte[] {30, 135, 112, 138, 159, 2, 113, 153, 106, 106, 120, 106, 184})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Unit unit)
    {
      this.checkRadius(unit);
      if ((double) unit.shield <= 0.0)
        return;
      Draw.z(125f);
      Draw.color(unit.team.__\u003C\u003Ecolor, Color.__\u003C\u003Ewhite, Mathf.clamp(this.alpha));
      if (Core.settings.getBool("animatedshields"))
      {
        Fill.poly(unit.x, unit.y, 6, ForceFieldAbility.realRad);
      }
      else
      {
        Lines.stroke(1.5f);
        Draw.alpha(0.09f);
        Fill.poly(unit.x, unit.y, 6, this.radius);
        Draw.alpha(1f);
        Lines.poly(unit.x, unit.y, 6, this.radius);
      }
    }

    [LineNumberTable(new byte[] {51, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void displayBars(Unit unit, Table bars)
    {
      Table table = bars;
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      mindustry.ui.Bar bar = new mindustry.ui.Bar("stat.shieldhealth", Pal.accent, (Floatp) new ForceFieldAbility.__\u003C\u003EAnon0(this, unit));
      table.add((Element) bar).row();
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ForceFieldAbility()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.abilities.ForceFieldAbility"))
        return;
      ForceFieldAbility.shieldConsumer = (Cons) new ForceFieldAbility.__\u003C\u003EAnon1();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly ForceFieldAbility arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon0([In] ForceFieldAbility obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024displayBars\u00241(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ForceFieldAbility.lambda\u0024static\u00240((Bullet) obj0);
    }
  }
}
