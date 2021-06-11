// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.BasicBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class BasicBulletType : BulletType
  {
    public Color backColor;
    public Color frontColor;
    public Color mixColorFrom;
    public Color mixColorTo;
    public float width;
    public float height;
    public float shrinkX;
    public float shrinkY;
    public float spin;
    public string sprite;
    public TextureRegion backRegion;
    public TextureRegion frontRegion;

    [LineNumberTable(new byte[] {159, 166, 236, 53, 118, 127, 31, 118, 118, 235, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BasicBulletType(float speed, float damage, string bulletSprite)
      : base(speed, damage)
    {
      BasicBulletType basicBulletType = this;
      this.backColor = Pal.bulletYellowBack;
      this.frontColor = Pal.bulletYellow;
      this.mixColorFrom = new Color(1f, 1f, 1f, 0.0f);
      this.mixColorTo = new Color(1f, 1f, 1f, 0.0f);
      this.width = 5f;
      this.height = 7f;
      this.shrinkX = 0.0f;
      this.shrinkY = 0.5f;
      this.spin = 0.0f;
      this.sprite = bulletSprite;
    }

    [LineNumberTable(new byte[] {159, 171, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BasicBulletType(float speed, float damage)
      : this(speed, damage, "bullet")
    {
    }

    [LineNumberTable(new byte[] {159, 176, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BasicBulletType()
      : this(1f, 1f, "bullet")
    {
    }

    [LineNumberTable(new byte[] {159, 181, 127, 16, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      this.backRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.sprite).append("-back").toString());
      this.frontRegion = (TextureRegion) Core.atlas.find(this.sprite);
    }

    [LineNumberTable(new byte[] {159, 187, 127, 8, 127, 8, 159, 31, 159, 4, 140, 107, 127, 4, 107, 159, 4, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float h = this.height * (1f - this.shrinkY + this.shrinkY * b.fout());
      float w = this.width * (1f - this.shrinkX + this.shrinkX * b.fout());
      float num = (float) (((double) this.spin == 0.0 ? 0.0 : (double) (Mathf.randomSeed((long) b.id, 360f) + b.time * this.spin)) - 90.0);
      Color color = Tmp.__\u003C\u003Ec1.set(this.mixColorFrom).lerp(this.mixColorTo, b.fin());
      Draw.mixcol(color, color.a);
      Draw.color(this.backColor);
      Draw.rect(this.backRegion, b.x, b.y, w, h, b.rotation() + num);
      Draw.color(this.frontColor);
      Draw.rect(this.frontRegion, b.x, b.y, w, h, b.rotation() + num);
      Draw.reset();
    }
  }
}
