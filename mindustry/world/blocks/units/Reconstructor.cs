// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.Reconstructor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.payloads;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.units
{
  public class Reconstructor : UnitBlock
  {
    public float constructTime;
    [Signature("Larc/struct/Seq<[Lmindustry/type/UnitType;>;")]
    public Seq upgrades;
    public int[] capacities;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00240(
      [In] Reconstructor.ReconstructorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Color ammo = Pal.ammo;
      Reconstructor.ReconstructorBuild reconstructorBuild = obj0;
      Objects.requireNonNull((object) reconstructorBuild);
      Floatp fraction = (Floatp) new Reconstructor.__\u003C\u003EAnon6(reconstructorBuild);
      return new mindustry.ui.Bar("bar.progress", ammo, fraction);
    }

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00244(
      [In] Reconstructor.ReconstructorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Reconstructor.__\u003C\u003EAnon3(obj0), (Prov) new Reconstructor.__\u003C\u003EAnon4(), (Floatp) new Reconstructor.__\u003C\u003EAnon5(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {20, 103, 127, 4, 102, 122, 127, 30, 159, 5, 156, 127, 15, 127, 5, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setStats\u00245([In] Table obj0)
    {
      obj0.row();
      Iterator iterator = this.upgrades.iterator();
      while (iterator.hasNext())
      {
        UnitType[] unitTypeArray = (UnitType[]) iterator.next();
        float size = 24f;
        if (unitTypeArray[0].unlockedNow() && unitTypeArray[1].unlockedNow())
        {
          obj0.image(unitTypeArray[0].icon(Cicon.__\u003C\u003Esmall)).size(size).padRight(4f).padLeft(10f).scaling(Scaling.__\u003C\u003Efit).right();
          Table table1 = obj0;
          object localizedName1 = (object) unitTypeArray[0].localizedName;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) localizedName1;
          CharSequence text1 = charSequence;
          table1.add(text1).left();
          Table table2 = obj0;
          object obj = (object) "[lightgray] -> ";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text2 = charSequence;
          table2.add(text2);
          obj0.image(unitTypeArray[1].icon(Cicon.__\u003C\u003Esmall)).size(size).padRight(4f).scaling(Scaling.__\u003C\u003Efit);
          Table table3 = obj0;
          object localizedName2 = (object) unitTypeArray[1].localizedName;
          charSequence.__\u003Cref\u003E = (__Null) localizedName2;
          CharSequence text3 = charSequence;
          table3.add(text3).left();
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 111, 115, 120, 126, 235, 61, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00241([In] Reconstructor.ReconstructorBuild obj0)
    {
      if (obj0.unit() == null)
        return "[lightgray]\uE815";
      return Core.bundle.format("bar.unitcap", (object) Fonts.getUnicodeStr(obj0.unit().__\u003C\u003Ename), (object) Integer.valueOf(obj0.team.data().countType(obj0.unit())), (object) Integer.valueOf(Units.getCap(obj0.team)));
    }

    [Modifiers]
    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00242() => Pal.power;

    [Modifiers]
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00243([In] Reconstructor.ReconstructorBuild obj0) => obj0.unit() == null ? 0.0f : (float) obj0.team.data().countType(obj0.unit()) / (float) Units.getCap(obj0.team);

    [LineNumberTable(new byte[] {159, 172, 233, 59, 107, 107, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Reconstructor(string name)
      : base(name)
    {
      Reconstructor reconstructor = this;
      this.constructTime = 120f;
      this.upgrades = new Seq();
      this.capacities = new int[0];
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 177, 121, 127, 4, 127, 4, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.region, req.drawx(), req.drawy());
      Draw.rect(this.inRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.rect(this.outRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.rect(this.topRegion, req.drawx(), req.drawy());
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[4]
    {
      this.region,
      this.inRegion,
      this.outRegion,
      this.topRegion
    };

    [LineNumberTable(new byte[] {159, 190, 134, 122, 250, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("progress", (Func) new Reconstructor.__\u003C\u003EAnon0());
      this.__\u003C\u003Ebars.add("units", (Func) new Reconstructor.__\u003C\u003EAnon1());
    }

    [LineNumberTable(new byte[] {16, 134, 127, 3, 251, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.constructTime / 60f, StatUnit.__\u003C\u003Eseconds);
      this.stats.add(Stat.__\u003C\u003Eoutput, (StatValue) new Reconstructor.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {39, 122, 127, 16, 127, 9, 127, 18, 25, 230, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.capacities = new int[Vars.content.items().size];
      if (this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eitem) && this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem) is ConsumeItems)
      {
        ItemStack[] items = ((ConsumeItems) this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem)).__\u003C\u003Eitems;
        int length = items.Length;
        for (int index = 0; index < length; ++index)
        {
          ItemStack itemStack = items[index];
          this.capacities[(int) itemStack.item.__\u003C\u003Eid] = Math.max(this.capacities[(int) itemStack.item.__\u003C\u003Eid], itemStack.amount * 2);
          this.itemCapacity = Math.max(this.itemCapacity, itemStack.amount * 2);
        }
      }
      base.init();
    }

    [HideFromJava]
    static Reconstructor() => UnitBlock.__\u003Cclinit\u003E();

    public class ReconstructorBuild : UnitBlock.UnitBuild
    {
      [Modifiers]
      internal Reconstructor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 84, 138, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual UnitType unit()
      {
        if (this.payload == null)
          return (UnitType) null;
        UnitType unitType = this.upgrade(((UnitPayload) this.payload).unit.type);
        return unitType != null && unitType.unlockedNow() ? unitType : (UnitType) null;
      }

      [LineNumberTable(103)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float fraction() => this.progress / this.this\u00240.constructTime;

      [LineNumberTable(new byte[] {160, 95, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasUpgrade(UnitType type)
      {
        UnitType unitType = this.upgrade(type);
        return unitType != null && unitType.unlockedNow();
      }

      [LineNumberTable(205)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool constructing() => this.payload != null && this.hasUpgrade(((UnitPayload) this.payload).unit.type);

      [LineNumberTable(new byte[] {160, 100, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual UnitType upgrade(UnitType type) => ((UnitType[]) this.this\u00240.upgrades.find((Boolf) new Reconstructor.ReconstructorBuild.__\u003C\u003EAnon1(type)))?[1];

      [Modifiers]
      [LineNumberTable(new byte[] {95, 127, 0, 127, 41, 101, 127, 57})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00240()
      {
        Draw.alpha(1f - this.progress / this.this\u00240.constructTime);
        Draw.rect(((UnitPayload) this.payload).unit.type.icon(Cicon.__\u003C\u003Efull), this.x, this.y, ((UnitPayload) this.payload).rotation() - 90f);
        Draw.reset();
        Drawf.construct((Building) this, (UnlockableContent) this.upgrade(((UnitPayload) this.payload).unit.type), ((UnitPayload) this.payload).rotation() - 90f, this.progress / this.this\u00240.constructTime, this.speedScl, this.time);
      }

      [Modifiers]
      [LineNumberTable(214)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024upgrade\u00241([In] UnitType obj0, [In] UnitType[] obj1) => object.ReferenceEquals((object) obj1[0], (object) obj0);

      [LineNumberTable(100)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReconstructorBuild(Reconstructor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((UnitBlock) _param1);
      }

      [LineNumberTable(new byte[] {62, 30, 110, 127, 12, 235, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload)
      {
        if (this.payload == null && (this.enabled || object.ReferenceEquals((object) source, (object) this)) && (int) (sbyte) this.relativeTo(source) != this.rotation)
        {
          Payload payload1 = payload;
          UnitPayload unitPayload;
          if (payload1 is UnitPayload && object.ReferenceEquals((object) (unitPayload = (UnitPayload) payload1), (object) (UnitPayload) payload1) && this.hasUpgrade(unitPayload.unit.type))
            return true;
        }
        return false;
      }

      [LineNumberTable(117)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => this.this\u00240.capacities[(int) item.__\u003C\u003Eid];

      [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
      [LineNumberTable(new byte[] {72, 125, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void overwrote(Seq builds)
      {
        if (!object.ReferenceEquals((object) ((Building) builds.first()).block, (object) this.block))
          return;
        this.items.add(((Building) builds.first()).items);
      }

      [LineNumberTable(new byte[] {79, 188, 98, 102, 114, 127, 8, 226, 61, 230, 70, 159, 10, 159, 4, 112, 247, 71, 138, 166, 106, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        int num = 1;
        for (int direction = 0; direction < 4; ++direction)
        {
          if (this.blends(direction) && direction != this.rotation)
          {
            Draw.rect(this.this\u00240.inRegion, this.x, this.y, (float) (direction * 90 - 180));
            num = 0;
          }
        }
        if (num != 0)
          Draw.rect(this.this\u00240.inRegion, this.x, this.y, (float) (this.rotation * 90));
        Draw.rect(this.this\u00240.outRegion, this.x, this.y, this.rotdeg());
        if (this.constructing() && this.hasArrived())
        {
          Draw.draw(35f, (Runnable) new Reconstructor.ReconstructorBuild.__\u003C\u003EAnon0(this));
        }
        else
        {
          Draw.z(35f);
          this.drawPayload();
        }
        Draw.z(35.1f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(new byte[] {112, 130, 139, 125, 139, 107, 104, 98, 223, 7, 118, 127, 38, 115, 112, 107, 102, 251, 70, 126, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        int num = 0;
        if (this.payload != null)
        {
          if (!this.hasUpgrade(((UnitPayload) this.payload).unit.type))
            this.moveOutPayload();
          else if (this.moveInPayload())
          {
            if (this.consValid())
            {
              num = 1;
              this.progress += this.edelta() * Vars.state.rules.unitBuildSpeedMultiplier;
            }
            if ((double) this.progress >= (double) this.this\u00240.constructTime)
            {
              ((UnitPayload) this.payload).unit = this.upgrade(((UnitPayload) this.payload).unit.type).create(((UnitPayload) this.payload).unit.team());
              this.progress %= 1f;
              Effect.shake(2f, 3f, (Position) this);
              Fx.__\u003C\u003Eproducesmoke.at((Position) this);
              this.consume();
              Events.fire((object) new EventType.UnitCreateEvent(((UnitPayload) this.payload).unit, (Building) this));
            }
          }
        }
        this.speedScl = Mathf.lerpDelta(this.speedScl, (float) Mathf.num(num != 0), 0.05f);
        this.time += this.edelta() * this.speedScl * Vars.state.rules.unitBuildSpeedMultiplier;
      }

      [LineNumberTable(194)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.constructing();

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {160, 111, 135, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
      }

      [LineNumberTable(new byte[] {159, 84, 67, 136, 100, 173})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        if (num != 1)
          return;
        this.progress = read.f();
      }

      [HideFromJava]
      static ReconstructorBuild() => UnitBlock.UnitBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly Reconstructor.ReconstructorBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] Reconstructor.ReconstructorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly UnitType arg\u00241;

        internal __\u003C\u003EAnon1([In] UnitType obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (Reconstructor.ReconstructorBuild.lambda\u0024upgrade\u00241(this.arg\u00241, (UnitType[]) obj0) ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) Reconstructor.lambda\u0024setBars\u00240((Reconstructor.ReconstructorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Func
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get([In] object obj0) => (object) Reconstructor.lambda\u0024setBars\u00244((Reconstructor.ReconstructorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : StatValue
    {
      private readonly Reconstructor arg\u00241;

      internal __\u003C\u003EAnon2([In] Reconstructor obj0) => this.arg\u00241 = obj0;

      public void display([In] Table obj0) => this.arg\u00241.lambda\u0024setStats\u00245(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Prov
    {
      private readonly Reconstructor.ReconstructorBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] Reconstructor.ReconstructorBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) Reconstructor.lambda\u0024setBars\u00241(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) Reconstructor.lambda\u0024setBars\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Floatp
    {
      private readonly Reconstructor.ReconstructorBuild arg\u00241;

      internal __\u003C\u003EAnon5([In] Reconstructor.ReconstructorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => Reconstructor.lambda\u0024setBars\u00243(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Floatp
    {
      private readonly Reconstructor.ReconstructorBuild arg\u00241;

      internal __\u003C\u003EAnon6([In] Reconstructor.ReconstructorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.fraction();
    }
  }
}
