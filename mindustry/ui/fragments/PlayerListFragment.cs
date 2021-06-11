// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.PlayerListFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using mindustry.net;
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class PlayerListFragment : Fragment
  {
    public Table content;
    private bool visible;
    private Interval timer;
    private TextField sField;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Player;>;")]
    private Seq players;

    [LineNumberTable(new byte[] {159, 161, 104, 127, 0, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlayerListFragment()
    {
      PlayerListFragment playerListFragment = this;
      this.content = new Table().marginRight(13f).marginLeft(13f);
      this.visible = false;
      this.timer = new Interval();
      this.players = new Seq();
    }

    [LineNumberTable(new byte[] {159, 170, 112, 241, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.content.name = "players";
      parent.fill((Cons) new PlayerListFragment.__\u003C\u003EAnon0(this));
      this.rebuild();
    }

    [LineNumberTable(new byte[] {127, 114, 104, 136, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle()
    {
      this.visible = !this.visible;
      if (this.visible)
      {
        this.rebuild();
      }
      else
      {
        Core.scene.setKeyboardFocus((Element) null);
        this.sField.clearText();
      }
    }

    [LineNumberTable(new byte[] {27, 139, 102, 130, 108, 145, 159, 16, 127, 4, 98, 136, 121, 159, 119, 103, 104, 151, 232, 75, 109, 127, 3, 141, 112, 127, 59, 141, 159, 22, 127, 27, 141, 138, 251, 91, 118, 127, 41, 141, 253, 69, 166, 127, 16, 108, 127, 36, 108, 133, 99, 191, 53, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild()
    {
      this.content.clear();
      float size = 74f;
      int num = 0;
      this.players.clear();
      Groups.player.copy(this.players);
      this.players.sort(Structs.comps(Structs.comparing((Func) new PlayerListFragment.__\u003C\u003EAnon1()), Structs.comparingBool((Boolf) new PlayerListFragment.__\u003C\u003EAnon2())));
      Iterator iterator = this.players.iterator();
      CharSequence str1;
      while (iterator.hasNext())
      {
        Player player = (Player) iterator.next();
        num = 1;
        NetConnection con = player.con;
        if (con == null && Vars.net.server() && !player.isLocal())
          return;
        if (String.instancehelper_length(this.sField.getText()) > 0)
        {
          string lowerCase1 = String.instancehelper_toLowerCase(player.name());
          object lowerCase2 = (object) String.instancehelper_toLowerCase(this.sField.getText());
          str1.__\u003Cref\u003E = (__Null) lowerCase2;
          CharSequence charSequence1 = str1;
          if (!String.instancehelper_contains(lowerCase1, charSequence1))
          {
            object lowerCase3 = (object) String.instancehelper_toLowerCase(player.name());
            str1.__\u003Cref\u003E = (__Null) lowerCase3;
            string str2 = Strings.stripColors(str1);
            object lowerCase4 = (object) String.instancehelper_toLowerCase(this.sField.getText());
            str1.__\u003Cref\u003E = (__Null) lowerCase4;
            CharSequence charSequence2 = str1;
            if (!String.instancehelper_contains(str2, charSequence2))
              return;
          }
        }
        Table table = new Table();
        table.left();
        table.margin(5f).marginBottom(10f);
        PlayerListFragment.\u0031 obj = new PlayerListFragment.\u0031(this);
        obj.margin(8f);
        obj.add((Element) new Image(player.icon()).setScaling(Scaling.__\u003C\u003Ebounded)).grow();
        obj.name = player.name();
        table.add((Element) obj).size(size);
        table.labelWrap(new StringBuilder().append("[#").append(String.instancehelper_toUpperCase(player.color().toString())).append("]").append(player.name()).toString()).width(170f).pad(10f);
        table.add().grow();
        table.image((Drawable) Icon.admin).visible((Boolp) new PlayerListFragment.__\u003C\u003EAnon3(player)).padRight(5f).get().updateVisibility();
        if ((Vars.net.server() || Vars.player.admin) && !player.isLocal() && (!player.admin || Vars.net.server()))
        {
          table.add().growY();
          float height = size / 2f;
          table.table((Cons) new PlayerListFragment.__\u003C\u003EAnon4(height, player, con)).padRight(12f).size(height + 10f, height);
        }
        else if (!player.isLocal() && !player.admin && (Vars.net.client() && Groups.player.size() >= 3) && object.ReferenceEquals((object) Vars.player.team(), (object) player.team()))
        {
          table.add().growY();
          table.button((Drawable) Icon.hammer, Styles.clearPartiali, (Runnable) new PlayerListFragment.__\u003C\u003EAnon5(player)).size(size);
        }
        this.content.add((Element) table).padBottom(-6f).width(350f).maxHeight(size + 14f);
        this.content.row();
        this.content.image().height(4f).color(!Vars.state.rules.pvp ? Pal.gray : player.team().__\u003C\u003Ecolor).growX();
        this.content.row();
      }
      if (num == 0)
      {
        Table content = this.content;
        object obj = (object) Core.bundle.format("players.notfound");
        str1.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = str1;
        content.add(text).padBottom(6f).width(350f).maxHeight(size + 14f);
      }
      this.content.marginBottom(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 107, 114, 242, 79, 251, 87, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00248([In] Table obj0)
    {
      obj0.name = "playerlist";
      obj0.visible((Boolp) new PlayerListFragment.__\u003C\u003EAnon18(this));
      obj0.update((Runnable) new PlayerListFragment.__\u003C\u003EAnon19(this));
      obj0.table((Drawable) Tex.buttonTrans, (Cons) new PlayerListFragment.__\u003C\u003EAnon20(this)).touchable(Touchable.__\u003C\u003Eenabled).margin(14f).minWidth(360f);
    }

    [Modifiers]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00249([In] Player obj0) => !obj0.admin;

    [Modifiers]
    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u002410([In] Player obj0) => obj0.admin && (obj0.isLocal() || !Vars.net.server());

    [Modifiers]
    [LineNumberTable(new byte[] {75, 142, 156, 188, 135, 255, 8, 74, 111, 111, 107, 134, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002422(
      [In] float obj0,
      [In] Player obj1,
      [In] NetConnection obj2,
      [In] Table obj3)
    {
      obj3.defaults().size(obj0);
      obj3.button((Drawable) Icon.hammer, Styles.clearPartiali, (Runnable) new PlayerListFragment.__\u003C\u003EAnon7(obj1));
      obj3.button((Drawable) Icon.cancel, Styles.clearPartiali, (Runnable) new PlayerListFragment.__\u003C\u003EAnon8(obj1));
      obj3.row();
      obj3.button((Drawable) Icon.admin, Styles.clearTogglePartiali, (Runnable) new PlayerListFragment.__\u003C\u003EAnon9(obj1, obj2)).update((Cons) new PlayerListFragment.__\u003C\u003EAnon10(obj1)).disabled((Boolf) new PlayerListFragment.__\u003C\u003EAnon11()).touchable((Prov) new PlayerListFragment.__\u003C\u003EAnon12()).@checked(obj1.admin);
      obj3.button((Drawable) Icon.zoom, Styles.clearPartiali, (Runnable) new PlayerListFragment.__\u003C\u003EAnon13(obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {107, 191, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002424([In] Player obj0) => Vars.ui.showConfirm("@confirm", Core.bundle.format("confirmvotekick", (object) obj0.name()), (Runnable) new PlayerListFragment.__\u003C\u003EAnon6(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {108, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002423([In] Player obj0) => Call.sendChatMessage(new StringBuilder().append("/votekick ").append(obj0.name()).toString());

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002412([In] Player obj0) => Vars.ui.showConfirm("@confirm", Core.bundle.format("confirmban", (object) obj0.name()), (Runnable) new PlayerListFragment.__\u003C\u003EAnon17(obj0));

    [Modifiers]
    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002414([In] Player obj0) => Vars.ui.showConfirm("@confirm", Core.bundle.format("confirmkick", (object) obj0.name()), (Runnable) new PlayerListFragment.__\u003C\u003EAnon16(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {85, 141, 135, 120, 159, 27, 159, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002417([In] Player obj0, [In] NetConnection obj1)
    {
      if (Vars.net.client())
        return;
      string id = obj0.uuid();
      if (Vars.netServer.__\u003C\u003Eadmins.isAdmin(id, obj1.__\u003C\u003Eaddress))
        Vars.ui.showConfirm("@confirm", Core.bundle.format("confirmunadmin", (object) obj0.name()), (Runnable) new PlayerListFragment.__\u003C\u003EAnon14(id));
      else
        Vars.ui.showConfirm("@confirm", Core.bundle.format("confirmadmin", (object) obj0.name()), (Runnable) new PlayerListFragment.__\u003C\u003EAnon15(id, obj0));
    }

    [Modifiers]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002418([In] Player obj0, [In] ImageButton obj1) => obj1.setChecked(obj0.admin);

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u002419([In] ImageButton obj0) => Vars.net.client();

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Touchable lambda\u0024rebuild\u002420() => Vars.net.client() ? Touchable.__\u003C\u003Edisabled : Touchable.__\u003C\u003Eenabled;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002421([In] Player obj0) => Call.adminRequest(obj0, Packets.AdminAction.__\u003C\u003Etrace);

    [Modifiers]
    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002415([In] string obj0) => Vars.netServer.__\u003C\u003Eadmins.unAdminPlayer(obj0);

    [Modifiers]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002416([In] string obj0, [In] Player obj1) => Vars.netServer.__\u003C\u003Eadmins.adminPlayer(obj0, obj1.usid());

    [Modifiers]
    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002413([In] Player obj0) => Call.adminRequest(obj0, Packets.AdminAction.__\u003C\u003Ekick);

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u002411([In] Player obj0) => Call.adminRequest(obj0, Packets.AdminAction.__\u003C\u003Eban);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00240() => this.visible;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 120, 103, 161, 122, 102, 107, 150, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241()
    {
      if (!Vars.net.active() || !Vars.state.isGame())
      {
        this.visible = false;
      }
      else
      {
        if (!this.visible || !this.timer.get(20f))
          return;
        this.rebuild();
        this.content.pack();
        this.content.act(Core.graphics.getDeltaTime());
        Core.scene.act(0.0f);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 113, 103, 147, 126, 112, 109, 159, 1, 103, 127, 3, 135, 246, 71, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00247([In] Table obj0)
    {
      obj0.label((Prov) new PlayerListFragment.__\u003C\u003EAnon21());
      obj0.row();
      this.sField = (TextField) obj0.field((string) null, (Cons) new PlayerListFragment.__\u003C\u003EAnon22(this)).grow().pad(8f).get();
      this.sField.name = "search";
      this.sField.setMaxLength(40);
      this.sField.setMessageText(Core.bundle.format("players.search"));
      obj0.row();
      ((ScrollPane) obj0.pane((Element) this.content).grow().get()).setScrollingDisabled(true, false);
      obj0.row();
      obj0.table((Cons) new PlayerListFragment.__\u003C\u003EAnon23(this)).margin(0.0f).pad(10f).growX();
    }

    [Modifiers]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u00242()
    {
      object obj = (object) Core.bundle.format(Groups.player.size() != 1 ? "players" : "players.single", (object) Integer.valueOf(Groups.player.size()));
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00243([In] string obj0) => this.rebuild();

    [Modifiers]
    [LineNumberTable(new byte[] {12, 123, 139, 127, 23, 127, 23, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00246([In] Table obj0)
    {
      obj0.defaults().growX().height(50f).fillY();
      obj0.name = "menu";
      Table table1 = obj0;
      BansDialog bans = Vars.ui.bans;
      Objects.requireNonNull((object) bans);
      Runnable listener1 = (Runnable) new PlayerListFragment.__\u003C\u003EAnon24(bans);
      table1.button("@server.bans", listener1).disabled((Boolf) new PlayerListFragment.__\u003C\u003EAnon25());
      Table table2 = obj0;
      AdminsDialog admins = Vars.ui.admins;
      Objects.requireNonNull((object) admins);
      Runnable listener2 = (Runnable) new PlayerListFragment.__\u003C\u003EAnon26(admins);
      table2.button("@server.admins", listener2).disabled((Boolf) new PlayerListFragment.__\u003C\u003EAnon27());
      obj0.button("@close", (Runnable) new PlayerListFragment.__\u003C\u003EAnon28(this));
    }

    [Modifiers]
    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00244([In] TextButton obj0) => Vars.net.client();

    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00245([In] TextButton obj0) => Vars.net.client();

    [EnclosingMethod(null, "rebuild", "()V")]
    [SpecialName]
    internal class \u0031 : Table
    {
      [Modifiers]
      internal PlayerListFragment this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(98)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] PlayerListFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {51, 102, 106, 107, 112, 125, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.color(Pal.gray);
        Draw.alpha(this.parentAlpha);
        Lines.stroke(Scl.scl(4f));
        Lines.rect(this.x, this.y, this.width, this.height);
        Draw.reset();
      }

      [HideFromJava]
      static \u0031() => Table.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00248((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Func
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get([In] object obj0) => (object) ((Player) obj0).team();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (PlayerListFragment.lambda\u0024rebuild\u00249((Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon3([In] Player obj0) => this.arg\u00241 = obj0;

      public bool get() => (PlayerListFragment.lambda\u0024rebuild\u002410(this.arg\u00241) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly float arg\u00241;
      private readonly Player arg\u00242;
      private readonly NetConnection arg\u00243;

      internal __\u003C\u003EAnon4([In] float obj0, [In] Player obj1, [In] NetConnection obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => PlayerListFragment.lambda\u0024rebuild\u002422(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon5([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002424(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon6([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002423(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon7([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002412(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon8([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002414(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Player arg\u00241;
      private readonly NetConnection arg\u00242;

      internal __\u003C\u003EAnon9([In] Player obj0, [In] NetConnection obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002417(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon10([In] Player obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlayerListFragment.lambda\u0024rebuild\u002418(this.arg\u00241, (ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolf
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public bool get([In] object obj0) => (PlayerListFragment.lambda\u0024rebuild\u002419((ImageButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) PlayerListFragment.lambda\u0024rebuild\u002420();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon13([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002421(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon14([In] string obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002415(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly string arg\u00241;
      private readonly Player arg\u00242;

      internal __\u003C\u003EAnon15([In] string obj0, [In] Player obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002416(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon16([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002413(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon17([In] Player obj0) => this.arg\u00241 = obj0;

      public void run() => PlayerListFragment.lambda\u0024rebuild\u002411(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Boolp
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon18([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon19([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon20([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00247((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Prov
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public object get() => (object) PlayerListFragment.lambda\u0024build\u00242().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon22([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon23([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00246((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly BansDialog arg\u00241;

      internal __\u003C\u003EAnon24([In] BansDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Boolf
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public bool get([In] object obj0) => (PlayerListFragment.lambda\u0024build\u00244((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly AdminsDialog arg\u00241;

      internal __\u003C\u003EAnon26([In] AdminsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Boolf
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public bool get([In] object obj0) => (PlayerListFragment.lambda\u0024build\u00245((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      private readonly PlayerListFragment arg\u00241;

      internal __\u003C\u003EAnon28([In] PlayerListFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.toggle();
    }
  }
}
