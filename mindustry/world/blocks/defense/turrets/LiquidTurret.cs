// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.LiquidTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class LiquidTurret : Turret
  {
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Liquid;Lmindustry/entities/bullet/BulletType;>;")]
    public ObjectMap ammoTypes;
    public TextureRegion liquidRegion;
    public TextureRegion topRegion;
    public bool extinguish;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024init\u00240([In] Liquid obj0) => this.ammoTypes.containsKey((object) obj0);

    [LineNumberTable(new byte[] {159, 167, 233, 58, 171, 199, 103, 103, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidTurret(string name)
      : base(name)
    {
      LiquidTurret liquidTurret = this;
      this.ammoTypes = new ObjectMap();
      this.extinguish = true;
      this.acceptCoolant = false;
      this.hasLiquids = true;
      this.loopSound = Sounds.spray;
      this.shootSound = Sounds.none;
      this.outlinedIcon = 1;
    }

    [LineNumberTable(new byte[] {159, 177, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ammo(params object[] objects) => this.ammoTypes = (ObjectMap) OrderedMap.of(objects);

    [LineNumberTable(new byte[] {159, 182, 134, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eammo, (StatValue) new AmmoListValue(this.ammoTypes));
    }

    [LineNumberTable(new byte[] {159, 189, 255, 3, 81, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.__\u003C\u003Econsumes.add((Consume) new LiquidTurret.\u0031(this, (Boolf) new LiquidTurret.__\u003C\u003EAnon0(this), 1f));
      base.init();
    }

    [LineNumberTable(new byte[] {19, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons()
    {
      if (!this.topRegion.found())
        return base.icons();
      return new TextureRegion[3]
      {
        this.baseRegion,
        this.region,
        this.topRegion
      };
    }

    [HideFromJava]
    static LiquidTurret() => Turret.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "init", "()V")]
    [SpecialName]
    internal new class \u0031 : ConsumeLiquidFilter
    {
      [Modifiers]
      internal LiquidTurret this\u00240;

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] LiquidTurret obj0, [In] Boolf obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
      }

      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool valid([In] Building obj0) => (double) obj0.liquids.total() > 1.0 / 1000.0;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void update([In] Building obj0)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void display([In] Stats obj0)
      {
      }
    }

    public class LiquidTurretBuild : Turret.TurretBuild
    {
      [Modifiers]
      internal LiquidTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BulletType peekAmmo() => (BulletType) this.this\u00240.ammoTypes.get((object) this.liquids.current());

      [LineNumberTable(73)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidTurretBuild(LiquidTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Turret) _param1);
      }

      [LineNumberTable(new byte[] {26, 134, 114, 159, 87, 127, 64})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.this\u00240.liquidRegion.found())
          Drawf.liquid(this.this\u00240.liquidRegion, this.x + this.this\u00240.tr2.x, this.y + this.this\u00240.tr2.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color, this.rotation - 90f);
        if (!this.this\u00240.topRegion.found())
          return;
        Draw.rect(this.this\u00240.topRegion, this.x + this.this\u00240.tr2.x, this.y + this.this\u00240.tr2.y, this.rotation - 90f);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldActiveSound() => this.wasShooting;

      [LineNumberTable(new byte[] {41, 159, 24, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.unit.ammo((float) this.unit.type().ammoCapacity * this.liquids.currentAmount() / this.this\u00240.liquidCapacity);
        base.updateTile();
      }

      [LineNumberTable(new byte[] {48, 127, 6, 120, 106, 106, 159, 8, 127, 35, 127, 6, 225, 59, 41, 233, 76, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void findTarget()
      {
        if (this.this\u00240.extinguish && this.liquids.current().canExtinguish())
        {
          int num = ByteCodeHelper.f2i(this.this\u00240.range / 8f);
          for (int index1 = -num; index1 <= num; ++index1)
          {
            for (int index2 = -num; index2 <= num; ++index2)
            {
              Tile tile = Vars.world.tileWorld((float) (index1 + (int) this.tile.x), (float) (index2 + (int) this.tile.y));
              if (tile != null && Fires.has(index1 + (int) this.tile.x, index2 + (int) this.tile.y) && (tile.build == null || object.ReferenceEquals((object) tile.team(), (object) this.team)))
              {
                this.target = (Posc) Fires.get(index1 + (int) this.tile.x, index2 + (int) this.tile.y);
                return;
              }
            }
          }
        }
        base.findTarget();
      }

      [LineNumberTable(new byte[] {67, 135, 127, 50, 127, 50, 151, 114, 191, 7, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void effects()
      {
        BulletType bulletType = this.peekAmmo();
        bulletType.shootEffect.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation, this.liquids.current().color);
        bulletType.smokeEffect.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation, this.liquids.current().color);
        this.this\u00240.shootSound.at((Position) this.tile);
        if ((double) this.this\u00240.shootShake > 0.0)
          Effect.shake(this.this\u00240.shootShake, this.this\u00240.shootShake, (Position) this.tile.build);
        this.recoil = this.this\u00240.recoilAmount;
      }

      [LineNumberTable(new byte[] {82, 127, 10, 127, 2, 127, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BulletType useAmmo()
      {
        if (this.cheating())
          return (BulletType) this.this\u00240.ammoTypes.get((object) this.liquids.current());
        BulletType bulletType = (BulletType) this.this\u00240.ammoTypes.get((object) this.liquids.current());
        this.liquids.remove(this.liquids.current(), 1f / bulletType.ammoMultiplier);
        return bulletType;
      }

      [LineNumberTable(145)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasAmmo() => this.this\u00240.ammoTypes.get((object) this.liquids.current()) != null && (double) this.liquids.total() >= (double) (1f / ((BulletType) this.this\u00240.ammoTypes.get((object) this.liquids.current())).ammoMultiplier);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => false;

      [LineNumberTable(new byte[] {105, 124, 127, 21, 31, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid) => this.this\u00240.ammoTypes.get((object) liquid) != null && (object.ReferenceEquals((object) this.liquids.current(), (object) liquid) || this.this\u00240.ammoTypes.containsKey((object) liquid) && (!this.this\u00240.ammoTypes.containsKey((object) this.liquids.current()) || (double) this.liquids.get(this.liquids.current()) <= (double) (1f / ((BulletType) this.this\u00240.ammoTypes.get((object) this.liquids.current())).ammoMultiplier + 1f / 1000f)));

      [HideFromJava]
      static LiquidTurretBuild() => Turret.TurretBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly LiquidTurret arg\u00241;

      internal __\u003C\u003EAnon0([In] LiquidTurret obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024init\u00240((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
