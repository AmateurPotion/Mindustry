// Decompiled with JetBrains decompiler
// Type: mindustry.content.SectorPresets
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class SectorPresets : Object, ContentList
  {
    public static SectorPreset groundZero;
    public static SectorPreset craters;
    public static SectorPreset biomassFacility;
    public static SectorPreset frozenForest;
    public static SectorPreset ruinousShores;
    public static SectorPreset windsweptIslands;
    public static SectorPreset stainedMountains;
    public static SectorPreset tarFields;
    public static SectorPreset fungalPass;
    public static SectorPreset extractionOutpost;
    public static SectorPreset saltFlats;
    public static SectorPreset overgrowth;
    public static SectorPreset impact0078;
    public static SectorPreset desolateRift;
    public static SectorPreset nuclearComplex;
    public static SectorPreset planetaryTerminal;

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SectorPresets()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 247, 71, 247, 69, 247, 69, 247, 69, 247, 69, 250, 69, 250, 69, 247, 69, 250, 69, 247, 69, 250, 69, 247, 69, 250, 69, 247, 69, 250, 69, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      SectorPresets.groundZero = (SectorPreset) new SectorPresets.\u0031(this, "groundZero", Planets.serpulo, 15);
      SectorPresets.saltFlats = (SectorPreset) new SectorPresets.\u0032(this, "saltFlats", Planets.serpulo, 101);
      SectorPresets.frozenForest = (SectorPreset) new SectorPresets.\u0033(this, "frozenForest", Planets.serpulo, 86);
      SectorPresets.biomassFacility = (SectorPreset) new SectorPresets.\u0034(this, "biomassFacility", Planets.serpulo, 81);
      SectorPresets.craters = (SectorPreset) new SectorPresets.\u0035(this, "craters", Planets.serpulo, 18);
      SectorPresets.ruinousShores = (SectorPreset) new SectorPresets.\u0036(this, "ruinousShores", Planets.serpulo, 213);
      SectorPresets.windsweptIslands = (SectorPreset) new SectorPresets.\u0037(this, "windsweptIslands", Planets.serpulo, 246);
      SectorPresets.stainedMountains = (SectorPreset) new SectorPresets.\u0038(this, "stainedMountains", Planets.serpulo, 20);
      SectorPresets.extractionOutpost = (SectorPreset) new SectorPresets.\u0039(this, "extractionOutpost", Planets.serpulo, 165);
      SectorPresets.fungalPass = (SectorPreset) new SectorPresets.\u00310(this, "fungalPass", Planets.serpulo, 21);
      SectorPresets.overgrowth = (SectorPreset) new SectorPresets.\u00311(this, "overgrowth", Planets.serpulo, 134);
      SectorPresets.tarFields = (SectorPreset) new SectorPresets.\u00312(this, "tarFields", Planets.serpulo, 23);
      SectorPresets.impact0078 = (SectorPreset) new SectorPresets.\u00313(this, "impact0078", Planets.serpulo, 227);
      SectorPresets.desolateRift = (SectorPreset) new SectorPresets.\u00314(this, "desolateRift", Planets.serpulo, 123);
      SectorPresets.nuclearComplex = (SectorPreset) new SectorPresets.\u00315(this, "nuclearComplex", Planets.serpulo, 130);
      SectorPresets.planetaryTerminal = (SectorPreset) new SectorPresets.\u00316(this, "planetaryTerminal", Planets.serpulo, 93);
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 160, 115, 103, 103, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0031 obj = this;
        this.alwaysUnlocked = true;
        this.addStartingItems = true;
        this.captureWave = 10;
        this.difficulty = 1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {15, 115, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00310 obj = this;
        this.difficulty = 4f;
        this.useAI = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {20, 115, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00311 obj = this;
        this.difficulty = 5f;
        this.useAI = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {25, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00312 obj = this;
        this.captureWave = 40;
        this.difficulty = 5f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {30, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00313 obj = this;
        this.captureWave = 45;
        this.difficulty = 7f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {35, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00314 obj = this;
        this.captureWave = 18;
        this.difficulty = 8f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {40, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00315 obj = this;
        this.captureWave = 50;
        this.difficulty = 7f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {45, 115, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u00316 obj = this;
        this.difficulty = 10f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 167, 115, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0032 obj = this;
        this.difficulty = 5f;
        this.useAI = false;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 172, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0033 obj = this;
        this.captureWave = 15;
        this.difficulty = 2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 177, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0034 obj = this;
        this.captureWave = 20;
        this.difficulty = 3f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 182, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0035 obj = this;
        this.captureWave = 20;
        this.difficulty = 2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {159, 187, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0036 obj = this;
        this.captureWave = 30;
        this.difficulty = 3f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {0, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0037 obj = this;
        this.captureWave = 30;
        this.difficulty = 4f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {5, 115, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0038 obj = this;
        this.captureWave = 30;
        this.difficulty = 3f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : SectorPreset
    {
      [Modifiers]
      internal SectorPresets this\u00240;

      [LineNumberTable(new byte[] {10, 115, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] SectorPresets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3);
        SectorPresets.\u0039 obj = this;
        this.difficulty = 5f;
        this.useAI = false;
      }
    }
  }
}
