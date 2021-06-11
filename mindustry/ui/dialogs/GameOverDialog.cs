// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.GameOverDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.ui;
using arc.scene.ui.layout;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.core;
using mindustry.game;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class GameOverDialog : BaseDialog
  {
    private Team winner;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 103, 103, 114, 140, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Team winner)
    {
      this.winner = winner;
      this.show();
      if (object.ReferenceEquals((object) winner, (object) Vars.player.team()))
        Events.fire((object) new EventType.WinEvent());
      else
        Events.fire((object) new EventType.LoseEvent());
    }

    [LineNumberTable(new byte[] {159, 158, 109, 103, 145, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GameOverDialog()
      : base("@gameover")
    {
      GameOverDialog gameOverDialog = this;
      this.setFillParent(true);
      this.shown((Runnable) new GameOverDialog.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new GameOverDialog.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {159, 176, 127, 20, 107, 139, 145, 127, 0, 127, 42, 191, 6, 139, 108, 127, 12, 172, 250, 91, 134, 108, 108, 255, 6, 69, 136, 191, 6, 168, 191, 6, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuild()
    {
      Label title = this.__\u003C\u003Etitle;
      object obj1 = !Vars.state.isCampaign() ? (object) "@gameover" : (object) "@sector.curlost";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence newText = charSequence;
      title.setText(newText);
      this.__\u003C\u003Ebuttons.clear();
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Ebuttons.margin(10f);
      if (Vars.state.rules.pvp && this.winner != null)
      {
        Table cont = this.__\u003C\u003Econt;
        object obj2 = (object) Core.bundle.format("gameover.pvp", (object) this.winner.localized());
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text = charSequence;
        cont.add(text).pad(6f);
        this.__\u003C\u003Ebuttons.button("@menu", (Runnable) new GameOverDialog.__\u003C\u003EAnon2(this)).size(130f, 60f);
      }
      else
      {
        if (Vars.control.isHighScore())
        {
          Table cont = this.__\u003C\u003Econt;
          object obj2 = (object) "@highscore";
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          CharSequence text = charSequence;
          cont.add(text).pad(6f);
          this.__\u003C\u003Econt.row();
        }
        this.__\u003C\u003Econt.pane((Cons) new GameOverDialog.__\u003C\u003EAnon3()).pad(12f);
        if (Vars.state.isCampaign())
        {
          if (Vars.net.client())
            this.__\u003C\u003Ebuttons.button("@gameover.disconnect", (Runnable) new GameOverDialog.__\u003C\u003EAnon4(this)).size(170f, 60f);
          else
            this.__\u003C\u003Ebuttons.button("@continue", (Runnable) new GameOverDialog.__\u003C\u003EAnon5(this)).size(170f, 60f);
        }
        else
          this.__\u003C\u003Ebuttons.button("@menu", (Runnable) new GameOverDialog.__\u003C\u003EAnon6(this)).size(140f, 60f);
      }
    }

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ResetEvent obj0) => this.hide();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00241()
    {
      this.hide();
      Vars.logic.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 108, 113, 127, 40, 127, 40, 127, 40, 127, 40, 127, 40, 113, 159, 40, 127, 9, 127, 1, 127, 5, 121, 177, 138, 162, 120, 191, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00243([In] Table obj0)
    {
      obj0.margin(13f);
      obj0.left().defaults().left();
      Table table1 = obj0;
      object obj1 = (object) Core.bundle.format("stat.wave", (object) Integer.valueOf(Vars.state.stats.wavesLasted));
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence text1 = charSequence;
      table1.add(text1).row();
      Table table2 = obj0;
      object obj2 = (object) Core.bundle.format("stat.enemiesDestroyed", (object) Integer.valueOf(Vars.state.stats.enemyUnitsDestroyed));
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text2 = charSequence;
      table2.add(text2).row();
      Table table3 = obj0;
      object obj3 = (object) Core.bundle.format("stat.built", (object) Integer.valueOf(Vars.state.stats.buildingsBuilt));
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text3 = charSequence;
      table3.add(text3).row();
      Table table4 = obj0;
      object obj4 = (object) Core.bundle.format("stat.destroyed", (object) Integer.valueOf(Vars.state.stats.buildingsDestroyed));
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text4 = charSequence;
      table4.add(text4).row();
      Table table5 = obj0;
      object obj5 = (object) Core.bundle.format("stat.deconstructed", (object) Integer.valueOf(Vars.state.stats.buildingsDeconstructed));
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text5 = charSequence;
      table5.add(text5).row();
      if (Vars.control.saves.getCurrent() != null)
      {
        Table table6 = obj0;
        object obj6 = (object) Core.bundle.format("stat.playtime", (object) Vars.control.saves.getCurrent().getPlayTime());
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence text6 = charSequence;
        table6.add(text6).row();
      }
      if (Vars.state.isCampaign() && !Vars.state.stats.itemsDelivered.isEmpty())
      {
        Table table6 = obj0;
        object obj6 = (object) "@stat.delivered";
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence text6 = charSequence;
        table6.add(text6).row();
        Iterator iterator = Vars.content.items().iterator();
        while (iterator.hasNext())
        {
          Item obj7 = (Item) iterator.next();
          if (Vars.state.stats.itemsDelivered.get((object) obj7, 0) > 0)
            obj0.table((Cons) new GameOverDialog.__\u003C\u003EAnon7(obj7)).left().row();
        }
      }
      if (!Vars.state.isCampaign() || !Vars.net.client())
        return;
      Table table7 = obj0;
      object obj8 = (object) "@gameover.waiting";
      charSequence.__\u003Cref\u003E = (__Null) obj8;
      CharSequence text7 = charSequence;
      table7.add(text7).padTop(20f).row();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 106, 106, 102, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00244()
    {
      Vars.logic.reset();
      Vars.net.reset();
      this.hide();
      Vars.state.set(GameState.State.__\u003C\u003Emenu);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00245()
    {
      this.hide();
      Vars.ui.planet.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00246()
    {
      this.hide();
      Vars.logic.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {18, 127, 39, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00242([In] Item obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) new StringBuilder().append("    [lightgray]").append(Vars.state.stats.itemsDelivered.get((object) obj0, 0)).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
      obj1.image(obj0.icon(Cicon.__\u003C\u003Esmall)).size(24f).pad(4f);
    }

    [HideFromJava]
    static GameOverDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuild();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => GameOverDialog.lambda\u0024rebuild\u00243((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00245();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly GameOverDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] GameOverDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00246();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Item arg\u00241;

      internal __\u003C\u003EAnon7([In] Item obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => GameOverDialog.lambda\u0024rebuild\u00242(this.arg\u00241, (Table) obj0);
    }
  }
}
