// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.AttributeSmelter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class AttributeSmelter : GenericSmelter
  {
    public Attribute attribute;
    public float baseEfficiency;
    public float boostScale;
    public float maxHeatBoost;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 188, 245, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00242([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Prov name = (Prov) new AttributeSmelter.__\u003C\u003EAnon1(obj0);
      Prov color = (Prov) new AttributeSmelter.__\u003C\u003EAnon2();
      Building building = obj0;
      Objects.requireNonNull((object) building);
      Floatp fraction = (Floatp) new AttributeSmelter.__\u003C\u003EAnon3(building);
      return new mindustry.ui.Bar(name, color, fraction);
    }

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] Building obj0) => Core.bundle.format("bar.efficiency", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.efficiency() * 100f)));

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.lightOrange;

    [LineNumberTable(new byte[] {159, 158, 233, 58, 107, 107, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AttributeSmelter(string name)
      : base(name)
    {
      AttributeSmelter attributeSmelter = this;
      this.attribute = Attribute.__\u003C\u003Eheat;
      this.baseEfficiency = 1f;
      this.boostScale = 1f;
      this.maxHeatBoost = 1f;
    }

    [LineNumberTable(new byte[] {159, 137, 99, 127, 15, 63, 3, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      double num2 = (double) this.drawPlaceText(Core.bundle.format("bar.efficiency", (object) Integer.valueOf(ByteCodeHelper.f2i((this.baseEfficiency + Math.min(this.maxHeatBoost, this.boostScale * this.sumAttribute(this.attribute, x, y))) * 100f))), x, y, num1 != 0);
    }

    [LineNumberTable(new byte[] {159, 169, 134, 250, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("efficiency", (Func) new AttributeSmelter.__\u003C\u003EAnon0());
    }

    [LineNumberTable(new byte[] {159, 180, 134, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eaffinities, this.attribute, this.boostScale);
    }

    [HideFromJava]
    static AttributeSmelter() => GenericSmelter.__\u003Cclinit\u003E();

    public class AttributeSmelterBuild : GenericSmelter.SmelterBuild
    {
      public float attrsum;
      [Modifiers]
      internal AttributeSmelter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AttributeSmelterBuild(AttributeSmelter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((GenericSmelter) _param1);
      }

      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float efficiency() => (this.this\u00240.baseEfficiency + Math.min(this.this\u00240.maxHeatBoost, this.this\u00240.boostScale * this.attrsum)) * base.efficiency();

      [LineNumberTable(new byte[] {3, 134, 127, 20})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        this.attrsum = this.this\u00240.sumAttribute(this.this\u00240.attribute, (int) this.tile.x, (int) this.tile.y);
      }

      [HideFromJava]
      static AttributeSmelterBuild() => GenericSmelter.SmelterBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) AttributeSmelter.lambda\u0024setBars\u00242((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon1([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) AttributeSmelter.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) AttributeSmelter.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon3([In] Building obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.efficiency();
    }
  }
}
