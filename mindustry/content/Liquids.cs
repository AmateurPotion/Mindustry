// Decompiled with JetBrains decompiler
// Type: mindustry.content.Liquids
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Liquids : Object, ContentList
  {
    public static Liquid water;
    public static Liquid slag;
    public static Liquid oil;
    public static Liquid cryofluid;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Liquids()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 250, 70, 250, 71, 250, 73, 250, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Liquids.water = (Liquid) new Liquids.\u0031(this, "water", Color.valueOf("596ab8"));
      Liquids.slag = (Liquid) new Liquids.\u0032(this, "slag", Color.valueOf("ffa166"));
      Liquids.oil = (Liquid) new Liquids.\u0033(this, "oil", Color.valueOf("313131"));
      Liquids.cryofluid = (Liquid) new Liquids.\u0034(this, "cryofluid", Color.valueOf("6ecdec"));
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : Liquid
    {
      [Modifiers]
      internal Liquids this\u00240;

      [LineNumberTable(new byte[] {159, 155, 113, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Liquids obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Liquids.\u0031 obj = this;
        this.heatCapacity = 0.4f;
        this.alwaysUnlocked = true;
        this.effect = StatusEffects.wet;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : Liquid
    {
      [Modifiers]
      internal Liquids this\u00240;

      [LineNumberTable(new byte[] {159, 161, 113, 107, 107, 107, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Liquids obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Liquids.\u0032 obj = this;
        this.temperature = 1f;
        this.viscosity = 0.7f;
        this.effect = StatusEffects.melting;
        this.lightColor = Color.valueOf("f0511d").a(0.4f);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : Liquid
    {
      [Modifiers]
      internal Liquids this\u00240;

      [LineNumberTable(new byte[] {159, 168, 113, 107, 107, 107, 107, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Liquids obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Liquids.\u0033 obj = this;
        this.viscosity = 0.7f;
        this.flammability = 1.2f;
        this.explosiveness = 1.2f;
        this.heatCapacity = 0.7f;
        this.barColor = Color.valueOf("6b675f");
        this.effect = StatusEffects.tarred;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : Liquid
    {
      [Modifiers]
      internal Liquids this\u00240;

      [LineNumberTable(new byte[] {159, 177, 113, 107, 107, 107, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Liquids obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Liquids.\u0034 obj = this;
        this.heatCapacity = 0.9f;
        this.temperature = 0.25f;
        this.effect = StatusEffects.freezing;
        this.lightColor = Color.valueOf("0097f5").a(0.2f);
      }
    }
  }
}
