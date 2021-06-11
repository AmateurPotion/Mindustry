// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.MoveLightningAbility
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
using mindustry.content;
using mindustry.entities.bullet;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.entities.abilities
{
  public class MoveLightningAbility : Ability
  {
    public float damage;
    public float chance;
    public int length;
    public float minSpeed;
    public float maxSpeed;
    public Color color;
    public float offset;
    public string heatRegion;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public BulletType bullet;
    public float bulletAngle;
    public float bulletSpread;
    public Effect shootEffect;
    public Sound shootSound;

    [LineNumberTable(new byte[] {159, 179, 232, 43, 139, 139, 136, 150, 144, 139, 203, 150, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MoveLightningAbility()
    {
      MoveLightningAbility lightningAbility = this;
      this.damage = 35f;
      this.chance = 0.15f;
      this.length = 12;
      this.minSpeed = 0.8f;
      this.maxSpeed = 1.2f;
      this.color = Color.valueOf("a9d8ff");
      this.offset = 0.0f;
      this.heatRegion = "error";
      this.bulletAngle = 0.0f;
      this.bulletSpread = 0.0f;
      this.shootEffect = Fx.__\u003C\u003EsparkShoot;
      this.shootSound = Sounds.spark;
    }

    [LineNumberTable(new byte[] {159, 181, 232, 41, 139, 139, 136, 150, 144, 139, 203, 150, 107, 235, 69, 104, 103, 104, 105, 105, 105, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MoveLightningAbility(
      float damage,
      int length,
      float chance,
      float offset,
      float minSpeed,
      float maxSpeed,
      Color color,
      string heatRegion)
    {
      MoveLightningAbility lightningAbility = this;
      this.damage = 35f;
      this.chance = 0.15f;
      this.length = 12;
      this.minSpeed = 0.8f;
      this.maxSpeed = 1.2f;
      this.color = Color.valueOf("a9d8ff");
      this.offset = 0.0f;
      this.heatRegion = "error";
      this.bulletAngle = 0.0f;
      this.bulletSpread = 0.0f;
      this.shootEffect = Fx.__\u003C\u003EsparkShoot;
      this.shootSound = Sounds.spark;
      this.damage = damage;
      this.length = length;
      this.chance = chance;
      this.offset = offset;
      this.minSpeed = minSpeed;
      this.maxSpeed = maxSpeed;
      this.color = color;
      this.heatRegion = heatRegion;
    }

    [LineNumberTable(new byte[] {0, 232, 30, 139, 139, 136, 150, 144, 139, 203, 150, 107, 235, 80, 104, 103, 104, 105, 105, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MoveLightningAbility(
      float damage,
      int length,
      float chance,
      float offset,
      float minSpeed,
      float maxSpeed,
      Color color)
    {
      MoveLightningAbility lightningAbility = this;
      this.damage = 35f;
      this.chance = 0.15f;
      this.length = 12;
      this.minSpeed = 0.8f;
      this.maxSpeed = 1.2f;
      this.color = Color.valueOf("a9d8ff");
      this.offset = 0.0f;
      this.heatRegion = "error";
      this.bulletAngle = 0.0f;
      this.bulletSpread = 0.0f;
      this.shootEffect = Fx.__\u003C\u003EsparkShoot;
      this.shootSound = Sounds.spark;
      this.damage = damage;
      this.length = length;
      this.chance = chance;
      this.offset = offset;
      this.minSpeed = minSpeed;
      this.maxSpeed = maxSpeed;
      this.color = color;
    }

    [LineNumberTable(new byte[] {12, 127, 12, 123, 159, 33, 121, 141, 105, 191, 32, 104, 191, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Unit unit)
    {
      float num = Mathf.clamp((unit.vel().len() - this.minSpeed) / (this.maxSpeed - this.minSpeed));
      if (!Mathf.chance((double) (Time.delta * this.chance * num)))
        return;
      float x = unit.x + Angles.trnsx(unit.rotation, this.offset, 0.0f);
      float y = unit.y + Angles.trnsy(unit.rotation, this.offset, 0.0f);
      this.shootEffect.at(x, y, unit.rotation, this.color);
      this.shootSound.at((Position) unit);
      if (this.length > 0)
        Lightning.create(unit.team, this.color, this.damage, x + unit.vel.x, y + unit.vel.y, unit.rotation, this.length);
      if (this.bullet == null)
        return;
      this.bullet.create((Entityc) unit, unit.team, x, y, unit.rotation + this.bulletAngle + Mathf.range(this.bulletSpread));
    }

    [LineNumberTable(new byte[] {31, 127, 12, 113, 120, 107, 109, 106, 127, 32, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Unit unit)
    {
      float num = Mathf.clamp((unit.vel().len() - this.minSpeed) / (this.maxSpeed - this.minSpeed));
      TextureAtlas.AtlasRegion atlasRegion = Core.atlas.find(this.heatRegion);
      if (!Core.atlas.isFound((TextureRegion) atlasRegion) || (double) num <= 9.99999974737875E-06)
        return;
      Draw.color(this.color);
      Draw.alpha(num / 2f);
      Draw.blend(Blending.__\u003C\u003Eadditive);
      Draw.rect((TextureRegion) atlasRegion, unit.x + Mathf.range(num / 2f), unit.y + Mathf.range(num / 2f), unit.rotation - 90f);
      Draw.blend();
    }
  }
}
