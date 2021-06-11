// Decompiled with JetBrains decompiler
// Type: mindustry.entities.EntityCollisions
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.gen;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class EntityCollisions : Object
  {
    private const int r = 1;
    private const float seg = 1f;
    private Rect tmp;
    private Vec2 vector;
    private Vec2 l1;
    private Rect r1;
    private Rect r2;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Hitboxc;>;")]
    private Seq arrOut;

    [LineNumberTable(new byte[] {159, 154, 232, 71, 107, 107, 107, 107, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EntityCollisions()
    {
      EntityCollisions entityCollisions = this;
      this.tmp = new Rect();
      this.vector = new Vec2();
      this.l1 = new Vec2();
      this.r1 = new Rect();
      this.r2 = new Rect();
      this.arrOut = new Seq();
    }

    [LineNumberTable(new byte[] {159, 181, 159, 3, 130, 114, 98, 159, 13, 111, 151, 204, 130, 114, 98, 159, 13, 111, 151, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void move(
      Hitboxc entity,
      float deltax,
      float deltay,
      EntityCollisions.SolidPred solidCheck)
    {
      if ((double) Math.abs(deltax) < 9.99999974737875E-05 & (double) Math.abs(deltay) < 9.99999974737875E-05)
        return;
      int num1 = 0;
      while ((double) Math.abs(deltax) > 0.0 || num1 == 0)
      {
        num1 = 1;
        this.moveDelta(entity, Math.min(Math.abs(deltax), 1f) * (float) Mathf.sign(deltax), 0.0f, true, solidCheck);
        if ((double) Math.abs(deltax) >= 1.0)
          deltax -= 1f * (float) Mathf.sign(deltax);
        else
          deltax = 0.0f;
      }
      int num2 = 0;
      while ((double) Math.abs(deltay) > 0.0 || num2 == 0)
      {
        num2 = 1;
        this.moveDelta(entity, 0.0f, Math.min(Math.abs(deltay), 1f) * (float) Mathf.sign(deltay), false, solidCheck);
        if ((double) Math.abs(deltay) >= 1.0)
          deltay -= 1f * (float) Mathf.sign(deltay);
        else
          deltay = 0.0f;
      }
    }

    [LineNumberTable(new byte[] {159, 125, 99, 108, 108, 117, 149, 159, 57, 105, 107, 107, 112, 159, 1, 115, 116, 125, 253, 56, 43, 233, 79, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveDelta(
      Hitboxc entity,
      float deltax,
      float deltay,
      bool x,
      EntityCollisions.SolidPred solidCheck)
    {
      int num1 = x ? 1 : 0;
      entity.hitboxTile(this.r1);
      entity.hitboxTile(this.r2);
      this.r1.x += deltax;
      this.r1.y += deltay;
      int num2 = Math.round((this.r1.x + this.r1.width / 2f) / 8f);
      int num3 = Math.round((this.r1.y + this.r1.height / 2f) / 8f);
      for (int index1 = -1; index1 <= 1; ++index1)
      {
        for (int index2 = -1; index2 <= 1; ++index2)
        {
          int i1 = index1 + num2;
          int i2 = index2 + num3;
          if (solidCheck.solid(i1, i2))
          {
            this.tmp.setSize(8f).setCenter((float) (i1 * 8), (float) (i2 * 8));
            if (this.tmp.overlaps(this.r1))
            {
              Vec2 vec2 = Geometry.overlap(this.r1, this.tmp, num1 != 0);
              if (num1 != 0)
                this.r1.x += vec2.x;
              if (num1 == 0)
                this.r1.y += vec2.y;
            }
          }
        }
      }
      entity.trns(this.r1.x - this.r2.x, this.r1.y - this.r2.y);
    }

    [LineNumberTable(new byte[] {89, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool solid(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {120, 136, 106, 234, 69, 106, 108, 143, 109, 172, 106, 110, 144, 110, 174, 104, 104, 105, 137, 108, 140, 127, 11, 130, 118, 151, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool collide(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7,
      [In] float obj8,
      [In] float obj9,
      [In] float obj10,
      [In] float obj11,
      [In] Vec2 obj12)
    {
      float num1 = obj4;
      float num2 = obj5;
      obj4 -= obj10;
      obj5 -= obj11;
      float num3;
      float num4;
      if ((double) obj4 > 0.0)
      {
        num3 = obj6 - (obj0 + obj2);
        num4 = obj6 + obj8 - obj0;
      }
      else
      {
        num3 = obj6 + obj8 - obj0;
        num4 = obj6 - (obj0 + obj2);
      }
      float num5;
      float num6;
      if ((double) obj5 > 0.0)
      {
        num5 = obj7 - (obj1 + obj3);
        num6 = obj7 + obj9 - obj1;
      }
      else
      {
        num5 = obj7 + obj9 - obj1;
        num6 = obj7 - (obj1 + obj3);
      }
      float num7 = num3 / obj4;
      float num8 = num4 / obj4;
      float num9 = num5 / obj5;
      float num10 = num6 / obj5;
      float num11 = Math.max(num7, num9);
      float num12 = Math.min(num8, num10);
      if ((double) num11 > (double) num12 || (double) num8 < 0.0 || ((double) num10 < 0.0 || (double) num7 > 1.0) || (double) num9 > 1.0)
        return false;
      float x = obj0 + obj2 / 2f + num1 * num11;
      float y = obj1 + obj3 / 2f + num2 * num11;
      obj12.set(x, y);
      return true;
    }

    [LineNumberTable(new byte[] {94, 108, 140, 127, 4, 127, 4, 127, 4, 159, 4, 113, 113, 113, 145, 120, 122, 159, 100, 100, 125, 189})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkCollide([In] Hitboxc obj0, [In] Hitboxc obj1)
    {
      obj0.hitbox(this.r1);
      obj1.hitbox(this.r2);
      this.r1.x += obj0.lastX() - ((Posc) obj0).getX();
      this.r1.y += obj0.lastY() - ((Posc) obj0).getY();
      this.r2.x += obj1.lastX() - ((Posc) obj1).getX();
      this.r2.y += obj1.lastY() - ((Posc) obj1).getY();
      float num1 = ((Posc) obj0).getX() - obj0.lastX();
      float num2 = ((Posc) obj0).getY() - obj0.lastY();
      float num3 = ((Posc) obj1).getX() - obj1.lastX();
      float num4 = ((Posc) obj1).getY() - obj1.lastY();
      if (object.ReferenceEquals((object) obj0, (object) obj1) || !obj0.collides(obj1))
        return;
      this.l1.set(((Posc) obj0).getX(), ((Posc) obj0).getY());
      if ((this.r1.overlaps(this.r2) || this.collide(this.r1.x, this.r1.y, this.r1.width, this.r1.height, num1, num2, this.r2.x, this.r2.y, this.r2.width, this.r2.height, num3, num4, this.l1) ? 1 : 0) == 0)
        return;
      obj0.collision(obj1, this.l1.x, this.l1.y);
      obj1.collision(obj0, this.l1.x, this.l1.y);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {73, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updatePhysics\u00240([In] QuadTree obj0, [In] Hitboxc obj1)
    {
      obj1.updateLastPosition();
      obj0.insert((QuadTree.QuadTreeObject) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 103, 108, 127, 4, 159, 4, 108, 146, 172, 145, 127, 1, 108, 115, 136, 137, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024collide\u00242([In] Hitboxc obj0)
    {
      obj0.hitbox(this.r1);
      this.r1.x += obj0.lastX() - ((Posc) obj0).getX();
      this.r1.y += obj0.lastY() - ((Posc) obj0).getY();
      obj0.hitbox(this.r2);
      this.r2.merge(this.r1);
      this.arrOut.clear();
      obj0.getCollisions((Cons) new EntityCollisions.__\u003C\u003EAnon3(this));
      Iterator iterator = this.arrOut.iterator();
      while (iterator.hasNext())
      {
        Hitboxc hitboxc = (Hitboxc) iterator.next();
        hitboxc.hitbox(this.r1);
        if (this.r2.overlaps(this.r1))
        {
          this.checkCollide(obj0, hitboxc);
          if (!obj0.isAdded())
            break;
        }
      }
    }

    [Modifiers]
    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024collide\u00241([In] QuadTree obj0) => obj0.intersect(this.r2, this.arrOut);

    [LineNumberTable(new byte[] {159, 171, 117, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveCheck(
      Hitboxc entity,
      float deltax,
      float deltay,
      EntityCollisions.SolidPred solidCheck)
    {
      if (solidCheck.solid(entity.tileX(), entity.tileY()))
        return;
      this.move(entity, deltax, deltay, solidCheck);
    }

    [LineNumberTable(new byte[] {159, 177, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void move(Hitboxc entity, float deltax, float deltay) => this.move(entity, deltax, deltay, (EntityCollisions.SolidPred) new EntityCollisions.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {45, 109, 162, 120, 152, 106, 105, 107, 107, 159, 1, 110, 226, 58, 40, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlapsTile(Rect rect)
    {
      rect.getCenter(this.vector);
      int num1 = 1;
      int num2 = Math.round(this.vector.x / 8f);
      int num3 = Math.round(this.vector.y / 8f);
      for (int index1 = -num1; index1 <= num1; ++index1)
      {
        for (int index2 = -num1; index2 <= num1; ++index2)
        {
          int x = index1 + num2;
          int y = index2 + num3;
          if (EntityCollisions.solid(x, y))
          {
            this.r2.setSize(8f).setCenter((float) (x * 8), (float) (y * 8));
            if (this.r2.overlaps(rect))
              return true;
          }
        }
      }
      return false;
    }

    [Signature("<T::Lmindustry/gen/Hitboxc;>(Lmindustry/entities/EntityGroup<TT;>;)V")]
    [LineNumberTable(new byte[] {69, 103, 134, 209})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePhysics(EntityGroup group)
    {
      QuadTree quadTree = group.tree();
      quadTree.clear();
      group.each((Cons) new EntityCollisions.__\u003C\u003EAnon1(quadTree));
    }

    [LineNumberTable(new byte[] {79, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool legsSolid(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile == null || tile.staticDarkness() >= 2 || tile.floor().solid && object.ReferenceEquals((object) tile.block(), (object) Blocks.air);
    }

    [LineNumberTable(new byte[] {84, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool waterSolid(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile == null || tile.solid() || !tile.floor().isLiquid;
    }

    [Signature("<T::Lmindustry/gen/Hitboxc;>(Lmindustry/entities/EntityGroup<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 102, 241, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collide(EntityGroup groupa) => groupa.each((Cons) new EntityCollisions.__\u003C\u003EAnon2(this));

    public interface SolidPred
    {
      bool solid(int i1, int i2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : EntityCollisions.SolidPred
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool solid([In] int obj0, [In] int obj1) => (EntityCollisions.solid(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly QuadTree arg\u00241;

      internal __\u003C\u003EAnon1([In] QuadTree obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => EntityCollisions.lambda\u0024updatePhysics\u00240(this.arg\u00241, (Hitboxc) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly EntityCollisions arg\u00241;

      internal __\u003C\u003EAnon2([In] EntityCollisions obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024collide\u00242((Hitboxc) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly EntityCollisions arg\u00241;

      internal __\u003C\u003EAnon3([In] EntityCollisions obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024collide\u00241((QuadTree) obj0);
    }
  }
}
