// Decompiled with JetBrains decompiler
// Type: mindustry.type.AmmoTypes
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.ctype;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class AmmoTypes : Object, ContentList
  {
    public static AmmoType powerLow;
    public static AmmoType power;
    public static AmmoType powerHigh;
    public static AmmoType copper;
    public static AmmoType thorium;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AmmoTypes()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 111, 111, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      AmmoTypes.powerLow = (AmmoType) new AmmoTypes.PowerAmmoType(500f);
      AmmoTypes.power = (AmmoType) new AmmoTypes.PowerAmmoType(1000f);
      AmmoTypes.powerHigh = (AmmoType) new AmmoTypes.PowerAmmoType(2000f);
      AmmoTypes.copper = (AmmoType) new AmmoTypes.ItemAmmoType(Items.copper);
      AmmoTypes.thorium = (AmmoType) new AmmoTypes.ItemAmmoType(Items.thorium);
    }

    public class ItemAmmoType : AmmoType
    {
      public Item item;

      [LineNumberTable(new byte[] {20, 104, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemAmmoType(Item item)
      {
        AmmoTypes.ItemAmmoType itemAmmoType = this;
        this.item = item;
        this.color = item.color;
      }

      [LineNumberTable(new byte[] {25, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemAmmoType()
      {
      }

      [LineNumberTable(new byte[] {30, 104, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void load()
      {
        if (this.item == null)
          return;
        this.icon = this.item.emoji();
      }
    }

    public class PowerAmmoType : AmmoType
    {
      public float totalPower;

      [LineNumberTable(new byte[] {159, 179, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerAmmoType(float totalPower)
        : this()
      {
        AmmoTypes.PowerAmmoType powerAmmoType = this;
        this.totalPower = totalPower;
      }

      [LineNumberTable(new byte[] {159, 174, 242, 61, 203, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerAmmoType()
        : base('\uE810', Pal.powerLight)
      {
        AmmoTypes.PowerAmmoType powerAmmoType = this;
        this.totalPower = 1000f;
        this.barColor = this.color;
      }

      [LineNumberTable(new byte[] {159, 185, 110, 159, 3, 127, 20, 135, 127, 16, 127, 9, 118, 118, 104, 139, 108, 127, 18, 148, 223, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void resupply(Unit unit)
      {
        float num1 = unit.hitSize + 60f;
        Tile closestFlag = Vars.indexer.findClosestFlag(unit.x, unit.y, unit.team, BlockFlag.__\u003C\u003Ebattery);
        if (closestFlag == null || closestFlag.build == null || (!unit.within((Position) closestFlag.build, num1) || closestFlag.build.power == null))
          return;
        Building build = closestFlag.build;
        if (!build.block.__\u003C\u003Econsumes.hasPower() || !build.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
          return;
        float num2 = closestFlag.build.power.status * build.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity;
        float num3 = this.totalPower / (float) unit.type.ammoCapacity;
        float num4 = ((float) unit.type.ammoCapacity - unit.ammo) * num3;
        float num5 = Math.min(num2, num4);
        if ((double) num5 <= 1.0)
          return;
        closestFlag.build.power.status -= num5 / build.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity;
        unit.ammo += num5 / num3;
        Fx.__\u003C\u003EitemTransfer.at(build.x, build.y, Math.max(num5 / 100f, 1f), Pal.power, (object) unit);
      }
    }
  }
}
