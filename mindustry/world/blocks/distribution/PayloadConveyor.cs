// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.PayloadConveyor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.production;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class PayloadConveyor : Block
  {
    public float moveTime;
    public float moveForce;
    public TextureRegion topRegion;
    public TextureRegion edgeRegion;
    public Interp interp;
    public float payloadLimit;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 233, 57, 182, 107, 203, 107, 103, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PayloadConveyor(string name)
      : base(name)
    {
      PayloadConveyor payloadConveyor = this;
      this.moveTime = 40f;
      this.moveForce = 201f;
      this.interp = (Interp) Interp.pow5;
      this.payloadLimit = 2.5f;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.size = 3;
      this.rotate = true;
      this.update = true;
      this.outputsPayload = true;
      this.noUpdateDisabled = true;
      this.sync = true;
    }

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override TextureRegion[] icons() => new TextureRegion[1]
    {
      (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-icon").toString())
    };

    [LineNumberTable(new byte[] {159, 131, 67, 138, 105, 127, 12, 127, 4, 255, 3, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      for (int index = 0; index < 4; ++index)
      {
        Building building = Vars.world.build(x + Geometry.__\u003C\u003Ed4x[index] * this.size, y + Geometry.__\u003C\u003Ed4y[index] * this.size);
        if (building != null && building.block.outputsPayload && building.block.size == this.size)
          Drawf.selected(building.tileX(), building.tileY(), building.block, building.team.__\u003C\u003Ecolor);
      }
    }

    [HideFromJava]
    static PayloadConveyor() => Block.__\u003Cclinit\u003E();

    public class PayloadConveyorBuild : Building
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Payload item;
      public float progress;
      public float itemRotation;
      public float animation;
      public float curInterp;
      public float lastInterp;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Building next;
      public bool blocked;
      public int step;
      public int stepAccepted;
      [Modifiers]
      internal PayloadConveyor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(318)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float fract() => this.this\u00240.interp.apply(this.progress / this.this\u00240.moveTime);

      [LineNumberTable(207)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float time() => Time.time;

      [LineNumberTable(new byte[] {160, 146, 107, 111, 188, 153, 103, 149, 104, 159, 24, 191, 16, 150, 158})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updatePayload()
      {
        if (this.item == null)
          return;
        if ((double) this.animation > (double) this.fract())
          this.animation = Mathf.lerp(this.animation, 0.8f, 0.15f);
        this.animation = Math.max(this.animation, this.fract());
        float animation = this.animation;
        float f3 = Mathf.slerp(this.itemRotation, this.rotdeg(), animation);
        if ((double) animation < 0.5)
          Tmp.__\u003C\u003Ev1.trns(this.itemRotation + 180f, (0.5f - animation) * 8f * (float) this.this\u00240.size);
        else
          Tmp.__\u003C\u003Ev1.trns(this.rotdeg(), (animation - 0.5f) * 8f * (float) this.this\u00240.size);
        this.item.set(this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, f3);
      }

      [LineNumberTable(314)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int curStep() => ByteCodeHelper.f2i(this.time() / this.this\u00240.moveTime);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void moved()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void moveFailed()
      {
      }

      [LineNumberTable(new byte[] {160, 176, 134, 137, 102, 140, 102, 111, 112, 112, 127, 0, 127, 1, 159, 8, 118, 98, 186})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual TextureRegion clipRegion(
        Rect bounds,
        Rect sprite,
        TextureRegion region)
      {
        Rect r3 = Tmp.__\u003C\u003Er3;
        int num1 = Intersector.intersectRectangles(bounds, sprite, r3) ? 1 : 0;
        TextureRegion tr1 = Tmp.__\u003C\u003Etr1;
        tr1.set(region.texture);
        if (num1 != 0)
        {
          float num2 = region.u2 - region.u;
          float num3 = region.v2 - region.v;
          float u1 = region.u;
          float v1 = region.v;
          float u2 = (r3.x - sprite.x) / sprite.width * num2 + u1;
          float v2 = (r3.y - sprite.y) / sprite.height * num3 + v1;
          float num4 = r3.width / sprite.width * num2;
          float num5 = r3.height / sprite.height * num3;
          tr1.set(u2, v2, u2 + num4, v2 + num5);
        }
        else
          tr1.set(0.0f, 0.0f, 0.0f, 0.0f);
        return tr1;
      }

      [LineNumberTable(new byte[] {160, 169, 105, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool blends(int direction)
      {
        if (direction != this.rotation)
          return PayloadAcceptor.blends((Building) this, direction);
        return !this.blocked || this.next != null;
      }

      [LineNumberTable(new byte[] {4, 239, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PayloadConveyorBuild(PayloadConveyor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        PayloadConveyor.PayloadConveyorBuild payloadConveyorBuild = this;
        this.step = -1;
        this.stepAccepted = -1;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Payload takePayload()
      {
        Payload payload = this.item;
        this.item = (Payload) null;
        return payload;
      }

      [LineNumberTable(new byte[] {21, 134, 159, 32, 159, 0, 255, 117, 69, 127, 28, 159, 12, 137, 167, 112, 127, 17, 127, 43})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        Building building = this.nearby(Geometry.d4(this.rotation).x * this.this\u00240.size, Geometry.d4(this.rotation).y * this.this\u00240.size);
        if (building != null)
        {
          if (building.block.size != this.this\u00240.size || this.tileX() + Geometry.d4(this.rotation).x * this.this\u00240.size != building.tileX() || this.tileY() + Geometry.d4(this.rotation).y * this.this\u00240.size != building.tileY())
          {
            if (building.block.size > this.this\u00240.size)
            {
              int rotation = this.rotation;
              int num = 2;
              if ((num != -1 ? rotation % num : 0) == 0)
              {
                if ((double) Math.abs(building.y - this.y) > (double) ((float) (building.block.size * 8 - this.this\u00240.size * 8) / 2f))
                  goto label_7;
              }
              else if ((double) Math.abs(building.x - this.x) > (double) ((float) (building.block.size * 8 - this.this\u00240.size * 8) / 2f))
                goto label_7;
            }
            else
              goto label_7;
          }
          this.next = building;
          goto label_8;
        }
label_7:
        this.next = (Building) null;
label_8:
        int num1 = 1 + this.this\u00240.size / 2;
        Tile tile = this.tile.nearby(Geometry.d4(this.rotation).x * num1, Geometry.d4(this.rotation).y * num1);
        int num2;
        if (tile == null || !tile.solid() || tile.block().outputsPayload)
        {
          if (this.next != null)
          {
            int num3 = this.next.rotation + 2;
            int num4 = 4;
            if ((num4 != -1 ? num3 % num4 : 0) == this.rotation)
              goto label_11;
          }
          num2 = 0;
          goto label_13;
        }
label_11:
        num2 = 1;
label_13:
        this.blocked = num2 != 0;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Payload getPayload() => this.item;

      [LineNumberTable(new byte[] {52, 137, 108, 141, 121, 154, 166, 103, 108, 109, 103, 141, 122, 136, 171, 148, 114, 103, 136, 136, 109, 103, 230, 69, 107, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!this.enabled)
          return;
        this.lastInterp = this.curInterp;
        this.curInterp = this.fract();
        if ((double) this.lastInterp > (double) this.curInterp)
          this.lastInterp = 0.0f;
        this.progress = this.time() % this.this\u00240.moveTime;
        this.updatePayload();
        int num1 = this.curStep();
        if (num1 <= this.step)
          return;
        int num2 = this.step != -1 ? 1 : 0;
        this.step = num1;
        int num3 = this.item == null ? 0 : 1;
        if (num2 != 0 && this.stepAccepted != num1 && this.item != null)
        {
          if (this.next != null)
          {
            this.next.updateTile();
            if (this.next.acceptPayload((Building) this, this.item))
            {
              this.next.handlePayload((Building) this, this.item);
              this.item = (Payload) null;
              this.moved();
            }
          }
          else if (!this.blocked && this.item.dump())
          {
            this.item = (Payload) null;
            this.moved();
          }
        }
        if (num3 == 0 || this.item == null)
          return;
        this.moveFailed();
      }

      [LineNumberTable(new byte[] {105, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void drawBottom() => base.draw();

      [LineNumberTable(new byte[] {110, 134, 134, 127, 14, 145, 159, 38, 127, 31, 176, 127, 95, 159, 14, 191, 31, 127, 55, 159, 14, 107, 122, 158, 127, 65, 255, 24, 59, 235, 73, 133, 104, 106, 31, 3, 232, 70, 138, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        float num1 = 0.8f;
        Draw.mixcol(this.team.__\u003C\u003Ecolor, Math.max((num1 - Math.abs(this.fract() - 0.5f) * 2f) / num1, 0.0f));
        float cx1 = this.fract() * (float) this.this\u00240.size * 8f;
        float cx2 = (float) (this.this\u00240.size * 8) * (this.fract() - 1f);
        float num2 = this.rotdeg();
        TextureRegion region1 = this.clipRegion(this.tile.getHitbox(Tmp.__\u003C\u003Er1), this.tile.getHitbox(Tmp.__\u003C\u003Er2).move(cx1, 0.0f), this.this\u00240.topRegion);
        float num3 = (float) (8 * this.this\u00240.size);
        Tmp.__\u003C\u003Ev1.set(num3 - (float) region1.width * Draw.scl + (float) region1.width / 2f * Draw.scl - num3 / 2f, num3 - (float) region1.height * Draw.scl + (float) region1.height / 2f * Draw.scl - num3 / 2f).rotate(num2);
        Draw.rect(region1, this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, num2);
        TextureRegion region2 = this.clipRegion(this.tile.getHitbox(Tmp.__\u003C\u003Er1), this.tile.getHitbox(Tmp.__\u003C\u003Er2).move(cx2, 0.0f), this.this\u00240.topRegion);
        Tmp.__\u003C\u003Ev1.set((float) (-(double) num3 / 2.0) + (float) region2.width / 2f * Draw.scl, (float) (-(double) num3 / 2.0) + (float) region2.height / 2f * Draw.scl).rotate(num2);
        Draw.rect(region2, this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, num2);
        for (int direction = 0; direction < 4; ++direction)
        {
          if (this.blends(direction) && direction != this.rotation)
          {
            Draw.alpha(1f - Interp.pow5In.apply(this.fract()));
            Tmp.__\u003C\u003Ev1.set((float) (-(double) num3 / 2.0) + (float) region2.width / 2f * Draw.scl, (float) (-(double) num3 / 2.0) + (float) region2.height / 2f * Draw.scl).rotate((float) (direction * 90 + 180));
            Draw.rect(region2, this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, (float) (direction * 90 + 180));
          }
        }
        Draw.reset();
        for (int direction = 0; direction < 4; ++direction)
        {
          if (!this.blends(direction))
            Draw.rect(this.this\u00240.edgeRegion, this.x, this.y, (float) (direction * 90));
        }
        Draw.z(35f);
        if (this.item == null)
          return;
        this.item.draw();
      }

      [LineNumberTable(new byte[] {160, 99, 127, 5, 127, 31, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void unitOn(Unit unit)
      {
        float num = (this.curInterp - this.lastInterp) * (float) this.this\u00240.size * 8f;
        Tmp.__\u003C\u003Ev1.trns(this.rotdeg(), num * this.this\u00240.moveForce).scl(1f / Math.max(unit.mass(), 201f));
        unit.move(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y);
      }

      [LineNumberTable(new byte[] {160, 106, 116, 63, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload) => this.item == null && payload.fits(this.this\u00240.payloadLimit) && (object.ReferenceEquals((object) source, (object) this) || this.enabled && (double) this.progress <= 5.0);

      [LineNumberTable(new byte[] {160, 113, 103, 108, 127, 1, 139, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handlePayload(Building source, Payload payload)
      {
        this.item = payload;
        this.stepAccepted = this.curStep();
        this.itemRotation = !object.ReferenceEquals((object) source, (object) this) ? source.angleTo((Position) this) : this.rotdeg();
        this.animation = 0.0f;
        this.updatePayload();
      }

      [LineNumberTable(new byte[] {160, 123, 102, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onRemoved()
      {
        base.onRemoved();
        if (this.item == null)
          return;
        this.item.dump();
      }

      [LineNumberTable(new byte[] {160, 129, 135, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
        write.f(this.itemRotation);
        Payload.write(this.item, write);
      }

      [LineNumberTable(new byte[] {159, 79, 67, 136, 104, 109, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        double num2 = (double) read.f();
        this.itemRotation = read.f();
        this.item = Payload.read(read);
      }

      [HideFromJava]
      static PayloadConveyorBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
