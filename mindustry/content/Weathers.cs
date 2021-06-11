// Decompiled with JetBrains decompiler
// Type: mindustry.content.Weathers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.gen;
using mindustry.type;
using mindustry.type.weather;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Weathers : Object, ContentList
  {
    public static Weather rain;
    public static Weather snow;
    public static Weather sandstorm;
    public static Weather sporestorm;
    public static Weather fog;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Weathers()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 240, 78, 240, 72, 240, 84, 240, 86, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Weathers.snow = (Weather) new Weathers.\u0031(this, "snow");
      Weathers.rain = (Weather) new Weathers.\u0032(this, "rain");
      Weathers.sandstorm = (Weather) new Weathers.\u0033(this, "sandstorm");
      Weathers.sporestorm = (Weather) new Weathers.\u0034(this, "sporestorm");
      Weathers.fog = (Weather) new Weathers.\u0035(this, "fog");
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : ParticleWeather
    {
      [Modifiers]
      internal Weathers this\u00240;

      [LineNumberTable(new byte[] {159, 163, 112, 107, 107, 107, 107, 149, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Weathers obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Weathers.\u0031 obj = this;
        this.particleRegion = "particle";
        this.sizeMax = 13f;
        this.sizeMin = 2.6f;
        this.density = 1200f;
        this.attrs.set(Attribute.__\u003C\u003Elight, -0.15f);
        this.sound = Sounds.windhowl;
        this.soundVol = 0.0f;
        this.soundVolOscMag = 1.5f;
        this.soundVolOscScl = 1100f;
        this.soundVolMin = 0.02f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : RainWeather
    {
      [Modifiers]
      internal Weathers this\u00240;

      [LineNumberTable(new byte[] {159, 177, 112, 117, 117, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Weathers obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Weathers.\u0032 obj = this;
        this.attrs.set(Attribute.__\u003C\u003Elight, -0.2f);
        this.attrs.set(Attribute.__\u003C\u003Ewater, 0.2f);
        this.status = StatusEffects.wet;
        this.sound = Sounds.rain;
        this.soundVol = 0.25f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : ParticleWeather
    {
      [Modifiers]
      internal Weathers this\u00240;

      [LineNumberTable(new byte[] {159, 185, 112, 123, 107, 103, 103, 107, 107, 107, 107, 107, 107, 117, 117, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Weathers obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Weathers.\u0033 obj2 = this;
        Weathers.\u0033 obj3 = this;
        Color color1 = Color.valueOf("f7cba4");
        Color color2 = color1;
        this.noiseColor = color1;
        this.color = color2;
        this.particleRegion = "particle";
        this.drawNoise = true;
        this.useWindVector = true;
        this.sizeMax = 140f;
        this.sizeMin = 70f;
        this.minAlpha = 0.0f;
        this.maxAlpha = 0.2f;
        this.density = 1500f;
        this.baseSpeed = 5.4f;
        this.attrs.set(Attribute.__\u003C\u003Elight, -0.1f);
        this.attrs.set(Attribute.__\u003C\u003Ewater, -0.1f);
        this.opacityMultiplier = 0.35f;
        this.force = 0.1f;
        this.sound = Sounds.wind;
        this.soundVol = 0.8f;
        this.duration = 25200f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : ParticleWeather
    {
      [Modifiers]
      internal Weathers this\u00240;

      [LineNumberTable(new byte[] {13, 112, 123, 107, 103, 103, 103, 107, 107, 107, 107, 107, 107, 117, 117, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Weathers obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Weathers.\u0034 obj2 = this;
        Weathers.\u0034 obj3 = this;
        Color color1 = Color.valueOf("7457ce");
        Color color2 = color1;
        this.noiseColor = color1;
        this.color = color2;
        this.particleRegion = "circle-small";
        this.drawNoise = true;
        this.statusGround = false;
        this.useWindVector = true;
        this.sizeMax = 5f;
        this.sizeMin = 2.5f;
        this.minAlpha = 0.1f;
        this.maxAlpha = 0.8f;
        this.density = 2000f;
        this.baseSpeed = 4.3f;
        this.attrs.set(Attribute.__\u003C\u003Espores, 1f);
        this.attrs.set(Attribute.__\u003C\u003Elight, -0.15f);
        this.status = StatusEffects.sporeSlowed;
        this.opacityMultiplier = 0.5f;
        this.force = 0.1f;
        this.sound = Sounds.wind;
        this.soundVol = 0.7f;
        this.duration = 25200f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : ParticleWeather
    {
      [Modifiers]
      internal Weathers this\u00240;

      [LineNumberTable(new byte[] {35, 112, 107, 103, 107, 107, 107, 107, 107, 123, 107, 107, 103, 103, 103, 107, 107, 117, 117, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Weathers obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Weathers.\u0035 obj2 = this;
        this.duration = 54000f;
        this.noiseLayers = 3;
        this.noiseLayerSclM = 0.8f;
        this.noiseLayerAlphaM = 0.7f;
        this.noiseLayerSpeedM = 2f;
        this.noiseLayerSclM = 0.6f;
        this.baseSpeed = 0.05f;
        Weathers.\u0035 obj3 = this;
        Color color1 = Color.grays(0.4f);
        Color color2 = color1;
        this.noiseColor = color1;
        this.color = color2;
        this.noiseScale = 1100f;
        this.noisePath = "fog";
        this.drawParticles = false;
        this.drawNoise = true;
        this.useWindVector = false;
        this.xspeed = 1f;
        this.yspeed = 0.01f;
        this.attrs.set(Attribute.__\u003C\u003Elight, -0.3f);
        this.attrs.set(Attribute.__\u003C\u003Ewater, 0.05f);
        this.opacityMultiplier = 0.47f;
      }
    }
  }
}
