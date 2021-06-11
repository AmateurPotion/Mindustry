// Decompiled with JetBrains decompiler
// Type: mindustry.type.weather.RainWeather
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.type.weather
{
  public class RainWeather : Weather
  {
    public float yspeed;
    public float xspeed;
    public float padding;
    public float density;
    public float stroke;
    public float sizeMin;
    public float sizeMax;
    public float splashTimeScale;
    public Liquid liquid;
    public TextureRegion[] splashes;
    public Color color;

    [LineNumberTable(new byte[] {159, 159, 233, 58, 127, 57, 107, 109, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RainWeather(string name)
      : base(name)
    {
      RainWeather rainWeather = this;
      this.yspeed = 5f;
      this.xspeed = 1.5f;
      this.padding = 16f;
      this.density = 1200f;
      this.stroke = 0.75f;
      this.sizeMin = 8f;
      this.sizeMax = 40f;
      this.splashTimeScale = 22f;
      this.liquid = Liquids.water;
      this.splashes = new TextureRegion[12];
      this.color = Color.valueOf("7a95eaff");
    }

    [LineNumberTable(new byte[] {159, 164, 134, 108, 63, 13, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      for (int index = 0; index < this.splashes.Length; ++index)
        this.splashes[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("splash-").append(index).toString());
    }

    [LineNumberTable(new byte[] {159, 173, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawOver(WeatherState state) => this.drawRain(this.sizeMin, this.sizeMax, this.xspeed, this.yspeed, this.density, state.intensity, this.stroke, this.color);

    [LineNumberTable(new byte[] {159, 178, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawUnder(WeatherState state) => this.drawSplashes(this.splashes, this.sizeMax, this.density, state.intensity, state.opacity, this.splashTimeScale, this.stroke, this.color, this.liquid);
  }
}
