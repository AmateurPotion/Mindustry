// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.UnitFactory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.payloads;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.units
{
  public class UnitFactory : UnitBlock
  {
    public int[] capacities;
    [Signature("Larc/struct/Seq<Lmindustry/world/blocks/units/UnitFactory$UnitPlan;>;")]
    public Seq plans;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 184, 127, 12, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] UnitFactory.UnitFactoryBuild obj0, [In] Integer obj1)
    {
      obj0.currentPlan = obj1.intValue() < 0 || obj1.intValue() >= this.plans.size ? -1 : obj1.intValue();
      obj0.progress = 0.0f;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 189, 124, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] UnitFactory.UnitFactoryBuild obj0, [In] UnitType obj1)
    {
      obj0.currentPlan = this.plans.indexOf((Boolf) new UnitFactory.__\u003C\u003EAnon11(obj1));
      obj0.progress = 0.0f;
    }

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ItemStack[] lambda\u0024new\u00243([In] UnitFactory.UnitFactoryBuild obj0) => obj0.currentPlan != -1 ? ((UnitFactory.UnitPlan) this.plans.get(obj0.currentPlan)).requirements : ItemStack.__\u003C\u003Eempty;

    [Modifiers]
    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00244([In] UnitFactory.UnitFactoryBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Color ammo = Pal.ammo;
      UnitFactory.UnitFactoryBuild unitFactoryBuild = obj0;
      Objects.requireNonNull((object) unitFactoryBuild);
      Floatp fraction = (Floatp) new UnitFactory.__\u003C\u003EAnon10(unitFactoryBuild);
      return new mindustry.ui.Bar("bar.progress", ammo, fraction);
    }

    [Modifiers]
    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00248([In] UnitFactory.UnitFactoryBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new UnitFactory.__\u003C\u003EAnon7(obj0), (Prov) new UnitFactory.__\u003C\u003EAnon8(), (Floatp) new UnitFactory.__\u003C\u003EAnon9(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 118, 103, 126, 112, 127, 17, 127, 8, 127, 81, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setStats\u002410([In] Table obj0)
    {
      Seq seq = this.plans.select((Boolf) new UnitFactory.__\u003C\u003EAnon6());
      obj0.row();
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        UnitFactory.UnitPlan unitPlan = (UnitFactory.UnitPlan) iterator.next();
        if (unitPlan.unit.unlockedNow())
        {
          obj0.image(unitPlan.unit.icon(Cicon.__\u003C\u003Esmall)).size(24f).padRight(2f).right();
          Table table1 = obj0;
          object localizedName = (object) unitPlan.unit.localizedName;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) localizedName;
          CharSequence text1 = charSequence;
          table1.add(text1).left();
          Table table2 = obj0;
          object obj = (object) new StringBuilder().append(Strings.autoFixed(unitPlan.time / 60f, 1)).append(" ").append(Core.bundle.get("unit.seconds")).toString();
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text2 = charSequence;
          table2.add(text2).color(Color.__\u003C\u003ElightGray).padLeft(12f).left();
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setStats\u00249([In] UnitFactory.UnitPlan obj0) => obj0.unit.unlockedNow();

    [Modifiers]
    [LineNumberTable(new byte[] {24, 111, 115, 120, 126, 235, 61, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00245([In] UnitFactory.UnitFactoryBuild obj0)
    {
      if (obj0.unit() == null)
        return "[lightgray]\uE815";
      return Core.bundle.format("bar.unitcap", (object) Fonts.getUnicodeStr(obj0.unit().__\u003C\u003Ename), (object) Integer.valueOf(obj0.team.data().countType(obj0.unit())), (object) Integer.valueOf(Units.getCap(obj0.team)));
    }

    [Modifiers]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00246() => Pal.power;

    [Modifiers]
    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00247([In] UnitFactory.UnitFactoryBuild obj0) => obj0.unit() == null ? 0.0f : (float) obj0.team.data().countType(obj0.unit()) / (float) Units.getCap(obj0.team);

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] UnitType obj0, [In] UnitFactory.UnitPlan obj1) => object.ReferenceEquals((object) obj1.unit, (object) obj0);

    [LineNumberTable(new byte[] {159, 174, 233, 59, 140, 204, 103, 103, 103, 103, 103, 103, 135, 246, 69, 246, 69, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitFactory(string name)
      : base(name)
    {
      UnitFactory unitFactory = this;
      this.capacities = new int[0];
      this.plans = new Seq(4);
      this.update = true;
      this.hasPower = true;
      this.hasItems = true;
      this.solid = true;
      this.configurable = true;
      this.outputsPayload = true;
      this.rotate = true;
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new UnitFactory.__\u003C\u003EAnon0(this));
      this.config((Class) ClassLiteral<UnitType>.Value, (Cons2) new UnitFactory.__\u003C\u003EAnon1(this));
      this.__\u003C\u003Econsumes.add((Consume) new ConsumeItemDynamic((Func) new UnitFactory.__\u003C\u003EAnon2(this)));
    }

    [LineNumberTable(new byte[] {6, 122, 127, 4, 120, 127, 21, 26, 200, 133, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.capacities = new int[Vars.content.items().size];
      Iterator iterator = this.plans.iterator();
label_1:
      while (iterator.hasNext())
      {
        ItemStack[] requirements = ((UnitFactory.UnitPlan) iterator.next()).requirements;
        int length = requirements.Length;
        int index = 0;
        while (true)
        {
          if (index < length)
          {
            ItemStack itemStack = requirements[index];
            this.capacities[(int) itemStack.item.__\u003C\u003Eid] = Math.max(this.capacities[(int) itemStack.item.__\u003C\u003Eid], itemStack.amount * 2);
            this.itemCapacity = Math.max(this.itemCapacity, itemStack.amount * 2);
            ++index;
          }
          else
            goto label_1;
        }
      }
      base.init();
    }

    [LineNumberTable(new byte[] {19, 102, 154, 250, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("progress", (Func) new UnitFactory.__\u003C\u003EAnon3());
      this.__\u003C\u003Ebars.add("units", (Func) new UnitFactory.__\u003C\u003EAnon4());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {42, 134, 144, 251, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003EitemCapacity);
      this.stats.add(Stat.__\u003C\u003Eoutput, (StatValue) new UnitFactory.__\u003C\u003EAnon5(this));
    }

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[3]
    {
      this.region,
      this.outRegion,
      this.topRegion
    };

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {67, 121, 127, 4, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.region, req.drawx(), req.drawy());
      Draw.rect(this.outRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
      Draw.rect(this.topRegion, req.drawx(), req.drawy());
    }

    [HideFromJava]
    static UnitFactory() => UnitBlock.__\u003Cclinit\u003E();

    public class UnitFactoryBuild : UnitBlock.UnitBuild
    {
      public int currentPlan;
      [Modifiers]
      internal UnitFactory this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(260)]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual UnitType unit() => this.currentPlan == -1 ? (UnitType) null : ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).unit;

      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float fraction() => this.currentPlan == -1 ? 0.0f : this.progress / ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).time;

      [LineNumberTable(250)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => this.this\u00240.capacities[(int) item.__\u003C\u003Eid];

      [Modifiers]
      [LineNumberTable(151)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static UnitType lambda\u0024buildConfiguration\u00240(
        [In] UnitFactory.UnitPlan obj0)
      {
        return obj0.unit;
      }

      [Modifiers]
      [LineNumberTable(151)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024buildConfiguration\u00241([In] UnitType obj0) => obj0.unlockedNow();

      [Modifiers]
      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UnitType lambda\u0024buildConfiguration\u00242() => this.currentPlan == -1 ? (UnitType) null : ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).unit;

      [Modifiers]
      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00244([In] UnitType obj0) => this.configure((object) Integer.valueOf(this.this\u00240.plans.indexOf((Boolf) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon10(obj0))));

      [Modifiers]
      [LineNumberTable(156)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024buildConfiguration\u00245([In] Table obj0)
      {
        Table table = obj0;
        object obj = (object) "@none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).color(Color.__\u003C\u003ElightGray);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {123, 103, 220, 122, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024display\u00248([In] TextureRegionDrawable obj0, [In] Table obj1)
      {
        obj1.left();
        obj1.image().update((Cons) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon8(this, obj0)).size(32f).padBottom(-4f).padRight(2f);
        obj1.label((Prov) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon9(this)).wrap().width(230f).color(Color.__\u003C\u003ElightGray);
      }

      [Modifiers]
      [LineNumberTable(195)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00249([In] UnitFactory.UnitPlan obj0) => Drawf.construct((Building) this, (UnlockableContent) obj0.unit, this.rotdeg() - 90f, this.progress / obj0.time, this.speedScl, this.time);

      [Modifiers]
      [LineNumberTable(256)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024acceptItem\u002410([In] Item obj0, [In] ItemStack obj1) => object.ReferenceEquals((object) obj1.item, (object) obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {125, 127, 39, 108, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024display\u00246([In] TextureRegionDrawable obj0, [In] Image obj1)
      {
        obj1.setDrawable(this.currentPlan != -1 ? (Drawable) obj0.set(((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).unit.icon(Cicon.__\u003C\u003Emedium)) : (Drawable) Icon.cancel);
        obj1.setScaling(Scaling.__\u003C\u003Efit);
        obj1.setColor(this.currentPlan != -1 ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003ElightGray);
      }

      [Modifiers]
      [LineNumberTable(179)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024display\u00247()
      {
        object obj = this.currentPlan != -1 ? (object) ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).unit.localizedName : (object) "@none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024buildConfiguration\u00243(
        [In] UnitType obj0,
        [In] UnitFactory.UnitPlan obj1)
      {
        return object.ReferenceEquals((object) obj1.unit, (object) obj0);
      }

      [LineNumberTable(new byte[] {86, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitFactoryBuild(UnitFactory _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((UnitBlock) _param1);
        UnitFactory.UnitFactoryBuild unitFactoryBuild = this;
        this.currentPlan = -1;
      }

      [LineNumberTable(new byte[] {95, 127, 27})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object senseObject(LAccess sensor)
      {
        if (!object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003Econfig))
          return base.senseObject(sensor);
        return this.currentPlan == -1 ? (object) null : (object) ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).unit;
      }

      [LineNumberTable(new byte[] {101, 159, 16, 104, 159, 0, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table)
      {
        Seq items = Seq.with((Iterable) this.this\u00240.plans).map((Func) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon0()).filter((Boolf) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon1());
        if (items.any())
          ItemSelection.buildTable(table, items, (Prov) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon2(this), (Cons) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon3(this));
        else
          table.table(Styles.black3, (Cons) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon4());
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptPayload(Building source, Payload payload) => false;

      [LineNumberTable(new byte[] {117, 135, 134, 103, 242, 72, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void display(Table table)
      {
        base.display(table);
        TextureRegionDrawable textureRegionDrawable = new TextureRegionDrawable();
        table.row();
        table.table((Cons) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon5(this, textureRegionDrawable)).left();
      }

      [LineNumberTable(185)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object config() => (object) Integer.valueOf(this.currentPlan);

      [LineNumberTable(new byte[] {160, 76, 124, 159, 4, 105, 124, 182, 138, 109, 134, 138, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Draw.rect(this.this\u00240.outRegion, this.x, this.y, this.rotdeg());
        if (this.currentPlan != -1)
          Draw.draw(35f, (Runnable) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon6(this, (UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)));
        Draw.z(35f);
        this.payRotation = this.rotdeg();
        this.drawPayload();
        Draw.z(35.1f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(new byte[] {160, 96, 127, 2, 167, 116, 127, 15, 127, 7, 158, 188, 134, 119, 156, 118, 147, 124, 108, 102, 187, 125, 98, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.currentPlan < 0 || this.currentPlan >= this.this\u00240.plans.size)
          this.currentPlan = -1;
        if (this.consValid() && this.currentPlan != -1)
        {
          this.time += this.edelta() * this.speedScl * Vars.state.rules.unitBuildSpeedMultiplier;
          this.progress += this.edelta() * Vars.state.rules.unitBuildSpeedMultiplier;
          this.speedScl = Mathf.lerpDelta(this.speedScl, 1f, 0.05f);
        }
        else
          this.speedScl = Mathf.lerpDelta(this.speedScl, 0.0f, 0.05f);
        this.moveOutPayload();
        if (this.currentPlan != -1 && this.payload == null)
        {
          UnitFactory.UnitPlan unitPlan = (UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan);
          if ((double) this.progress >= (double) unitPlan.time && this.consValid())
          {
            this.progress %= 1f;
            this.payload = (Payload) new UnitPayload(unitPlan.unit.create(this.team));
            this.payVector.setZero();
            this.consume();
            Events.fire((object) new EventType.UnitCreateEvent(((UnitPayload) this.payload).unit, (Building) this));
          }
          this.progress = Mathf.clamp(this.progress, 0.0f, unitPlan.time);
        }
        else
          this.progress = 0.0f;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.currentPlan != -1 && (this.enabled && this.payload == null);

      [LineNumberTable(new byte[] {160, 141, 127, 16, 63, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.currentPlan != -1 && this.items.get(item) < this.getMaximumAccepted(item) && Structs.contains((object[]) ((UnitFactory.UnitPlan) this.this\u00240.plans.get(this.currentPlan)).requirements, (Boolf) new UnitFactory.UnitFactoryBuild.__\u003C\u003EAnon7(item));

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {160, 156, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
        write.s(this.currentPlan);
      }

      [LineNumberTable(new byte[] {159, 73, 99, 104, 109, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.progress = read.f();
        this.currentPlan = (int) read.s();
      }

      [HideFromJava]
      static UnitFactoryBuild() => UnitBlock.UnitBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Func
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get([In] object obj0) => (object) UnitFactory.UnitFactoryBuild.lambda\u0024buildConfiguration\u00240((UnitFactory.UnitPlan) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public bool get([In] object obj0) => (UnitFactory.UnitFactoryBuild.lambda\u0024buildConfiguration\u00241((UnitType) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Prov
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00242();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;

        internal __\u003C\u003EAnon3([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildConfiguration\u00244((UnitType) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public void get([In] object obj0) => UnitFactory.UnitFactoryBuild.lambda\u0024buildConfiguration\u00245((Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;
        private readonly TextureRegionDrawable arg\u00242;

        internal __\u003C\u003EAnon5([In] UnitFactory.UnitFactoryBuild obj0, [In] TextureRegionDrawable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00248(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Runnable
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;
        private readonly UnitFactory.UnitPlan arg\u00242;

        internal __\u003C\u003EAnon6([In] UnitFactory.UnitFactoryBuild obj0, [In] UnitFactory.UnitPlan obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024draw\u00249(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Boolf
      {
        private readonly Item arg\u00241;

        internal __\u003C\u003EAnon7([In] Item obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (UnitFactory.UnitFactoryBuild.lambda\u0024acceptItem\u002410(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;
        private readonly TextureRegionDrawable arg\u00242;

        internal __\u003C\u003EAnon8([In] UnitFactory.UnitFactoryBuild obj0, [In] TextureRegionDrawable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00246(this.arg\u00242, (Image) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Prov
      {
        private readonly UnitFactory.UnitFactoryBuild arg\u00241;

        internal __\u003C\u003EAnon9([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024display\u00247().__\u003Cref\u003E;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon10 : Boolf
      {
        private readonly UnitType arg\u00241;

        internal __\u003C\u003EAnon10([In] UnitType obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (UnitFactory.UnitFactoryBuild.lambda\u0024buildConfiguration\u00243(this.arg\u00241, (UnitFactory.UnitPlan) obj0) ? 1 : 0) != 0;
      }
    }

    public class UnitPlan : Object
    {
      public UnitType unit;
      public ItemStack[] requirements;
      public float time;

      [LineNumberTable(new byte[] {77, 104, 103, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitPlan(UnitType unit, float time, ItemStack[] requirements)
      {
        UnitFactory.UnitPlan unitPlan = this;
        this.unit = unit;
        this.time = time;
        this.requirements = requirements;
      }

      [LineNumberTable(133)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal UnitPlan()
      {
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly UnitFactory arg\u00241;

      internal __\u003C\u003EAnon0([In] UnitFactory obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00240((UnitFactory.UnitFactoryBuild) obj0, (Integer) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons2
    {
      private readonly UnitFactory arg\u00241;

      internal __\u003C\u003EAnon1([In] UnitFactory obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00242((UnitFactory.UnitFactoryBuild) obj0, (UnitType) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Func
    {
      private readonly UnitFactory arg\u00241;

      internal __\u003C\u003EAnon2([In] UnitFactory obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024new\u00243((UnitFactory.UnitFactoryBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) UnitFactory.lambda\u0024setBars\u00244((UnitFactory.UnitFactoryBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Func
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get([In] object obj0) => (object) UnitFactory.lambda\u0024setBars\u00248((UnitFactory.UnitFactoryBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : StatValue
    {
      private readonly UnitFactory arg\u00241;

      internal __\u003C\u003EAnon5([In] UnitFactory obj0) => this.arg\u00241 = obj0;

      public void display([In] Table obj0) => this.arg\u00241.lambda\u0024setStats\u002410(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (UnitFactory.lambda\u0024setStats\u00249((UnitFactory.UnitPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Prov
    {
      private readonly UnitFactory.UnitFactoryBuild arg\u00241;

      internal __\u003C\u003EAnon7([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) UnitFactory.lambda\u0024setBars\u00245(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) UnitFactory.lambda\u0024setBars\u00246();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon9 : Floatp
    {
      private readonly UnitFactory.UnitFactoryBuild arg\u00241;

      internal __\u003C\u003EAnon9([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

      public float get() => UnitFactory.lambda\u0024setBars\u00247(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon10 : Floatp
    {
      private readonly UnitFactory.UnitFactoryBuild arg\u00241;

      internal __\u003C\u003EAnon10([In] UnitFactory.UnitFactoryBuild obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.fraction();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon11 : Boolf
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon11([In] UnitType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (UnitFactory.lambda\u0024new\u00241(this.arg\u00241, (UnitFactory.UnitPlan) obj0) ? 1 : 0) != 0;
    }
  }
}
