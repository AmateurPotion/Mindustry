// Decompiled with JetBrains decompiler
// Type: mindustry.gen.WeatherState
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.io;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.WeatherStatec", "mindustry.gen.Syncc", "mindustry.gen.Entityc"})]
  public class WeatherState : 
    Object,
    Pool.Poolable,
    Drawc,
    Posc,
    Position,
    Entityc,
    WeatherStatec,
    Syncc
  {
    public const float fadeTime = 240f;
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
    public Weather weather;
    public float intensity;
    public float opacity;
    public float life;
    public float effectTimer;
    public Vec2 windVector;
    [NonSerialized]
    public long lastUpdated;
    [NonSerialized]
    public long updateSpacing;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void intensity(float intensity) => this.intensity = intensity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init(Weather weather) => this.weather = weather;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void life(float life) => this.life = life;

    [LineNumberTable(new byte[] {161, 21, 106, 107, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.sync.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      Groups.weather.add((Entityc) this);
      this.added = true;
    }

    [LineNumberTable(new byte[] {161, 54, 105, 107, 107, 107, 139, 108, 208, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.sync.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      Groups.weather.remove((Entityc) this);
      if (Vars.net.client())
        Vars.netClient.addRemovedEntity(this.id());
      this.added = false;
      Groups.queueFree((Pool.Poolable) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Weather weather() => this.weather;

    [LineNumberTable(504)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static WeatherState create() => (WeatherState) Pools.obtain((Class) ClassLiteral<WeatherState>.Value, (Prov) new WeatherState.__\u003C\u003EAnon2());

    [LineNumberTable(new byte[] {160, 72, 232, 46, 139, 235, 70, 240, 72, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal WeatherState()
    {
      WeatherState weatherState = this;
      this.intensity = 1f;
      this.opacity = 0.0f;
      this.windVector = new Vec2().setToRandomDirection();
      this.id = EntityGroup.nextId();
    }

    [LineNumberTable(486)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterSync()
    {
    }

    [LineNumberTable(309)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {161, 30, 116, 109, 118, 121, 121, 108, 108, 140})]
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

    [LineNumberTable(420)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [LineNumberTable(new byte[] {161, 12, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 82, 114, 127, 6, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00240()
    {
      this.weather.rand.setSeed(0L);
      Draw.alpha(Vars.renderer.weatherAlpha() * this.opacity * this.weather.opacityMultiplier);
      this.weather.drawOver(this);
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 88, 114, 127, 6, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00241()
    {
      this.weather.rand.setSeed(0L);
      Draw.alpha(Vars.renderer.weatherAlpha() * this.opacity * this.weather.opacityMultiplier);
      this.weather.drawUnder(this);
      Draw.reset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => true;

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("WeatherState#").append(this.id).toString();

    [LineNumberTable(new byte[] {160, 85, 123, 107, 103, 109, 109, 109, 109, 127, 1, 114, 99, 108, 143, 104, 108, 140, 99, 108, 143, 104, 108, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readSync(Reads read)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      int num1 = this.isLocal() ? 1 : 0;
      this.effectTimer = read.f();
      this.intensity = read.f();
      this.life = read.f();
      this.opacity = read.f();
      this.weather = (Weather) Vars.content.getByID(ContentType.__\u003C\u003Eweather, (int) read.s());
      this.windVector = TypeIO.readVec2(read, this.windVector);
      if (num1 == 0)
      {
        this.x_LAST_ = this.x;
        this.x_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
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
        double num2 = (double) read.f();
        this.y_LAST_ = this.y;
        this.y_TARGET_ = this.y;
      }
      this.afterSync();
    }

    [LineNumberTable(new byte[] {160, 114, 123, 107, 108, 109, 108, 109})]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 131, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(new byte[] {160, 136, 105, 107, 108, 108, 108, 108})]
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

    [LineNumberTable(new byte[] {160, 146, 109, 159, 2, 156, 115, 108, 108, 109, 198, 124, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.opacity = (double) this.life >= 240.0 ? Mathf.lerpDelta(this.opacity, 1f, 0.004f) : Math.min(this.life / 240f, this.opacity);
      this.life -= Time.delta;
      this.weather.update(this);
      this.weather.updateEffect(this);
      if ((double) this.life < 0.0)
        this.remove();
      if ((!Vars.net.client() || this.isLocal()) && !this.isRemote())
        return;
      this.interpolate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 175, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(new byte[] {160, 184, 108, 108, 108, 108, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSync(Writes write)
    {
      write.f(this.effectTimer);
      write.f(this.intensity);
      write.f(this.life);
      write.f(this.opacity);
      write.s((int) this.weather.__\u003C\u003Eid);
      TypeIO.writeVec2(write, this.windVector);
      write.f(this.x);
      write.f(this.y);
    }

    [LineNumberTable(new byte[] {160, 199, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {160, 207, 103, 108, 108, 108, 108, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.s(2);
      write.f(this.effectTimer);
      write.f(this.intensity);
      write.f(this.life);
      write.f(this.opacity);
      write.s((int) this.weather.__\u003C\u003Eid);
      TypeIO.writeVec2(write, this.windVector);
      write.f(this.x);
      write.f(this.y);
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 224, 103, 99, 109, 109, 109, 127, 1, 109, 114, 100, 109, 109, 109, 109, 127, 1, 109, 114, 103, 109, 109, 109, 109, 127, 1, 114, 109, 143, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      int num = (int) read.s();
      switch (num)
      {
        case 0:
          this.intensity = read.f();
          this.life = read.f();
          this.opacity = read.f();
          this.weather = (Weather) Vars.content.getByID(ContentType.__\u003C\u003Eweather, (int) read.s());
          this.x = read.f();
          this.y = read.f();
          break;
        case 1:
          this.effectTimer = read.f();
          this.intensity = read.f();
          this.life = read.f();
          this.opacity = read.f();
          this.weather = (Weather) Vars.content.getByID(ContentType.__\u003C\u003Eweather, (int) read.s());
          this.x = read.f();
          this.y = read.f();
          break;
        case 2:
          this.effectTimer = read.f();
          this.intensity = read.f();
          this.life = read.f();
          this.opacity = read.f();
          this.weather = (Weather) Vars.content.getByID(ContentType.__\u003C\u003Eweather, (int) read.s());
          this.windVector = TypeIO.readVec2(read, this.windVector);
          this.x = read.f();
          this.y = read.f();
          break;
        default:
          string str = new StringBuilder().append("Unknown revision '").append(num).append("' for entity type 'WeatherStateComp'").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.afterRead();
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(new byte[] {161, 7, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeSyncManual(FloatBuffer buffer)
    {
      buffer.put(this.x);
      buffer.put(this.y);
    }

    [LineNumberTable(412)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(416)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => float.MaxValue;

    [LineNumberTable(new byte[] {161, 75, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 80, 127, 16, 245, 70, 245, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      if ((double) Vars.renderer.weatherAlpha() <= 9.99999974737875E-05 || !Vars.renderer.drawWeather || !Core.settings.getBool("showweather"))
        return;
      Draw.draw(130f, (Runnable) new WeatherState.__\u003C\u003EAnon0(this));
      Draw.draw(20f, (Runnable) new WeatherState.__\u003C\u003EAnon1(this));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {161, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {161, 107, 105, 107, 108, 108, 108, 108})]
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

    [LineNumberTable(new byte[] {161, 120, 107, 107, 103, 107, 107, 107, 107, 104, 104, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      this.weather = (Weather) null;
      this.intensity = 1f;
      this.opacity = 0.0f;
      this.life = 0.0f;
      this.effectTimer = 0.0f;
      this.lastUpdated = 0L;
      this.updateSpacing = 0L;
      this.added = false;
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 14;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void weather(Weather weather) => this.weather = weather;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float intensity() => this.intensity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float opacity() => this.opacity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void opacity(float opacity) => this.opacity = opacity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float life() => this.life;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float effectTimer() => this.effectTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void effectTimer(float effectTimer) => this.effectTimer = effectTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 windVector() => this.windVector;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void windVector(Vec2 windVector) => this.windVector = windVector;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long lastUpdated() => this.lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastUpdated(long lastUpdated) => this.lastUpdated = lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long updateSpacing() => this.updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSpacing(long updateSpacing) => this.updateSpacing = updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

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

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly WeatherState arg\u00241;

      internal __\u003C\u003EAnon0([In] WeatherState obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly WeatherState arg\u00241;

      internal __\u003C\u003EAnon1([In] WeatherState obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new WeatherState();
    }
  }
}
