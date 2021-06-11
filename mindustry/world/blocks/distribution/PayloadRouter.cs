// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.PayloadRouter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.world.blocks.payloads;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class PayloadRouter : PayloadConveyor
  {
    public TextureRegion overRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 137, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PayloadRouter(string name)
      : base(name)
    {
      PayloadRouter payloadRouter = this;
      this.outputsPayload = true;
      this.outputFacing = false;
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 166, 136, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      base.drawRequestRegion(req, list);
      Draw.rect(this.overRegion, req.drawx(), req.drawy());
    }

    [HideFromJava]
    static PayloadRouter() => PayloadConveyor.__\u003Cclinit\u003E();

    public class PayloadRouterBuild : PayloadConveyor.PayloadConveyorBuild
    {
      public float smoothRot;
      [Modifiers]
      internal PayloadRouter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 181, 104, 130, 121, 166, 159, 18})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void pickNext()
      {
        if (this.item == null)
          return;
        int num1 = 0;
        do
        {
          int num2 = this.rotation + 1;
          int num3 = 4;
          this.rotation = num3 != -1 ? num2 % num3 : 0;
          this.onProximityUpdate();
          if (this.blocked || this.next == null || !this.next.acceptPayload(this.next, this.item))
            ++num1;
          else
            goto label_5;
        }
        while (num1 < 4);
        goto label_6;
label_5:
        return;
label_6:;
      }

      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PayloadRouterBuild(PayloadRouter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PayloadConveyor) _param1);
      }

      [LineNumberTable(new byte[] {159, 176, 102, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void add()
      {
        base.add();
        this.smoothRot = this.rotdeg();
      }

      [LineNumberTable(new byte[] {2, 104, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handlePayload(Building source, Payload payload)
      {
        base.handlePayload(source, payload);
        this.pickNext();
      }

      [LineNumberTable(new byte[] {8, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void moveFailed() => this.pickNext();

      [LineNumberTable(new byte[] {13, 134, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        base.updateTile();
        this.smoothRot = Mathf.slerpDelta(this.smoothRot, this.rotdeg(), 0.2f);
      }

      [LineNumberTable(new byte[] {20, 156, 134, 127, 29, 127, 3, 133, 156, 138, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        float num = 0.8f;
        Draw.mixcol(this.team.__\u003C\u003Ecolor, Math.max((num - Math.abs(this.fract() - 0.5f) * 2f) / num, 0.0f));
        Draw.rect(this.this\u00240.topRegion, this.x, this.y, this.smoothRot);
        Draw.reset();
        Draw.rect(this.this\u00240.overRegion, this.x, this.y);
        Draw.z(35f);
        if (this.item == null)
          return;
        this.item.draw();
      }

      [HideFromJava]
      static PayloadRouterBuild() => PayloadConveyor.PayloadConveyorBuild.__\u003Cclinit\u003E();
    }
  }
}
