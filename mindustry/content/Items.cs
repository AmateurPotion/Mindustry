// Decompiled with JetBrains decompiler
// Type: mindustry.content.Items
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
  public class Items : Object, ContentList
  {
    public static Item scrap;
    public static Item copper;
    public static Item lead;
    public static Item graphite;
    public static Item coal;
    public static Item titanium;
    public static Item thorium;
    public static Item silicon;
    public static Item plastanium;
    public static Item phaseFabric;
    public static Item surgeAlloy;
    public static Item sporePod;
    public static Item sand;
    public static Item blastCompound;
    public static Item pyratite;
    public static Item metaglass;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Items()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 250, 70, 250, 70, 218, 218, 250, 69, 250, 70, 250, 69, 250, 71, 218, 218, 250, 70, 250, 69, 250, 69, 218, 250, 69, 218})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Items.copper = (Item) new Items.\u0031(this, "copper", Color.valueOf("d99d73"));
      Items.lead = (Item) new Items.\u0032(this, "lead", Color.valueOf("8c7fa9"));
      Items.metaglass = (Item) new Items.\u0033(this, "metaglass", Color.valueOf("ebeef5"));
      Items.graphite = (Item) new Items.\u0034(this, "graphite", Color.valueOf("b2c6d2"));
      Items.sand = (Item) new Items.\u0035(this, "sand", Color.valueOf("f7cba4"));
      Items.coal = (Item) new Items.\u0036(this, "coal", Color.valueOf("272727"));
      Items.titanium = (Item) new Items.\u0037(this, "titanium", Color.valueOf("8da1e3"));
      Items.thorium = (Item) new Items.\u0038(this, "thorium", Color.valueOf("f9a3c7"));
      Items.scrap = (Item) new Items.\u0039(this, "scrap", Color.valueOf("777777"));
      Items.silicon = (Item) new Items.\u00310(this, "silicon", Color.valueOf("53565c"));
      Items.plastanium = (Item) new Items.\u00311(this, "plastanium", Color.valueOf("cbd97f"));
      Items.phaseFabric = (Item) new Items.\u00312(this, "phase-fabric", Color.valueOf("f4ba6e"));
      Items.surgeAlloy = (Item) new Items.\u00313(this, "surge-alloy", Color.valueOf("f3e979"));
      Items.sporePod = (Item) new Items.\u00314(this, "spore-pod", Color.valueOf("7457ce"));
      Items.blastCompound = (Item) new Items.\u00315(this, "blast-compound", Color.valueOf("ff795e"));
      Items.pyratite = (Item) new Items.\u00316(this, "pyratite", Color.valueOf("ffaa5f"));
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 155, 113, 103, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0031 obj = this;
        this.hardness = 1;
        this.cost = 0.5f;
        this.alwaysUnlocked = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {10, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00310 obj = this;
        this.cost = 0.8f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {14, 113, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00311 obj = this;
        this.flammability = 0.1f;
        this.explosiveness = 0.2f;
        this.cost = 1.3f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {20, 113, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00312 obj = this;
        this.cost = 1.3f;
        this.radioactivity = 0.6f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {25, 113, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00313 obj = this;
        this.cost = 1.2f;
        this.charge = 0.75f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {30, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00314 obj = this;
        this.flammability = 1.15f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {34, 113, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00315 obj = this;
        this.flammability = 0.4f;
        this.explosiveness = 1.2f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {39, 113, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u00316 obj = this;
        this.flammability = 1.4f;
        this.explosiveness = 0.4f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 161, 113, 103, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0032 obj = this;
        this.hardness = 1;
        this.cost = 0.7f;
        this.alwaysUnlocked = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 167, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0033 obj = this;
        this.cost = 1.5f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 171, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0034 obj = this;
        this.cost = 1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 175, 113, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0035 obj = this;
        this.alwaysUnlocked = true;
        this.lowPriority = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 180, 113, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0036 obj = this;
        this.explosiveness = 0.2f;
        this.flammability = 1f;
        this.hardness = 2;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 186, 113, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0037 obj = this;
        this.hardness = 3;
        this.cost = 1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {159, 191, 113, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Items.\u0038 obj = this;
        this.explosiveness = 0.2f;
        this.hardness = 4;
        this.radioactivity = 1f;
        this.cost = 1.1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : Item
    {
      [Modifiers]
      internal Items this\u00240;

      [LineNumberTable(new byte[] {6, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] Items obj0, [In] string obj1, [In] Color obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
      }
    }
  }
}
