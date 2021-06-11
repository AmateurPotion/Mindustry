// Decompiled with JetBrains decompiler
// Type: mindustry.gen.LaunchPayload
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.game;
using mindustry.graphics;
using mindustry.io;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.campaign;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.LaunchPayloadc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public class LaunchPayload : 
    Object,
    Drawc,
    Posc,
    Position,
    Entityc,
    Teamc,
    LaunchPayloadc,
    Timedc,
    Scaled
  {
    public float x;
    public float y;
    public Team team;
    [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    public Seq stacks;
    [NonSerialized]
    public Interval @in;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public float time;
    public float lifetime;

    [LineNumberTable(new byte[] {118, 232, 50, 139, 139, 203, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal LaunchPayload()
    {
      LaunchPayload launchPayload = this;
      this.team = Team.__\u003C\u003Ederelict;
      this.stacks = new Seq();
      this.@in = new Interval();
      this.id = EntityGroup.nextId();
    }

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [LineNumberTable(384)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float cx() => this.x + this.fin((Interp) Interp.pow2In) * (12f + Mathf.randomSeedRange((long) (this.id() + 3), 4f));

    [LineNumberTable(388)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float cy() => this.y + this.fin((Interp) Interp.pow5In) * (100f + Mathf.randomSeedRange((long) (this.id() + 2), 30f));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [LineNumberTable(new byte[] {160, 163, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [LineNumberTable(new byte[] {160, 132, 105, 107, 139, 113, 122, 127, 0, 127, 13, 102, 127, 1, 103, 122, 107, 98, 108, 231, 70, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      if (Vars.state.isCampaign())
      {
        Sector realDestination = Vars.state.rules.sector.info.getRealDestination();
        if (object.ReferenceEquals((object) this.team(), (object) Vars.state.rules.defaultTeam) && realDestination != null && (!object.ReferenceEquals((object) realDestination, (object) Vars.state.rules.sector) || Vars.net.client()))
        {
          ItemSeq items = new ItemSeq();
          Iterator iterator = this.stacks.iterator();
          while (iterator.hasNext())
          {
            ItemStack stack = (ItemStack) iterator.next();
            items.add(stack);
            Vars.state.rules.sector.info.handleItemExport(stack);
            Events.fire((object) new EventType.LaunchItemEvent(stack));
          }
          if (!Vars.net.client())
            realDestination.addItems(items);
        }
      }
      this.added = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.team;

    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(406)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {160, 221, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => true;

    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("LaunchPayload#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 76, 109, 119, 104, 104, 127, 5, 106, 106, 112, 127, 43, 102, 104, 63, 14, 168, 101, 106, 127, 36, 116, 116, 102, 111, 127, 4, 106, 124, 127, 8, 133})]
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

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 114, 102, 127, 3, 223, 18, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      float range = 3f;
      if (this.@in.get(4f - this.fin() * 2f))
        Fx.__\u003C\u003ErocketSmoke.at(this.cx() + Mathf.range(range), this.cy() + Mathf.range(range), this.fin());
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 158, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 176, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {160, 183, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 193, 103, 102, 109, 103, 108, 102, 103, 15, 198, 108, 109, 109, 109, 98, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      int num1 = (int) read.s();
      if (num1 == 0)
      {
        this.lifetime = read.f();
        int num2 = read.i();
        this.stacks.clear();
        for (int index = 0; index < num2; ++index)
        {
          ItemStack itemStack = TypeIO.readItems(read);
          if (itemStack != null)
            this.stacks.add((object) itemStack);
        }
        this.team = TypeIO.readTeam(read);
        this.time = read.f();
        this.x = read.f();
        this.y = read.f();
        this.afterRead();
      }
      else
      {
        string str = new StringBuilder().append("Unknown revision '").append(num1).append("' for entity type 'LaunchPayloadComp'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(327)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestCore() => (Building) Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building core() => (Building) this.team.core();

    [LineNumberTable(new byte[] {160, 230, 106, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.added = true;
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 237, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(356)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(368)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestEnemyCore() => (Building) Vars.state.teams.closestEnemyCore(this.x, this.y, this.team);

    [LineNumberTable(372)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool cheating() => this.team.rules().cheat;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => float.MaxValue;

    [LineNumberTable(new byte[] {161, 10, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 23, 103, 108, 113, 112, 55, 166, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.s(0);
      write.f(this.lifetime);
      write.i(this.stacks.size);
      for (int index = 0; index < this.stacks.size; ++index)
        TypeIO.writeItems(write, (ItemStack) this.stacks.get(index));
      TypeIO.writeTeam(write, this.team);
      write.f(this.time);
      write.f(this.x);
      write.f(this.y);
    }

    [LineNumberTable(410)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LaunchPayload create() => new LaunchPayload();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 15;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team(Team team) => this.team = team;

    [Signature("()Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq stacks() => this.stacks;

    [Signature("(Larc/struct/Seq<Lmindustry/type/ItemStack;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stacks(Seq stacks) => this.stacks = stacks;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interval @in() => this.@in;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void @in(Interval @in) => this.@in = @in;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float time() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void time(float time) => this.time = time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lifetime() => this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lifetime(float lifetime) => this.lifetime = lifetime;

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
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);
  }
}
