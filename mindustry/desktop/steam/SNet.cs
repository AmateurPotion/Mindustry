// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.steam.SNet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.util;
using arc.util.pooling;
using com.codedisaster.steamworks;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util;
using java.util.concurrent;
using mindustry.game;
using mindustry.net;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop.steam
{
  [Implements(new string[] {"com.codedisaster.steamworks.SteamNetworkingCallback", "com.codedisaster.steamworks.SteamMatchmakingCallback", "com.codedisaster.steamworks.SteamFriendsCallback", "mindustry.net.Net$NetProvider"})]
  public class SNet : 
    Object,
    SteamNetworkingCallback,
    SteamMatchmakingCallback,
    SteamFriendsCallback,
    mindustry.net.Net.NetProvider
  {
    internal SteamNetworking __\u003C\u003Esnet;
    internal SteamMatchmaking __\u003C\u003Esmat;
    internal SteamFriends __\u003C\u003Efriends;
    [Modifiers]
    internal mindustry.net.Net.NetProvider provider;
    [Modifiers]
    internal ArcNetProvider.PacketSerializer serializer;
    [Modifiers]
    internal ByteBuffer writeBuffer;
    [Modifiers]
    internal ByteBuffer readBuffer;
    [Modifiers]
    [Signature("Ljava/util/concurrent/CopyOnWriteArrayList<Lmindustry/desktop/steam/SNet$SteamConnection;>;")]
    internal CopyOnWriteArrayList connections;
    [Modifiers]
    [Signature("Larc/struct/IntMap<Lmindustry/desktop/steam/SNet$SteamConnection;>;")]
    internal IntMap steamConnections;
    internal SteamID currentLobby;
    internal SteamID currentServer;
    [Signature("Larc/func/Cons<Lmindustry/net/Host;>;")]
    internal Cons lobbyCallback;
    internal Runnable lobbyDoneCallback;
    internal Runnable joinCallback;

    [LineNumberTable(new byte[] {159, 186, 232, 47, 108, 108, 204, 107, 112, 144, 107, 235, 71, 135, 245, 112, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SNet(mindustry.net.Net.NetProvider provider)
    {
      SNet snet = this;
      this.__\u003C\u003Esnet = new SteamNetworking((SteamNetworkingCallback) this);
      this.__\u003C\u003Esmat = new SteamMatchmaking((SteamMatchmakingCallback) this);
      this.__\u003C\u003Efriends = new SteamFriends((SteamFriendsCallback) this);
      this.serializer = new ArcNetProvider.PacketSerializer();
      this.writeBuffer = ByteBuffer.allocateDirect(16384);
      this.readBuffer = ByteBuffer.allocateDirect(16384);
      this.connections = new CopyOnWriteArrayList();
      this.steamConnections = new IntMap();
      this.provider = provider;
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new SNet.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.WaveEvent>.Value, (Cons) new SNet.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {161, 6, 104, 113, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showFriendInvites()
    {
      if (this.currentLobby == null)
        return;
      this.__\u003C\u003Efriends.activateGameOverlayInviteDialog(this.currentLobby);
      Log.info((object) "Activating overlay dialog");
    }

    [LineNumberTable(new byte[] {160, 73, 116, 127, 16, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateLobby()
    {
      if (this.currentLobby == null || !Vars.net.server())
        return;
      this.__\u003C\u003Esmat.setLobbyType(this.currentLobby, !Core.settings.getBool("publichost") ? SteamMatchmaking.LobbyType.__\u003C\u003EFriendsOnly : SteamMatchmaking.LobbyType.__\u003C\u003EPublic);
      this.__\u003C\u003Esmat.setLobbyMemberLimit(this.currentLobby, Core.settings.getInt("playerlimit"));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSteamClient() => this.currentServer != null;

    [LineNumberTable(new byte[] {160, 104, 103, 141, 110, 114, 112, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void disconnectSteamUser([In] SteamID obj0)
    {
      int accountId = obj0.getAccountID();
      this.__\u003C\u003Esnet.closeP2PSessionWithUser(obj0);
      if (!this.steamConnections.containsKey(accountId))
        return;
      SNet.SteamConnection steamConnection = (SNet.SteamConnection) this.steamConnections.get(accountId);
      Vars.net.handleServerReceived((NetConnection) steamConnection, (object) new Packets.Disconnect());
      this.steamConnections.remove(accountId);
      this.connections.remove((object) steamConnection);
    }

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ClientLoadEvent obj0) => Core.app.addListener((ApplicationListener) new SNet.\u0031(this));

    [Modifiers]
    [LineNumberTable(new byte[] {46, 116, 159, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] EventType.WaveEvent obj0)
    {
      if (this.currentLobby == null || !Vars.net.server())
        return;
      this.__\u003C\u003Esmat.setLobbyData(this.currentLobby, "wave", new StringBuilder().append(Vars.state.wave).append("").toString());
    }

    [Modifiers]
    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024discoverServers\u00242([In] Cons obj0, [In] Runnable obj1) => this.provider.discoverServers(obj0, obj1);

    [Modifiers]
    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024hostServer\u00245() => Core.app.post((Runnable) new SNet.__\u003C\u003EAnon8());

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024onLobbyEnter\u00248() => Core.app.post((Runnable) new SNet.__\u003C\u003EAnon6());

    [Modifiers]
    [LineNumberTable(343)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024onLobbyMatchList\u00249([In] Host obj0) => -obj0.__\u003C\u003Eplayers;

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024onLobbyEnter\u00247() => Core.app.post((Runnable) new SNet.__\u003C\u003EAnon7());

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024onLobbyEnter\u00246() => Log.info("Server: @\nClient: @\nActive: @", (object) Boolean.valueOf(Vars.net.server()), (object) Boolean.valueOf(Vars.net.client()), (object) Boolean.valueOf(Vars.net.active()));

    [Modifiers]
    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024hostServer\u00244() => Core.app.post((Runnable) new SNet.__\u003C\u003EAnon9());

    [Modifiers]
    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024hostServer\u00243() => Log.info("Server: @\nClient: @\nActive: @", (object) Boolean.valueOf(Vars.net.server()), (object) Boolean.valueOf(Vars.net.client()), (object) Boolean.valueOf(Vars.net.active()));

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {58, 112, 145, 108, 103, 184, 2, 97, 159, 6, 98, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connectClient(string ip, int port, Runnable success)
    {
      if (String.instancehelper_startsWith(ip, "steam:"))
      {
        string str1 = String.instancehelper_substring(ip, String.instancehelper_length("steam:"));
        try
        {
          SteamID fromNativeHandle = SteamID.createFromNativeHandle(Long.parseLong(str1));
          this.joinCallback = success;
          this.__\u003C\u003Esmat.joinLobby(fromNativeHandle);
          return;
        }
        catch (NumberFormatException ex)
        {
        }
        string str2 = new StringBuilder().append("Invalid Steam ID: ").append(str1).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str2);
      }
      this.provider.connectClient(ip, port, success);
    }

    [LineNumberTable(new byte[] {74, 107, 104, 106, 193, 119, 109, 114, 108, 140, 191, 50, 2, 97, 139, 136, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendClient(object @object, mindustry.net.Net.SendMode mode)
    {
      if (this.isSteamClient())
      {
        if (this.currentServer == null)
        {
          Log.info((object) "Not connected, quitting.");
        }
        else
        {
          Exception exception1;
          try
          {
            ((Buffer) this.writeBuffer).limit(((Buffer) this.writeBuffer).capacity());
            ((Buffer) this.writeBuffer).position(0);
            this.serializer.write(this.writeBuffer, @object);
            int num = ((Buffer) this.writeBuffer).position();
            ((Buffer) this.writeBuffer).flip();
            this.__\u003C\u003Esnet.sendP2PPacket(this.currentServer, this.writeBuffer, object.ReferenceEquals((object) mode, (object) mindustry.net.Net.SendMode.__\u003C\u003Etcp) || num >= 1200 ? SteamNetworking.P2PSend.__\u003C\u003EReliable : SteamNetworking.P2PSend.__\u003C\u003EUnreliableNoDelay, 0);
            goto label_8;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception1 = (Exception) m0;
          }
          Exception exception2 = exception1;
          Vars.net.showError((Exception) exception2);
label_8:
          Pools.free(@object);
        }
      }
      else
        this.provider.sendClient(@object, mode);
    }

    [LineNumberTable(new byte[] {100, 104, 104, 113, 114, 103, 103, 177, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnectClient()
    {
      if (this.isSteamClient())
      {
        if (this.currentLobby == null)
          return;
        this.__\u003C\u003Esmat.leaveLobby(this.currentLobby);
        this.__\u003C\u003Esnet.closeP2PSessionWithUser(this.currentServer);
        this.currentServer = (SteamID) null;
        this.currentLobby = (SteamID) null;
        Vars.net.handleClientReceived((object) new Packets.Disconnect());
      }
      else
        this.provider.disconnectClient();
    }

    [Signature("(Larc/func/Cons<Lmindustry/net/Host;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {115, 109, 108, 167, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void discoverServers(Cons callback, Runnable done)
    {
      this.__\u003C\u003Esmat.addRequestLobbyListResultCountFilter(32);
      this.__\u003C\u003Esmat.requestLobbyList();
      this.lobbyCallback = callback;
      this.lobbyDoneCallback = (Runnable) new SNet.__\u003C\u003EAnon2(this, callback, done);
    }

    [Signature("(Ljava/lang/String;ILarc/func/Cons<Lmindustry/net/Host;>;Larc/func/Cons<Ljava/lang/Exception;>;)V")]
    [LineNumberTable(new byte[] {125, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pingHost(string address, int port, Cons valid, Cons failed) => this.provider.pingHost(address, port, valid, failed);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 66, 108, 159, 25, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hostServer(int port)
    {
      this.provider.hostServer(port);
      this.__\u003C\u003Esmat.createLobby(!Core.settings.getBool("publichost") ? SteamMatchmaking.LobbyType.__\u003C\u003EFriendsOnly : SteamMatchmaking.LobbyType.__\u003C\u003EPublic, Core.settings.getInt("playerlimit"));
      Core.app.post((Runnable) new SNet.__\u003C\u003EAnon3());
    }

    [LineNumberTable(new byte[] {160, 81, 139, 104, 113, 127, 6, 102, 98, 167, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void closeServer()
    {
      this.provider.closeServer();
      if (this.currentLobby != null)
      {
        this.__\u003C\u003Esmat.leaveLobby(this.currentLobby);
        Iterator iterator = this.steamConnections.values().iterator();
        while (iterator.hasNext())
          ((SNet.SteamConnection) iterator.next()).close();
        this.currentLobby = (SteamID) null;
      }
      this.steamConnections.clear();
    }

    [Signature("()Ljava/lang/Iterable<+Lmindustry/net/NetConnection;>;")]
    [LineNumberTable(new byte[] {160, 97, 113, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterable getConnections()
    {
      CopyOnWriteArrayList.__\u003Cclinit\u003E();
      CopyOnWriteArrayList onWriteArrayList = new CopyOnWriteArrayList((Collection) this.connections);
      Iterator iterator = this.provider.getConnections().iterator();
      while (iterator.hasNext())
      {
        NetConnection netConnection = (NetConnection) iterator.next();
        onWriteArrayList.add((object) netConnection);
      }
      return (Iterable) onWriteArrayList;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onFavoritesListChanged(
      int i,
      int i1,
      int i2,
      int i3,
      int i4,
      bool b,
      int i5)
    {
    }

    [LineNumberTable(new byte[] {160, 122, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyInvite(SteamID steamIDUser, SteamID steamIDLobby, long gameID) => Log.info("onLobbyInvite @ @ @", (object) Integer.valueOf(steamIDLobby.getAccountID()), (object) Integer.valueOf(steamIDUser.getAccountID()), (object) Long.valueOf(gameID));

    [LineNumberTable(new byte[] {160, 127, 159, 4, 110, 111, 127, 10, 161, 184, 107, 111, 127, 52, 62, 133, 108, 161, 106, 138, 103, 146, 159, 24, 104, 107, 167, 102, 159, 11, 106, 139, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyEnter(
      SteamID steamIDLobby,
      int chatPermissions,
      bool blocked,
      SteamMatchmaking.ChatRoomEnterResponse response)
    {
      Log.info("onLobbyEnter @ @", (object) Integer.valueOf(steamIDLobby.getAccountID()), (object) response);
      if (!object.ReferenceEquals((object) response, (object) SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ESuccess))
      {
        Vars.ui.loadfrag.hide();
        Vars.ui.showErrorMessage(Core.bundle.format("cantconnect", (object) response.toString()));
      }
      else
      {
        int num = Strings.parseInt(this.__\u003C\u003Esmat.getLobbyData(steamIDLobby, "version"), -1);
        if (num != mindustry.core.Version.build)
        {
          Vars.ui.loadfrag.hide();
          Vars.ui.showInfo(new StringBuilder().append("[scarlet]").append((num <= mindustry.core.Version.build ? Packets.KickReason.__\u003C\u003EserverOutdated : Packets.KickReason.__\u003C\u003EclientOutdated).toString()).append("\n[]").append(Core.bundle.format("server.versions", (object) Integer.valueOf(mindustry.core.Version.build), (object) Integer.valueOf(num))).toString());
          this.__\u003C\u003Esmat.leaveLobby(steamIDLobby);
        }
        else
        {
          Vars.logic.reset();
          Vars.net.reset();
          this.currentLobby = steamIDLobby;
          this.currentServer = this.__\u003C\u003Esmat.getLobbyOwner(steamIDLobby);
          Log.info("Connect to owner @: @", (object) Integer.valueOf(this.currentServer.getAccountID()), (object) this.__\u003C\u003Efriends.getFriendPersonaName(this.currentServer));
          if (this.joinCallback != null)
          {
            this.joinCallback.run();
            this.joinCallback = (Runnable) null;
          }
          Packets.Connect connect = new Packets.Connect();
          connect.addressTCP = new StringBuilder().append("steam:").append(this.currentServer.getAccountID()).toString();
          Vars.net.setClientConnected();
          Vars.net.handleClientReceived((object) connect);
          Core.app.post((Runnable) new SNet.__\u003C\u003EAnon4());
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyDataUpdate(SteamID steamID, SteamID steamID1, bool b)
    {
    }

    [LineNumberTable(new byte[] {160, 175, 127, 32, 124, 140, 124, 106, 204, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyChatUpdate(
      SteamID lobby,
      SteamID who,
      SteamID changer,
      SteamMatchmaking.ChatMemberStateChange change)
    {
      Log.info("lobby @: @ caused @'s change: @", (object) Integer.valueOf(lobby.getAccountID()), (object) Integer.valueOf(who.getAccountID()), (object) Integer.valueOf(changer.getAccountID()), (object) change);
      if (!object.ReferenceEquals((object) change, (object) SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EDisconnected) && !object.ReferenceEquals((object) change, (object) SteamMatchmaking.ChatMemberStateChange.__\u003C\u003ELeft))
        return;
      if (Vars.net.client())
      {
        if (!who.equals((object) this.currentServer) && !who.equals((object) this.currentLobby))
          return;
        Vars.net.disconnect();
        Log.info((object) "Current host left.");
      }
      else
        this.disconnectSteamUser(who);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyChatMessage(
      SteamID steamID,
      SteamID steamID1,
      SteamMatchmaking.ChatEntryType chatEntryType,
      int i)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyGameCreated(SteamID steamID, SteamID steamID1, int i, short i1)
    {
    }

    [LineNumberTable(new byte[] {160, 202, 159, 3, 107, 102, 137, 109, 141, 117, 123, 113, 114, 113, 119, 113, 113, 209, 191, 1, 2, 98, 231, 45, 233, 87, 118, 140, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyMatchList(int matches)
    {
      Log.info("found @ matches @", (object) Integer.valueOf(matches), (object) this.lobbyDoneCallback);
      if (this.lobbyDoneCallback == null)
        return;
      Seq seq = new Seq();
      for (int lobby = 0; lobby < matches; ++lobby)
      {
        Exception exception;
        try
        {
          SteamID lobbyByIndex = this.__\u003C\u003Esmat.getLobbyByIndex(lobby);
          Host host = new Host(-1, this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "name"), new StringBuilder().append("steam:").append(lobbyByIndex.handle()).toString(), this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "mapname"), Strings.parseInt(this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "wave"), -1), this.__\u003C\u003Esmat.getNumLobbyMembers(lobbyByIndex), Strings.parseInt(this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "version"), -1), this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "versionType"), Gamemode.valueOf(this.__\u003C\u003Esmat.getLobbyData(lobbyByIndex, "gamemode")), this.__\u003C\u003Esmat.getLobbyMemberLimit(lobbyByIndex), "", (string) null);
          seq.add((object) host);
          continue;
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
      seq.sort(Structs.comparingInt((Intf) new SNet.__\u003C\u003EAnon5()));
      seq.each(this.lobbyCallback);
      this.lobbyDoneCallback.run();
    }

    [LineNumberTable(new byte[] {159, 54, 66, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyKicked(SteamID steamID, SteamID steamID1, bool b)
    {
      int num = b ? 1 : 0;
      Log.info("Kicked: @ @ @", (object) steamID, (object) steamID1, (object) Boolean.valueOf(num != 0));
    }

    [LineNumberTable(new byte[] {160, 243, 108, 116, 161, 127, 3, 112, 135, 124, 127, 2, 127, 17, 119, 127, 22, 159, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLobbyCreated(SteamResult result, SteamID steamID)
    {
      if (!Vars.net.server())
      {
        Log.info("Lobby created on server: @, ignoring.", (object) steamID);
      }
      else
      {
        Log.info("Lobby @ created? @", (object) result, (object) Integer.valueOf(steamID.getAccountID()));
        if (!object.ReferenceEquals((object) result, (object) SteamResult.__\u003C\u003EOK))
          return;
        this.currentLobby = steamID;
        this.__\u003C\u003Esmat.setLobbyData(steamID, "name", Vars.player.name);
        this.__\u003C\u003Esmat.setLobbyData(steamID, "mapname", Vars.state.map.name());
        this.__\u003C\u003Esmat.setLobbyData(steamID, "version", new StringBuilder().append(mindustry.core.Version.build).append("").toString());
        this.__\u003C\u003Esmat.setLobbyData(steamID, "versionType", mindustry.core.Version.type);
        this.__\u003C\u003Esmat.setLobbyData(steamID, "wave", new StringBuilder().append(Vars.state.wave).append("").toString());
        this.__\u003C\u003Esmat.setLobbyData(steamID, "gamemode", new StringBuilder().append(Vars.state.rules.mode().name()).append("").toString());
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onFavoritesListAccountsUpdated(SteamResult steamResult)
    {
    }

    [LineNumberTable(new byte[] {161, 19, 108, 127, 3, 105, 110, 127, 3, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onP2PSessionConnectFail(
      SteamID steamIDRemote,
      SteamNetworking.P2PSessionError sessionError)
    {
      if (Vars.net.server())
      {
        Log.info("@ has disconnected: @", (object) Integer.valueOf(steamIDRemote.getAccountID()), (object) sessionError);
        this.disconnectSteamUser(steamIDRemote);
      }
      else
      {
        if (!steamIDRemote.equals((object) this.currentServer))
          return;
        Log.info("Disconnected! @: @", (object) Integer.valueOf(steamIDRemote.getAccountID()), (object) sessionError);
        Vars.net.handleClientReceived((object) new Packets.Disconnect());
      }
    }

    [LineNumberTable(new byte[] {161, 30, 126, 108, 127, 5, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onP2PSessionRequest(SteamID steamIDRemote)
    {
      Log.info("Connection request: @", (object) Integer.valueOf(steamIDRemote.getAccountID()));
      if (!Vars.net.server())
        return;
      Log.info((object) new StringBuilder().append("Am server, accepting request from ").append(steamIDRemote.getAccountID()).toString());
      this.__\u003C\u003Esnet.acceptP2PSessionWithUser(steamIDRemote);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onSetPersonaNameResponse(bool b, bool b1, SteamResult steamResult)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onPersonaStateChange(
      SteamID steamID,
      SteamFriends.PersonaChange personaChange)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGameOverlayActivated(bool b)
    {
    }

    [LineNumberTable(new byte[] {161, 54, 120, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGameLobbyJoinRequested(SteamID lobby, SteamID steamIDFriend)
    {
      Log.info("onGameLobbyJoinRequested @ @", (object) lobby, (object) steamIDFriend);
      this.__\u003C\u003Esmat.joinLobby(lobby);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onAvatarImageLoaded(SteamID steamID, int i, int i1, int i2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onFriendRichPresenceUpdate(SteamID steamID, int i)
    {
    }

    [LineNumberTable(new byte[] {161, 70, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGameRichPresenceJoinRequested(SteamID steamID, string connect) => Log.info("onGameRichPresenceJoinRequested @ @", (object) steamID, (object) connect);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGameServerChangeRequested(string server, string password)
    {
    }

    [HideFromJava]
    public virtual void dispose() => mindustry.net.Net.NetProvider.\u003Cdefault\u003Edispose((mindustry.net.Net.NetProvider) this);

    [Modifiers]
    public SteamNetworking snet
    {
      [HideFromJava] get => this.__\u003C\u003Esnet;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esnet = value;
    }

    [Modifiers]
    public SteamMatchmaking smat
    {
      [HideFromJava] get => this.__\u003C\u003Esmat;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esmat = value;
    }

    [Modifiers]
    public SteamFriends friends
    {
      [HideFromJava] get => this.__\u003C\u003Efriends;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efriends = value;
    }

    [EnclosingMethod(null, "<init>", "(Lmindustry.net.Net$NetProvider;)V")]
    [SpecialName]
    internal class \u0031 : Object, ApplicationListener
    {
      internal int length;
      internal SteamID from;
      [Modifiers]
      internal SNet this\u00240;

      [LineNumberTable(new byte[] {159, 189, 175})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SNet obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        SNet.\u0031 obj = this;
        this.from = new SteamID();
      }

      [LineNumberTable(new byte[] {4, 159, 2, 114, 127, 4, 108, 156, 111, 183, 102, 124, 103, 159, 12, 154, 125, 114, 173, 188, 31, 4, 98, 158, 159, 6, 187, 28, 98, 255, 1, 69, 5, 98, 103, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        while (true)
        {
          SNet.\u0031 obj = this;
          int num1 = this.this\u00240.__\u003C\u003Esnet.isP2PPacketAvailable(0);
          int num2 = num1;
          this.length = num1;
          if (num2 != 0)
          {
            int accountId;
            object @object;
            Exception exception1;
            SteamException steamException1;
            try
            {
              ((Buffer) this.this\u00240.readBuffer).position(0);
              this.this\u00240.__\u003C\u003Esnet.readP2PPacket(this.from, this.this\u00240.readBuffer, 0);
              accountId = this.from.getAccountID();
              @object = this.this\u00240.serializer.read(this.this\u00240.readBuffer);
              if (Vars.net.server())
              {
                SNet.SteamConnection steamConnection = (SNet.SteamConnection) this.this\u00240.steamConnections.get(accountId);
                try
                {
                  if (steamConnection == null)
                  {
                    steamConnection = new SNet.SteamConnection(this.this\u00240, SteamID.createFromNativeHandle(this.from.handle()));
                    Packets.Connect connect = new Packets.Connect();
                    connect.addressTCP = new StringBuilder().append("steam:").append(this.from.getAccountID()).toString();
                    Log.info("&bReceived STEAM connection: @", (object) connect.addressTCP);
                    this.this\u00240.steamConnections.put(this.from.getAccountID(), (object) steamConnection);
                    this.this\u00240.connections.add((object) steamConnection);
                    Vars.net.handleServerReceived((NetConnection) steamConnection, (object) connect);
                  }
                  Vars.net.handleServerReceived((NetConnection) steamConnection, @object);
                  continue;
                }
                catch (Exception ex)
                {
                  exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                }
              }
              else
                goto label_13;
            }
            catch (SteamException ex)
            {
              steamException1 = (SteamException) ByteCodeHelper.MapException<SteamException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              goto label_9;
            }
            Exception th = exception1;
            SteamException steamException2;
            try
            {
              Log.err(th);
              continue;
            }
            catch (SteamException ex)
            {
              steamException2 = (SteamException) ByteCodeHelper.MapException<SteamException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
            SteamException steamException3 = steamException2;
            goto label_24;
label_9:
            steamException3 = steamException1;
            goto label_24;
label_13:
            Exception exception2;
            SteamException steamException4;
            try
            {
              if (this.this\u00240.currentServer != null)
              {
                if (accountId == this.this\u00240.currentServer.getAccountID())
                {
                  try
                  {
                    Vars.net.handleClientReceived(@object);
                    continue;
                  }
                  catch (Exception ex)
                  {
                    exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                  }
                }
                else
                  continue;
              }
              else
                continue;
            }
            catch (SteamException ex)
            {
              steamException4 = (SteamException) ByteCodeHelper.MapException<SteamException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              goto label_19;
            }
            Exception exception3 = exception2;
            SteamException steamException5;
            try
            {
              Exception e = exception3;
              Vars.net.handleException(e);
              continue;
            }
            catch (SteamException ex)
            {
              steamException5 = (SteamException) ByteCodeHelper.MapException<SteamException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
            steamException3 = steamException5;
            goto label_24;
label_19:
            steamException3 = steamException4;
label_24:
            Log.err((Exception) steamException3);
          }
          else
            break;
        }
      }

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
    }

    public class SteamConnection : NetConnection
    {
      [Modifiers]
      internal SteamID sid;
      [Modifiers]
      internal SteamNetworking.P2PSessionState state;
      [Modifiers]
      internal SNet this\u00240;

      [LineNumberTable(new byte[] {161, 82, 103, 255, 8, 61, 203, 103, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SteamConnection(SNet _param1, SteamID sid)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector(new StringBuilder().append(sid.getAccountID()).append("").toString());
        SNet.SteamConnection steamConnection = this;
        this.state = new SteamNetworking.P2PSessionState();
        this.sid = sid;
        Log.info("Create STEAM client @", (object) Integer.valueOf(sid.getAccountID()));
      }

      [LineNumberTable(new byte[] {161, 116, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void close() => this.this\u00240.disconnectSteamUser(this.sid);

      [LineNumberTable(new byte[] {161, 91, 127, 2, 114, 124, 113, 145, 255, 75, 72, 226, 57, 97, 102, 106, 134, 127, 2, 159, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void send(object @object, mindustry.net.Net.SendMode mode)
      {
        Exception exception;
        try
        {
          ((Buffer) this.this\u00240.writeBuffer).limit(((Buffer) this.this\u00240.writeBuffer).capacity());
          ((Buffer) this.this\u00240.writeBuffer).position(0);
          this.this\u00240.serializer.write(this.this\u00240.writeBuffer, @object);
          int num = ((Buffer) this.this\u00240.writeBuffer).position();
          ((Buffer) this.this\u00240.writeBuffer).flip();
          this.this\u00240.__\u003C\u003Esnet.sendP2PPacket(this.sid, this.this\u00240.writeBuffer, object.ReferenceEquals((object) mode, (object) mindustry.net.Net.SendMode.__\u003C\u003Etcp) || num >= 1200 ? (!(@object is Packets.StreamChunk) ? SteamNetworking.P2PSend.__\u003C\u003EReliable : SteamNetworking.P2PSend.__\u003C\u003EReliableWithBuffering) : SteamNetworking.P2PSend.__\u003C\u003EUnreliableNoDelay, 0);
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
        Log.info((object) "Error sending packet. Disconnecting invalid client!");
        this.close();
        if ((SNet.SteamConnection) this.this\u00240.steamConnections.get(this.sid.getAccountID()) == null)
          return;
        this.this\u00240.steamConnections.remove(this.sid.getAccountID());
      }

      [LineNumberTable(new byte[] {161, 110, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool isConnected()
      {
        this.this\u00240.__\u003C\u003Esnet.getP2PSessionState(this.sid, this.state);
        return true;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly SNet arg\u00241;

      internal __\u003C\u003EAnon0([In] SNet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly SNet arg\u00241;

      internal __\u003C\u003EAnon1([In] SNet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((EventType.WaveEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly SNet arg\u00241;
      private readonly Cons arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon2([In] SNet obj0, [In] Cons obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024discoverServers\u00242(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => SNet.lambda\u0024hostServer\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => SNet.lambda\u0024onLobbyEnter\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Intf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public int get([In] object obj0) => SNet.lambda\u0024onLobbyMatchList\u00249((Host) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => SNet.lambda\u0024onLobbyEnter\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => SNet.lambda\u0024onLobbyEnter\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => SNet.lambda\u0024hostServer\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void run() => SNet.lambda\u0024hostServer\u00243();
    }
  }
}
