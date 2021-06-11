// Decompiled with JetBrains decompiler
// Type: mindustry.core.NetClient
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.math;
using arc.scene.style;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.net;
using mindustry.ui;
using mindustry.ui.fragments;
using mindustry.world;
using mindustry.world.modules;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class NetClient : Object, ApplicationListener
  {
    private const float dataTimeout = 1080f;
    private const float playerSyncTime = 2f;
    public const float viewScale = 2f;
    private long ping;
    private Interval timer;
    private bool connecting;
    private bool quiet;
    private bool quietReset;
    private float timeoutTime;
    private int lastSent;
    private IntSet removed;
    private ReusableByteInStream byteStream;
    private DataInputStream dataStream;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Larc/func/Cons<Ljava/lang/String;>;>;>;")]
    private ObjectMap customPacketHandlers;

    [LineNumberTable(new byte[] {10, 232, 44, 140, 135, 135, 135, 235, 69, 139, 107, 145, 203, 250, 111, 250, 88, 250, 71, 185})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NetClient()
    {
      NetClient netClient = this;
      this.timer = new Interval(5);
      this.connecting = false;
      this.quiet = false;
      this.quietReset = false;
      this.timeoutTime = 0.0f;
      this.removed = new IntSet();
      this.byteStream = new ReusableByteInStream();
      this.dataStream = new DataInputStream((InputStream) this.byteStream);
      this.customPacketHandlers = new ObjectMap();
      Vars.net.handleClient((Class) ClassLiteral<Packets.Connect>.Value, (Cons) new NetClient.__\u003C\u003EAnon0(this));
      Vars.net.handleClient((Class) ClassLiteral<Packets.Disconnect>.Value, (Cons) new NetClient.__\u003C\u003EAnon1(this));
      Vars.net.handleClient((Class) ClassLiteral<Packets.WorldStream>.Value, (Cons) new NetClient.__\u003C\u003EAnon2(this));
      Vars.net.handleClient((Class) ClassLiteral<Packets.InvokePacket>.Value, (Cons) new NetClient.__\u003C\u003EAnon3());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuiet() => this.quiet = true;

    [LineNumberTable(new byte[] {105, 114, 127, 16, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketReliable(string type, string contents)
    {
      if (!Vars.netClient.customPacketHandlers.containsKey((object) type))
        return;
      Iterator iterator = ((Seq) Vars.netClient.customPacketHandlers.get((object) type)).iterator();
      while (iterator.hasNext())
        ((Cons) iterator.next()).get((object) contents);
    }

    [LineNumberTable(new byte[] {160, 134, 113, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string colorizeName(int id, string name)
    {
      Player byId = (Player) Groups.player.getByID(id);
      return name == null || byId == null ? (string) null : new StringBuilder().append("[#").append(String.instancehelper_toUpperCase(byId.color().toString())).append("]").append(name).toString();
    }

    [LineNumberTable(new byte[] {120, 103, 177, 99, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendMessage(string message, string sender, Player playersender)
    {
      if (Vars.ui != null)
        Vars.ui.chatfrag.addMessage(message, sender);
      if (playersender == null)
        return;
      playersender.lastText(message);
      playersender.textFadeTime(1f);
    }

    [LineNumberTable(new byte[] {161, 210, 103, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnectQuietly()
    {
      this.quiet = true;
      this.connecting = false;
      Vars.net.disconnect();
    }

    [LineNumberTable(new byte[] {160, 194, 132, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudText(string message)
    {
      if (message == null)
        return;
      Vars.ui.hudfrag.setHudText(message);
    }

    [LineNumberTable(new byte[] {160, 240, 132, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effect(Effect effect, float x, float y, float rotation, Color color) => effect?.at(x, y, rotation, color);

    [LineNumberTable(new byte[] {161, 231, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRemovedEntity(int id) => this.removed.add(id);

    [LineNumberTable(605)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEntityUsed(int id) => this.removed.contains(id);

    [LineNumberTable(new byte[] {161, 239, 118, 98, 143, 156, 162, 105, 124, 127, 11, 101, 165, 104, 100, 226, 55, 233, 77, 103, 102, 61, 230, 69, 127, 0, 151, 190, 101, 127, 36, 159, 3, 159, 50, 127, 9, 255, 54, 54, 229, 81, 115, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sync()
    {
      if (this.timer.get(0, 2f))
      {
        BuildPlan[] buildPlanArray = (BuildPlan[]) null;
        if (Vars.player.isBuilder())
        {
          int length1 = Math.min(Vars.player.unit().plans().size, 10);
          int num = 0;
          for (int index = 0; index < length1; ++index)
          {
            object config = ((BuildPlan) Vars.player.unit().plans().get(index)).config;
            byte[] numArray;
            if (config is byte[] && object.ReferenceEquals((object) (numArray = (byte[]) config), (object) (byte[]) config))
            {
              int length2 = numArray.Length;
              num += length2;
            }
            if (num > 1024)
            {
              length1 = index + 1;
              break;
            }
          }
          buildPlanArray = new BuildPlan[length1];
          for (int index = 0; index < length1; ++index)
            buildPlanArray[index] = (BuildPlan) Vars.player.unit().plans().get(index);
        }
        Unit unit1 = !Vars.player.dead() ? Vars.player.unit() : Nulls.__\u003C\u003Eunit;
        int num1 = !Vars.player.dead() ? unit1.id : -1;
        NetClient netClient1 = this;
        int lastSent = netClient1.lastSent;
        NetClient netClient2 = netClient1;
        int snapshotID = lastSent;
        netClient2.lastSent = lastSent + 1;
        int unitID = num1;
        int num2 = Vars.player.dead() ? 1 : 0;
        double num3 = !Vars.player.dead() ? (double) unit1.x : (double) Vars.player.x;
        double num4 = !Vars.player.dead() ? (double) unit1.y : (double) Vars.player.y;
        double num5 = (double) Vars.player.unit().aimX();
        double num6 = (double) Vars.player.unit().aimY();
        double rotation = (double) unit1.rotation;
        Unit unit2 = unit1;
        Mechc mechc;
        double num7 = !(unit2 is Mechc) || !object.ReferenceEquals((object) (mechc = (Mechc) unit2), (object) (Mechc) unit2) ? 0.0 : (double) mechc.baseRotation();
        double x1 = (double) unit1.vel.x;
        double y1 = (double) unit1.vel.y;
        Tile mineTile = Vars.player.unit().mineTile;
        int num8 = Vars.player.boosting ? 1 : 0;
        int num9 = Vars.player.shooting ? 1 : 0;
        int num10 = Vars.ui.chatfrag.shown() ? 1 : 0;
        int num11 = Vars.control.input.isBuilding ? 1 : 0;
        BuildPlan[] requests = buildPlanArray;
        double x2 = (double) Core.camera.__\u003C\u003Eposition.x;
        double y2 = (double) Core.camera.__\u003C\u003Eposition.y;
        double num12 = (double) (Core.camera.width * 2f);
        double num13 = (double) (Core.camera.height * 2f);
        Call.clientSnapshot(snapshotID, unitID, num2 != 0, (float) num3, (float) num4, (float) num5, (float) num6, (float) rotation, (float) num7, (float) x1, (float) y1, mineTile, num8 != 0, num9 != 0, num10 != 0, num11 != 0, requests, (float) x2, (float) y2, (float) num12, (float) num13);
      }
      if (!this.timer.get(1, 60f))
        return;
      Call.ping(Time.millis());
    }

    [LineNumberTable(new byte[] {161, 182, 111, 103, 111, 107, 116, 127, 2, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void finishConnecting()
    {
      Vars.state.set(GameState.State.__\u003C\u003Eplaying);
      this.connecting = false;
      Vars.ui.join.hide();
      Vars.net.setClientLoaded(true);
      Core.app.post((Runnable) new NetClient.__\u003C\u003EAnon6());
      Platform platform = Vars.platform;
      Objects.requireNonNull((object) platform);
      Time.runTask(40f, (Runnable) new NetClient.__\u003C\u003EAnon7(platform));
      Application app = Core.app;
      LoadingFragment loadfrag = Vars.ui.loadfrag;
      Objects.requireNonNull((object) loadfrag);
      Runnable r = (Runnable) new NetClient.__\u003C\u003EAnon8(loadfrag);
      app.post(r);
    }

    [LineNumberTable(new byte[] {161, 192, 107, 107, 107, 103, 103, 103, 135, 101, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reset()
    {
      Vars.net.setClientLoaded(false);
      this.removed.clear();
      this.timeoutTime = 0.0f;
      this.connecting = true;
      this.quietReset = false;
      this.quiet = false;
      this.lastSent = 0;
      Groups.clear();
      Vars.ui.chatfrag.clearMessages();
    }

    [LineNumberTable(new byte[] {162, 38, 125, 181, 127, 8, 159, 7, 103, 107, 108, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getUsid([In] string obj0)
    {
      string str1 = obj0;
      object obj = (object) "/";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str1, charSequence2))
        obj0 = String.instancehelper_substring(obj0, String.instancehelper_indexOf(obj0, "/") + 1);
      if (Core.settings.getString(new StringBuilder().append("usid-").append(obj0).toString(), (string) null) != null)
        return Core.settings.getString(new StringBuilder().append("usid-").append(obj0).toString(), (string) null);
      byte[] numArray = new byte[8];
      new Rand().nextBytes(numArray);
      string str2 = String.newhelper(Base64Coder.encode(numArray));
      Core.settings.put(new StringBuilder().append("usid-").append(obj0).toString(), (object) str2);
      return str2;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {13, 153, 139, 166, 108, 106, 102, 161, 111, 148, 250, 69, 112, 109, 171, 102, 112, 103, 112, 107, 107, 117, 114, 144, 104, 111, 111, 102, 161, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] Packets.Connect obj0)
    {
      Log.info("Connecting to server: @", (object) obj0.addressTCP);
      Vars.player.admin(false);
      this.reset();
      if (!Vars.net.client())
      {
        Log.info((object) "Connection canceled.");
        this.disconnectQuietly();
      }
      else
      {
        Vars.ui.loadfrag.hide();
        Vars.ui.loadfrag.show("@connecting.data");
        Vars.ui.loadfrag.setButton((Runnable) new NetClient.__\u003C\u003EAnon9(this));
        string str = Core.settings.getString("locale");
        if (String.instancehelper_equals(str, (object) "default"))
          str = Locale.getDefault().toString();
        Packets.ConnectPacket connectPacket = new Packets.ConnectPacket();
        connectPacket.name = Vars.player.name;
        connectPacket.locale = str;
        connectPacket.mods = Vars.mods.getModStrings();
        connectPacket.mobile = Vars.mobile;
        connectPacket.versionType = Version.type;
        connectPacket.color = Vars.player.color().rgba();
        connectPacket.usid = this.getUsid(obj0.addressTCP);
        connectPacket.uuid = Vars.platform.getUUID();
        if (connectPacket.uuid == null)
        {
          Vars.ui.showErrorMessage("@invalidid");
          Vars.ui.loadfrag.hide();
          this.disconnectQuietly();
        }
        else
          Vars.net.send((object) connectPacket, mindustry.net.Net.SendMode.__\u003C\u003Etcp);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {60, 137, 103, 106, 106, 121, 159, 0, 137, 159, 7, 107, 127, 89, 118, 118, 182, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] Packets.Disconnect obj0)
    {
      if (this.quietReset)
        return;
      this.connecting = false;
      Vars.logic.reset();
      Vars.platform.updateRPC();
      Vars.player.name(Core.settings.getString("name"));
      Vars.player.color().set(Core.settings.getInt("color-0"));
      if (this.quiet)
        return;
      LoadingFragment loadfrag = Vars.ui.loadfrag;
      Objects.requireNonNull((object) loadfrag);
      Time.runTask(3f, (Runnable) new NetClient.__\u003C\u003EAnon8(loadfrag));
      if (obj0.reason != null)
      {
        string reason = obj0.reason;
        int num = -1;
        switch (String.instancehelper_hashCode(reason))
        {
          case -1357520532:
            if (String.instancehelper_equals(reason, (object) "closed"))
            {
              num = 0;
              break;
            }
            break;
          case -1313911455:
            if (String.instancehelper_equals(reason, (object) "timeout"))
            {
              num = 1;
              break;
            }
            break;
          case 96784904:
            if (String.instancehelper_equals(reason, (object) "error"))
            {
              num = 2;
              break;
            }
            break;
        }
        switch (num)
        {
          case 0:
            Vars.ui.showSmall("@disconnect", "@disconnect.closed");
            break;
          case 1:
            Vars.ui.showSmall("@disconnect", "@disconnect.timeout");
            break;
          case 2:
            Vars.ui.showSmall("@disconnect", "@disconnect.error");
            break;
        }
      }
      else
        Vars.ui.showErrorMessage("@disconnect");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {84, 127, 4, 144, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] Packets.WorldStream obj0)
    {
      Log.info("Received world data: @ bytes.", (object) Integer.valueOf(obj0.stream.available()));
      NetworkIO.loadWorld((InputStream) new InflaterInputStream((InputStream) obj0.stream));
      this.finishConnecting();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {91, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244([In] Packets.InvokePacket obj0) => RemoteReadClient.readPacket(obj0.reader(), (int) (sbyte) obj0.type);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 25, 143, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024worldDataBegin\u00245()
    {
      Vars.ui.loadfrag.hide();
      Vars.netClient.disconnectQuietly();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {30, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      Vars.ui.loadfrag.hide();
      this.disconnectQuietly();
    }

    [Signature("(Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {96, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPacketHandler(string type, Cons handler) => ((Seq) this.customPacketHandlers.get((object) type, (Prov) new NetClient.__\u003C\u003EAnon4())).add((object) handler);

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Larc/func/Cons<Ljava/lang/String;>;>;")]
    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getPacketHandlers(string type) => (Seq) this.customPacketHandlers.get((object) type, (Prov) new NetClient.__\u003C\u003EAnon4());

    [LineNumberTable(new byte[] {114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketUnreliable(string type, string contents) => NetClient.clientPacketReliable(type, contents);

    [LineNumberTable(new byte[] {160, 69, 103, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendMessage(string message)
    {
      if (Vars.ui == null)
        return;
      Vars.ui.chatfrag.addMessage(message, (string) null);
    }

    [LineNumberTable(new byte[] {160, 79, 159, 38, 109, 177, 172, 151, 223, 48, 114, 117, 147, 99, 193, 103, 216, 223, 48, 221, 213, 114, 127, 34, 114, 159, 34, 166, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendChatMessage(Player player, string message)
    {
      if (Vars.net.server() && player != null && player.con != null && (Time.timeSinceMillis(player.con.connectTime) < 500L || !player.con.hasConnected || !player.isAdded()))
        return;
      if (String.instancehelper_length(message) > 150)
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player has sent a message above the text limit.");
      }
      Events.fire((object) new EventType.PlayerChatEvent(player, message));
      if (String.instancehelper_startsWith(message, Vars.netServer.__\u003C\u003EclientCommands.getPrefix()))
        Log.info("<&fi@: @&fr>", (object) new StringBuilder().append("&lk").append(player.name).toString(), (object) new StringBuilder().append("&lw").append(message).toString());
      CommandHandler.CommandResponse commandResponse = Vars.netServer.__\u003C\u003EclientCommands.handleMessage(message, (object) player);
      if (object.ReferenceEquals((object) commandResponse.__\u003C\u003Etype, (object) CommandHandler.ResponseType.__\u003C\u003EnoCommand))
      {
        message = Vars.netServer.__\u003C\u003Eadmins.filterMessage(player, message);
        if (message == null)
          return;
        if (!Vars.headless)
          NetClient.sendMessage(message, NetClient.colorizeName(player.id, player.name), player);
        Log.info("&fi@: @", (object) new StringBuilder().append("&lc").append(player.name).toString(), (object) new StringBuilder().append("&lw").append(message).toString());
        Call.sendMessage(message, NetClient.colorizeName(player.id(), player.name), player);
      }
      else
      {
        if (object.ReferenceEquals((object) commandResponse.__\u003C\u003Etype, (object) CommandHandler.ResponseType.__\u003C\u003Evalid))
          return;
        string text = !object.ReferenceEquals((object) commandResponse.__\u003C\u003Etype, (object) CommandHandler.ResponseType.__\u003C\u003EmanyArguments) ? (!object.ReferenceEquals((object) commandResponse.__\u003C\u003Etype, (object) CommandHandler.ResponseType.__\u003C\u003EfewArguments) ? "[scarlet]Unknown command. Check [lightgray]/help[scarlet]." : new StringBuilder().append("[scarlet]Too few arguments. Usage:[lightgray] ").append(commandResponse.__\u003C\u003Ecommand.__\u003C\u003Etext).append("[gray] ").append(commandResponse.__\u003C\u003Ecommand.__\u003C\u003EparamText).toString()) : new StringBuilder().append("[scarlet]Too many arguments. Usage:[lightgray] ").append(commandResponse.__\u003C\u003Ecommand.__\u003C\u003Etext).append("[gray] ").append(commandResponse.__\u003C\u003Ecommand.__\u003C\u003EparamText).toString();
        player.sendMessage(text);
      }
    }

    [LineNumberTable(new byte[] {160, 141, 106, 138, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void connect(string ip, int port)
    {
      Vars.netClient.disconnectQuietly();
      Vars.logic.reset();
      Vars.ui.join.connect(ip, port);
    }

    [LineNumberTable(new byte[] {160, 149, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ping(Player player, long time) => Call.pingResponse(player.con, time);

    [LineNumberTable(new byte[] {160, 154, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pingResponse(long time) => Vars.netClient.ping = Time.timeSinceMillis(time);

    [LineNumberTable(new byte[] {160, 159, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void traceInfo(Player player, Administration.TraceInfo info)
    {
      if (player == null)
        return;
      Vars.ui.traces.show(player, info);
    }

    [LineNumberTable(new byte[] {160, 166, 106, 138, 109, 111, 161, 104, 104, 152, 181, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void kick(Packets.KickReason reason)
    {
      Vars.netClient.disconnectQuietly();
      Vars.logic.reset();
      if (object.ReferenceEquals((object) reason, (object) Packets.KickReason.__\u003C\u003EserverRestarting))
      {
        Vars.ui.join.reconnect();
      }
      else
      {
        if (!reason.__\u003C\u003Equiet)
        {
          if (reason.extraText() != null)
            Vars.ui.showText(reason.toString(), reason.extraText());
          else
            Vars.ui.showText("@disconnect", reason.toString());
        }
        Vars.ui.loadfrag.hide();
      }
    }

    [LineNumberTable(new byte[] {160, 186, 106, 106, 113, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void kick(string reason)
    {
      Vars.netClient.disconnectQuietly();
      Vars.logic.reset();
      Vars.ui.showText("@disconnect", reason, 8);
      Vars.ui.loadfrag.hide();
    }

    [LineNumberTable(new byte[] {160, 201, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void hideHudText() => Vars.ui.hudfrag.toggleHudText(false);

    [LineNumberTable(new byte[] {160, 207, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudTextReliable(string message) => NetClient.setHudText(message);

    [LineNumberTable(new byte[] {160, 212, 132, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void announce(string message)
    {
      if (message == null)
        return;
      Vars.ui.announce(message);
    }

    [LineNumberTable(new byte[] {160, 219, 132, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoMessage(string message)
    {
      if (message == null)
        return;
      Vars.ui.showText("", message);
    }

    [LineNumberTable(new byte[] {160, 226, 132, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoPopup(
      string message,
      float duration,
      int align,
      int top,
      int left,
      int bottom,
      int right)
    {
      if (message == null)
        return;
      Vars.ui.showInfoPopup(message, duration, align, top, left, bottom, right);
    }

    [LineNumberTable(new byte[] {160, 233, 132, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void label(string message, float duration, float worldx, float worldy)
    {
      if (message == null)
        return;
      Vars.ui.showLabel(message, duration, worldx, worldy);
    }

    [LineNumberTable(new byte[] {160, 247, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effectReliable(
      Effect effect,
      float x,
      float y,
      float rotation,
      Color color)
    {
      NetClient.effect(effect, x, y, rotation, color);
    }

    [LineNumberTable(new byte[] {160, 252, 132, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoToast(string message, float duration)
    {
      if (message == null)
        return;
      Vars.ui.showInfoToast(message, duration);
    }

    [LineNumberTable(new byte[] {161, 3, 151, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void warningToast(int unicode, string text)
    {
      if (text == null || Fonts.icon.getData().getGlyph((char) unicode) == null)
        return;
      Vars.ui.hudfrag.showToast((Drawable) Fonts.getGlyph(Fonts.icon, (char) unicode), text);
    }

    [LineNumberTable(new byte[] {161, 10, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setRules(Rules rules) => Vars.state.rules = rules;

    [LineNumberTable(new byte[] {161, 15, 101, 111, 106, 139, 139, 148, 249, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void worldDataBegin()
    {
      Groups.clear();
      Vars.netClient.removed.clear();
      Vars.logic.reset();
      Vars.netClient.connecting = true;
      Vars.net.setClientLoaded(false);
      Vars.ui.loadfrag.show("@connecting.data");
      Vars.ui.loadfrag.setButton((Runnable) new NetClient.__\u003C\u003EAnon5());
    }

    [LineNumberTable(new byte[] {161, 33, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setPosition(float x, float y)
    {
      Vars.player.unit().set(x, y);
      Vars.player.set(x, y);
    }

    [LineNumberTable(new byte[] {161, 39, 103, 139, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void playerDisconnect(int playerid)
    {
      if (Vars.netClient != null)
        Vars.netClient.addRemovedEntity(playerid);
      Groups.player.removeByID(playerid);
    }

    [LineNumberTable(new byte[] {159, 38, 132, 123, 139, 105, 104, 137, 115, 134, 119, 103, 195, 100, 115, 110, 120, 131, 195, 159, 5, 132, 186, 100, 122, 255, 5, 32, 251, 101, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void entitySnapshot(short amount, short dataLen, byte[] data)
    {
      int size = (int) dataLen;
      int num1 = (int) amount;
      IOException ioException1;
      try
      {
        Vars.netClient.byteStream.setBytes(Vars.net.decompressSnapshot(data, size));
        DataInputStream dataStream = Vars.netClient.dataStream;
        for (int index = 0; index < num1; ++index)
        {
          int num2 = dataStream.readInt();
          int id1 = (int) (sbyte) dataStream.readByte();
          object obj1 = (object) (Syncc) Groups.sync.getByID(num2);
          int num3 = 0;
          int num4 = 0;
          if ((Syncc) obj1 == null && num2 == Vars.player.id())
          {
            obj1 = (object) Vars.player;
            num3 = 1;
          }
          if (obj1 == null)
          {
            obj1 = (object) (Syncc) EntityMapping.map(id1).get();
            ((Entityc) obj1).id(num2);
            if (!Vars.netClient.isEntityUsed(((Entityc) obj1).id()))
              num3 = 1;
            num4 = 1;
          }
          object obj2 = obj1;
          Reads reads = Reads.get((DataInput) dataStream);
          Syncc syncc1;
          if (obj2 != null)
            syncc1 = obj2 is Syncc syncc15 ? syncc15 : throw new IncompatibleClassChangeError();
          else
            syncc1 = (Syncc) null;
          Reads r = reads;
          syncc1.readSync(r);
          if (num4 != 0)
          {
            object obj3 = obj1;
            Syncc syncc4;
            if (obj3 != null)
              syncc4 = obj3 is Syncc syncc16 ? syncc16 : throw new IncompatibleClassChangeError();
            else
              syncc4 = (Syncc) null;
            syncc4.snapSync();
          }
          if (num3 != 0)
          {
            object obj3 = obj1;
            Entityc entityc1;
            if (obj3 != null)
              entityc1 = obj3 is Entityc entityc17 ? entityc17 : throw new IncompatibleClassChangeError();
            else
              entityc1 = (Entityc) null;
            entityc1.add();
            NetClient netClient = Vars.netClient;
            object obj4 = obj1;
            Entityc entityc4;
            if (obj4 != null)
              entityc4 = obj4 is Entityc entityc18 ? entityc18 : throw new IncompatibleClassChangeError();
            else
              entityc4 = (Entityc) null;
            int id2 = entityc4.id();
            netClient.addRemovedEntity(id2);
          }
        }
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 26, 68, 123, 139, 105, 104, 104, 110, 109, 117, 133, 117, 127, 25, 130, 255, 0, 52, 255, 1, 80, 2, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blockSnapshot(short amount, short dataLen, byte[] data)
    {
      int size = (int) dataLen;
      int num1 = (int) amount;
      Exception exception;
      try
      {
        Vars.netClient.byteStream.setBytes(Vars.net.decompressSnapshot(data, size));
        DataInputStream dataStream = Vars.netClient.dataStream;
        for (int index = 0; index < num1; ++index)
        {
          int pos = dataStream.readInt();
          int num2 = (int) dataStream.readShort();
          Tile tile = Vars.world.tile(pos);
          if (tile == null || tile.build == null)
          {
            Log.warn("Missing entity at @. Skipping block snapshot.", (object) tile);
            break;
          }
          if ((int) tile.build.block.__\u003C\u003Eid != num2)
          {
            Log.warn("Block ID mismatch at @: @ != @. Skipping block snapshot.", (object) tile, (object) Short.valueOf(tile.build.block.__\u003C\u003Eid), (object) Short.valueOf((short) num2));
            break;
          }
          tile.build.readAll(Reads.get((DataInput) dataStream), tile.build.version());
        }
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Log.err((Exception) exception);
    }

    [LineNumberTable(new byte[] {159, 20, 104, 109, 107, 170, 107, 108, 107, 107, 139, 140, 124, 139, 104, 105, 104, 142, 109, 153, 240, 57, 253, 77, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stateSnapshot(
      float waveTime,
      int wave,
      int enemies,
      bool paused,
      bool gameOver,
      int timeData,
      short coreDataLen,
      byte[] coreData)
    {
      int num1 = gameOver ? 1 : 0;
      int num2 = paused ? 1 : 0;
      int size = (int) coreDataLen;
      IOException ioException1;
      try
      {
        if (wave > Vars.state.wave)
        {
          Vars.state.wave = wave;
          Events.fire((object) new EventType.WaveEvent());
        }
        Vars.state.gameOver = num1 != 0;
        Vars.state.wavetime = waveTime;
        Vars.state.wave = wave;
        Vars.state.enemies = enemies;
        Vars.state.serverPaused = num2 != 0;
        Vars.universe.updateNetSeconds(timeData);
        Vars.netClient.byteStream.setBytes(Vars.net.decompressSnapshot(coreData, size));
        DataInputStream dataStream = Vars.netClient.dataStream;
        int num3 = dataStream.readInt();
        for (int index = 0; index < num3; ++index)
        {
          int pos = dataStream.readInt();
          Tile tile = Vars.world.tile(pos);
          if (tile != null && tile.build != null)
            tile.build.items.read(Reads.get((DataInput) dataStream));
          else
            new ItemModule().read(Reads.get((DataInput) dataStream));
        }
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {161, 154, 141, 108, 118, 104, 140, 115, 109, 112, 111, 103, 111, 106, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (!Vars.net.client())
        return;
      if (Vars.state.isGame())
      {
        if (this.connecting)
          return;
        this.sync();
      }
      else if (!this.connecting)
      {
        Vars.net.disconnect();
      }
      else
      {
        this.timeoutTime += Time.delta;
        if ((double) this.timeoutTime <= 1080.0)
          return;
        Log.err("Failed to load data!");
        Vars.ui.loadfrag.hide();
        this.quiet = true;
        Vars.ui.showErrorMessage("@disconnect.data");
        Vars.net.disconnect();
        this.timeoutTime = 0.0f;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isConnecting() => this.connecting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPing() => (int) this.ping;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginConnecting() => this.connecting = true;

    [LineNumberTable(new byte[] {161, 217, 114, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnectNoReset()
    {
      NetClient netClient = this;
      int num1 = 1;
      int num2 = num1;
      this.quietReset = num1 != 0;
      this.quiet = num2 != 0;
      Vars.net.disconnect();
    }

    [LineNumberTable(new byte[] {161, 227, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearRemovedEntity(int id) => this.removed.remove(id);

    [HideFromJava]
    public virtual void init() => ApplicationListener.\u003Cdefault\u003Einit((ApplicationListener) this);

    [HideFromJava]
    public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

    [HideFromJava]
    public virtual void pause() => ApplicationListener.\u003Cdefault\u003Epause((ApplicationListener) this);

    [HideFromJava]
    public virtual void resume() => ApplicationListener.\u003Cdefault\u003Eresume((ApplicationListener) this);

    [HideFromJava]
    public virtual void dispose() => ApplicationListener.\u003Cdefault\u003Edispose((ApplicationListener) this);

    [HideFromJava]
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

    [HideFromJava]
    public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly NetClient arg\u00241;

      internal __\u003C\u003EAnon0([In] NetClient obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((Packets.Connect) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly NetClient arg\u00241;

      internal __\u003C\u003EAnon1([In] NetClient obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((Packets.Disconnect) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly NetClient arg\u00241;

      internal __\u003C\u003EAnon2([In] NetClient obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((Packets.WorldStream) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => NetClient.lambda\u0024new\u00244((Packets.InvokePacket) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => NetClient.lambda\u0024worldDataBegin\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => Call.connectConfirm();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Platform arg\u00241;

      internal __\u003C\u003EAnon7([In] Platform obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.updateRPC();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly LoadingFragment arg\u00241;

      internal __\u003C\u003EAnon8([In] LoadingFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly NetClient arg\u00241;

      internal __\u003C\u003EAnon9([In] NetClient obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }
  }
}
