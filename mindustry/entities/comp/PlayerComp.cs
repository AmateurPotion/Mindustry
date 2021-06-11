// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.PlayerComp
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
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.net;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.entities.units.UnitController", "mindustry.gen.Entityc", "mindustry.gen.Syncc", "mindustry.gen.Timerc", "mindustry.gen.Drawc"})]
  internal abstract class PlayerComp : 
    Object,
    UnitController,
    Entityc,
    Syncc,
    Timerc,
    Drawc,
    Posc,
    Position
  {
    internal const float deathDelay = 60f;
    internal float x;
    internal float y;
    internal Unit unit;
    [NonSerialized]
    private Unit lastReadUnit;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    internal NetConnection con;
    internal Team team;
    internal bool typing;
    internal bool shooting;
    internal bool boosting;
    internal bool admin;
    internal float mouseX;
    internal float mouseY;
    internal string name;
    internal Color color;
    [NonSerialized]
    internal string locale;
    [NonSerialized]
    internal float deathTimer;
    [NonSerialized]
    internal string lastText;
    [NonSerialized]
    internal float textFadeTime;

    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool dead() => this.unit.isNull() || !this.unit.isValid();

    [LineNumberTable(61)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild core() => this.team.core();

    [HideFromJava]
    public abstract bool isAdded();

    [LineNumberTable(new byte[] {126, 115, 143, 146, 155, 103, 109, 108, 167, 104, 198, 111, 208, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unit([In] Unit obj0)
    {
      if (obj0 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Unit cannot be null. Use clearUnit() instead.");
      }
      if (object.ReferenceEquals((object) this.unit, (object) obj0))
        return;
      if (!object.ReferenceEquals((object) this.unit, (object) Nulls.__\u003C\u003Eunit))
        this.unit.controller(this.unit.type.createController());
      this.unit = obj0;
      if (!object.ReferenceEquals((object) obj0, (object) Nulls.__\u003C\u003Eunit))
      {
        obj0.team(this.team);
        obj0.controller((UnitController) this);
        if (obj0.isRemote())
          obj0.snapInterpolation();
        if (!Vars.headless && this.isLocal())
          Vars.control.input.block = (Block) null;
      }
      Events.fire((object) new EventType.UnitChangeEvent((Player) this.self(), obj0));
    }

    [LineNumberTable(new byte[] {118, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearUnit() => this.unit(Nulls.__\u003C\u003Eunit);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [LineNumberTable(67)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild bestCore() => (CoreBlock.CoreBuild) this.team.cores().min(Structs.comps(Structs.comparingInt((Intf) new PlayerComp.__\u003C\u003EAnon0()), Structs.comparingFloat((Floatf) new PlayerComp.__\u003C\u003EAnon1(this))));

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public abstract bool isLocal();

    [LineNumberTable(new byte[] {160, 184, 104, 103, 179, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sendMessage([In] string obj0, [In] Player obj1, [In] string obj2)
    {
      if (this.isLocal())
      {
        if (Vars.ui == null)
          return;
        Vars.ui.chatfrag.addMessage(obj0, obj2);
      }
      else
        Call.sendMessage(this.con, obj0, obj2, obj1);
    }

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string uuid() => this.con == null ? "[LOCAL]" : this.con.uuid;

    [Modifiers]
    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024bestCore\u00240([In] CoreBlock.CoreBuild obj0) => -obj0.block.size;

    [Modifiers]
    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024bestCore\u00241([In] CoreBlock.CoreBuild obj0) => obj0.dst(this.x, this.y);

    [LineNumberTable(new byte[] {159, 172, 232, 69, 107, 171, 203, 107, 171, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal PlayerComp()
    {
      PlayerComp playerComp = this;
      this.unit = Nulls.__\u003C\u003Eunit;
      this.lastReadUnit = Nulls.__\u003C\u003Eunit;
      this.team = Team.__\u003C\u003Esharded;
      this.name = "noname";
      this.color = new Color();
      this.locale = "en";
      this.lastText = "";
    }

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBuilder() => this.unit.canBuild();

    [LineNumberTable(57)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild closestCore() => Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(new byte[] {22, 159, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon()
    {
      if (!this.dead())
        return this.unit.icon();
      return this.core() == null ? UnitTypes.alpha.icon(Cicon.__\u003C\u003Efull) : ((CoreBlock) this.core().block).unitType.icon(Cicon.__\u003C\u003Efull);
    }

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool displayAmmo() => this.unit is BlockUnitc || Vars.state.rules.unitAmmo;

    [LineNumberTable(new byte[] {32, 117, 114, 107, 118, 104, 123, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.team = Vars.state.rules.defaultTeam;
      PlayerComp playerComp1 = this;
      int num1 = 0;
      int num2 = num1;
      this.typing = num1 != 0;
      this.admin = num2 != 0;
      this.textFadeTime = 0.0f;
      PlayerComp playerComp2 = this;
      float num3 = 0.0f;
      double num4 = (double) num3;
      this.y = num3;
      this.x = (float) num4;
      if (this.dead())
        return;
      this.unit.controller(this.unit.type.createController());
      this.unit = Nulls.__\u003C\u003Eunit;
    }

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValidController() => this.isAdded();

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => this.unit.isNull() ? 20f : this.unit.type.hitSize * 2f;

    [LineNumberTable(new byte[] {55, 103, 108, 103, 140, 151, 151, 140, 140, 108})]
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

    [LineNumberTable(new byte[] {73, 109, 230, 69, 107, 108, 113, 171, 117, 108, 127, 44, 98, 170, 115, 141, 113, 203, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
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
            coreBuild.requestSpawn((Player) this.self());
            this.deathTimer = 0.0f;
          }
        }
      }
      this.textFadeTime -= Time.delta / 300f;
    }

    [LineNumberTable(new byte[] {107, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (this.unit.isNull())
        return;
      this.clearUnit();
    }

    [LineNumberTable(new byte[] {113, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team([In] Team obj0)
    {
      this.team = obj0;
      this.unit.team(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit unit() => this.unit;

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string ip() => this.con == null ? "localhost" : this.con.__\u003C\u003Eaddress;

    [LineNumberTable(215)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string usid() => this.con == null ? "[LOCAL]" : this.con.usid;

    [LineNumberTable(new byte[] {160, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void kick([In] Packets.KickReason obj0) => this.con.kick(obj0);

    [LineNumberTable(new byte[] {160, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void kick([In] string obj0) => this.con.kick(obj0);

    [LineNumberTable(new byte[] {160, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void kick([In] string obj0, [In] long obj1) => this.con.kick(obj0, obj1);

    [LineNumberTable(new byte[] {160, 118, 106, 135, 102, 122, 102, 134, 103, 103, 125, 159, 0, 107, 121, 127, 44, 101, 108, 159, 56, 107, 103, 127, 33, 127, 53, 107, 223, 53, 127, 21, 127, 46, 103, 127, 2, 159, 20, 159, 21, 127, 26, 127, 52, 191, 68, 101, 102, 112, 107, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(150f);
      float z = Drawf.text();
      Font def = Fonts.def;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new PlayerComp.__\u003C\u003EAnon2());
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

    [LineNumberTable(new byte[] {160, 170, 104, 103, 179, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sendMessage([In] string obj0)
    {
      if (this.isLocal())
      {
        if (Vars.ui == null)
          return;
        Vars.ui.chatfrag.addMessage(obj0, (string) null);
      }
      else
        Call.sendMessage(this.con, obj0, (string) null, (Player) null);
    }

    [LineNumberTable(new byte[] {160, 180, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sendMessage([In] string obj0, [In] Player obj1) => this.sendMessage(obj0, obj1, NetClient.colorizeName(obj1.id(), obj1.name));

    [LineNumberTable(new byte[] {160, 194, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Administration.PlayerInfo getInfo()
    {
      if (this.isLocal())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Local players cannot be traced and do not have info.");
      }
      return Vars.netServer.__\u003C\u003Eadmins.getInfo(this.uuid());
    }

    [HideFromJava]
    public virtual void command([In] UnitCommand obj0) => UnitController.\u003Cdefault\u003Ecommand((UnitController) this, obj0);

    [HideFromJava]
    public virtual void updateUnit() => UnitController.\u003Cdefault\u003EupdateUnit((UnitController) this);

    [HideFromJava]
    public virtual void removed([In] Unit obj0) => UnitController.\u003Cdefault\u003Eremoved((UnitController) this, obj0);

    [HideFromJava]
    public virtual bool isBeingControlled([In] Unit obj0) => UnitController.\u003Cdefault\u003EisBeingControlled((UnitController) this, obj0);

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

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
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void snapSync();

    [HideFromJava]
    public abstract void snapInterpolation();

    [HideFromJava]
    public abstract void readSync([In] Reads obj0);

    [HideFromJava]
    public abstract void writeSync([In] Writes obj0);

    [HideFromJava]
    public abstract void readSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void writeSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void interpolate();

    [HideFromJava]
    public abstract long lastUpdated();

    [HideFromJava]
    public abstract void lastUpdated([In] long obj0);

    [HideFromJava]
    public abstract long updateSpacing();

    [HideFromJava]
    public abstract void updateSpacing([In] long obj0);

    [HideFromJava]
    public abstract bool timer([In] int obj0, [In] float obj1);

    [HideFromJava]
    public abstract Interval timer();

    [HideFromJava]
    public abstract void timer([In] Interval obj0);

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
    public abstract void set([In] float obj0, [In] float obj1);

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
    public abstract Block blockOn();

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

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public int get([In] object obj0) => PlayerComp.lambda\u0024bestCore\u00240((CoreBlock.CoreBuild) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatf
    {
      private readonly PlayerComp arg\u00241;

      internal __\u003C\u003EAnon1([In] PlayerComp obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024bestCore\u00241((CoreBlock.CoreBuild) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
