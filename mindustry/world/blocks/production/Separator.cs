// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Separator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class Separator : Block
  {
    public ItemStack[] results;
    public float craftTime;
    public TextureRegion liquidRegion;
    public TextureRegion spinnerRegion;
    public float spinnerSpeed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 182, 116, 48, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00240([In] Item obj0)
    {
      ItemStack[] results = this.results;
      int length = results.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = results[index];
        if (object.ReferenceEquals((object) obj0, (object) itemStack.item))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {159, 170, 233, 61, 203, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Separator(string name)
      : base(name)
    {
      Separator separator = this;
      this.spinnerSpeed = 3f;
      this.update = true;
      this.solid = true;
      this.hasItems = true;
      this.hasLiquids = true;
    }

    [LineNumberTable(new byte[] {159, 179, 134, 255, 1, 71, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eoutput, (StatValue) new ItemFilterValue((Boolf) new Separator.__\u003C\u003EAnon0(this)));
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.craftTime / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [Modifiers]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024000([In] Separator obj0) => obj0.__\u003C\u003EtimerDump;

    [HideFromJava]
    static Separator() => Block.__\u003Cclinit\u003E();

    public class SeparatorBuild : Building
    {
      public float progress;
      public float totalProgress;
      public float warmup;
      [Modifiers]
      internal Separator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(49)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SeparatorBuild(Separator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(56)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => this.cons.valid();

      [LineNumberTable(new byte[] {11, 140, 127, 26, 123, 120, 53, 200})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume()
      {
        int num = this.items.total();
        if (this.this\u00240.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eitem) && this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem) is ConsumeItems)
        {
          ItemStack[] items = ((ConsumeItems) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem)).__\u003C\u003Eitems;
          int length = items.Length;
          for (int index = 0; index < length; ++index)
          {
            ItemStack itemStack = items[index];
            num -= this.items.get(itemStack.item);
          }
        }
        return num < this.this\u00240.itemCapacity && this.enabled;
      }

      [LineNumberTable(new byte[] {24, 134, 159, 38, 119, 159, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
        if (!Core.atlas.isFound(this.this\u00240.spinnerRegion))
          return;
        Draw.rect(this.this\u00240.spinnerRegion, this.x, this.y, this.totalProgress * this.this\u00240.spinnerSpeed);
      }

      [LineNumberTable(new byte[] {35, 157, 104, 127, 1, 158, 188, 112, 115, 98, 159, 11, 104, 98, 163, 127, 3, 114, 105, 130, 234, 59, 232, 72, 134, 126, 200, 120, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.totalProgress += this.warmup * this.delta();
        if (this.consValid())
        {
          this.progress += this.getProgressIncrease(this.this\u00240.craftTime);
          this.warmup = Mathf.lerpDelta(this.warmup, 1f, 0.02f);
        }
        else
          this.warmup = Mathf.lerpDelta(this.warmup, 0.0f, 0.02f);
        if ((double) this.progress >= 1.0)
        {
          this.progress %= 1f;
          int range = 0;
          ItemStack[] results1 = this.this\u00240.results;
          int length1 = results1.Length;
          for (int index = 0; index < length1; ++index)
          {
            ItemStack itemStack = results1[index];
            range += itemStack.amount;
          }
          int num1 = Mathf.random(range);
          int num2 = 0;
          Item obj = (Item) null;
          ItemStack[] results2 = this.this\u00240.results;
          int length2 = results2.Length;
          for (int index = 0; index < length2; ++index)
          {
            ItemStack itemStack = results2[index];
            if (num1 >= num2 && num1 < num2 + itemStack.amount)
            {
              obj = itemStack.item;
              break;
            }
            num2 += itemStack.amount;
          }
          this.consume();
          if (obj != null && this.items.get(obj) < this.this\u00240.itemCapacity)
            this.offload(obj);
        }
        if (!this.timer(Separator.access\u0024000(this.this\u00240), 5f))
          return;
        this.dump();
      }

      [LineNumberTable(126)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canDump(Building to, Item item) => !this.this\u00240.__\u003C\u003Econsumes.__\u003C\u003EitemFilters.get((int) item.__\u003C\u003Eid);

      [LineNumberTable(new byte[] {81, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.progress);
        write.f(this.warmup);
      }

      [LineNumberTable(new byte[] {159, 108, 131, 104, 109, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.progress = read.f();
        this.warmup = read.f();
      }

      [HideFromJava]
      static SeparatorBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly Separator arg\u00241;

      internal __\u003C\u003EAnon0([In] Separator obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00240((Item) obj0) ? 1 : 0) != 0;
    }
  }
}
