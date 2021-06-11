// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.CommandCenter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.units
{
  public class CommandCenter : Block
  {
    public TextureRegionDrawable[] commandRegions;
    public Color topColor;
    public Color bottomColor;
    public Effect effect;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 113, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] CommandCenter.CommandBuild obj0, [In] UnitCommand obj1)
    {
      obj0.team.data().command = obj1;
      this.effect.at((Position) obj0);
      Events.fire((object) new EventType.CommandIssueEvent((Building) obj0, obj1));
    }

    [LineNumberTable(new byte[] {159, 170, 233, 59, 113, 119, 235, 69, 121, 103, 103, 103, 135, 246, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CommandCenter(string name)
      : base(name)
    {
      CommandCenter commandCenter = this;
      this.commandRegions = new TextureRegionDrawable[UnitCommand.__\u003C\u003Eall.Length];
      this.topColor = (Color) null;
      this.bottomColor = Color.valueOf("5e5e5e");
      this.effect = Fx.__\u003C\u003EcommandSend;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Erally
      });
      this.destructible = true;
      this.solid = true;
      this.configurable = true;
      this.drawDisabled = false;
      this.config((Class) ClassLiteral<UnitCommand>.Value, (Cons2) new CommandCenter.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 187, 134, 106, 115, 63, 33, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      if (Vars.ui == null)
        return;
      UnitCommand[] all = UnitCommand.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        UnitCommand unitCommand = all[index];
        this.commandRegions[unitCommand.ordinal()] = Vars.ui.getIcon(new StringBuilder().append("command").append(Strings.capitalize(unitCommand.name())).toString(), "cancel");
      }
    }

    [HideFromJava]
    static CommandCenter() => Block.__\u003Cclinit\u003E();

    public class CommandBuild : Building
    {
      [Modifiers]
      internal CommandCenter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {31, 127, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00240([In] UnitCommand obj0)
      {
        if (object.ReferenceEquals((object) this.team.data().command, (object) obj0))
          return;
        this.configure((object) obj0);
      }

      [Modifiers]
      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00241([In] UnitCommand obj0, [In] ImageButton obj1) => obj1.setChecked(object.ReferenceEquals((object) this.team.data().command, (object) obj0));

      [Modifiers]
      [LineNumberTable(86)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024buildConfiguration\u00242()
      {
        object obj = (object) this.team.data().command.localized();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CommandBuild(CommandCenter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(58)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object config() => (object) this.team.data().command;

      [LineNumberTable(new byte[] {13, 134, 134, 112, 127, 45, 127, 11, 127, 38, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        float num = 6f;
        Draw.color(this.this\u00240.bottomColor);
        Draw.rect(this.this\u00240.commandRegions[this.team.data().command.ordinal()].getRegion(), this.tile.drawx(), this.tile.drawy() - 1f, num, num);
        Draw.color(this.this\u00240.topColor != null ? this.this\u00240.topColor : this.team.__\u003C\u003Ecolor);
        Draw.rect(this.this\u00240.commandRegions[this.team.data().command.ordinal()].getRegion(), this.tile.drawx(), this.tile.drawy(), num, num);
        Draw.color();
      }

      [LineNumberTable(new byte[] {26, 102, 134, 119, 159, 17, 254, 61, 232, 69, 104, 103, 127, 22})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table)
      {
        ButtonGroup group = new ButtonGroup();
        Table table1 = new Table();
        UnitCommand[] all = UnitCommand.__\u003C\u003Eall;
        int length = all.Length;
        for (int index = 0; index < length; ++index)
        {
          UnitCommand unitCommand = all[index];
          table1.button((Drawable) this.this\u00240.commandRegions[unitCommand.ordinal()], Styles.clearToggleTransi, (Runnable) new CommandCenter.CommandBuild.__\u003C\u003EAnon0(this, unitCommand)).size(44f).group(group).update((Cons) new CommandCenter.CommandBuild.__\u003C\u003EAnon1(this, unitCommand));
        }
        table.add((Element) table1);
        table.row();
        ((Label) table.label((Prov) new CommandCenter.CommandBuild.__\u003C\u003EAnon2(this)).style((Style) Styles.outlineLabel).center().growX().get()).setAlignment(1);
      }

      [LineNumberTable(new byte[] {41, 103, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.b(this.team.data().command.ordinal());
      }

      [LineNumberTable(new byte[] {159, 118, 99, 104, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte version)
      {
        int num = (int) (sbyte) version;
        base.read(read, (byte) num);
        this.team.data().command = UnitCommand.__\u003C\u003Eall[(int) (sbyte) read.b()];
      }

      [HideFromJava]
      static CommandBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly CommandCenter.CommandBuild arg\u00241;
        private readonly UnitCommand arg\u00242;

        internal __\u003C\u003EAnon0([In] CommandCenter.CommandBuild obj0, [In] UnitCommand obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00240(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly CommandCenter.CommandBuild arg\u00241;
        private readonly UnitCommand arg\u00242;

        internal __\u003C\u003EAnon1([In] CommandCenter.CommandBuild obj0, [In] UnitCommand obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildConfiguration\u00241(this.arg\u00242, (ImageButton) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Prov
      {
        private readonly CommandCenter.CommandBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] CommandCenter.CommandBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00242().__\u003Cref\u003E;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly CommandCenter arg\u00241;

      internal __\u003C\u003EAnon0([In] CommandCenter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00240((CommandCenter.CommandBuild) obj0, (UnitCommand) obj1);
    }
  }
}
