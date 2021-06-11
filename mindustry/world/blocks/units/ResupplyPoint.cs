// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.ResupplyPoint
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.units
{
  public class ResupplyPoint : Block
  {
    internal int __\u003C\u003EtimerResupply;
    public int ammoAmount;
    public float resupplyRate;
    public float range;
    public Color ammoColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Lmindustry/game/Team;FFFFLarc/graphics/Color;Larc/func/Boolf<Lmindustry/gen/Unit;>;)Z")]
    [LineNumberTable(new byte[] {16, 147, 124, 99, 123, 127, 4, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool resupply(
      Team team,
      float x,
      float y,
      float range,
      float ammoAmount,
      Color ammoColor,
      Boolf valid)
    {
      if (!Vars.state.rules.unitAmmo)
        return false;
      Unit unit = Units.closest(team, x, y, range, (Boolf) new ResupplyPoint.__\u003C\u003EAnon1(ammoAmount, valid));
      if (unit == null)
        return false;
      Fx.__\u003C\u003EitemTransfer.at(x, y, ammoAmount / 2f, ammoColor, (object) unit);
      unit.ammo = Math.min(unit.ammo + ammoAmount, (float) unit.type.ammoCapacity);
      return true;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024resupply\u00240([In] Unit obj0) => true;

    [Modifiers]
    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024resupply\u00241([In] float obj0, [In] Boolf obj1, [In] Unit obj2) => obj2.type.ammoType is AmmoTypes.ItemAmmoType && (double) obj2.ammo <= (double) ((float) obj2.type.ammoCapacity - obj0) && obj1.get((object) obj2);

    [LineNumberTable(new byte[] {159, 168, 233, 56, 153, 104, 107, 107, 208, 114, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ResupplyPoint(string name)
      : base(name)
    {
      ResupplyPoint resupplyPoint1 = this;
      ResupplyPoint resupplyPoint2 = this;
      int timers = resupplyPoint2.timers;
      ResupplyPoint resupplyPoint3 = resupplyPoint2;
      int num1 = timers;
      resupplyPoint3.timers = timers + 1;
      this.__\u003C\u003EtimerResupply = num1;
      this.ammoAmount = 10;
      this.resupplyRate = 5f;
      this.range = 60f;
      this.ammoColor = Items.copper.color;
      ResupplyPoint resupplyPoint4 = this;
      int num2 = 1;
      int num3 = num2;
      this.update = num2 != 0;
      this.solid = num3 != 0;
      this.hasItems = true;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Eresupply
      });
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 181, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid) => Drawf.dashCircle((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range, Pal.placing);

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool resupply(Building tile, float range, float ammoAmount, Color ammoColor) => ResupplyPoint.resupply(tile.team, tile.x, tile.y, range, ammoAmount, ammoColor, (Boolf) new ResupplyPoint.__\u003C\u003EAnon0());

    [HideFromJava]
    static ResupplyPoint() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerResupply
    {
      [HideFromJava] get => this.__\u003C\u003EtimerResupply;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerResupply = value;
    }

    public class ResupplyPointBuild : Building
    {
      [Modifiers]
      internal ResupplyPoint this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ResupplyPointBuild(ResupplyPoint _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 188, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect() => Drawf.dashCircle(this.x, this.y, this.this\u00240.range, this.team.__\u003C\u003Ecolor);

      [LineNumberTable(new byte[] {1, 127, 57, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!this.consValid() || !this.timer(this.this\u00240.__\u003C\u003EtimerResupply, this.this\u00240.resupplyRate / this.timeScale) || !ResupplyPoint.resupply((Building) this, this.this\u00240.range, (float) this.this\u00240.ammoAmount, this.this\u00240.ammoColor))
          return;
        this.consume();
      }

      [HideFromJava]
      static ResupplyPointBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (ResupplyPoint.lambda\u0024resupply\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly float arg\u00241;
      private readonly Boolf arg\u00242;

      internal __\u003C\u003EAnon1([In] float obj0, [In] Boolf obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (ResupplyPoint.lambda\u0024resupply\u00241(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }
  }
}
