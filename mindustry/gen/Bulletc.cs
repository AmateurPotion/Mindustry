// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Bulletc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.bullet;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Damagec", "mindustry.gen.Ownerc", "mindustry.gen.Drawc", "mindustry.gen.Shielderc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Teamc", "mindustry.gen.Timerc", "mindustry.gen.Entityc", "mindustry.gen.Velc", "mindustry.gen.Timedc"})]
  public interface Bulletc : 
    Damagec,
    Entityc,
    Ownerc,
    Drawc,
    Posc,
    Position,
    Shielderc,
    Teamc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Timerc,
    Velc,
    Timedc,
    Scaled
  {
    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    new void getCollisions(Cons c);

    void drawBullets();

    new void add();

    new void remove();

    float damageMultiplier();

    new void absorb();

    new float clipSize();

    new bool collides(Hitboxc h);

    new void collision(Hitboxc h, float f1, float f2);

    new void update();

    new void draw();

    void rotation(float f);

    float rotation();

    IntSeq collided();

    void collided(IntSeq @is);

    object data();

    void data(object obj);

    BulletType type();

    void type(BulletType bt);

    float fdata();

    void fdata(float f);

    bool absorbed();

    void absorbed(bool b);

    bool hit();

    void hit(bool b);
  }
}
