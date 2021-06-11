// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.Battery
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class Battery : PowerDistributor
  {
    public TextureRegion topRegion;
    public Color emptyLightColor;
    public Color fullLightColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 233, 60, 112, 208, 103, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Battery(string name)
      : base(name)
    {
      Battery battery = this;
      this.emptyLightColor = Color.valueOf("f8c266");
      this.fullLightColor = Color.valueOf("fb9567");
      this.outputsPower = true;
      this.consumesPower = true;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Ebattery
      });
    }

    [HideFromJava]
    static Battery() => PowerDistributor.__\u003Cclinit\u003E();

    public class BatteryBuild : Building
    {
      [Modifiers]
      internal Battery this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BatteryBuild(Battery _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 171, 127, 7, 127, 14, 133, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.color(this.this\u00240.emptyLightColor, this.this\u00240.fullLightColor, this.power.status);
        Fill.square(this.x, this.y, (float) (8 * this.this\u00240.size) / 2f - 1f);
        Draw.color();
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
      [LineNumberTable(new byte[] {159, 180, 126, 127, 24, 127, 4, 159, 23, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void overwrote(Seq previous)
      {
        Iterator iterator = previous.iterator();
        while (iterator.hasNext())
        {
          Building building = (Building) iterator.next();
          if (building.power != null && building.block.__\u003C\u003Econsumes.hasPower() && building.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
            this.power.status = Mathf.clamp(this.power.status + building.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity * building.power.status / this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity);
        }
      }

      [LineNumberTable(new byte[] {159, 190, 127, 3, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BlockStatus status()
      {
        if (Mathf.equal(this.power.status, 0.0f, 1f / 1000f))
          return BlockStatus.__\u003C\u003EnoInput;
        return Mathf.equal(this.power.status, 1f, 1f / 1000f) ? BlockStatus.__\u003C\u003Eactive : BlockStatus.__\u003C\u003EnoOutput;
      }

      [HideFromJava]
      static BatteryBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
