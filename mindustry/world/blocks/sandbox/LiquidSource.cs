// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.LiquidSource
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.sandbox
{
  public class LiquidSource : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] LiquidSource.LiquidSourceBuild obj0, [In] Liquid obj1) => obj0.source = obj1;

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] LiquidSource.LiquidSourceBuild obj0) => obj0.source = (Liquid) null;

    [LineNumberTable(new byte[] {159, 161, 105, 103, 103, 103, 107, 103, 103, 103, 103, 103, 139, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidSource(string name)
      : base(name)
    {
      LiquidSource liquidSource = this;
      this.update = true;
      this.solid = true;
      this.hasLiquids = true;
      this.liquidCapacity = 100f;
      this.configurable = true;
      this.outputsLiquid = true;
      this.saveConfig = true;
      this.noUpdateDisabled = true;
      this.displayFlow = false;
      this.group = BlockGroup.__\u003C\u003Eliquids;
      this.config((Class) ClassLiteral<Liquid>.Value, (Cons2) new LiquidSource.__\u003C\u003EAnon0());
      this.configClear((Cons) new LiquidSource.__\u003C\u003EAnon1());
    }

    [LineNumberTable(new byte[] {159, 179, 134, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.remove("liquid");
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 186, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfig(BuildPlan req, Eachable list) => this.drawRequestConfigCenter(req, req.config, "center", true);

    [HideFromJava]
    static LiquidSource() => Block.__\u003Cclinit\u003E();

    public class LiquidSourceBuild : Building
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Liquid source;
      [Modifiers]
      internal LiquidSource this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Liquid config() => this.source;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Liquid lambda\u0024buildConfiguration\u00240() => this.source;

      [LineNumberTable(new byte[] {159, 189, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidSourceBuild(LiquidSource _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LiquidSource.LiquidSourceBuild liquidSourceBuild = this;
        this.source = (Liquid) null;
      }

      [LineNumberTable(new byte[] {2, 104, 141, 124, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.source == null)
        {
          this.liquids.clear();
        }
        else
        {
          this.liquids.add(this.source, this.this\u00240.liquidCapacity);
          this.dumpLiquid(this.source);
        }
      }

      [LineNumberTable(new byte[] {12, 134, 104, 152, 112, 118, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.source == null)
        {
          Draw.rect("cross", this.x, this.y);
        }
        else
        {
          Draw.color(this.source.color);
          Draw.rect("center", this.x, this.y);
          Draw.color();
        }
      }

      [LineNumberTable(new byte[] {25, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => ItemSelection.buildTable(table, Vars.content.liquids(), (Prov) new LiquidSource.LiquidSourceBuild.__\u003C\u003EAnon0(this), (Cons) new LiquidSource.LiquidSourceBuild.__\u003C\u003EAnon1(this));

      [LineNumberTable(new byte[] {30, 105, 102, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (!object.ReferenceEquals((object) this, (object) other))
          return true;
        this.deselect();
        this.configure((object) null);
        return false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {51, 103, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.s(this.source != null ? (int) this.source.__\u003C\u003Eid : -1);
      }

      [LineNumberTable(new byte[] {159, 116, 163, 104, 116, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        int id = num != 1 ? (int) (sbyte) read.b() : (int) read.s();
        this.source = id != -1 ? Vars.content.liquid(id) : (Liquid) null;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static LiquidSourceBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly LiquidSource.LiquidSourceBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] LiquidSource.LiquidSourceBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LiquidSource.LiquidSourceBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] LiquidSource.LiquidSourceBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.configure((object) (Liquid) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => LiquidSource.lambda\u0024new\u00240((LiquidSource.LiquidSourceBuild) obj0, (Liquid) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => LiquidSource.lambda\u0024new\u00241((LiquidSource.LiquidSourceBuild) obj0);
    }
  }
}
