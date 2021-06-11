// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Cultivator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using mindustry.content;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class Cultivator : GenericCrafter
  {
    public Color plantColor;
    public Color plantColorLight;
    public Color bottomColor;
    public TextureRegion middleRegion;
    public TextureRegion topRegion;
    public Rand random;
    public float recurrence;
    public Attribute attribute;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00243([In] Cultivator.CultivatorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Cultivator.__\u003C\u003EAnon1(this, obj0), (Prov) new Cultivator.__\u003C\u003EAnon2(), (Floatp) new Cultivator.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 125, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string lambda\u0024setBars\u00240([In] Cultivator.CultivatorBuild obj0) => Core.bundle.formatFloat("bar.efficiency", (obj0.boost + 1f + this.attribute.env()) * obj0.warmup * 100f, 1);

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.ammo;

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] Cultivator.CultivatorBuild obj0) => obj0.warmup;

    [LineNumberTable(new byte[] {159, 169, 233, 53, 112, 112, 208, 109, 107, 203, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cultivator(string name)
      : base(name)
    {
      Cultivator cultivator = this;
      this.plantColor = Color.valueOf("5541b1");
      this.plantColorLight = Color.valueOf("7457ce");
      this.bottomColor = Color.valueOf("474747");
      this.random = new Rand(0L);
      this.recurrence = 6f;
      this.attribute = Attribute.__\u003C\u003Espores;
      this.craftEffect = Fx.__\u003C\u003Enone;
    }

    [LineNumberTable(new byte[] {159, 175, 102, 251, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("multiplier", (Func) new Cultivator.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 185, 134, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eaffinities, this.attribute);
    }

    [LineNumberTable(new byte[] {159, 130, 131, 138, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num1 != 0);
      double num2 = (double) this.drawPlaceText(Core.bundle.formatFloat("bar.efficiency", (1f + this.sumAttribute(this.attribute, x, y)) * 100f, 1), x, y, num1 != 0);
    }

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.region,
      this.topRegion
    };

    [HideFromJava]
    static Cultivator() => GenericCrafter.__\u003Cclinit\u003E();

    public class CultivatorBuild : GenericCrafter.GenericCrafterBuild
    {
      public new float warmup;
      public float boost;
      [Modifiers]
      internal Cultivator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(60)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CultivatorBuild(Cultivator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((GenericCrafter) _param1);
      }

      [LineNumberTable(new byte[] {16, 134, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        base.updateTile();
        this.warmup = Mathf.lerpDelta(this.warmup, !this.consValid() ? 0.0f : 1f, 0.015f);
      }

      [LineNumberTable(new byte[] {23, 156, 159, 14, 159, 2, 124, 106, 121, 127, 15, 159, 6, 105, 118, 254, 57, 233, 75, 101, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Drawf.liquid(this.this\u00240.middleRegion, this.x, this.y, this.warmup, this.this\u00240.plantColor);
        Draw.color(this.this\u00240.bottomColor, this.this\u00240.plantColorLight, this.warmup);
        this.this\u00240.random.setSeed((long) this.tile.pos());
        for (int index = 0; index < 12; ++index)
        {
          float num1 = this.this\u00240.random.nextFloat() * 999999f;
          float num2 = this.this\u00240.random.range(4f);
          float num3 = this.this\u00240.random.range(4f);
          float num4 = 1f - (Time.time + num1) / 50f % this.this\u00240.recurrence;
          if ((double) num4 > 0.0)
          {
            Lines.stroke(this.warmup * (num4 + 0.2f));
            Lines.poly(num2 + num2, num3 + num3, 8, (1f - num4) * 3f);
          }
        }
        Draw.color();
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(new byte[] {47, 134, 127, 20})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        this.onProximityAdded();
        this.boost = this.this\u00240.sumAttribute(this.this\u00240.attribute, (int) this.tile.x, (int) this.tile.y);
      }

      [LineNumberTable(104)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getProgressIncrease(float baseTime) => base.getProgressIncrease(baseTime) * (1f + this.boost + this.this\u00240.attribute.env());

      [LineNumberTable(new byte[] {59, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.warmup);
      }

      [LineNumberTable(new byte[] {159, 114, 163, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.warmup = read.f();
      }

      [HideFromJava]
      static CultivatorBuild() => GenericCrafter.GenericCrafterBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly Cultivator arg\u00241;

      internal __\u003C\u003EAnon0([In] Cultivator obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00243((Cultivator.CultivatorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly Cultivator arg\u00241;
      private readonly Cultivator.CultivatorBuild arg\u00242;

      internal __\u003C\u003EAnon1([In] Cultivator obj0, [In] Cultivator.CultivatorBuild obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024setBars\u00240(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) Cultivator.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly Cultivator.CultivatorBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] Cultivator.CultivatorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => Cultivator.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
