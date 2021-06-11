// Decompiled with JetBrains decompiler
// Type: mindustry.type.Liquid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.ctype;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class Liquid : UnlockableContent
  {
    public Color color;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Color barColor;
    public Color lightColor;
    public float flammability;
    public float temperature;
    public float heatCapacity;
    public float viscosity;
    public float explosiveness;
    public StatusEffect effect;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color barColor() => this.barColor == null ? this.color : this.barColor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canExtinguish() => (double) this.flammability < 0.100000001490116 && (double) this.temperature <= 0.5;

    [LineNumberTable(new byte[] {159, 172, 233, 49, 208, 139, 139, 203, 203, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Liquid(string name, Color color)
      : base(name)
    {
      Liquid liquid = this;
      this.lightColor = Color.__\u003C\u003Eclear.cpy();
      this.temperature = 0.5f;
      this.heatCapacity = 0.5f;
      this.viscosity = 0.5f;
      this.effect = StatusEffects.none;
      this.color = new Color(color);
    }

    [LineNumberTable(new byte[] {159, 178, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Liquid(string name)
    {
      string name1 = name;
      Color.__\u003Cclinit\u003E();
      Color color = new Color(Color.__\u003C\u003Eblack);
      // ISSUE: explicit constructor call
      this.\u002Ector(name1, color);
    }

    [LineNumberTable(new byte[] {159, 191, 118, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      this.stats.addPercent(Stat.__\u003C\u003Eexplosiveness, this.explosiveness);
      this.stats.addPercent(Stat.__\u003C\u003Eflammability, this.flammability);
      this.stats.addPercent(Stat.__\u003C\u003Etemperature, this.temperature);
      this.stats.addPercent(Stat.__\u003C\u003EheatCapacity, this.heatCapacity);
      this.stats.addPercent(Stat.__\u003C\u003Eviscosity, this.viscosity);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.localizedName;

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eliquid;
  }
}
