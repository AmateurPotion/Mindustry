// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeLiquidFilter
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
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumeLiquidFilter : ConsumeLiquidBase
  {
    [Signature("Larc/func/Boolf<Lmindustry/type/Liquid;>;")]
    internal Boolf __\u003C\u003Efilter;

    [Signature("(Larc/func/Boolf<Lmindustry/type/Liquid;>;F)V")]
    [LineNumberTable(new byte[] {159, 160, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeLiquidFilter(Boolf liquid, float amount)
      : base(amount)
    {
      ConsumeLiquidFilter consumeLiquidFilter = this;
      this.__\u003C\u003Efilter = liquid;
    }

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity) => entity != null && entity.liquids != null && (this.__\u003C\u003Efilter.get((object) entity.liquids.current()) && (double) entity.liquids.currentAmount() >= (double) this.use(entity));

    [LineNumberTable(new byte[] {159, 186, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity) => entity.liquids.remove(entity.liquids.current(), this.use(entity));

    [Modifiers]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024applyLiquidFilter\u00240([In] Bits obj0, [In] Liquid obj1) => obj0.set((int) obj1.__\u003C\u003Eid);

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00241([In] Liquid obj0) => !obj0.isHidden() && this.__\u003C\u003Efilter.get((object) obj0);

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00243([In] MultiReqImage obj0, [In] Building obj1, [In] Liquid obj2)
    {
      MultiReqImage multiReqImage = obj0;
      ReqImage.__\u003Cclinit\u003E();
      ReqImage display = new ReqImage(obj2.icon(Cicon.__\u003C\u003Emedium), (Boolp) new ConsumeLiquidFilter.__\u003C\u003EAnon3(this, obj1, obj2));
      multiReqImage.add(display);
    }

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00242([In] Building obj0, [In] Liquid obj1) => obj0.liquids != null && object.ReferenceEquals((object) obj0.liquids.current(), (object) obj1) && (double) obj0.liquids.get(obj1) >= (double) Math.max(this.use(obj0), this.__\u003C\u003Eamount * obj0.delta());

    [LineNumberTable(new byte[] {159, 166, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void applyLiquidFilter(Bits arr) => Vars.content.liquids().each(this.__\u003C\u003Efilter, (Cons) new ConsumeLiquidFilter.__\u003C\u003EAnon0(arr));

    [LineNumberTable(new byte[] {159, 171, 123, 102, 179, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building build, Table table)
    {
      Seq seq = Vars.content.liquids().select((Boolf) new ConsumeLiquidFilter.__\u003C\u003EAnon1(this));
      MultiReqImage multiReqImage = new MultiReqImage();
      seq.each((Cons) new ConsumeLiquidFilter.__\u003C\u003EAnon2(this, multiReqImage, build));
      table.add((Element) multiReqImage).size(32f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-liquid-consume";

    [LineNumberTable(new byte[] {4, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats) => stats.add(!this.booster ? Stat.__\u003C\u003Einput : Stat.__\u003C\u003Ebooster, (StatValue) new LiquidFilterValue(this.__\u003C\u003Efilter, this.__\u003C\u003Eamount * 60f, true));

    [Modifiers]
    public Boolf filter
    {
      [HideFromJava] get => this.__\u003C\u003Efilter;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efilter = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Bits arg\u00241;

      internal __\u003C\u003EAnon0([In] Bits obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ConsumeLiquidFilter.lambda\u0024applyLiquidFilter\u00240(this.arg\u00241, (Liquid) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly ConsumeLiquidFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] ConsumeLiquidFilter obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024build\u00241((Liquid) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ConsumeLiquidFilter arg\u00241;
      private readonly MultiReqImage arg\u00242;
      private readonly Building arg\u00243;

      internal __\u003C\u003EAnon2([In] ConsumeLiquidFilter obj0, [In] MultiReqImage obj1, [In] Building obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243(this.arg\u00242, this.arg\u00243, (Liquid) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      private readonly ConsumeLiquidFilter arg\u00241;
      private readonly Building arg\u00242;
      private readonly Liquid arg\u00243;

      internal __\u003C\u003EAnon3([In] ConsumeLiquidFilter obj0, [In] Building obj1, [In] Liquid obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get() => (this.arg\u00241.lambda\u0024build\u00242(this.arg\u00242, this.arg\u00243) ? 1 : 0) != 0;
    }
  }
}
