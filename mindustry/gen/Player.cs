// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Player
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.ai.formations;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.graphics;
using mindustry.io;
using mindustry.net;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Syncc", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Timerc", "mindustry.gen.Entityc", "mindustry.gen.Playerc"})]
  public class Player : 
    Object,
    Syncc,
    Entityc,
    Drawc,
    Posc,
    Position,
    Timerc,
    Playerc,
    UnitController
  {
    public const float deathDelay = 60f;
    [NonSerialized]
    public long lastUpdated;
    [NonSerialized]
    public long updateSpacing;
    public float x;
    [NonSerialized]
    private float x_TARGET_;
    [NonSerialized]
    private float x_LAST_;
    public float y;
    [NonSerialized]
    private float y_TARGET_;
    [NonSerialized]
    private float y_LAST_;
    [NonSerialized]
    public Interval timer;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    protected internal Unit unit;
    [NonSerialized]
    public Unit lastReadUnit;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    public NetConnection con;
    protected internal Team team;
    public bool typing;
    public bool shooting;
    public bool boosting;
    public bool admin;
    public float mouseX;
    public float mouseY;
    public string name;
    public Color color;
    [NonSerialized]
    public string locale;
    [NonSerialized]
    public float deathTimer;
    [NonSerialized]
    public string lastText;
    [NonSerialized]
    public float textFadeTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.team;

    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild core() => this.team.core();

    [LineNumberTable(633)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dead() => this.unit.isNull() || !this.unit.isValid();

    [LineNumberTable(529)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBuilder() => this.unit.canBuild();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit unit() => this.unit;

    [LineNumberTable(new byte[] {160, 206, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(731)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Player create() => new Player();

    [LineNumberTable(new byte[] {161, 60, 106, 107, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.player.add((Entityc) this);
      Groups.sync.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.added = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(349)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild closestCore() => Vars.state.teams.closestCore(this.x, this.y, this.team);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void admin(bool admin) => this.admin = admin;

    [LineNumberTable(new byte[] {160, 191, 117, 114, 107, 118, 104, 123, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.team = Vars.state.rules.defaultTeam;
      Player player1 = this;
      int num1 = 0;
      int num2 = num1;
      this.typing = num1 != 0;
      this.admin = num2 != 0;
      this.textFadeTime = 0.0f;
      Player player2 = this;
      float num3 = 0.0f;
      double num4 = (double) num3;
      this.y = num3;
      this.x = (float) num4;
      if (this.dead())
        return;
      this.unit.controller(this.unit.type.createController());
      this.unit = Nulls.__\u003C\u003Eunit;
    }

    [LineNumberTable(629)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild bestCore() => (CoreBlock.CoreBuild) this.team.cores().min(Structs.comps(Structs.comparingInt((Intf) new Player.__\u003C\u003EAnon1()), Structs.comparingFloat((Floatf) new Player.__\u003C\u003EAnon2(this))));

    [LineNumberTable(new byte[] {161, 69, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team(Team team)
    {
      this.team = team;
      this.unit.team(team);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastText(string lastText) => this.lastText = lastText;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void textFadeTime(float textFadeTime) => this.textFadeTime = textFadeTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [LineNumberTable(new byte[] {161, 221, 104, 103, 179, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendMessage(string text)
    {
      if (this.isLocal())
      {
        if (Vars.ui == null)
          return;
        Vars.ui.chatfrag.addMessage(text, (string) null);
      }
      else
        Call.sendMessage(this.con, text, (string) null, (Player) null);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color color() => this.color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void name(string name) => this.name = name;

    [LineNumberTable(727)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string uuid() => this.con == null ? "[LOCAL]" : this.con.uuid;

    [LineNumberTable(new byte[] {160, 248, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Administration.PlayerInfo getInfo()
    {
      if (this.isLocal())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Local players cannot be traced and do not have info.");
      }
      return Vars.netServer.__\u003C\u003Eadmins.getInfo(this.uuid());
    }

    [LineNumberTable(new byte[] {161, 208, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(Packets.KickReason reason) => this.con.kick(reason);

    [LineNumberTable(new byte[] {161, 22, 105, 107, 107, 107, 139, 108, 208, 167, 109, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.player.remove((Entityc) this);
      Groups.sync.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      if (Vars.net.client())
        Vars.netClient.addRemovedEntity(this.id());
      this.added = false;
      if (this.unit.isNull())
        return;
      this.clearUnit();
    }

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [LineNumberTable(new byte[] {161, 180, 104, 103, 179, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendMessage(string text, Player from, string fromName)
    {
      if (this.isLocal())
      {
        if (Vars.ui == null)
          return;
        Vars.ui.chatfrag.addMessage(text, fromName);
      }
      else
        Call.sendMessage(this.con, text, fromName, from);
    }

    [LineNumberTable(new byte[] {161, 164, 103, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.s(0);
      write.@bool(this.admin);
      write.@bool(this.boosting);
      TypeIO.writeColor(write, this.color);
      write.f(this.mouseX);
      write.f(this.mouseY);
      TypeIO.writeString(write, this.name);
      write.@bool(this.shooting);
      TypeIO.writeTeam(write, this.team);
      write.@bool(this.typing);
      TypeIO.writeUnit(write, this.unit);
      write.f(this.x);
      write.f(this.y);
    }

    [LineNumberTable(670)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string usid() => this.con == null ? "[LOCAL]" : this.con.usid;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool admin() => this.admin;

    [LineNumberTable(new byte[] {162, 36, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearUnit() => this.unit(Nulls.__\u003C\u003Eunit);

    [LineNumberTable(new byte[] {161, 235, 115, 111, 114, 155, 103, 109, 108, 103, 104, 134, 111, 176, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unit(Unit unit)
    {
      if (unit == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Unit cannot be null. Use clearUnit() instead.");
      }
      if (object.ReferenceEquals((object) this.unit, (object) unit))
        return;
      if (!object.ReferenceEquals((object) this.unit, (object) Nulls.__\u003C\u003Eunit))
        this.unit.controller(this.unit.type.createController());
      this.unit = unit;
      if (!object.ReferenceEquals((object) unit, (object) Nulls.__\u003C\u003Eunit))
      {
        unit.team(this.team);
        unit.controller((UnitController) this);
        if (unit.isRemote())
          unit.snapInterpolation();
        if (!Vars.headless && this.isLocal())
          Vars.control.input.block = (Block) null;
      }
      Events.fire((object) new EventType.UnitChangeEvent(this, unit));
    }

    [LineNumberTable(new byte[] {160, 108, 232, 18, 204, 139, 171, 235, 69, 235, 84, 139, 139, 203, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Player()
    {
      Player player = this;
      this.timer = new Interval(6);
      this.id = EntityGroup.nextId();
      this.unit = Nulls.__\u003C\u003Eunit;
      this.lastReadUnit = Nulls.__\u003C\u003Eunit;
      this.team = Team.__\u003C\u003Esharded;
      this.name = "noname";
      this.color = new Color();
      this.locale = "en";
      this.lastText = "";
    }

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {161, 74, 116, 109, 118, 121, 121, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void interpolate()
    {
      if (this.lastUpdated != 0L && this.updateSpacing != 0L)
      {
        float progress = Math.min((float) Time.timeSinceMillis(this.lastUpdated) / (float) this.updateSpacing, 2f);
        this.x = Mathf.lerp(this.x_LAST_, this.x_TARGET_, progress);
        this.y = Mathf.lerp(this.y_LAST_, this.y_TARGET_, progress);
      }
      else
      {
        if (this.lastUpdated == 0L)
          return;
        this.x = this.x_TARGET_;
        this.y = this.y_TARGET_;
      }
    }

    [LineNumberTable(654)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {161, 255, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {161, 191, 103, 108, 103, 108, 119, 119, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterSync()
    {
      Unit unit = this.unit;
      this.unit = this.lastReadUnit;
      this.unit(unit);
      this.lastReadUnit = this.unit;
      this.unit.aim(this.mouseX, this.mouseY);
      this.unit.controlWeapons(this.shooting, this.shooting);
      Formation formation = this.unit.formation;
      this.unit.controller((UnitController) this);
      this.unit.formation = formation;
    }

    [Modifiers]
    [LineNumberTable(629)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024bestCore\u00240([In] CoreBlock.CoreBuild obj0) => -obj0.block.size;

    [Modifiers]
    [LineNumberTable(629)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024bestCore\u00241([In] CoreBlock.CoreBuild obj0) => obj0.dst(this.x, this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Player#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 125, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(string reason) => this.con.kick(reason);

    [LineNumberTable(243)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValidController() => this.isAdded();

    [LineNumberTable(new byte[] {160, 137, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(string reason, long duration) => this.con.kick(reason, duration);

    [LineNumberTable(new byte[] {160, 142, 124, 198, 109, 166, 107, 108, 113, 107, 117, 108, 127, 44, 98, 106, 115, 109, 103, 171, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Vars.net.client() && !this.isLocal() || this.isRemote())
        this.interpolate();
      if (!this.unit.isValid())
        this.clearUnit();
      if (!this.dead())
      {
        this.set((Position) this.unit);
        this.unit.team(this.team);
        this.deathTimer = 0.0f;
        if (this.unit.type.canBoost)
        {
          Tile tile = this.unit.tileOn();
          this.unit.elevation = Mathf.approachDelta(this.unit.elevation, tile != null && tile.solid() || this.boosting ? 1f : 0.0f, this.unit.type.riseSpeed);
        }
      }
      else
      {
        CoreBlock.CoreBuild coreBuild;
        if ((coreBuild = this.bestCore()) != null)
        {
          this.deathTimer += Time.delta;
          if ((double) this.deathTimer >= 60.0)
          {
            coreBuild.requestSpawn(this);
            this.deathTimer = 0.0f;
          }
        }
      }
      this.textFadeTime -= Time.delta / 300f;
    }

    [LineNumberTable(new byte[] {160, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {160, 176, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSync(Writes write)
    {
      write.@bool(this.admin);
      write.@bool(this.boosting);
      TypeIO.writeColor(write, this.color);
      write.f(this.mouseX);
      write.f(this.mouseY);
      TypeIO.writeString(write, this.name);
      write.@bool(this.shooting);
      TypeIO.writeTeam(write, this.team);
      write.@bool(this.typing);
      TypeIO.writeUnit(write, this.unit);
      write.f(this.x);
      write.f(this.y);
    }

    [LineNumberTable(new byte[] {160, 214, 103, 102, 108, 108, 114, 109, 109, 108, 108, 108, 108, 108, 109, 143, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      int num = (int) read.s();
      if (num == 0)
      {
        this.admin = read.@bool();
        this.boosting = read.@bool();
        this.color = TypeIO.readColor(read, this.color);
        this.mouseX = read.f();
        this.mouseY = read.f();
        this.name = TypeIO.readString(read);
        this.shooting = read.@bool();
        this.team = TypeIO.readTeam(read);
        this.typing = read.@bool();
        this.unit = TypeIO.readUnit(read);
        this.x = read.f();
        this.y = read.f();
        this.afterRead();
      }
      else
      {
        string str = new StringBuilder().append("Unknown revision '").append(num).append("' for entity type 'PlayerComp'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {161, 0, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(new byte[] {161, 5, 123, 107, 108, 109, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readSyncManual(FloatBuffer buffer)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x;
      this.x_TARGET_ = buffer.get();
      this.y_LAST_ = this.y;
      this.y_TARGET_ = buffer.get();
    }

    [LineNumberTable(new byte[] {161, 14, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendMessage(string text, Player from) => this.sendMessage(text, from, NetClient.colorizeName(from.id(), from.name));

    [LineNumberTable(388)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(413)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool displayAmmo() => this.unit is BlockUnitc || Vars.state.rules.unitAmmo;

    [LineNumberTable(417)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => this.unit.isNull() ? 20f : this.unit.type.hitSize * 2f;

    [LineNumberTable(new byte[] {161, 51, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 55, 127, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon()
    {
      if (!this.dead())
        return this.unit.icon();
      return this.core() == null ? UnitTypes.alpha.icon(Cicon.__\u003C\u003Efull) : ((CoreBlock) this.core().block).unitType.icon(Cicon.__\u003C\u003Efull);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [LineNumberTable(new byte[] {161, 91, 106, 103, 102, 122, 102, 102, 103, 103, 125, 127, 0, 107, 121, 127, 44, 101, 108, 127, 56, 107, 103, 127, 33, 127, 53, 107, 191, 53, 127, 21, 127, 46, 103, 127, 2, 127, 20, 127, 21, 127, 26, 127, 52, 159, 68, 101, 102, 112, 107, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(150f);
      float z = Drawf.text();
      Font def = Fonts.def;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new Player.__\u003C\u003EAnon0());
      int num1 = def.usesIntegerPositions() ? 1 : 0;
      def.setUseIntegerPositions(false);
      def.getData().setScale(0.25f / Scl.scl(1f));
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font font1 = def;
      object name1 = (object) this.name;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) name1;
      CharSequence str1 = charSequence;
      glyphLayout2.setText(font1, str1);
      if (!this.isLocal())
      {
        Draw.color(0.0f, 0.0f, 0.0f, 0.3f);
        Fill.rect(this.unit.x, this.unit.y + 11f - glyphLayout1.height / 2f, glyphLayout1.width + 2f, glyphLayout1.height + 3f);
        Draw.color();
        def.setColor(this.color);
        Font font2 = def;
        string name2 = this.name;
        double x = (double) this.unit.x;
        double num2 = (double) (this.unit.y + 11f);
        bool flag = false;
        int num3 = 1;
        float num4 = 0.0f;
        float num5 = (float) num2;
        float num6 = (float) x;
        object obj = (object) name2;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str2 = charSequence;
        double num7 = (double) num6;
        double num8 = (double) num5;
        double num9 = (double) num4;
        int halign = num3;
        int num10 = flag ? 1 : 0;
        font2.draw(str2, (float) num7, (float) num8, (float) num9, halign, num10 != 0);
        if (this.admin)
        {
          float num11 = 3f;
          Draw.color(this.color.r * 0.5f, this.color.g * 0.5f, this.color.b * 0.5f, 1f);
          Draw.rect(Icon.adminSmall.getRegion(), this.unit.x + glyphLayout1.width / 2f + 2f + 1f, this.unit.y + 11f - 1.5f, num11, num11);
          Draw.color(this.color);
          Draw.rect(Icon.adminSmall.getRegion(), this.unit.x + glyphLayout1.width / 2f + 2f + 1f, this.unit.y + 11f - 1f, num11, num11);
        }
      }
      if (Core.settings.getBool("playerchat") && ((double) this.textFadeTime > 0.0 && this.lastText != null || this.typing))
      {
        string str2 = (double) this.textFadeTime <= 0.0 || this.lastText == null ? new StringBuilder().append("[lightgray]").append(Strings.animated(Time.time, 4, 15f, ".")).toString() : this.lastText;
        float num2 = 100f;
        float num3 = 1f - Mathf.curve(1f - this.textFadeTime, 0.9f);
        def.setColor(1f, 1f, 1f, (double) this.textFadeTime <= 0.0 || this.lastText == null ? 1f : num3);
        GlyphLayout glyphLayout3 = glyphLayout1;
        Font font2 = def;
        string str3 = str2;
        Color white = Color.__\u003C\u003Ewhite;
        double num4 = (double) num2;
        bool flag1 = true;
        int num5 = 4;
        float num6 = (float) num4;
        Color color1 = white;
        object obj1 = (object) str3;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence str4 = charSequence;
        Color color2 = color1;
        double num7 = (double) num6;
        int halign1 = num5;
        int num8 = flag1 ? 1 : 0;
        glyphLayout3.setText(font2, str4, color2, (float) num7, halign1, num8 != 0);
        Draw.color(0.0f, 0.0f, 0.0f, (float) (0.300000011920929 * ((double) this.textFadeTime <= 0.0 || this.lastText == null ? 1.0 : (double) num3)));
        Fill.rect(this.unit.x, this.unit.y + 15f + glyphLayout1.height - glyphLayout1.height / 2f, glyphLayout1.width + 2f, glyphLayout1.height + 3f);
        Font font3 = def;
        string str5 = str2;
        double num9 = (double) (this.unit.x - num2 / 2f);
        double num10 = (double) (this.unit.y + 15f + glyphLayout1.height);
        double num11 = (double) num2;
        bool flag2 = true;
        int num12 = 1;
        float num13 = (float) num11;
        float num14 = (float) num10;
        float num15 = (float) num9;
        object obj2 = (object) str5;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence str6 = charSequence;
        double num16 = (double) num15;
        double num17 = (double) num14;
        double num18 = (double) num13;
        int halign2 = num12;
        int num19 = flag2 ? 1 : 0;
        font3.draw(str6, (float) num16, (float) num17, (float) num18, halign2, num19 != 0);
      }
      Draw.reset();
      Pools.free((object) glyphLayout1);
      def.getData().setScale(1f);
      def.setColor(Color.__\u003C\u003Ewhite);
      def.setUseIntegerPositions(num1 != 0);
      Draw.z(z);
    }

    [LineNumberTable(new byte[] {161, 135, 105, 107, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void snapSync()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x_TARGET_;
      this.x = this.x_TARGET_;
      this.y_LAST_ = this.y_TARGET_;
      this.y = this.y_TARGET_;
    }

    [LineNumberTable(new byte[] {161, 144, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSyncManual(FloatBuffer buffer)
    {
      buffer.put(this.x);
      buffer.put(this.y);
    }

    [LineNumberTable(new byte[] {161, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {161, 154, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(new byte[] {161, 212, 105, 107, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void snapInterpolation()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.x_LAST_ = this.x;
      this.x_TARGET_ = this.x;
      this.y_LAST_ = this.y;
      this.y_TARGET_ = this.y;
    }

    [LineNumberTable(637)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string ip() => this.con == null ? "localhost" : this.con.__\u003C\u003Eaddress;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(645)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(new byte[] {162, 23, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool timer(int index, float time) => !Float.isInfinite(time) && this.timer.get(index, time);

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {162, 48, 123, 107, 103, 108, 99, 142, 135, 114, 99, 143, 136, 99, 143, 136, 108, 99, 142, 135, 108, 99, 142, 135, 108, 99, 108, 143, 104, 108, 140, 99, 108, 143, 104, 108, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readSync(Reads read)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      int num1 = this.isLocal() ? 1 : 0;
      this.admin = read.@bool();
      if (num1 == 0)
        this.boosting = read.@bool();
      else
        read.@bool();
      this.color = TypeIO.readColor(read, this.color);
      if (num1 == 0)
      {
        this.mouseX = read.f();
      }
      else
      {
        double num2 = (double) read.f();
      }
      if (num1 == 0)
      {
        this.mouseY = read.f();
      }
      else
      {
        double num3 = (double) read.f();
      }
      this.name = TypeIO.readString(read);
      if (num1 == 0)
        this.shooting = read.@bool();
      else
        read.@bool();
      this.team = TypeIO.readTeam(read);
      if (num1 == 0)
        this.typing = read.@bool();
      else
        read.@bool();
      this.unit = TypeIO.readUnit(read);
      if (num1 == 0)
      {
        this.x_LAST_ = this.x;
        this.x_TARGET_ = read.f();
      }
      else
      {
        double num4 = (double) read.f();
        this.x_LAST_ = this.x;
        this.x_TARGET_ = this.x;
      }
      if (num1 == 0)
      {
        this.y_LAST_ = this.y;
        this.y_TARGET_ = read.f();
      }
      else
      {
        double num4 = (double) read.f();
        this.y_LAST_ = this.y;
        this.y_TARGET_ = this.y;
      }
      this.afterSync();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 12;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long lastUpdated() => this.lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastUpdated(long lastUpdated) => this.lastUpdated = lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long updateSpacing() => this.updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSpacing(long updateSpacing) => this.updateSpacing = updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interval timer() => this.timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void timer(Interval timer) => this.timer = timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NetConnection con() => this.con;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void con(NetConnection con) => this.con = con;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool typing() => this.typing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void typing(bool typing) => this.typing = typing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shooting() => this.shooting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shooting(bool shooting) => this.shooting = shooting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool boosting() => this.boosting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void boosting(bool boosting) => this.boosting = boosting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mouseX() => this.mouseX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mouseX(float mouseX) => this.mouseX = mouseX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mouseY() => this.mouseY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mouseY(float mouseY) => this.mouseY = mouseY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name() => this.name;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(Color color) => this.color = color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string locale() => this.locale;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void locale(string locale) => this.locale = locale;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float deathTimer() => this.deathTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deathTimer(float deathTimer) => this.deathTimer = deathTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string lastText() => this.lastText;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float textFadeTime() => this.textFadeTime;

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
    public virtual void command([In] UnitCommand obj0) => UnitController.\u003Cdefault\u003Ecommand((UnitController) this, obj0);

    [HideFromJava]
    public virtual void updateUnit() => UnitController.\u003Cdefault\u003EupdateUnit((UnitController) this);

    [HideFromJava]
    public virtual void removed([In] Unit obj0) => UnitController.\u003Cdefault\u003Eremoved((UnitController) this, obj0);

    [HideFromJava]
    public virtual bool isBeingControlled([In] Unit obj0) => UnitController.\u003Cdefault\u003EisBeingControlled((UnitController) this, obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new GlyphLayout();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public int get([In] object obj0) => Player.lambda\u0024bestCore\u00240((CoreBlock.CoreBuild) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatf
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon2([In] Player obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024bestCore\u00241((CoreBlock.CoreBuild) obj0);
    }
  }
}
