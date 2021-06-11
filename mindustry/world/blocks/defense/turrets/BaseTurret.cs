// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.BaseTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class BaseTurret : Block
  {
    public float range;
    public float rotateSpeed;
    public bool acceptCoolant;
    public Effect coolEffect;
    public float coolantMultiplier;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00240([In] Liquid obj0) => (double) obj0.temperature <= 0.5 && (double) obj0.flammability < 0.100000001490116;

    [LineNumberTable(new byte[] {159, 168, 233, 54, 107, 139, 135, 139, 235, 69, 103, 103, 103, 107, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseTurret(string name)
      : base(name)
    {
      BaseTurret baseTurret = this;
      this.range = 80f;
      this.rotateSpeed = 5f;
      this.acceptCoolant = true;
      this.coolEffect = Fx.__\u003C\u003Efuelburn;
      this.coolantMultiplier = 5f;
      this.update = true;
      this.solid = true;
      this.outlineIcon = true;
      this.priority = TargetPriority.__\u003C\u003Eturret;
      this.group = BlockGroup.__\u003C\u003Eturrets;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Eturret
      });
    }

    [LineNumberTable(new byte[] {159, 180, 122, 103, 191, 17, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (this.acceptCoolant && !this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eliquid))
      {
        this.hasLiquids = true;
        this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new BaseTurret.__\u003C\u003EAnon0(), 0.2f)).update(false).boost();
      }
      base.init();
    }

    [LineNumberTable(new byte[] {159, 130, 67, 138, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Drawf.dashCircle((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, Pal.placing);
    }

    [LineNumberTable(new byte[] {5, 134, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EshootRange, this.range / 8f, StatUnit.__\u003C\u003Eblocks);
    }

    [HideFromJava]
    static BaseTurret() => Block.__\u003Cclinit\u003E();

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class BaseTurretBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      public float rotation;
      [Modifiers]
      internal BaseTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {10, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BaseTurretBuild(BaseTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        BaseTurret.BaseTurretBuild baseTurretBuild = this;
        this.rotation = 90f;
      }

      [LineNumberTable(65)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.this\u00240.range;

      [LineNumberTable(new byte[] {20, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect() => Drawf.dashCircle(this.x, this.y, this.this\u00240.range, this.team.__\u003C\u003Ecolor);

      [HideFromJava]
      public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

      [HideFromJava]
      public override float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

      [HideFromJava]
      static BaseTurretBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (BaseTurret.lambda\u0024init\u00240((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
