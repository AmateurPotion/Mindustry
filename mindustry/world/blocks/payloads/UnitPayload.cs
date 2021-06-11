// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.payloads.UnitPayload
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.payloads
{
  public class UnitPayload : Object, Payload
  {
    public const float deactiveDuration = 40f;
    public Unit unit;
    public float deactiveTime;

    [LineNumberTable(new byte[] {159, 166, 8, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitPayload(Unit unit)
    {
      UnitPayload unitPayload = this;
      this.deactiveTime = 0.0f;
      this.unit = unit;
    }

    [LineNumberTable(new byte[] {159, 172, 103, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.b(0);
      write.b(this.unit.classId());
      this.unit.write(write);
    }

    [LineNumberTable(new byte[] {159, 179, 111, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y, float rotation)
    {
      this.unit.set(x, y);
      this.unit.rotation = rotation;
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotation() => this.unit.rotation;

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float size() => this.unit.hitSize;

    [LineNumberTable(new byte[] {4, 143, 125, 107, 194, 108, 102, 120, 111, 124, 63, 2, 232, 69, 197, 174, 127, 8, 107, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dump()
    {
      if (this.unit.type == null)
        return true;
      if (!Units.canCreate(this.unit.team, this.unit.type))
      {
        this.deactiveTime = 1f;
        return false;
      }
      EntityCollisions.SolidPred solidPred = this.unit.solidity();
      if (solidPred != null)
      {
        int i1 = this.unit.tileX();
        int i2 = this.unit.tileY();
        int num = solidPred.solid(i1, i2) ? 0 : 1;
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = d4[index];
          num |= solidPred.solid(i1 + point2.x, i2 + point2.y) ? 0 : 1;
        }
        if (num == 0)
          return false;
      }
      if (Vars.net.client())
        return true;
      this.unit.vel.add(Mathf.range(0.5f), Mathf.range(0.5f));
      this.unit.add();
      Events.fire((object) new EventType.UnitUnloadEvent(this.unit));
      return true;
    }

    [LineNumberTable(new byte[] {38, 142, 127, 1, 127, 35, 182, 112, 106, 157, 102, 159, 8, 133, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      if (this.unit.type == null)
        return;
      Drawf.shadow(this.unit.x, this.unit.y, 20f);
      Draw.rect(this.unit.type.icon(Cicon.__\u003C\u003Efull), this.unit.x, this.unit.y, this.unit.rotation - 90f);
      this.unit.type.drawCell(this.unit);
      if ((double) this.deactiveTime <= 0.0)
        return;
      Draw.color(Color.__\u003C\u003Escarlet);
      Draw.alpha(0.8f * Interp.exp5Out.apply(this.deactiveTime));
      float num = 8f;
      Draw.rect(Icon.warning.getRegion(), this.unit.x, this.unit.y, num, num);
      Draw.reset();
      this.deactiveTime = Math.max(this.deactiveTime - Time.delta / 40f, 0.0f);
    }

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon(Cicon icon) => this.unit.type.icon(icon);

    [HideFromJava]
    public virtual bool fits([In] float obj0) => Payload.\u003Cdefault\u003Efits((Payload) this, obj0);
  }
}
