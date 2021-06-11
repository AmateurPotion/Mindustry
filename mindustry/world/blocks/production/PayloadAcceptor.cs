// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.PayloadAcceptor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.world.blocks.payloads;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class PayloadAcceptor : Block
  {
    public float payloadSpeed;
    public float payloadRotateSpeed;
    public TextureRegion topRegion;
    public TextureRegion outRegion;
    public TextureRegion inRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 233, 57, 246, 73, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PayloadAcceptor(string name)
      : base(name)
    {
      PayloadAcceptor payloadAcceptor = this;
      this.payloadSpeed = 0.5f;
      this.payloadRotateSpeed = 5f;
      this.update = true;
      this.sync = true;
    }

    [LineNumberTable(new byte[] {159, 173, 108, 112, 127, 2, 255, 9, 69, 127, 3, 127, 16, 255, 119, 71, 127, 21, 127, 16, 254, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool blends(Building build, int direction)
    {
      int size = build.block.size;
      int num1 = build.block.size / 2 + 1;
      Building building = build.nearby(Geometry.d4(direction).x * num1, Geometry.d4(direction).y * num1);
      if (building != null && building.block.outputsPayload)
      {
        if (building.block.size == size)
        {
          int num2 = Math.abs(building.tileX() - build.tileX());
          int num3 = size;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
          {
            int num4 = Math.abs(building.tileY() - build.tileY());
            int num5 = size;
            if ((num5 != -1 ? num4 % num5 : 0) == 0 && (building.block.rotate && building.tileX() + Geometry.d4(building.rotation).x * size == build.tileX() && building.tileY() + Geometry.d4(building.rotation).y * size == build.tileY() || (!building.block.rotate || !building.block.outputFacing)))
              goto label_9;
          }
        }
        if (building.block.size < size)
        {
          int rotation = building.rotation;
          int num2 = 2;
          if ((num2 != -1 ? rotation % num2 : 0) == 0)
          {
            if ((double) Math.abs(building.y - build.y) > (double) ((float) (size * 8 - building.block.size * 8) / 2f))
              goto label_10;
          }
          else if ((double) Math.abs(building.x - build.x) > (double) ((float) (size * 8 - building.block.size * 8) / 2f))
            goto label_10;
          if (building.block.rotate && !object.ReferenceEquals((object) building.front(), (object) build) && building.block.outputFacing)
            goto label_10;
        }
        else
          goto label_10;
label_9:
        return true;
      }
label_10:
      return false;
    }

    [HideFromJava]
    static PayloadAcceptor() => Block.__\u003Cclinit\u003E();

    [Signature("<T::Lmindustry/world/blocks/payloads/Payload;>Lmindustry/gen/Building;")]
    public class PayloadAcceptorBuild : Building
    {
      [Signature("TT;")]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Payload payload;
      public Vec2 payVector;
      public float payRotation;
      public bool carried;
      [Modifiers]
      internal PayloadAcceptor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {57, 104, 159, 24})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updatePayload()
      {
        if (this.payload == null)
          return;
        this.payload.set(this.x + this.payVector.x, this.y + this.payVector.y, this.payRotation);
      }

      [LineNumberTable(155)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasArrived() => this.payVector.isZero(0.01f);

      [LineNumberTable(new byte[] {99, 109, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dumpPayload()
      {
        if (!this.payload.dump())
          return;
        this.payload = (Payload) null;
      }

      [LineNumberTable(new byte[] {4, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PayloadAcceptorBuild(PayloadAcceptor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        PayloadAcceptor.PayloadAcceptorBuild payloadAcceptorBuild = this;
        this.payVector = new Vec2();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload) => this.payload == null;

      [LineNumberTable(new byte[] {17, 103, 127, 79, 141, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handlePayload(Building source, Payload payload)
      {
        this.payload = payload;
        this.payVector.set((Position) source).sub((Position) this).clamp((float) (-this.this\u00240.size * 8) / 2f, (float) (-this.this\u00240.size * 8) / 2f, (float) (this.this\u00240.size * 8) / 2f, (float) (this.this\u00240.size * 8) / 2f);
        this.payRotation = payload.rotation();
        this.updatePayload();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Payload getPayload() => this.payload;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void pickedUp() => this.carried = true;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawTeamTop() => this.carried = false;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Payload takePayload()
      {
        Payload payload = this.payload;
        this.payload = (Payload) null;
        return payload;
      }

      [LineNumberTable(new byte[] {48, 102, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onRemoved()
      {
        base.onRemoved();
        if (this.payload == null || this.carried)
          return;
        this.payload.dump();
      }

      [LineNumberTable(103)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool blends(int direction) => PayloadAcceptor.blends((Building) this, direction);

      [LineNumberTable(new byte[] {64, 138, 134, 127, 34, 159, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool moveInPayload()
      {
        if (this.payload == null)
          return false;
        this.updatePayload();
        this.payRotation = Angles.moveToward(this.payRotation, !this.this\u00240.rotate ? 90f : this.rotdeg(), this.this\u00240.payloadRotateSpeed * this.edelta());
        this.payVector.approach(Vec2.__\u003C\u003EZERO, this.this\u00240.payloadSpeed * this.delta());
        return this.hasArrived();
      }

      [LineNumberTable(new byte[] {75, 137, 134, 159, 8, 127, 14, 159, 2, 118, 159, 67, 103, 112, 110, 137, 112, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void moveOutPayload()
      {
        if (this.payload == null)
          return;
        this.updatePayload();
        Vec2 target = Tmp.__\u003C\u003Ev1.trns(this.rotdeg(), (float) (this.this\u00240.size * 8) / 2f);
        this.payRotation = Angles.moveToward(this.payRotation, this.rotdeg(), this.this\u00240.payloadRotateSpeed * this.edelta());
        this.payVector.approach(target, this.this\u00240.payloadSpeed * this.delta());
        if (!this.payVector.within((Position) target, 1f / 1000f))
          return;
        this.payVector.clamp((float) (-this.this\u00240.size * 8) / 2f, (float) (-this.this\u00240.size * 8) / 2f, (float) (this.this\u00240.size * 8) / 2f, (float) (this.this\u00240.size * 8) / 2f);
        Building building = this.front();
        if (building != null && building.block.outputsPayload)
        {
          if (!this.movePayload(this.payload))
            return;
          this.payload = (Payload) null;
        }
        else
        {
          if (building != null && building.tile().solid())
            return;
          this.dumpPayload();
        }
      }

      [LineNumberTable(new byte[] {109, 104, 134, 106, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void drawPayload()
      {
        if (this.payload == null)
          return;
        this.updatePayload();
        Draw.z(35f);
        this.payload.draw();
      }

      [LineNumberTable(new byte[] {119, 135, 113, 113, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.payVector.x);
        write.f(this.payVector.y);
        write.f(this.payRotation);
        Payload.write(this.payload, write);
      }

      [LineNumberTable(new byte[] {159, 98, 163, 136, 122, 109, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.payVector.set(read.f(), read.f());
        this.payRotation = read.f();
        this.payload = Payload.read(read);
      }

      [HideFromJava]
      static PayloadAcceptorBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
