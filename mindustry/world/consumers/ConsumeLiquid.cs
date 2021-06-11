// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeLiquid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumeLiquid : ConsumeLiquidBase
  {
    internal Liquid __\u003C\u003Eliquid;

    [LineNumberTable(new byte[] {159, 156, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeLiquid(Liquid liquid, float amount)
      : base(amount)
    {
      ConsumeLiquid consumeLiquid = this;
      this.__\u003C\u003Eliquid = liquid;
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity) => entity != null && entity.liquids != null && (double) entity.liquids.get(this.__\u003C\u003Eliquid) >= (double) (this.__\u003C\u003Eamount * entity.delta());

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00240([In] Building obj0) => this.valid(obj0);

    [LineNumberTable(new byte[] {159, 161, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ConsumeLiquid()
      : this((Liquid) null, 0.0f)
    {
    }

    [LineNumberTable(new byte[] {159, 166, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void applyLiquidFilter(Bits filter) => filter.set((int) this.__\u003C\u003Eliquid.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {159, 171, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building tile, Table table)
    {
      Table table1 = table;
      ReqImage.__\u003Cclinit\u003E();
      ReqImage reqImage = new ReqImage(this.__\u003C\u003Eliquid.icon(Cicon.__\u003C\u003Emedium), (Boolp) new ConsumeLiquid.__\u003C\u003EAnon0(this, tile));
      table1.add((Element) reqImage).size(32f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-liquid-consume";

    [LineNumberTable(new byte[] {159, 181, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity) => entity.liquids.remove(this.__\u003C\u003Eliquid, Math.min(this.use(entity), entity.liquids.get(this.__\u003C\u003Eliquid)));

    [LineNumberTable(new byte[] {159, 191, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats) => stats.add(!this.booster ? Stat.__\u003C\u003Einput : Stat.__\u003C\u003Ebooster, this.__\u003C\u003Eliquid, this.__\u003C\u003Eamount * 60f, true);

    [Modifiers]
    public Liquid liquid
    {
      [HideFromJava] get => this.__\u003C\u003Eliquid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eliquid = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolp
    {
      private readonly ConsumeLiquid arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon0([In] ConsumeLiquid obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (this.arg\u00241.lambda\u0024build\u00240(this.arg\u00242) ? 1 : 0) != 0;
    }
  }
}
