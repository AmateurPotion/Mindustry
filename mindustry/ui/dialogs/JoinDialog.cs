// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.JoinDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.input;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io.legacy;
using mindustry.net;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class JoinDialog : BaseDialog
  {
    [Signature("Larc/struct/Seq<Lmindustry/ui/dialogs/JoinDialog$Server;>;")]
    internal Seq servers;
    internal Dialog add;
    internal JoinDialog.Server renaming;
    internal Table local;
    internal Table remote;
    internal Table global;
    internal Table hosts;
    internal int totalHosts;
    internal int refreshes;
    internal bool showHidden;
    internal string lastIp;
    internal int lastPort;
    internal Timer.Task ping;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 79, 118, 111, 161, 148, 249, 69, 248, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(string ip, int port)
    {
      if (String.instancehelper_isEmpty(String.instancehelper_trim(Vars.player.name)))
      {
        Vars.ui.showInfo("@noname");
      }
      else
      {
        Vars.ui.loadfrag.show("@connecting");
        Vars.ui.loadfrag.setButton((Runnable) new JoinDialog.__\u003C\u003EAnon34());
        Time.runTask(2f, (Runnable) new JoinDialog.__\u003C\u003EAnon35(this, ip, port));
      }
    }

    [LineNumberTable(new byte[] {161, 105, 118, 148, 255, 1, 73, 250, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reconnect()
    {
      if (this.lastIp == null || String.instancehelper_isEmpty(this.lastIp))
        return;
      Vars.ui.loadfrag.show("@reconnecting");
      this.ping = Timer.schedule((Runnable) new JoinDialog.__\u003C\u003EAnon36(this), 1f, 1f);
      Vars.ui.loadfrag.setButton((Runnable) new JoinDialog.__\u003C\u003EAnon37(this));
    }

    [LineNumberTable(new byte[] {159, 185, 237, 48, 171, 107, 107, 107, 235, 76, 134, 125, 155, 134, 123, 103, 191, 21, 112, 159, 22, 159, 20, 156, 113, 127, 11, 127, 14, 255, 11, 76, 134, 247, 71, 150, 241, 73, 209})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JoinDialog()
      : base("@joingame")
    {
      JoinDialog joinDialog = this;
      this.servers = new Seq();
      this.local = new Table();
      this.remote = new Table();
      this.global = new Table();
      this.hosts = new Table();
      this.loadServers();
      if (!Vars.steam)
        this.__\u003C\u003Ebuttons.add().width(60f);
      this.__\u003C\u003Ebuttons.add().growX().width(-1f);
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.add().growX().width(-1f);
      if (!Vars.steam)
        this.__\u003C\u003Ebuttons.button("?", (Runnable) new JoinDialog.__\u003C\u003EAnon0()).size(60f, 64f).width(-1f);
      this.add = (Dialog) new BaseDialog("@joingame.title");
      Table cont = this.add.__\u003C\u003Econt;
      object obj = (object) "@joingame.ip";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      cont.add(text).padRight(5f).left();
      TextField textField = (TextField) this.add.__\u003C\u003Econt.field(Core.settings.getString("ip"), (Cons) new JoinDialog.__\u003C\u003EAnon1()).size(320f, 54f).maxTextLength(100).addInputDialog().get();
      this.add.__\u003C\u003Econt.row();
      this.add.__\u003C\u003Ebuttons.defaults().size(140f, 60f).pad(4f);
      Table buttons = this.add.__\u003C\u003Ebuttons;
      Dialog add = this.add;
      Objects.requireNonNull((object) add);
      Runnable listener = (Runnable) new JoinDialog.__\u003C\u003EAnon2(add);
      buttons.button("@cancel", listener);
      this.add.__\u003C\u003Ebuttons.button("@ok", (Runnable) new JoinDialog.__\u003C\u003EAnon3(this)).disabled((Boolf) new JoinDialog.__\u003C\u003EAnon4());
      this.add.shown((Runnable) new JoinDialog.__\u003C\u003EAnon5(this, textField));
      this.keyDown(KeyCode.__\u003C\u003Ef5, (Runnable) new JoinDialog.__\u003C\u003EAnon6(this));
      this.shown((Runnable) new JoinDialog.__\u003C\u003EAnon7(this));
      this.onResize((Runnable) new JoinDialog.__\u003C\u003EAnon8(this));
    }

    [LineNumberTable(new byte[] {161, 140, 191, 15, 113, 107, 175, 121, 180, 255, 0, 96})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loadServers()
    {
      this.servers = (Seq) Core.settings.getJson("servers", (Class) ClassLiteral<Seq>.Value, (Class) ClassLiteral<JoinDialog.Server>.Value, (Prov) new JoinDialog.__\u003C\u003EAnon38());
      if (Core.settings.has("server-list"))
      {
        this.servers = LegacyIO.readServers();
        Core.settings.remove("server-list");
      }
      string url = !Vars.becontrol.active() ? "https://raw.githubusercontent.com/Anuken/Mindustry/master/servers_v6.json" : "https://raw.githubusercontent.com/Anuken/Mindustry/master/servers_be.json";
      Log.info("Fetching community servers at @", (object) url);
      Core.net.httpGet(url, (Cons) new JoinDialog.__\u003C\u003EAnon39(), (Cons) new JoinDialog.__\u003C\u003EAnon40());
    }

    [LineNumberTable(new byte[] {160, 226, 135, 107, 109, 127, 1, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshLocal()
    {
      this.totalHosts = 0;
      this.local.clear();
      this.local.background((Drawable) null);
      this.local.table((Drawable) Tex.button, (Cons) new JoinDialog.__\u003C\u003EAnon24()).growX();
      Vars.net.discoverServers((Cons) new JoinDialog.__\u003C\u003EAnon25(this), (Runnable) new JoinDialog.__\u003C\u003EAnon26(this));
    }

    [LineNumberTable(new byte[] {160, 82, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshRemote()
    {
      Iterator iterator = this.servers.iterator();
      while (iterator.hasNext())
        this.refreshServer((JoinDialog.Server) iterator.next());
    }

    [LineNumberTable(new byte[] {160, 235, 135, 107, 109, 127, 3, 103, 107, 162, 172, 127, 1, 127, 21, 127, 29, 255, 11, 61, 235, 100, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshGlobal()
    {
      int refreshes = this.refreshes;
      this.global.clear();
      this.global.background((Drawable) null);
      Iterator iterator = Vars.__\u003C\u003EdefaultServers.iterator();
label_1:
      while (iterator.hasNext())
      {
        ServerGroup serverGroup = (ServerGroup) iterator.next();
        int num = serverGroup.hidden() ? 1 : 0;
        if (num == 0 || this.showHidden)
        {
          Table[] tableArray = new Table[1]
          {
            (Table) null
          };
          string[] addresses = serverGroup.addresses;
          int length = addresses.Length;
          int index = 0;
          while (true)
          {
            if (index < length)
            {
              string str1 = addresses[index];
              string str2 = str1;
              object obj1 = (object) ":";
              CharSequence charSequence1;
              charSequence1.__\u003Cref\u003E = (__Null) obj1;
              CharSequence charSequence2 = charSequence1;
              string address = !String.instancehelper_contains(str2, charSequence2) ? str1 : String.instancehelper_split(str1, ":")[0];
              string str3 = str1;
              object obj2 = (object) ":";
              charSequence1.__\u003Cref\u003E = (__Null) obj2;
              CharSequence charSequence3 = charSequence1;
              int port = !String.instancehelper_contains(str3, charSequence3) ? 6567 : Strings.parseInt(String.instancehelper_split(str1, ":")[1]);
              Vars.net.pingHost(address, port, (Cons) new JoinDialog.__\u003C\u003EAnon27(this, refreshes, port, tableArray, serverGroup, num != 0), (Cons) new JoinDialog.__\u003C\u003EAnon28());
              ++index;
            }
            else
              goto label_1;
          }
        }
      }
    }

    [LineNumberTable(505)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float targetWidth() => Math.min((float) Core.graphics.getWidth() / Scl.scl() * 0.9f, 500f);

    [LineNumberTable(new byte[] {161, 187, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void saveServers() => Core.settings.putJson("servers", (Class) ClassLiteral<JoinDialog.Server>.Value, (object) this.servers);

    [LineNumberTable(new byte[] {64, 139, 159, 4, 139, 255, 32, 73, 159, 14, 141, 103, 103, 143, 148, 191, 3, 154, 191, 3, 159, 5, 159, 3, 159, 5, 191, 3, 159, 5, 255, 3, 71, 159, 5, 136, 159, 7, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setupRemote()
    {
      this.remote.clear();
      Iterator iterator = this.servers.iterator();
      while (iterator.hasNext())
      {
        JoinDialog.Server server = (JoinDialog.Server) iterator.next();
        TextButton[] textButtonArray1 = new TextButton[1]
        {
          (TextButton) null
        };
        TextButton[] textButtonArray2 = textButtonArray1;
        TextButton textButton1 = (TextButton) this.remote.button(new StringBuilder().append("[accent]").append(server.displayIP()).toString(), Styles.cleart, (Runnable) new JoinDialog.__\u003C\u003EAnon9(this, textButtonArray1, server)).width(this.targetWidth()).pad(4f).get();
        int index = 0;
        TextButton[] textButtonArray3 = textButtonArray2;
        TextButton textButton2 = textButton1;
        textButtonArray3[index] = textButton1;
        TextButton textButton3 = textButton2;
        textButton3.getLabel().setWrap(true);
        Table table = new Table();
        textButton3.clearChildren();
        textButton3.add((Element) table).growX();
        table.add((Element) textButton3.getLabel()).growX();
        table.button((Drawable) Icon.upOpen, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon10(this, server)).margin(3f).padTop(6f).top().right();
        table.button((Drawable) Icon.downOpen, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon11(this, server)).margin(3f).pad(2f).padTop(6f).top().right();
        table.button((Drawable) Icon.refresh, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon12(this, server)).margin(3f).pad(2f).padTop(6f).top().right();
        table.button((Drawable) Icon.pencil, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon13(this, server)).margin(3f).pad(2f).padTop(6f).top().right();
        table.button((Drawable) Icon.trash, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon14(this, server)).margin(3f).pad(2f).pad(6f).top().right();
        textButton3.row();
        server.content = (Table) textButton3.table((Cons) new JoinDialog.__\u003C\u003EAnon15()).grow().get();
        this.remote.row();
      }
    }

    [LineNumberTable(new byte[] {160, 98, 103, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setupServer([In] JoinDialog.Server obj0, [In] Host obj1)
    {
      obj0.lastHost = obj1;
      obj0.content.clear();
      this.buildServer(obj1, obj0.content);
    }

    [LineNumberTable(new byte[] {160, 88, 107, 150, 223, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshServer([In] JoinDialog.Server obj0)
    {
      obj0.content.clear();
      obj0.content.label((Prov) new JoinDialog.__\u003C\u003EAnon16());
      Vars.net.pingHost(obj0.ip, obj0.port, (Cons) new JoinDialog.__\u003C\u003EAnon17(this, obj0), (Cons) new JoinDialog.__\u003C\u003EAnon18(obj0));
    }

    [LineNumberTable(new byte[] {160, 106, 105, 127, 22, 104, 117, 117, 127, 28, 127, 4, 117, 127, 28, 127, 1, 159, 0, 136, 191, 14, 243, 78, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void buildServer([In] Host obj0, [In] Table obj1)
    {
      string str;
      if (obj0.__\u003C\u003Eversion == -1)
        str = Core.bundle.format("server.version", (object) Core.bundle.get("server.custombuild"), (object) "");
      else if (obj0.__\u003C\u003Eversion == 0)
        str = Core.bundle.get("server.outdated");
      else if (obj0.__\u003C\u003Eversion < mindustry.core.Version.build && mindustry.core.Version.build != -1)
        str = new StringBuilder().append(Core.bundle.get("server.outdated")).append("\n").append(Core.bundle.format("server.version", (object) Integer.valueOf(obj0.__\u003C\u003Eversion), (object) "")).toString();
      else if (obj0.__\u003C\u003Eversion > mindustry.core.Version.build && mindustry.core.Version.build != -1)
        str = new StringBuilder().append(Core.bundle.get("server.outdated.client")).append("\n").append(Core.bundle.format("server.version", (object) Integer.valueOf(obj0.__\u003C\u003Eversion), (object) "")).toString();
      else if (obj0.__\u003C\u003Eversion == mindustry.core.Version.build && String.instancehelper_equals(mindustry.core.Version.type, (object) obj0.__\u003C\u003EversionType))
        str = "";
      else
        str = Core.bundle.format("server.version", (object) Integer.valueOf(obj0.__\u003C\u003Eversion), (object) obj0.__\u003C\u003EversionType);
      obj1.table((Cons) new JoinDialog.__\u003C\u003EAnon19(this, obj0, str)).expand().left().bottom().padLeft(12f).padBottom(8f);
    }

    [LineNumberTable(new byte[] {159, 64, 98, 127, 18, 140, 249, 79, 102, 108, 127, 36, 108, 121, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void section([In] string obj0, [In] Table obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      Collapser.__\u003Cclinit\u003E();
      Collapser collapser = new Collapser(obj1, Core.settings.getBool(new StringBuilder().append("collapsed-").append(obj0).toString(), false));
      collapser.setDuration(0.1f);
      this.hosts.table((Cons) new JoinDialog.__\u003C\u003EAnon23(this, obj0, num != 0, collapser)).growX();
      this.hosts.row();
      this.hosts.image().growX().pad(5f).padLeft(10f).padRight(10f).height(3f).color(Pal.accent);
      this.hosts.row();
      this.hosts.add((Element) collapser).width(this.targetWidth());
      this.hosts.row();
    }

    [LineNumberTable(new byte[] {161, 126, 125, 127, 52, 62, 167, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void safeConnect([In] string obj0, [In] int obj1, [In] int obj2)
    {
      if (obj2 != mindustry.core.Version.build && mindustry.core.Version.build != -1 && obj2 != -1)
        Vars.ui.showInfo(new StringBuilder().append("[scarlet]").append((obj2 <= mindustry.core.Version.build ? Packets.KickReason.__\u003C\u003EserverOutdated : Packets.KickReason.__\u003C\u003EclientOutdated).toString()).append("\n[]").append(Core.bundle.format("server.versions", (object) Integer.valueOf(mindustry.core.Version.build), (object) Integer.valueOf(obj2))).toString());
      else
        this.connect(obj0, obj1);
    }

    [LineNumberTable(new byte[] {161, 32, 109, 136, 255, 5, 76, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addGlobalHost([In] Host obj0, [In] Table obj1)
    {
      this.global.background((Drawable) null);
      float width = this.targetWidth();
      obj1.button((Cons) new JoinDialog.__\u003C\u003EAnon29(this, obj0), (Button.ButtonStyle) Styles.cleart, (Runnable) new JoinDialog.__\u003C\u003EAnon30(this, obj0)).width(width).row();
    }

    [LineNumberTable(new byte[] {126, 141, 103, 147, 109, 143, 102, 102, 127, 1, 104, 143, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void moveRemote([In] JoinDialog.Server obj0, [In] int obj1)
    {
      int index = this.servers.indexOf((object) obj0);
      if (index + obj1 < 0 || index + obj1 > this.servers.size - 1)
        return;
      this.servers.remove(index);
      this.servers.insert(index + obj1, (object) obj0);
      this.saveServers();
      this.setupRemote();
      Iterator iterator = this.servers.iterator();
      while (iterator.hasNext())
      {
        JoinDialog.Server server = (JoinDialog.Server) iterator.next();
        if (server.lastHost != null)
          this.setupServer(server, server.lastHost);
        else
          this.refreshServer(server);
      }
    }

    [LineNumberTable(new byte[] {160, 141, 107, 107, 107, 136, 139, 114, 114, 146, 113, 103, 136, 134, 107, 246, 78, 122, 108, 127, 5, 108, 191, 6, 255, 8, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.local.clear();
      this.remote.clear();
      this.global.clear();
      float width = this.targetWidth();
      this.hosts.clear();
      this.section("@servers.local", this.local, false);
      this.section("@servers.remote", this.remote, false);
      this.section("@servers.global", this.global, true);
      ScrollPane.__\u003Cclinit\u003E();
      ScrollPane scrollPane = new ScrollPane((Element) this.hosts);
      scrollPane.setFadeScrollBars(false);
      scrollPane.setScrollingDisabled(true, false);
      this.setupRemote();
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.table((Cons) new JoinDialog.__\u003C\u003EAnon20()).width(width).height(70f).pad(4f);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add((Element) scrollPane).width(width + 38f).pad(0.0f);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.buttonCenter("@server.add", (Drawable) Icon.add, (Runnable) new JoinDialog.__\u003C\u003EAnon21(this)).marginLeft(10f).width(width).height(80f).update((Cons) new JoinDialog.__\u003C\u003EAnon22(width, scrollPane));
    }

    [LineNumberTable(new byte[] {56, 142, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshAll()
    {
      ++this.refreshes;
      this.refreshLocal();
      this.refreshRemote();
      this.refreshGlobal();
    }

    [Modifiers]
    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240() => Vars.ui.showInfo("@join.info");

    [Modifiers]
    [LineNumberTable(new byte[] {11, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] string obj0) => Core.settings.put("ip", (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {18, 104, 102, 117, 108, 98, 154, 102, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242()
    {
      if (this.renaming == null)
      {
        JoinDialog.Server server = new JoinDialog.Server();
        server.setIP(Core.settings.getString("ip"));
        this.servers.add((object) server);
      }
      else
        this.renaming.setIP(Core.settings.getString("ip"));
      this.saveServers();
      this.setupRemote();
      this.refreshRemote();
      this.add.hide();
    }

    [Modifiers]
    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00243([In] TextButton obj0) => String.instancehelper_isEmpty(Core.settings.getString("ip")) || Vars.net.active();

    [Modifiers]
    [LineNumberTable(new byte[] {32, 127, 21, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] TextField obj0)
    {
      Label title = this.add.__\u003C\u003Etitle;
      object obj = this.renaming == null ? (object) "@server.add" : (object) "@server.edit";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence newText = charSequence;
      title.setText(newText);
      if (this.renaming == null)
        return;
      obj0.setText(this.renaming.displayIP());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 102, 134, 103, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00247()
    {
      this.setup();
      this.refreshAll();
      if (Vars.steam)
        return;
      Core.app.post((Runnable) new JoinDialog.__\u003C\u003EAnon64());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {50, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00248()
    {
      this.setup();
      this.refreshAll();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {71, 106, 104, 112, 159, 0, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u00249([In] TextButton[] obj0, [In] JoinDialog.Server obj1)
    {
      if (obj0[0].childrenPressed())
        return;
      if (obj1.lastHost != null)
      {
        Events.fire((object) new EventType.ClientPreConnectEvent(obj1.lastHost));
        this.safeConnect(obj1.ip, obj1.port, obj1.lastHost.__\u003C\u003Eversion);
      }
      else
        this.connect(obj1.ip, obj1.port);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {90, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002410([In] JoinDialog.Server obj0) => this.moveRemote(obj0, -1);

    [Modifiers]
    [LineNumberTable(new byte[] {95, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002411([In] JoinDialog.Server obj0) => this.moveRemote(obj0, 1);

    [Modifiers]
    [LineNumberTable(new byte[] {100, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002412([In] JoinDialog.Server obj0) => this.refreshServer(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002413([In] JoinDialog.Server obj0)
    {
      this.renaming = obj0;
      this.add.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {109, 255, 1, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002415([In] JoinDialog.Server obj0) => Vars.ui.showConfirm("@confirm", "@server.delete", (Runnable) new JoinDialog.__\u003C\u003EAnon63(this, obj0));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setupRemote\u002416([In] Table obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024refreshServer\u002417()
    {
      object obj = (object) new StringBuilder().append(Core.bundle.get("server.refreshing")).append(Strings.animated(Time.time, 4, 11f, ".")).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024refreshServer\u002418([In] JoinDialog.Server obj0, [In] Host obj1) => this.setupServer(obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 92, 107, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024refreshServer\u002419([In] JoinDialog.Server obj0, [In] Exception obj1)
    {
      obj0.content.clear();
      Table content = obj0.content;
      object obj = (object) "@host.invalid";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      content.add(text).padBottom(4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 124, 127, 78, 103, 109, 127, 52, 135, 127, 160, 140, 103, 127, 160, 64, 105, 103, 159, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildServer\u002420([In] Host obj0, [In] string obj1, [In] Table obj2)
    {
      Table table1 = obj2;
      object obj3 = (object) new StringBuilder().append("[lightgray]").append(obj0.__\u003C\u003Ename).append("   ").append(obj1).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text1 = charSequence;
      ((Label) table1.add(text1).width(this.targetWidth() - 10f).left().get()).setEllipsis(true);
      obj2.row();
      if (!String.instancehelper_isEmpty(obj0.__\u003C\u003Edescription))
      {
        Table table2 = obj2;
        object obj4 = (object) new StringBuilder().append("[gray]").append(obj0.__\u003C\u003Edescription).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text2 = charSequence;
        table2.add(text2).width(this.targetWidth() - 10f).left().wrap();
        obj2.row();
      }
      Table table3 = obj2;
      object obj5 = (object) new StringBuilder().append("[lightgray]").append(Core.bundle.format(new StringBuilder().append("players").append(obj0.__\u003C\u003Eplayers != 1 || obj0.__\u003C\u003EplayerLimit > 0 ? "" : ".single").toString(), (object) new StringBuilder().append(obj0.__\u003C\u003Eplayers != 0 ? "[accent]" : "[lightgray]").append(obj0.__\u003C\u003Eplayers).append(obj0.__\u003C\u003EplayerLimit <= 0 ? "" : new StringBuilder().append("[lightgray]/[accent]").append(obj0.__\u003C\u003EplayerLimit).toString()).append("[lightgray]").toString())).toString();
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text3 = charSequence;
      table3.add(text3).left();
      obj2.row();
      Table table4 = obj2;
      object obj6 = (object) new StringBuilder().append("[lightgray]").append(Core.bundle.format("save.map", (object) obj0.__\u003C\u003Emapname)).append("[lightgray] / ").append(obj0.__\u003C\u003EmodeName != null ? obj0.__\u003C\u003EmodeName : obj0.__\u003C\u003Emode.toString()).toString();
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text4 = charSequence;
      ((Label) table4.add(text4).width(this.targetWidth() - 10f).left().get()).setEllipsis(true);
      if (obj0.ping <= 0)
        return;
      obj2.row();
      Table table5 = obj2;
      object obj7 = (object) new StringBuilder().append("\uE819 ").append(obj0.ping).append("ms").toString();
      charSequence.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text5 = charSequence;
      table5.add(text5).color(Color.__\u003C\u003Egray).left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 160, 127, 7, 191, 0, 151, 255, 5, 69, 112, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002425([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@name";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padRight(10f);
      obj0.field(Core.settings.getString("name"), (Cons) new JoinDialog.__\u003C\u003EAnon59()).grow().pad(8f).addInputDialog(40);
      ImageButton imageButton = (ImageButton) obj0.button((Drawable) Tex.whiteui, Styles.clearFulli, 40f, (Runnable) new JoinDialog.__\u003C\u003EAnon60()).size(54f).get();
      imageButton.update((Runnable) new JoinDialog.__\u003C\u003EAnon61(imageButton));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 178, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002426()
    {
      this.renaming = (JoinDialog.Server) null;
      this.add.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 181, 99, 102, 127, 0, 106, 166, 146, 111, 104, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002427([In] float obj0, [In] ScrollPane obj1, [In] TextButton obj2)
    {
      float num = obj0;
      float padLeft = 0.0f;
      if ((double) ((Element) obj1.getChildren().first()).getPrefHeight() > (double) obj1.getHeight())
      {
        num = obj0 + 30f;
        padLeft = 6f;
      }
      Cell cell = ((Table) obj1.parent).getCell((Element) obj2);
      if (Mathf.equal(cell.minWidth(), num))
        return;
      cell.width(num);
      cell.padLeft(padLeft);
      obj1.parent.invalidateHierarchy();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 63, 98, 159, 24, 99, 191, 8, 106, 191, 0, 191, 9, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024section\u002432([In] string obj0, [In] bool obj1, [In] Collapser obj2, [In] Table obj3)
    {
      int num = obj1 ? 1 : 0;
      Table table = obj3;
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).pad(10f).growX().left().color(Pal.accent);
      if (num != 0)
        obj3.button((Drawable) Icon.eyeSmall, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon55(this)).update((Cons) new JoinDialog.__\u003C\u003EAnon56(this)).size(40f).right().padRight(3f).tooltip("@servers.showhidden");
      obj3.button((Drawable) Icon.downOpen, Styles.emptyi, (Runnable) new JoinDialog.__\u003C\u003EAnon57(obj2, obj0)).update((Cons) new JoinDialog.__\u003C\u003EAnon58(obj2)).size(40f).right().padRight(10f);
    }

    [Modifiers]
    [LineNumberTable(344)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024refreshLocal\u002434([In] Table obj0) => obj0.label((Prov) new JoinDialog.__\u003C\u003EAnon54()).pad(10f);

    [LineNumberTable(new byte[] {161, 63, 104, 139, 109, 110, 136, 140, 191, 10, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addLocalHost([In] Host obj0)
    {
      if (this.totalHosts == 0)
        this.local.clear();
      this.local.background((Drawable) null);
      ++this.totalHosts;
      float width = this.targetWidth();
      this.local.row();
      this.local.button((Cons) new JoinDialog.__\u003C\u003EAnon32(this, obj0), (Button.ButtonStyle) Styles.cleart, (Runnable) new JoinDialog.__\u003C\u003EAnon33(this, obj0)).width(width);
    }

    [LineNumberTable(new byte[] {161, 51, 107, 107, 113, 127, 12, 113, 159, 29, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void finishLocalHosts()
    {
      if (this.totalHosts == 0)
      {
        this.local.clear();
        this.local.background((Drawable) Tex.button);
        Table local = this.local;
        object obj = (object) "@hosts.none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        local.add(text).pad(10f);
        this.local.add().growX();
        this.local.button((Drawable) Icon.refresh, (Runnable) new JoinDialog.__\u003C\u003EAnon31(this)).pad(-12f).padLeft(0.0f).size(70f);
      }
      else
        this.local.background((Drawable) null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 51, 131, 106, 168, 101, 155, 248, 80, 186, 139, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024refreshGlobal\u002440(
      [In] int obj0,
      [In] int obj1,
      [In] Table[] obj2,
      [In] ServerGroup obj3,
      [In] bool obj4,
      [In] Host obj5)
    {
      int num = obj4 ? 1 : 0;
      if (this.refreshes != obj0)
        return;
      obj5.port = obj1;
      if (obj2[0] == null)
      {
        this.global.table((Cons) new JoinDialog.__\u003C\u003EAnon49(obj2)).row();
        obj2[0].table((Cons) new JoinDialog.__\u003C\u003EAnon50(this, obj3, num != 0, obj2)).width(this.targetWidth()).padBottom(-2f).row();
      }
      this.addGlobalHost(obj5, obj2[0]);
      obj2[0].margin(5f);
      obj2[0].pack();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024refreshGlobal\u002441([In] Exception obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addGlobalHost\u002442([In] Host obj0, [In] Button obj1) => this.buildServer(obj0, (Table) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 36, 107, 114, 255, 23, 71, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addGlobalHost\u002445([In] Host obj0)
    {
      Events.fire((object) new EventType.ClientPreConnectEvent(obj0));
      if (!Core.settings.getBool("server-disclaimer", false))
        Vars.ui.showCustomConfirm("@warning", "@servers.disclaimer", "@ok", "@back", (Runnable) new JoinDialog.__\u003C\u003EAnon47(this, obj0), (Runnable) new JoinDialog.__\u003C\u003EAnon48());
      else
        this.safeConnect(obj0.__\u003C\u003Eaddress, obj0.port, obj0.__\u003C\u003Eversion);
    }

    [Modifiers]
    [LineNumberTable(442)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addLocalHost\u002446([In] Host obj0, [In] Button obj1) => this.buildServer(obj0, (Table) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 73, 107, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addLocalHost\u002447([In] Host obj0)
    {
      Events.fire((object) new EventType.ClientPreConnectEvent(obj0));
      this.safeConnect(obj0.__\u003C\u003Eaddress, obj0.port, obj0.__\u003C\u003Eversion);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 87, 111, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024connect\u002448()
    {
      Vars.ui.loadfrag.hide();
      Vars.netClient.disconnectQuietly();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 92, 106, 106, 106, 255, 14, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024connect\u002450([In] string obj0, [In] int obj1)
    {
      Vars.logic.reset();
      Vars.net.reset();
      Vars.netClient.beginConnecting();
      mindustry.net.Net net = Vars.net;
      JoinDialog joinDialog1 = this;
      string str = obj0;
      string ip = str;
      this.lastIp = str;
      JoinDialog joinDialog2 = this;
      int num = obj1;
      int port = num;
      this.lastPort = num;
      Runnable success = (Runnable) new JoinDialog.__\u003C\u003EAnon46(this);
      net.connect(ip, port, success);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 109, 255, 12, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024reconnect\u002453() => Vars.net.pingHost(this.lastIp, this.lastPort, (Cons) new JoinDialog.__\u003C\u003EAnon44(this), (Cons) new JoinDialog.__\u003C\u003EAnon45());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 118, 111, 105, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024reconnect\u002454()
    {
      Vars.ui.loadfrag.hide();
      if (this.ping == null)
        return;
      this.ping.cancel();
      this.ping = (Timer.Task) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 154, 114, 121, 162, 108, 255, 9, 86, 226, 61, 97, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadServers\u002457([In] arc.Net.HttpResponse obj0)
    {
      Exception exception;
      try
      {
        if (!object.ReferenceEquals((object) obj0.getStatus(), (object) arc.Net.HttpStatus.__\u003C\u003EOK))
        {
          Log.warn("Failed to fetch community servers: @", (object) obj0.getStatus());
          return;
        }
        Jval jval = Jval.read(obj0.getResultAsString());
        Core.app.post((Runnable) new JoinDialog.__\u003C\u003EAnon41(jval));
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception th = exception;
      Log.err("Failed to fetch community servers.");
      Log.err(th);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 162, 107, 245, 74, 223, 21, 226, 61, 97, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadServers\u002456([In] Jval obj0)
    {
      Exception exception;
      try
      {
        Vars.__\u003C\u003EdefaultServers.clear();
        obj0.asArray().each((Cons) new JoinDialog.__\u003C\u003EAnon42());
        Log.info("Fetched @ community servers.", (object) Integer.valueOf(Vars.__\u003C\u003EdefaultServers.size));
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception th = exception;
      Log.err("Failed to parse community servers.");
      Log.err(th);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 164, 145, 127, 13, 159, 44, 154, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadServers\u002455([In] Jval obj0)
    {
      string name = obj0.getString("name", "");
      string[] addresses;
      if (obj0.has("addresses") || obj0.has("address") && obj0.get("address").isArray())
        addresses = (string[]) (!obj0.has("addresses") ? obj0.get("address") : obj0.get("addresses")).asArray().map((Func) new JoinDialog.__\u003C\u003EAnon43()).toArray((Class) ClassLiteral<String>.Value);
      else
        addresses = new string[1]
        {
          obj0.getString("address", "<invalid>")
        };
      Vars.__\u003C\u003EdefaultServers.add((object) new ServerGroup(name, addresses));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 110, 105, 107, 103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024reconnect\u002451([In] Host obj0)
    {
      if (this.ping == null)
        return;
      this.ping.cancel();
      this.ping = (Timer.Task) null;
      this.connect(this.lastIp, this.lastPort);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024reconnect\u002452([In] Exception obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 96, 108, 102, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024connect\u002449()
    {
      if (!Vars.net.client())
        return;
      this.hide();
      this.add.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 39, 117, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addGlobalHost\u002443([In] Host obj0)
    {
      Core.settings.put("server-disclaimer", (object) Boolean.valueOf(true));
      this.safeConnect(obj0.__\u003C\u003Eaddress, obj0.port, obj0.__\u003C\u003Eversion);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 42, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addGlobalHost\u002444() => Core.settings.put("server-disclaimer", (object) Boolean.valueOf(false));

    [Modifiers]
    [LineNumberTable(371)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024refreshGlobal\u002435([In] Table[] obj0, [In] Table obj1) => obj0[0] = obj1;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 49, 130, 109, 159, 19, 191, 2, 107, 255, 17, 70, 112, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024refreshGlobal\u002439(
      [In] ServerGroup obj0,
      [In] bool obj1,
      [In] Table[] obj2,
      [In] Table obj3)
    {
      int num = obj1 ? 1 : 0;
      if (!String.instancehelper_isEmpty(obj0.name))
      {
        Table table = obj3;
        object name = (object) obj0.name;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) name;
        CharSequence text = charSequence;
        table.add(text).color(Color.__\u003C\u003ElightGray).padRight(4f);
      }
      obj3.image().height(3f).growX().color(Color.__\u003C\u003ElightGray);
      ImageButton[] imageButtonArray = new ImageButton[1]
      {
        (ImageButton) null
      };
      imageButtonArray[0] = (ImageButton) obj3.button(num == 0 ? (Drawable) Icon.eyeSmall : (Drawable) Icon.eyeOffSmall, Styles.accenti, (Runnable) new JoinDialog.__\u003C\u003EAnon51(this, obj0, imageButtonArray, obj2)).size(40f).get();
      ImageButton imageButton = imageButtonArray[0];
      Tooltip.__\u003Cclinit\u003E();
      Tooltip tooltip = new Tooltip((Cons) new JoinDialog.__\u003C\u003EAnon52(obj0));
      imageButton.addListener((EventListener) tooltip);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 12, 114, 127, 2, 112, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024refreshGlobal\u002436(
      [In] ServerGroup obj0,
      [In] ImageButton[] obj1,
      [In] Table[] obj2)
    {
      obj0.setHidden(!obj0.hidden());
      obj1[0].getStyle().imageUp = !obj0.hidden() ? (Drawable) Icon.eyeSmall : (Drawable) Icon.eyeOffSmall;
      if (!obj0.hidden() || this.showHidden)
        return;
      obj2[0].remove();
    }

    [Modifiers]
    [LineNumberTable(388)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024refreshGlobal\u002438([In] ServerGroup obj0, [In] Table obj1) => obj1.background(Styles.black6).margin(4f).label((Prov) new JoinDialog.__\u003C\u003EAnon53(obj0));

    [Modifiers]
    [LineNumberTable(388)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024refreshGlobal\u002437([In] ServerGroup obj0)
    {
      object obj = obj0.hidden() ? (object) "@server.hidden" : (object) "@server.shown";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(344)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024refreshLocal\u002433()
    {
      object obj = (object) new StringBuilder().append("[accent]").append(Core.bundle.get("hosts.discovering.any")).append(Strings.animated(Time.time, 4, 10f, ".")).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 207, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024section\u002428()
    {
      this.showHidden = !this.showHidden;
      this.refreshGlobal();
    }

    [Modifiers]
    [LineNumberTable(323)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024section\u002429([In] ImageButton obj0) => obj0.getStyle().imageUp = !this.showHidden ? (Drawable) Icon.eyeOffSmall : (Drawable) Icon.eyeSmall;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 214, 103, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024section\u002430([In] Collapser obj0, [In] string obj1)
    {
      obj0.toggle(false);
      Core.settings.put(new StringBuilder().append("collapsed-").append(obj1).toString(), (object) Boolean.valueOf(obj0.isCollapsed()));
    }

    [Modifiers]
    [LineNumberTable(330)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024section\u002431([In] Collapser obj0, [In] ImageButton obj1) => obj1.getStyle().imageUp = obj0.isCollapsed() ? (Drawable) Icon.downOpen : (Drawable) Icon.upOpen;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 162, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002421([In] string obj0)
    {
      Vars.player.name(obj0);
      Core.settings.put("name", (object) obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 167, 212})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002423() => new PaletteDialog().show((Cons) new JoinDialog.__\u003C\u003EAnon62());

    [Modifiers]
    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002424([In] ImageButton obj0) => obj0.getStyle().imageUpColor = Vars.player.color();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 168, 113, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002422([In] Color obj0)
    {
      Vars.player.color().set(obj0);
      Core.settings.put("color-0", (object) Integer.valueOf(obj0.rgba8888()));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 110, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupRemote\u002414([In] JoinDialog.Server obj0)
    {
      this.servers.remove((object) obj0, true);
      this.saveServers();
      this.setupRemote();
      this.refreshRemote();
    }

    [Modifiers]
    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00246() => Core.settings.getBoolOnce("joininfo", (Runnable) new JoinDialog.__\u003C\u003EAnon65());

    [Modifiers]
    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00245() => Vars.ui.showInfo("@join.info");

    [HideFromJava]
    static JoinDialog() => BaseDialog.__\u003Cclinit\u003E();

    public class Server : Object
    {
      public string ip;
      public int port;
      [NonSerialized]
      internal Table content;
      [NonSerialized]
      internal Host lastHost;

      [LineNumberTable(new byte[] {161, 226, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Server()
      {
      }

      [LineNumberTable(new byte[] {161, 199, 126, 127, 7, 109, 111, 117, 127, 3, 106, 111, 117, 98, 103, 255, 1, 69, 226, 61, 97, 103, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void setIP([In] string obj0)
      {
        try
        {
          string str = obj0;
          char c = ':';
          object obj = (object) str;
          CharSequence s;
          s.__\u003Cref\u003E = (__Null) obj;
          int num1 = Strings.count(s, c) > 1 ? 1 : 0;
          if (num1 != 0 && String.instancehelper_lastIndexOf(obj0, "]:") != -1 && String.instancehelper_lastIndexOf(obj0, "]:") != String.instancehelper_length(obj0) - 1)
          {
            int num2 = String.instancehelper_indexOf(obj0, "]:");
            this.ip = String.instancehelper_substring(obj0, 1, num2);
            this.port = Integer.parseInt(String.instancehelper_substring(obj0, num2 + 2));
            return;
          }
          if (num1 == 0 && String.instancehelper_lastIndexOf(obj0, 58) != -1 && String.instancehelper_lastIndexOf(obj0, 58) != String.instancehelper_length(obj0) - 1)
          {
            int num2 = String.instancehelper_lastIndexOf(obj0, 58);
            this.ip = String.instancehelper_substring(obj0, 0, num2);
            this.port = Integer.parseInt(String.instancehelper_substring(obj0, num2 + 1));
            return;
          }
          this.ip = obj0;
          this.port = 6567;
          return;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        this.ip = obj0;
        this.port = 6567;
      }

      [LineNumberTable(new byte[] {161, 219, 127, 3, 159, 43})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual string displayIP()
      {
        string ip = this.ip;
        char c = ':';
        object obj = (object) ip;
        CharSequence s;
        s.__\u003Cref\u003E = (__Null) obj;
        if (Strings.count(s, c) <= 1)
          return new StringBuilder().append(this.ip).append(this.port == 6567 ? "" : new StringBuilder().append(":").append(this.port).toString()).toString();
        return this.port != 6567 ? new StringBuilder().append("[").append(this.ip).append("]:").append(this.port).toString() : this.ip;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => JoinDialog.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024new\u00241((string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Dialog arg\u00241;

      internal __\u003C\u003EAnon2([In] Dialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (JoinDialog.lambda\u0024new\u00243((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly TextField arg\u00242;

      internal __\u003C\u003EAnon5([In] JoinDialog obj0, [In] TextField obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00244(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.refreshAll();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly TextButton[] arg\u00242;
      private readonly JoinDialog.Server arg\u00243;

      internal __\u003C\u003EAnon9([In] JoinDialog obj0, [In] TextButton[] obj1, [In] JoinDialog.Server obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u00249(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon10([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon11([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002411(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon12([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002412(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon13([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002413(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon14([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002415(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024setupRemote\u002416((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Prov
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public object get() => (object) JoinDialog.lambda\u0024refreshServer\u002417().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon17([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024refreshServer\u002418(this.arg\u00242, (Host) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly JoinDialog.Server arg\u00241;

      internal __\u003C\u003EAnon18([In] JoinDialog.Server obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => JoinDialog.lambda\u0024refreshServer\u002419(this.arg\u00241, (Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon19([In] JoinDialog obj0, [In] Host obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildServer\u002420(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024setup\u002425((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon21([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002426();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      private readonly float arg\u00241;
      private readonly ScrollPane arg\u00242;

      internal __\u003C\u003EAnon22([In] float obj0, [In] ScrollPane obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024setup\u002427(this.arg\u00241, this.arg\u00242, (TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly string arg\u00242;
      private readonly bool arg\u00243;
      private readonly Collapser arg\u00244;

      internal __\u003C\u003EAnon23([In] JoinDialog obj0, [In] string obj1, [In] bool obj2, [In] Collapser obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024section\u002432(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024refreshLocal\u002434((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon25([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.addLocalHost((Host) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon26([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.finishLocalHosts();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;
      private readonly Table[] arg\u00244;
      private readonly ServerGroup arg\u00245;
      private readonly bool arg\u00246;

      internal __\u003C\u003EAnon27(
        [In] JoinDialog obj0,
        [In] int obj1,
        [In] int obj2,
        [In] Table[] obj3,
        [In] ServerGroup obj4,
        [In] bool obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024refreshGlobal\u002440(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, (Host) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024refreshGlobal\u002441((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon29([In] JoinDialog obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addGlobalHost\u002442(this.arg\u00242, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon30([In] JoinDialog obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024addGlobalHost\u002445(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon31([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.refreshLocal();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon32([In] JoinDialog obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addLocalHost\u002446(this.arg\u00242, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon33([In] JoinDialog obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024addLocalHost\u002447(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void run() => JoinDialog.lambda\u0024connect\u002448();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly string arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon35([In] JoinDialog obj0, [In] string obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024connect\u002450(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon36([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024reconnect\u002453();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon37([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024reconnect\u002454();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Prov
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Cons
    {
      internal __\u003C\u003EAnon39()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024loadServers\u002457((arc.Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Cons
    {
      internal __\u003C\u003EAnon40()
      {
      }

      public void get([In] object obj0) => Log.err((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Runnable
    {
      private readonly Jval arg\u00241;

      internal __\u003C\u003EAnon41([In] Jval obj0) => this.arg\u00241 = obj0;

      public void run() => JoinDialog.lambda\u0024loadServers\u002456(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Cons
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024loadServers\u002455((Jval) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Func
    {
      internal __\u003C\u003EAnon43()
      {
      }

      public object get([In] object obj0) => (object) ((Jval) obj0).asString();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Cons
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon44([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024reconnect\u002451((Host) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Cons
    {
      internal __\u003C\u003EAnon45()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024reconnect\u002452((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon46([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024connect\u002449();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon47([In] JoinDialog obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024addGlobalHost\u002443(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Runnable
    {
      internal __\u003C\u003EAnon48()
      {
      }

      public void run() => JoinDialog.lambda\u0024addGlobalHost\u002444();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Cons
    {
      private readonly Table[] arg\u00241;

      internal __\u003C\u003EAnon49([In] Table[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => JoinDialog.lambda\u0024refreshGlobal\u002435(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Cons
    {
      private readonly JoinDialog arg\u00241;
      private readonly ServerGroup arg\u00242;
      private readonly bool arg\u00243;
      private readonly Table[] arg\u00244;

      internal __\u003C\u003EAnon50([In] JoinDialog obj0, [In] ServerGroup obj1, [In] bool obj2, [In] Table[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024refreshGlobal\u002439(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly ServerGroup arg\u00242;
      private readonly ImageButton[] arg\u00243;
      private readonly Table[] arg\u00244;

      internal __\u003C\u003EAnon51(
        [In] JoinDialog obj0,
        [In] ServerGroup obj1,
        [In] ImageButton[] obj2,
        [In] Table[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024refreshGlobal\u002436(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Cons
    {
      private readonly ServerGroup arg\u00241;

      internal __\u003C\u003EAnon52([In] ServerGroup obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => JoinDialog.lambda\u0024refreshGlobal\u002438(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Prov
    {
      private readonly ServerGroup arg\u00241;

      internal __\u003C\u003EAnon53([In] ServerGroup obj0) => this.arg\u00241 = obj0;

      public object get() => (object) JoinDialog.lambda\u0024refreshGlobal\u002437(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Prov
    {
      internal __\u003C\u003EAnon54()
      {
      }

      public object get() => (object) JoinDialog.lambda\u0024refreshLocal\u002433().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon55([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024section\u002428();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Cons
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon56([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024section\u002429((ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Runnable
    {
      private readonly Collapser arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon57([In] Collapser obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => JoinDialog.lambda\u0024section\u002430(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Cons
    {
      private readonly Collapser arg\u00241;

      internal __\u003C\u003EAnon58([In] Collapser obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => JoinDialog.lambda\u0024section\u002431(this.arg\u00241, (ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Cons
    {
      internal __\u003C\u003EAnon59()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024setup\u002421((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Runnable
    {
      internal __\u003C\u003EAnon60()
      {
      }

      public void run() => JoinDialog.lambda\u0024setup\u002423();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Runnable
    {
      private readonly ImageButton arg\u00241;

      internal __\u003C\u003EAnon61([In] ImageButton obj0) => this.arg\u00241 = obj0;

      public void run() => JoinDialog.lambda\u0024setup\u002424(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Cons
    {
      internal __\u003C\u003EAnon62()
      {
      }

      public void get([In] object obj0) => JoinDialog.lambda\u0024setup\u002422((Color) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Runnable
    {
      private readonly JoinDialog arg\u00241;
      private readonly JoinDialog.Server arg\u00242;

      internal __\u003C\u003EAnon63([In] JoinDialog obj0, [In] JoinDialog.Server obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setupRemote\u002414(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Runnable
    {
      internal __\u003C\u003EAnon64()
      {
      }

      public void run() => JoinDialog.lambda\u0024new\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Runnable
    {
      internal __\u003C\u003EAnon65()
      {
      }

      public void run() => JoinDialog.lambda\u0024new\u00245();
    }
  }
}
