// Decompiled with JetBrains decompiler
// Type: mindustry.type.Weather
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using mindustry.content;
using mindustry.ctype;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class Weather : UnlockableContent
  {
    public float duration;
    public float opacityMultiplier;
    public mindustry.world.blocks.Attributes attrs;
    public Sound sound;
    public float soundVol;
    public float soundVolMin;
    public float soundVolOscMag;
    public float soundVolOscScl;
    public Rand rand;
    [Signature("Larc/func/Prov<Lmindustry/gen/WeatherState;>;")]
    public Prov type;
    public StatusEffect status;
    public float statusDuration;
    public bool statusAir;
    public bool statusGround;

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual WeatherState create(float intensity) => this.create(intensity, this.duration);

    [LineNumberTable(new byte[] {6, 113, 104, 103, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual WeatherState create(float intensity, float duration)
    {
      WeatherState weatherState = (WeatherState) this.type.get();
      weatherState.intensity(intensity);
      weatherState.init(this);
      weatherState.life(duration);
      weatherState.add();
      return weatherState;
    }

    [LineNumberTable(66)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual WeatherState instance() => (WeatherState) Groups.weather.find((Boolf) new Weather.__\u003C\u003EAnon1(this));

    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024instance\u00240([In] WeatherState obj0) => object.ReferenceEquals((object) obj0.weather(), (object) this);

    [Modifiers]
    [LineNumberTable(new byte[] {38, 116, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateEffect\u00241([In] Unit obj0)
    {
      if (!obj0.checkTarget(this.statusAir, this.statusGround))
        return;
      obj0.apply(this.status, this.statusDuration);
    }

    [Signature("(Ljava/lang/String;Larc/func/Prov<Lmindustry/gen/WeatherState;>;)V")]
    [LineNumberTable(new byte[] {159, 181, 233, 49, 107, 107, 107, 107, 118, 182, 107, 112, 107, 107, 206, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Weather(string name, Prov type)
      : base(name)
    {
      Weather weather = this;
      this.duration = 36000f;
      this.opacityMultiplier = 1f;
      this.attrs = new mindustry.world.blocks.Attributes();
      this.sound = Sounds.none;
      this.soundVol = 0.1f;
      this.soundVolMin = 0.0f;
      this.soundVolOscMag = 0.0f;
      this.soundVolOscScl = 20f;
      this.rand = new Rand();
      this.type = (Prov) new Weather.__\u003C\u003EAnon0();
      this.status = StatusEffects.none;
      this.statusDuration = 120f;
      this.statusAir = true;
      this.statusGround = true;
      this.type = type;
    }

    [LineNumberTable(new byte[] {159, 186, 233, 44, 107, 107, 107, 107, 118, 182, 107, 112, 107, 107, 238, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Weather(string name)
      : base(name)
    {
      Weather weather = this;
      this.duration = 36000f;
      this.opacityMultiplier = 1f;
      this.attrs = new mindustry.world.blocks.Attributes();
      this.sound = Sounds.none;
      this.soundVol = 0.1f;
      this.soundVolMin = 0.0f;
      this.soundVolOscMag = 0.0f;
      this.soundVolOscScl = 20f;
      this.rand = new Rand();
      this.type = (Prov) new Weather.__\u003C\u003EAnon0();
      this.status = StatusEffects.none;
      this.statusDuration = 120f;
      this.statusAir = true;
      this.statusGround = true;
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual WeatherState create() => this.create(1f);

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isActive() => this.instance() != null;

    [LineNumberTable(new byte[] {24, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => this.instance()?.remove();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(WeatherState state)
    {
    }

    [LineNumberTable(new byte[] {33, 114, 109, 147, 247, 70, 211, 124, 127, 25, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateEffect(WeatherState state)
    {
      if (!object.ReferenceEquals((object) this.status, (object) StatusEffects.none))
      {
        if ((double) state.effectTimer <= 0.0)
        {
          state.effectTimer = this.statusDuration - 5f;
          Groups.unit.each((Cons) new Weather.__\u003C\u003EAnon2(this));
        }
        else
          state.effectTimer -= Time.delta;
      }
      if (Vars.headless || object.ReferenceEquals((object) this.sound, (object) Sounds.none))
        return;
      float num = (double) this.soundVolOscMag <= 0.0 ? 0.0f : (float) Math.abs(Noise.rawNoise((double) (Time.time / this.soundVolOscScl))) * this.soundVolOscMag;
      Vars.control.sound.loop(this.sound, Math.max((this.soundVol + num) * state.opacity, this.soundVolMin));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawOver(WeatherState state)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawUnder(WeatherState state)
    {
    }

    [LineNumberTable(new byte[] {67, 109, 127, 58, 117, 112, 123, 137, 105, 119, 119, 115, 127, 14, 127, 14, 148, 159, 19, 112, 112, 116, 116, 112, 144, 124, 108, 238, 45, 233, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawParticles(
      TextureRegion region,
      Color color,
      float sizeMin,
      float sizeMax,
      float density,
      float intensity,
      float opacity,
      float windx,
      float windy,
      float minAlpha,
      float maxAlpha,
      float sinSclMin,
      float sinSclMax,
      float sinMagMin,
      float sinMagMax)
    {
      this.rand.setSeed(0L);
      Tmp.__\u003C\u003Er1.setCentered(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, (float) Core.graphics.getWidth() / Vars.renderer.minScale(), (float) Core.graphics.getHeight() / Vars.renderer.minScale());
      Tmp.__\u003C\u003Er1.grow(sizeMax * 1.5f);
      Core.camera.bounds(Tmp.__\u003C\u003Er2);
      int num1 = ByteCodeHelper.f2i(Tmp.__\u003C\u003Er1.area() / density * intensity);
      Draw.color(color, opacity);
      for (int index = 0; index < num1; ++index)
      {
        float num2 = this.rand.random(0.5f, 1f);
        float num3 = this.rand.random(0.5f, 1f);
        float num4 = this.rand.random(sizeMin, sizeMax);
        float num5 = this.rand.random(0.0f, (float) Vars.world.unitWidth()) + Time.time * windx * num3;
        float radians = this.rand.random(0.0f, (float) Vars.world.unitHeight()) + Time.time * windy * num2;
        float num6 = this.rand.random(minAlpha, maxAlpha);
        float f1 = num5 + Mathf.sin(radians, this.rand.random(sinSclMin, sinSclMax), this.rand.random(sinMagMin, sinMagMax)) - Tmp.__\u003C\u003Er1.x;
        float f2 = radians - Tmp.__\u003C\u003Er1.y;
        float num7 = Mathf.mod(f1, Tmp.__\u003C\u003Er1.width);
        float num8 = Mathf.mod(f2, Tmp.__\u003C\u003Er1.height);
        float x = num7 + Tmp.__\u003C\u003Er1.x;
        float y = num8 + Tmp.__\u003C\u003Er1.y;
        if (Tmp.__\u003C\u003Er3.setCentered(x, y, num4).overlaps(Tmp.__\u003C\u003Er2))
        {
          Draw.alpha(num6 * opacity);
          Draw.rect(region, x, y, num4, num4);
        }
      }
    }

    [LineNumberTable(new byte[] {99, 138, 127, 58, 108, 112, 123, 104, 107, 135, 105, 120, 120, 114, 127, 14, 127, 15, 150, 112, 112, 116, 116, 112, 144, 124, 103, 255, 7, 47, 233, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRain(
      float sizeMin,
      float sizeMax,
      float xspeed,
      float yspeed,
      float density,
      float intensity,
      float stroke,
      Color color)
    {
      float amount = sizeMax * 0.9f;
      Tmp.__\u003C\u003Er1.setCentered(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, (float) Core.graphics.getWidth() / Vars.renderer.minScale(), (float) Core.graphics.getHeight() / Vars.renderer.minScale());
      Tmp.__\u003C\u003Er1.grow(amount);
      Core.camera.bounds(Tmp.__\u003C\u003Er2);
      int num1 = ByteCodeHelper.f2i(Tmp.__\u003C\u003Er1.area() / density * intensity);
      Lines.stroke(stroke);
      float a = Draw.getColor().a;
      Draw.color(color);
      for (int index = 0; index < num1; ++index)
      {
        float num2 = this.rand.random(0.5f, 1f);
        float num3 = this.rand.random(0.5f, 1f);
        float size = this.rand.random(sizeMin, sizeMax);
        float num4 = this.rand.random(0.0f, (float) Vars.world.unitWidth()) + Time.time * xspeed * num3;
        float num5 = this.rand.random(0.0f, (float) Vars.world.unitHeight()) - Time.time * yspeed * num2;
        float alpha = this.rand.random(1f) * a;
        float f1 = num4 - Tmp.__\u003C\u003Er1.x;
        float f2 = num5 - Tmp.__\u003C\u003Er1.y;
        float num6 = Mathf.mod(f1, Tmp.__\u003C\u003Er1.width);
        float num7 = Mathf.mod(f2, Tmp.__\u003C\u003Er1.height);
        float x = num6 + Tmp.__\u003C\u003Er1.x;
        float y = num7 + Tmp.__\u003C\u003Er1.y;
        if (Tmp.__\u003C\u003Er3.setCentered(x, y, size).overlaps(Tmp.__\u003C\u003Er2))
        {
          Draw.alpha(alpha);
          Lines.lineAngle(x, y, Angles.angle(xspeed * num3, -yspeed * num2), size / 2f);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 68, 127, 58, 109, 112, 124, 136, 139, 105, 119, 134, 105, 107, 127, 10, 159, 10, 112, 112, 116, 116, 112, 144, 127, 7, 176, 121, 127, 14, 126, 127, 10, 103, 146, 103, 127, 9, 127, 10, 31, 32, 235, 36, 233, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSplashes(
      TextureRegion[] splashes,
      float padding,
      float density,
      float intensity,
      float opacity,
      float timeScale,
      float stroke,
      Color color,
      Liquid splasher)
    {
      Tmp.__\u003C\u003Er1.setCentered(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, (float) Core.graphics.getWidth() / Vars.renderer.minScale(), (float) Core.graphics.getHeight() / Vars.renderer.minScale());
      Tmp.__\u003C\u003Er1.grow(padding);
      Core.camera.bounds(Tmp.__\u003C\u003Er2);
      int num1 = ByteCodeHelper.f2i(Tmp.__\u003C\u003Er1.area() / density * intensity) / 2;
      Lines.stroke(stroke);
      float num2 = Time.time / timeScale;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        float num3 = this.rand.random(0.0f, 1f);
        float num4 = num2 + num3;
        int num5 = ByteCodeHelper.f2i(num4);
        float fin = num4 % 1f;
        float num6 = this.rand.random(0.0f, (float) Vars.world.unitWidth()) + (float) (num5 * 953);
        float num7 = this.rand.random(0.0f, (float) Vars.world.unitHeight()) - (float) (num5 * 453);
        float f1 = num6 - Tmp.__\u003C\u003Er1.x;
        float f2 = num7 - Tmp.__\u003C\u003Er1.y;
        float num8 = Mathf.mod(f1, Tmp.__\u003C\u003Er1.width);
        float num9 = Mathf.mod(f2, Tmp.__\u003C\u003Er1.height);
        float x = num8 + Tmp.__\u003C\u003Er1.x;
        float y = num9 + Tmp.__\u003C\u003Er1.y;
        if (Tmp.__\u003C\u003Er3.setCentered(x, y, fin * 4f).overlaps(Tmp.__\u003C\u003Er2))
        {
          Tile tile = Vars.world.tileWorld(x, y);
          if (tile != null && object.ReferenceEquals((object) tile.floor().liquidDrop, (object) splasher))
          {
            Draw.color(Tmp.__\u003C\u003Ec1.set(tile.floor().mapColor).mul(1.5f).a(opacity));
            Draw.rect(splashes[ByteCodeHelper.f2i(fin * (float) (splashes.Length - 1))], x, y);
          }
          else if (tile != null && tile.floor().liquidDrop == null && !tile.floor().solid)
          {
            Draw.color(color);
            Draw.alpha(Mathf.slope(fin) * opacity);
            float num10 = 45f;
            int[] numArray = new int[2]{ -1, 1 };
            int length = numArray.Length;
            for (int index2 = 0; index2 < length; ++index2)
            {
              int num11 = numArray[index2];
              Tmp.__\u003C\u003Ev1.trns(90f + (float) num11 * num10, 1f + 5f * fin);
              Lines.lineAngle(x + Tmp.__\u003C\u003Ev1.x, y + Tmp.__\u003C\u003Ev1.y, 90f + (float) num11 * num10, 3f * (1f - fin));
            }
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 114, 104, 134, 105, 142, 106, 111, 107, 112, 127, 55, 118, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawNoise(
      Texture noise,
      Color color,
      float noisescl,
      float opacity,
      float baseSpeed,
      float intensity,
      float vwindx,
      float vwindy,
      float offset)
    {
      Draw.alpha(opacity);
      Draw.tint(color);
      float num1 = baseSpeed * intensity;
      float num2 = vwindx * num1;
      float num3 = vwindy * num1;
      float num4 = 1f / noisescl;
      float num5 = Time.time * num4 + offset;
      Tmp.__\u003C\u003Etr1.texture = noise;
      Core.camera.bounds(Tmp.__\u003C\u003Er1);
      Tmp.__\u003C\u003Etr1.set(Tmp.__\u003C\u003Er1.x * num4, Tmp.__\u003C\u003Er1.y * num4, (Tmp.__\u003C\u003Er1.x + Tmp.__\u003C\u003Er1.width) * num4, (Tmp.__\u003C\u003Er1.y + Tmp.__\u003C\u003Er1.height) * num4);
      Tmp.__\u003C\u003Etr1.scroll(-num2 * num5, -num3 * num5);
      Draw.rect(Tmp.__\u003C\u003Etr1, Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, Core.camera.width, -Core.camera.height);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => true;

    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eweather;

    [LineNumberTable(new byte[] {160, 141, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createWeather(
      Weather weather,
      float intensity,
      float duration,
      float windX,
      float windY)
    {
      weather.create(intensity, duration).windVector.set(windX, windY);
    }

    public class WeatherEntry : Object
    {
      public Weather weather;
      public float minFrequency;
      public float maxFrequency;
      public float minDuration;
      public float maxDuration;
      public float cooldown;
      public float intensity;
      public bool always;

      [LineNumberTable(new byte[] {160, 158, 127, 28})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WeatherEntry(Weather weather)
        : this(weather, weather.duration * 2f, weather.duration * 6f, weather.duration / 2f, weather.duration * 1.5f)
      {
      }

      [LineNumberTable(new byte[] {160, 161, 232, 55, 139, 231, 72, 103, 104, 104, 105, 137, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WeatherEntry(
        Weather weather,
        float minFrequency,
        float maxFrequency,
        float minDuration,
        float maxDuration)
      {
        Weather.WeatherEntry weatherEntry = this;
        this.intensity = 1f;
        this.always = false;
        this.weather = weather;
        this.minFrequency = minFrequency;
        this.maxFrequency = maxFrequency;
        this.minDuration = minDuration;
        this.maxDuration = maxDuration;
        this.cooldown = Mathf.random(minFrequency, maxFrequency);
      }

      [LineNumberTable(new byte[] {160, 172, 232, 44, 139, 231, 84})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WeatherEntry()
      {
        Weather.WeatherEntry weatherEntry = this;
        this.intensity = 1f;
        this.always = false;
      }
    }

    [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Syncc"})]
    internal abstract class WeatherStateComp : Object, Drawc, Posc, Position, Entityc, Syncc
    {
      private const float fadeTime = 240f;
      internal Weather weather;
      internal float intensity;
      internal float opacity;
      internal float life;
      internal float effectTimer;
      internal Vec2 windVector;

      [HideFromJava]
      public abstract Entityc self();

      [HideFromJava]
      public abstract void remove();

      [Modifiers]
      [LineNumberTable(new byte[] {160, 212, 114, 127, 6, 118, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00240()
      {
        this.weather.rand.setSeed(0L);
        Draw.alpha(Vars.renderer.weatherAlpha() * this.opacity * this.weather.opacityMultiplier);
        this.weather.drawOver((WeatherState) this.self());
        Draw.reset();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 219, 114, 127, 6, 118, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00241()
      {
        this.weather.rand.setSeed(0L);
        Draw.alpha(Vars.renderer.weatherAlpha() * this.opacity * this.weather.opacityMultiplier);
        this.weather.drawUnder((WeatherState) this.self());
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 179, 200, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal WeatherStateComp()
      {
        Weather.WeatherStateComp weatherStateComp = this;
        this.intensity = 1f;
        this.opacity = 0.0f;
        this.windVector = new Vec2().setToRandomDirection();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void init([In] Weather obj0) => this.weather = obj0;

      [LineNumberTable(new byte[] {160, 192, 109, 159, 2, 188, 147, 118, 150, 109, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        this.opacity = (double) this.life >= 240.0 ? Mathf.lerpDelta(this.opacity, 1f, 0.004f) : Math.min(this.life / 240f, this.opacity);
        this.life -= Time.delta;
        this.weather.update((WeatherState) this.self());
        this.weather.updateEffect((WeatherState) this.self());
        if ((double) this.life >= 0.0)
          return;
        this.remove();
      }

      [LineNumberTable(new byte[] {160, 210, 127, 16, 245, 71, 245, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void draw()
      {
        if ((double) Vars.renderer.weatherAlpha() <= 9.99999974737875E-05 || !Vars.renderer.drawWeather || !Core.settings.getBool("showweather"))
          return;
        Draw.draw(130f, (Runnable) new Weather.WeatherStateComp.__\u003C\u003EAnon0(this));
        Draw.draw(20f, (Runnable) new Weather.WeatherStateComp.__\u003C\u003EAnon1(this));
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

      [HideFromJava]
      public abstract float clipSize();

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
      public abstract void afterSync();

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

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly Weather.WeatherStateComp arg\u00241;

        internal __\u003C\u003EAnon0([In] Weather.WeatherStateComp obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00240();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly Weather.WeatherStateComp arg\u00241;

        internal __\u003C\u003EAnon1([In] Weather.WeatherStateComp obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00241();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) WeatherState.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Weather arg\u00241;

      internal __\u003C\u003EAnon1([In] Weather obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024instance\u00240((WeatherState) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Weather arg\u00241;

      internal __\u003C\u003EAnon2([In] Weather obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateEffect\u00241((Unit) obj0);
    }
  }
}
