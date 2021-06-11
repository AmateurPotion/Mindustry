// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.Wall
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class Wall : Block
  {
    public int variants;
    public float lightningChance;
    public float lightningDamage;
    public int lightningLength;
    public Color lightningColor;
    public Sound lightningSound;
    public float chanceDeflect;
    public bool flashHit;
    public Color flashColor;
    public Sound deflectSound;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 233, 48, 167, 107, 107, 104, 107, 171, 139, 107, 203, 103, 103, 107, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Wall(string name)
      : base(name)
    {
      Wall wall = this;
      this.variants = 0;
      this.lightningChance = -1f;
      this.lightningDamage = 20f;
      this.lightningLength = 17;
      this.lightningColor = Pal.surge;
      this.lightningSound = Sounds.spark;
      this.chanceDeflect = -1f;
      this.flashColor = Color.__\u003C\u003Ewhite;
      this.deflectSound = Sounds.none;
      this.solid = true;
      this.destructible = true;
      this.group = BlockGroup.__\u003C\u003Ewalls;
      this.buildCostMultiplier = 6f;
      this.canOverdrive = false;
      this.drawDisabled = false;
    }

    [LineNumberTable(new byte[] {159, 187, 134, 127, 9, 109, 127, 3, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      if ((double) this.chanceDeflect > 0.0)
        this.stats.add(Stat.__\u003C\u003EbaseDeflectChance, this.chanceDeflect, StatUnit.__\u003C\u003Enone);
      if ((double) this.lightningChance <= 0.0)
        return;
      this.stats.add(Stat.__\u003C\u003ElightningChance, this.lightningChance * 100f, StatUnit.__\u003C\u003Epercent);
      this.stats.add(Stat.__\u003C\u003ElightningDamage, this.lightningDamage, StatUnit.__\u003C\u003Enone);
    }

    [LineNumberTable(new byte[] {6, 134, 104, 145, 107, 63, 16, 166, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      if (this.variants == 0)
        return;
      this.variantRegions = new TextureRegion[this.variants];
      for (int index = 0; index < this.variants; ++index)
        this.variantRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append(index + 1).toString());
      this.region = this.variantRegions[0];
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[1]
    {
      (TextureRegion) Core.atlas.find(!Core.atlas.has(this.__\u003C\u003Ename) ? new StringBuilder().append(this.__\u003C\u003Ename).append("1").toString() : this.__\u003C\u003Ename)
    };

    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TextureRegion[] access\u0024000([In] Wall obj0) => obj0.variantRegions;

    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TextureRegion[] access\u0024100([In] Wall obj0) => obj0.variantRegions;

    [HideFromJava]
    static Wall() => Block.__\u003Cclinit\u003E();

    public class WallBuild : Building
    {
      public float hit;
      [Modifiers]
      internal Wall this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(73)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WallBuild(Wall _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {28, 109, 158, 223, 36, 112, 142, 112, 114, 106, 127, 14, 101, 133, 159, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        if (this.this\u00240.variants == 0)
          Draw.rect(this.this\u00240.region, this.x, this.y);
        else
          Draw.rect(Wall.access\u0024000(this.this\u00240)[Mathf.randomSeed((long) this.tile.pos(), 0, Math.max(0, Wall.access\u0024100(this.this\u00240).Length - 1))], this.x, this.y);
        if (!this.this\u00240.flashHit || (double) this.hit < 9.99999974737875E-05)
          return;
        Draw.color(this.this\u00240.flashColor);
        Draw.alpha(this.hit * 0.5f);
        Draw.blend(Blending.__\u003C\u003Eadditive);
        Fill.rect(this.x, this.y, (float) (8 * this.this\u00240.size), (float) (8 * this.this\u00240.size));
        Draw.blend();
        Draw.reset();
        this.hit = Mathf.clamp(this.hit - Time.delta / 10f);
      }

      [LineNumberTable(new byte[] {51, 136, 171, 117, 115, 127, 39, 255, 8, 69, 149, 191, 3, 190, 191, 8, 158, 159, 11, 100, 154, 184, 103, 108, 180, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool collision(Bullet bullet)
      {
        base.collision(bullet);
        this.hit = 1f;
        if ((double) this.this\u00240.lightningChance > 0.0 && Mathf.chance((double) this.this\u00240.lightningChance))
        {
          Lightning.create(this.team, this.this\u00240.lightningColor, this.this\u00240.lightningDamage, this.x, this.y, bullet.rotation() + 180f, this.this\u00240.lightningLength);
          this.this\u00240.lightningSound.at((Position) this.tile, Mathf.random(0.9f, 1.1f));
        }
        if ((double) this.this\u00240.chanceDeflect <= 0.0 || (double) bullet.vel().len() <= 0.100000001490116 || (!bullet.type.reflectable || !Mathf.chance((double) (this.this\u00240.chanceDeflect / bullet.damage()))))
          return true;
        this.this\u00240.deflectSound.at((Position) this.tile, Mathf.random(0.9f, 1.1f));
        bullet.trns(-bullet.vel.x, -bullet.vel.y);
        if ((double) Math.abs(this.x - bullet.x) > (double) Math.abs(this.y - bullet.y))
          bullet.vel.x *= -1f;
        else
          bullet.vel.y *= -1f;
        bullet.owner((Entityc) this);
        bullet.team(this.team);
        bullet.time(bullet.time() + 1f);
        return false;
      }

      [HideFromJava]
      static WallBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
