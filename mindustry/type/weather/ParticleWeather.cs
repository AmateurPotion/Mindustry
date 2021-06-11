// Decompiled with JetBrains decompiler
// Type: mindustry.type.weather.ParticleWeather
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.type.weather
{
  public class ParticleWeather : Weather
  {
    public string particleRegion;
    public Color color;
    public TextureRegion region;
    public float yspeed;
    public float xspeed;
    public float padding;
    public float sizeMin;
    public float sizeMax;
    public float density;
    public float minAlpha;
    public float maxAlpha;
    public float force;
    public float noiseScale;
    public float baseSpeed;
    public float sinSclMin;
    public float sinSclMax;
    public float sinMagMin;
    public float sinMagMax;
    public Color noiseColor;
    public bool drawNoise;
    public bool drawParticles;
    public bool useWindVector;
    public int noiseLayers;
    public float noiseLayerSpeedM;
    public float noiseLayerAlphaM;
    public float noiseLayerSclM;
    public float noiseLayerColorM;
    public string noisePath;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Texture noise;

    [LineNumberTable(new byte[] {159, 168, 233, 50, 107, 144, 127, 90, 159, 13, 108, 117, 103, 127, 13, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParticleWeather(string name)
      : base(name)
    {
      ParticleWeather particleWeather = this;
      this.particleRegion = "circle-shadow";
      this.color = Color.__\u003C\u003Ewhite.cpy();
      this.yspeed = -2f;
      this.xspeed = 0.25f;
      this.padding = 16f;
      this.sizeMin = 2.4f;
      this.sizeMax = 12f;
      this.density = 1200f;
      this.minAlpha = 1f;
      this.maxAlpha = 1f;
      this.force = 0.0f;
      this.noiseScale = 2000f;
      this.baseSpeed = 6.1f;
      this.sinSclMin = 30f;
      this.sinSclMax = 80f;
      this.sinMagMin = 1f;
      this.sinMagMax = 7f;
      this.noiseColor = this.color;
      this.drawNoise = false;
      this.drawParticles = true;
      this.useWindVector = false;
      this.noiseLayers = 1;
      this.noiseLayerSpeedM = 1.1f;
      this.noiseLayerAlphaM = 0.8f;
      this.noiseLayerSclM = 0.99f;
      this.noiseLayerColorM = 1f;
      this.noisePath = "noiseAlpha";
    }

    [LineNumberTable(new byte[] {159, 173, 134, 214, 111, 159, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      this.region = (TextureRegion) Core.atlas.find(this.particleRegion);
      if (!this.drawNoise || Core.assets == null)
        return;
      Core.assets.load(new StringBuilder().append("sprites/").append(this.noisePath).append(".png").toString(), (Class) ClassLiteral<Texture>.Value);
    }

    [LineNumberTable(new byte[] {159, 186, 111, 104, 158, 127, 1, 105, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(WeatherState state)
    {
      float num1 = this.force * state.intensity;
      if ((double) num1 <= 1.0 / 1000.0)
        return;
      float num2 = state.windVector.x * num1;
      float num3 = state.windVector.y * num1;
      Iterator iterator = Groups.unit.iterator();
      while (iterator.hasNext())
        ((Unit) iterator.next()).impulse(num2, num3);
    }

    [LineNumberTable(new byte[] {8, 104, 111, 111, 111, 98, 103, 167, 107, 104, 127, 36, 112, 176, 122, 114, 112, 127, 48, 106, 108, 106, 107, 238, 58, 235, 74, 104, 159, 55})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawOver(WeatherState state)
    {
      float num1;
      float num2;
      if (this.useWindVector)
      {
        float num3 = this.baseSpeed * state.intensity;
        num1 = state.windVector.x * num3;
        num2 = state.windVector.y * num3;
      }
      else
      {
        num1 = this.xspeed;
        num2 = this.yspeed;
      }
      if (this.drawNoise)
      {
        if (this.noise == null)
        {
          this.noise = (Texture) Core.assets.get(new StringBuilder().append("sprites/").append(this.noisePath).append(".png").toString(), (Class) ClassLiteral<Texture>.Value);
          this.noise.setWrap(Texture.TextureWrap.__\u003C\u003Erepeat);
          this.noise.setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
        }
        float num3 = 1f;
        float num4 = 1f;
        float num5 = 1f;
        float offset = 0.0f;
        Color color = Tmp.__\u003C\u003Ec1.set(this.noiseColor);
        for (int index = 0; index < this.noiseLayers; ++index)
        {
          this.drawNoise(this.noise, this.noiseColor, this.noiseScale * num4, state.opacity * num5 * this.opacityMultiplier, num3 * (!this.useWindVector ? this.baseSpeed : 1f), state.intensity, num1, num2, offset);
          num3 *= this.noiseLayerSpeedM;
          num5 *= this.noiseLayerAlphaM;
          num4 *= this.noiseLayerSclM;
          offset += 0.29f;
          color.mul(this.noiseLayerColorM);
        }
      }
      if (!this.drawParticles)
        return;
      this.drawParticles(this.region, this.color, this.sizeMin, this.sizeMax, this.density, state.intensity, state.opacity, num1, num2, this.minAlpha, this.maxAlpha, this.sinSclMin, this.sinSclMax, this.sinMagMin, this.sinMagMax);
    }
  }
}
