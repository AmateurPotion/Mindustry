// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.campaign.LaunchPad
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.environment;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.modules;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.campaign
{
  public class LaunchPad : Block
  {
    internal int __\u003C\u003EtimerLaunch;
    public float launchTime;
    public Sound launchSound;
    public TextureRegion lightRegion;
    public TextureRegion podRegion;
    public new Color lightColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00243([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new LaunchPad.__\u003C\u003EAnon1(obj0), (Prov) new LaunchPad.__\u003C\u003EAnon2(), (Floatp) new LaunchPad.__\u003C\u003EAnon3(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] Building obj0) => Core.bundle.format("bar.items", (object) Integer.valueOf(obj0.items.total()));

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.items;

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00242([In] Building obj0) => (float) obj0.items.total() / (float) this.itemCapacity;

    [LineNumberTable(new byte[] {159, 181, 233, 54, 185, 203, 208, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaunchPad(string name)
      : base(name)
    {
      LaunchPad launchPad1 = this;
      LaunchPad launchPad2 = this;
      int timers = launchPad2.timers;
      LaunchPad launchPad3 = launchPad2;
      int num = timers;
      launchPad3.timers = timers + 1;
      this.__\u003C\u003EtimerLaunch = num;
      this.launchSound = Sounds.none;
      this.lightColor = Color.valueOf("eab678");
      this.hasItems = true;
      this.solid = true;
      this.update = true;
      this.configurable = true;
      this.drawDisabled = false;
    }

    [LineNumberTable(new byte[] {159, 191, 134, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003ElaunchTime, this.launchTime / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [LineNumberTable(new byte[] {6, 134, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("items", (Func) new LaunchPad.__\u003C\u003EAnon0(this));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [HideFromJava]
    static LaunchPad() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerLaunch
    {
      [HideFromJava] get => this.__\u003C\u003EtimerLaunch;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerLaunch = value;
    }

    public class LaunchPadBuild : Building
    {
      [Modifiers]
      internal LaunchPad this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(76)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float efficiency() => this.power != null && this.block.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Epower) && !this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered ? this.power.status : 1f;

      [Modifiers]
      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024updateTile\u00240([In] LaunchPayload obj0, [In] Item obj1, [In] int obj2) => obj0.stacks.add((object) new ItemStack(obj1, obj2));

      [Modifiers]
      [LineNumberTable(new byte[] {100, 159, 15, 114, 116, 31, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static CharSequence lambda\u0024display\u00241()
      {
        Sector sector = Vars.state.rules.sector != null ? Vars.state.rules.sector.info.getRealDestination() : (Sector) null;
        object obj = (object) Core.bundle.format("launch.destination", sector != null ? (object) new StringBuilder().append("[accent]").append(sector.name()).toString() : (object) Core.bundle.get("sectors.nonelaunch"));
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {116, 255, 9, 69, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00243()
      {
        Vars.ui.planet.showSelect(Vars.state.rules.sector, (Cons) new LaunchPad.LaunchPadBuild.__\u003C\u003EAnon3());
        this.deselect();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {117, 108, 154})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024buildConfiguration\u00242([In] Sector obj0)
      {
        if (!Vars.state.isCampaign())
          return;
        Vars.state.rules.sector.info.destination = obj0;
      }

      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LaunchPadBuild(LaunchPad _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(70)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Graphics.Cursor getCursor()
      {
        Graphics.Cursor cursor1 = !Vars.state.isCampaign() || Vars.net.client() ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow : base.getCursor();
        if (cursor1 == null)
          return (Graphics.Cursor) null;
        return cursor1 is Graphics.Cursor cursor2 ? cursor2 : throw new IncompatibleClassChangeError();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => true;

      [LineNumberTable(new byte[] {36, 134, 141, 117, 112, 127, 46, 98, 134, 105, 107, 126, 144, 119, 255, 38, 59, 43, 233, 74, 165, 159, 14, 152, 156, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (!Vars.state.isCampaign())
          return;
        if (this.this\u00240.lightRegion.found())
        {
          Draw.color(this.this\u00240.lightColor);
          float f = Math.min((float) this.items.total() / (float) this.this\u00240.itemCapacity, this.timer.getTime(this.this\u00240.__\u003C\u003EtimerLaunch) / (this.this\u00240.launchTime / this.timeScale));
          int num1 = 3;
          float num2 = 1f;
          for (int i = 0; i < 4; ++i)
          {
            for (int index = 0; index < num1; ++index)
            {
              float s = Mathf.curve(f, (float) index / (float) num1, ((float) index + 1f) / (float) num1);
              float num3 = -((float) index - 1f) * num2;
              Draw.color(Pal.metalGrayDark, this.this\u00240.lightColor, s);
              Draw.rect(this.this\u00240.lightRegion, this.x + (float) Geometry.d8edge(i).x * num3, this.y + (float) Geometry.d8edge(i).y * num3, (float) (i * 90));
            }
          }
          Draw.reset();
        }
        Draw.mixcol(this.this\u00240.lightColor, 1f - Mathf.clamp(this.timer.getTime(this.this\u00240.__\u003C\u003EtimerLaunch) / (90f / this.timeScale)));
        Draw.rect(this.this\u00240.podRegion, this.x, this.y);
        Draw.reset();
      }

      [LineNumberTable(120)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.total() < this.this\u00240.itemCapacity;

      [LineNumberTable(new byte[] {75, 173, 127, 54, 125, 102, 118, 103, 107, 108, 102, 107, 107, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!Vars.state.isCampaign() || this.items.total() < this.this\u00240.itemCapacity || ((double) this.efficiency() < 1.0 || !this.timer(this.this\u00240.__\u003C\u003EtimerLaunch, this.this\u00240.launchTime / this.timeScale)))
          return;
        this.this\u00240.launchSound.at(this.x, this.y);
        LaunchPayload launchPayload = LaunchPayload.create();
        this.items.each((ItemModule.ItemConsumer) new LaunchPad.LaunchPadBuild.__\u003C\u003EAnon0(launchPayload));
        launchPayload.set((Position) this);
        launchPayload.lifetime(120f);
        launchPayload.team(this.team);
        launchPayload.add();
        Fx.__\u003C\u003ElaunchPod.at((Position) this);
        this.items.clear();
        Effect.shake(3f, 3f, (Position) this);
      }

      [LineNumberTable(new byte[] {94, 135, 141, 103, 245, 70, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void display(Table table)
      {
        base.display(table);
        if (!Vars.state.isCampaign())
          return;
        table.row();
        table.label((Prov) new LaunchPad.LaunchPadBuild.__\u003C\u003EAnon1()).pad(4f).wrap().width(200f).left();
      }

      [LineNumberTable(new byte[] {110, 120, 102, 161, 255, 1, 71, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table)
      {
        if (!Vars.state.isCampaign() || Vars.net.client())
          this.deselect();
        else
          table.button((Drawable) Icon.upOpen, Styles.clearTransi, (Runnable) new LaunchPad.LaunchPadBuild.__\u003C\u003EAnon2(this)).size(40f);
      }

      [HideFromJava]
      static LaunchPadBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : ItemModule.ItemConsumer
      {
        private readonly LaunchPayload arg\u00241;

        internal __\u003C\u003EAnon0([In] LaunchPayload obj0) => this.arg\u00241 = obj0;

        public void accept([In] Item obj0, [In] int obj1) => LaunchPad.LaunchPadBuild.lambda\u0024updateTile\u00240(this.arg\u00241, obj0, obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Prov
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public object get() => (object) LaunchPad.LaunchPadBuild.lambda\u0024display\u00241().__\u003Cref\u003E;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly LaunchPad.LaunchPadBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] LaunchPad.LaunchPadBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00243();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public void get([In] object obj0) => LaunchPad.LaunchPadBuild.lambda\u0024buildConfiguration\u00242((Sector) obj0);
      }
    }

    [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Timedc", "mindustry.gen.Teamc"})]
    internal abstract class LaunchPayloadComp : 
      Object,
      Drawc,
      Posc,
      Position,
      Entityc,
      Timedc,
      Scaled,
      Teamc
    {
      internal float x;
      internal float y;
      [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
      internal Seq stacks;
      [NonSerialized]
      internal Interval @in;

      [HideFromJava]
      public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

      [LineNumberTable(224)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual float cx() => this.x + this.fin((Interp) Interp.pow2In) * (12f + Mathf.randomSeedRange((long) (this.id() + 3), 4f));

      [LineNumberTable(228)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual float cy() => this.y + this.fin((Interp) Interp.pow5In) * (100f + Mathf.randomSeedRange((long) (this.id() + 2), 30f));

      [HideFromJava]
      public abstract float fin();

      [HideFromJava]
      public abstract int id();

      [HideFromJava]
      public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

      [HideFromJava]
      public abstract Block blockOn();

      [HideFromJava]
      public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

      [HideFromJava]
      public abstract Team team();

      [LineNumberTable(new byte[] {160, 64, 168, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal LaunchPayloadComp()
      {
        LaunchPad.LaunchPayloadComp launchPayloadComp = this;
        this.stacks = new Seq();
        this.@in = new Interval();
      }

      [LineNumberTable(new byte[] {160, 72, 109, 119, 112, 159, 5, 138, 138, 144, 159, 43, 102, 104, 63, 14, 200, 133, 138, 127, 36, 159, 9, 102, 143, 159, 4, 106, 124, 159, 8, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void draw()
      {
        float num1 = this.fout((Interp) Interp.pow5Out);
        float num2 = (1f - num1) * 1.3f + 1f;
        float x = this.cx();
        float y = this.cy();
        float rotation = this.fin() * (130f + Mathf.randomSeedRange((long) this.id(), 50f));
        Draw.z(110.001f);
        Draw.color(Pal.engine);
        float num3 = 0.2f + this.fslope();
        Fill.light(x, y, 10, 25f * (num3 + num2 - 1f), Tmp.__\u003C\u003Ec2.set(Pal.engine).a(num1), Tmp.__\u003C\u003Ec1.set(Pal.engine).a(0.0f));
        Draw.alpha(num1);
        for (int index = 0; index < 4; ++index)
          Drawf.tri(x, y, 6f, 40f * (num3 + num2 - 1f), (float) index * 90f + rotation);
        Draw.color();
        Draw.z(129f);
        Block block = this.blockOn();
        LaunchPad launchPad;
        TextureRegion region = !(block is LaunchPad) || !object.ReferenceEquals((object) (launchPad = (LaunchPad) block), (object) (LaunchPad) block) ? (TextureRegion) Core.atlas.find("launchpod") : launchPad.podRegion;
        float w = (float) region.width * Draw.scl * num2;
        float h = (float) region.height * Draw.scl * num2;
        Draw.alpha(num1);
        Draw.rect(region, x, y, w, h, rotation);
        Tmp.__\u003C\u003Ev1.trns(225f, this.fin((Interp) Interp.pow3In) * 250f);
        Draw.z(116f);
        Draw.color(0.0f, 0.0f, 0.0f, 0.22f * num1);
        Draw.rect(region, x + Tmp.__\u003C\u003Ev1.x, y + Tmp.__\u003C\u003Ev1.y, w, h, rotation);
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 119, 102, 127, 3, 159, 18})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        float range = 3f;
        if (!this.@in.get(4f - this.fin() * 2f))
          return;
        Fx.__\u003C\u003ErocketSmoke.at(this.cx() + Mathf.range(range), this.cy() + Mathf.range(range), this.fin());
      }

      [LineNumberTable(new byte[] {160, 127, 141, 186, 127, 0, 127, 13, 134, 127, 1, 167, 122, 107, 130, 108, 199})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (!Vars.state.isCampaign())
          return;
        Sector realDestination = Vars.state.rules.sector.info.getRealDestination();
        if (!object.ReferenceEquals((object) this.team(), (object) Vars.state.rules.defaultTeam) || realDestination == null || object.ReferenceEquals((object) realDestination, (object) Vars.state.rules.sector) && !Vars.net.client())
          return;
        ItemSeq items = new ItemSeq();
        Iterator iterator = this.stacks.iterator();
        while (iterator.hasNext())
        {
          ItemStack stack = (ItemStack) iterator.next();
          items.add(stack);
          Vars.state.rules.sector.info.handleItemExport(stack);
          Events.fire((object) new EventType.LaunchItemEvent(stack));
        }
        if (Vars.net.client())
          return;
        realDestination.addItems(items);
      }

      [HideFromJava]
      public abstract float getX();

      [HideFromJava]
      public abstract float getY();

      [HideFromJava]
      public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

      [HideFromJava]
      public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

      [HideFromJava]
      public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

      [HideFromJava]
      public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

      [HideFromJava]
      public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

      [HideFromJava]
      public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

      [HideFromJava]
      public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

      [HideFromJava]
      public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

      [HideFromJava]
      public abstract bool isAdded();

      [HideFromJava]
      public abstract void add();

      [HideFromJava]
      public abstract bool isLocal();

      [HideFromJava]
      public abstract bool isRemote();

      [HideFromJava]
      public abstract bool isNull();

      [HideFromJava]
      public abstract Entityc self();

      [HideFromJava]
      public abstract object @as();

      [HideFromJava]
      public abstract object with([In] Cons obj0);

      [HideFromJava]
      public abstract int classId();

      [HideFromJava]
      public abstract bool serialize();

      [HideFromJava]
      public abstract void read([In] Reads obj0);

      [HideFromJava]
      public abstract void write([In] Writes obj0);

      [HideFromJava]
      public abstract void afterRead();

      [HideFromJava]
      public abstract void id([In] int obj0);

      [HideFromJava]
      public abstract void set([In] float obj0, [In] float obj1);

      [HideFromJava]
      public abstract void set([In] Position obj0);

      [HideFromJava]
      public abstract void trns([In] float obj0, [In] float obj1);

      [HideFromJava]
      public abstract void trns([In] Position obj0);

      [HideFromJava]
      public abstract int tileX();

      [HideFromJava]
      public abstract int tileY();

      [HideFromJava]
      public abstract Floor floorOn();

      [HideFromJava]
      public abstract bool onSolid();

      [HideFromJava]
      public abstract Tile tileOn();

      [HideFromJava]
      public abstract float x();

      [HideFromJava]
      public abstract void x([In] float obj0);

      [HideFromJava]
      public abstract float y();

      [HideFromJava]
      public abstract void y([In] float obj0);

      [HideFromJava]
      public abstract float clipSize();

      [HideFromJava]
      public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

      [HideFromJava]
      public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

      [HideFromJava]
      public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

      [HideFromJava]
      public abstract float time();

      [HideFromJava]
      public abstract void time([In] float obj0);

      [HideFromJava]
      public abstract float lifetime();

      [HideFromJava]
      public abstract void lifetime([In] float obj0);

      [HideFromJava]
      public abstract bool cheating();

      [HideFromJava]
      public abstract Building core();

      [HideFromJava]
      public abstract Building closestCore();

      [HideFromJava]
      public abstract Building closestEnemyCore();

      [HideFromJava]
      public abstract void team([In] Team obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly LaunchPad arg\u00241;

      internal __\u003C\u003EAnon0([In] LaunchPad obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00243((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon1([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) LaunchPad.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) LaunchPad.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly LaunchPad arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon3([In] LaunchPad obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00242(this.arg\u00242);
    }
  }
}
