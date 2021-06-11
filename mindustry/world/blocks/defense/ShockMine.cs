// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.ShockMine
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class ShockMine : Block
  {
    internal int __\u003C\u003EtimerDamage;
    public float cooldown;
    public float tileDamage;
    public float damage;
    public int length;
    public int tendrils;
    public Color lightningColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 233, 54, 153, 107, 107, 107, 104, 103, 203, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShockMine(string name)
      : base(name)
    {
      ShockMine shockMine1 = this;
      ShockMine shockMine2 = this;
      int timers = shockMine2.timers;
      ShockMine shockMine3 = shockMine2;
      int num = timers;
      shockMine3.timers = timers + 1;
      this.__\u003C\u003EtimerDamage = num;
      this.cooldown = 80f;
      this.tileDamage = 5f;
      this.damage = 13f;
      this.length = 10;
      this.tendrils = 6;
      this.lightningColor = Pal.lancerLaser;
      this.update = false;
      this.destructible = true;
      this.solid = false;
      this.targetable = false;
      this.rebuildable = false;
    }

    [HideFromJava]
    static ShockMine() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerDamage
    {
      [HideFromJava] get => this.__\u003C\u003EtimerDamage;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerDamage = value;
    }

    public class ShockMineBuild : Building
    {
      [Modifiers]
      internal ShockMine this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(30)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ShockMineBuild(ShockMine _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawTeam()
      {
      }

      [LineNumberTable(new byte[] {159, 181, 102, 112, 106, 123, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.color(this.team.__\u003C\u003Ecolor);
        Draw.alpha(0.22f);
        Fill.rect(this.x, this.y, 2f, 2f);
        Draw.color();
      }

      [LineNumberTable(new byte[] {159, 190, 127, 32, 112, 63, 36, 166, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void unitOn(Unit unit)
      {
        if (!this.enabled || object.ReferenceEquals((object) unit.team, (object) this.team) || !this.timer(this.this\u00240.__\u003C\u003EtimerDamage, this.this\u00240.cooldown))
          return;
        for (int index = 0; index < this.this\u00240.tendrils; ++index)
          Lightning.create(this.team, this.this\u00240.lightningColor, this.this\u00240.damage, this.x, this.y, Mathf.random(360f), this.this\u00240.length);
        this.damage(this.this\u00240.tileDamage);
      }

      [HideFromJava]
      static ShockMineBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
