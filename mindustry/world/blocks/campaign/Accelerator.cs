// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.campaign.Accelerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.campaign
{
  public class Accelerator : Block
  {
    public TextureRegion arrowRegion;
    public Block launching;
    public int[] capacities;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 233, 60, 107, 204, 103, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Accelerator(string name)
      : base(name)
    {
      Accelerator accelerator = this;
      this.launching = Blocks.coreNucleus;
      this.capacities = new int[0];
      this.update = true;
      this.solid = true;
      this.hasItems = true;
      this.itemCapacity = 8000;
      this.configurable = true;
    }

    [LineNumberTable(new byte[] {159, 179, 103, 122, 121, 120, 19, 198, 119, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.itemCapacity = 0;
      this.capacities = new int[Vars.content.items().size];
      ItemStack[] requirements = this.launching.requirements;
      int length = requirements.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = requirements[index];
        this.capacities[(int) itemStack.item.__\u003C\u003Eid] = itemStack.amount;
        this.itemCapacity += itemStack.amount;
      }
      this.__\u003C\u003Econsumes.items(this.launching.requirements);
      base.init();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [HideFromJava]
    static Accelerator() => Block.__\u003Cclinit\u003E();

    public class AcceleratorBuild : Building
    {
      public float heat;
      public float statusLerp;
      [Modifiers]
      internal Accelerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(118)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => this.this\u00240.capacities[(int) item.__\u003C\u003Eid];

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AcceleratorBuild(Accelerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {7, 102, 127, 12, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        base.updateTile();
        this.heat = Mathf.lerpDelta(this.heat, !this.consValid() ? 0.0f : 1f, 0.05f);
        this.statusLerp = Mathf.lerpDelta(this.statusLerp, this.power.status, 0.05f);
      }

      [LineNumberTable(new byte[] {14, 134, 105, 113, 159, 48, 102, 113, 31, 25, 230, 60, 233, 74, 142, 126, 134, 106, 119, 159, 0, 119, 123, 156, 112, 152, 105, 127, 8, 111, 255, 27, 61, 233, 70, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        for (int index1 = 0; index1 < 4; ++index1)
        {
          float len = 7f + (float) index1 * 5f;
          Draw.color(Tmp.__\u003C\u003Ec1.set(Pal.darkMetal).lerp(this.team.__\u003C\u003Ecolor, this.statusLerp), Pal.darkMetal, Mathf.absin(Time.time + (float) index1 * 50f, 10f, 1f));
          for (int index2 = 0; index2 < 4; ++index2)
          {
            float angle = (float) index2 * 90f + 45f;
            Draw.rect(this.this\u00240.arrowRegion, this.x + Angles.trnsx(angle, len), this.y + Angles.trnsy(angle, len), angle + 180f);
          }
        }
        if ((double) this.heat < 9.99999974737875E-05)
          return;
        float rad = (float) (this.this\u00240.size * 8) / 2f * 0.74f;
        float num = 2f;
        Draw.z(99.9999f);
        Lines.stroke(1.75f * this.heat, Pal.accent);
        Lines.square(this.x, this.y, rad * 1.22f, 45f);
        Lines.stroke(3f * this.heat, Pal.accent);
        Lines.square(this.x, this.y, rad, Time.time / num);
        Lines.square(this.x, this.y, rad, -Time.time / num);
        Draw.color(this.team.__\u003C\u003Ecolor);
        Draw.alpha(Mathf.clamp(this.heat * 3f));
        for (int index = 0; index < 4; ++index)
        {
          float angle = (float) index * 90f + 45f + (float) (-(double) Time.time / 3.0) % 360f;
          float len = 26f * this.heat;
          Draw.rect(this.this\u00240.arrowRegion, this.x + Angles.trnsx(angle, len), this.y + Angles.trnsy(angle, len), angle + 180f);
        }
        Draw.reset();
      }

      [LineNumberTable(103)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Graphics.Cursor getCursor()
      {
        Graphics.Cursor cursor1 = !Vars.state.isCampaign() || !this.consValid() ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow : base.getCursor();
        if (cursor1 == null)
          return (Graphics.Cursor) null;
        return cursor1 is Graphics.Cursor cursor2 ? cursor2 : throw new IncompatibleClassChangeError();
      }

      [LineNumberTable(new byte[] {58, 134, 149, 111, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table)
      {
        this.deselect();
        if (!Vars.state.isCampaign() || !this.consValid())
          return;
        Vars.ui.showInfo("@indev.campaign");
        Events.fire((object) EventType.Trigger.__\u003C\u003EacceleratorUse);
      }

      [LineNumberTable(123)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.get(item) < this.getMaximumAccepted(item);

      [HideFromJava]
      static AcceleratorBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
