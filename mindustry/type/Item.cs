// Decompiled with JetBrains decompiler
// Type: mindustry.type.Item
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using IKVM.Attributes;
using mindustry.ctype;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class Item : UnlockableContent
  {
    public Color color;
    public float explosiveness;
    public float flammability;
    public float radioactivity;
    public float charge;
    public int hardness;
    public float cost;
    public bool lowPriority;

    [Signature("()Larc/struct/Seq<Lmindustry/type/Item;>;")]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq getAllOres() => Vars.content.blocks().select((Boolf) new Item.__\u003C\u003EAnon0()).map((Func) new Item.__\u003C\u003EAnon1());

    [LineNumberTable(new byte[] {159, 175, 233, 46, 139, 203, 139, 231, 69, 235, 70, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Item(string name, Color color)
      : base(name)
    {
      Item obj = this;
      this.explosiveness = 0.0f;
      this.flammability = 0.0f;
      this.charge = 0.0f;
      this.hardness = 0;
      this.cost = 1f;
      this.color = color;
    }

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getAllOres\u00240([In] Block obj0) => obj0 is OreBlock;

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Item lambda\u0024getAllOres\u00241([In] Block obj0) => ((Floor) obj0).itemDrop;

    [LineNumberTable(new byte[] {159, 180, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Item(string name)
    {
      string name1 = name;
      Color.__\u003Cclinit\u003E();
      Color color = new Color(Color.__\u003C\u003Eblack);
      // ISSUE: explicit constructor call
      this.\u002Ector(name1, color);
    }

    [LineNumberTable(new byte[] {159, 185, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      this.stats.addPercent(Stat.__\u003C\u003Eexplosiveness, this.explosiveness);
      this.stats.addPercent(Stat.__\u003C\u003Eflammability, this.flammability);
      this.stats.addPercent(Stat.__\u003C\u003Eradioactivity, this.radioactivity);
      this.stats.addPercent(Stat.__\u003C\u003Echarge, this.charge);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.localizedName;

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eitem;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Item.lambda\u0024getAllOres\u00240((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Func
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get([In] object obj0) => (object) Item.lambda\u0024getAllOres\u00241((Block) obj0);
    }
  }
}
