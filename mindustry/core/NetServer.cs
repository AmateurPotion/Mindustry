// Decompiled with JetBrains decompiler
// Type: mindustry.core.NetServer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using java.util;
using java.util.zip;
using mindustry.content;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.mod;
using mindustry.net;
using mindustry.world;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class NetServer : Object, ApplicationListener
  {
    private const int maxSnapshotSize = 800;
    private const int timerBlockSync = 0;
    private const int serverSyncTime = 200;
    private const float blockSyncTime = 360f;
    [Modifiers]
    private static FloatBuffer fbuffer;
    [Modifiers]
    private static Vec2 vector;
    [Modifiers]
    private static Rect viewport;
    private const float correctDist = 112f;
    internal Administration __\u003C\u003Eadmins;
    internal CommandHandler __\u003C\u003EclientCommands;
    public NetServer.TeamAssigner assigner;
    private bool closing;
    private Interval timer;
    private ReusableByteOutStream writeBuffer;
    private Writes outputBuffer;
    private ReusableByteOutStream syncStream;
    private DataOutputStream dataStream;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Larc/func/Cons2<Lmindustry/gen/Player;Ljava/lang/String;>;>;>;")]
    private ObjectMap customPacketHandlers;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {31, 232, 29, 107, 112, 240, 84, 103, 139, 109, 187, 139, 145, 203, 250, 72, 249, 70, 250, 160, 160, 249, 80, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NetServer()
    {
      NetServer netServer = this;
      this.__\u003C\u003Eadmins = new Administration();
      this.__\u003C\u003EclientCommands = new CommandHandler("/");
      this.assigner = (NetServer.TeamAssigner) new NetServer.__\u003C\u003EAnon0();
      this.closing = false;
      this.timer = new Interval();
      this.writeBuffer = new ReusableByteOutStream((int) sbyte.MaxValue);
      Writes.__\u003Cclinit\u003E();
      this.outputBuffer = new Writes((DataOutput) new DataOutputStream((OutputStream) this.writeBuffer));
      this.syncStream = new ReusableByteOutStream();
      this.dataStream = new DataOutputStream((OutputStream) this.syncStream);
      this.customPacketHandlers = new ObjectMap();
      Vars.net.handleServer((Class) ClassLiteral<Packets.Connect>.Value, (Cons2) new NetServer.__\u003C\u003EAnon1(this));
      Vars.net.handleServer((Class) ClassLiteral<Packets.Disconnect>.Value, (Cons2) new NetServer.__\u003C\u003EAnon2());
      Vars.net.handleServer((Class) ClassLiteral<Packets.ConnectPacket>.Value, (Cons2) new NetServer.__\u003C\u003EAnon3(this));
      Vars.net.handleServer((Class) ClassLiteral<Packets.InvokePacket>.Value, (Cons2) new NetServer.__\u003C\u003EAnon4());
      this.registerCommands();
    }

    [LineNumberTable(503)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team assignTeam(Player current) => this.assigner.assign(current, (Iterable) Groups.player);

    [LineNumberTable(499)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int votesRequired() => 2 + (Groups.player.size() > 4 ? 1 : 0);

    [LineNumberTable(new byte[] {160, 168, 255, 7, 90, 255, 7, 71, 255, 6, 74, 134, 134, 230, 109, 134, 140, 255, 13, 160, 64, 255, 9, 104, 255, 1, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void registerCommands()
    {
      this.__\u003C\u003EclientCommands.register("help", "[page]", "Lists all commands.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon6(this));
      this.__\u003C\u003EclientCommands.register("t", "<message...>", "Send a message only to your teammates.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon7(this));
      this.__\u003C\u003EclientCommands.register("a", "<message...>", "Send a message only to admins.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon8());
      int num1 = 3600;
      float num2 = 30f;
      int num3 = 300;
      ObjectMap objectMap = new ObjectMap();
      NetServer.\u0031VoteSession[] objArray = new NetServer.\u0031VoteSession[1]
      {
        (NetServer.\u0031VoteSession) null
      };
      this.__\u003C\u003EclientCommands.register("votekick", "[player...]", "Vote to kick a player.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon9(this, objArray, objectMap, num3, num2, num1));
      this.__\u003C\u003EclientCommands.register("vote", "<y/n>", "Vote to kick the current player.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon10(this, objArray));
      this.__\u003C\u003EclientCommands.register("sync", "Re-synchronize world state.", (CommandHandler.CommandRunner) new NetServer.__\u003C\u003EAnon11());
    }

    [LineNumberTable(new byte[] {161, 183, 114, 127, 16, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void serverPacketReliable(Player player, string type, string contents)
    {
      if (!Vars.netServer.customPacketHandlers.containsKey((object) type))
        return;
      Iterator iterator = ((Seq) Vars.netServer.customPacketHandlers.get((object) type)).iterator();
      while (iterator.hasNext())
        ((Cons2) iterator.next()).get((object) player, (object) contents);
    }

    [LineNumberTable(566)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool invalid([In] float obj0) => Float.isInfinite(obj0) || Float.isNaN(obj0);

    [LineNumberTable(new byte[] {162, 156, 127, 1, 98, 127, 10, 120, 132, 98, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isWaitingForPlayers()
    {
      if (!Vars.state.rules.pvp || Vars.state.gameOver)
        return false;
      int num = 0;
      Iterator iterator = Vars.state.teams.getActive().iterator();
      while (iterator.hasNext())
      {
        Teams.TeamData teamData = (Teams.TeamData) iterator.next();
        if (Groups.player.count((Boolf) new NetServer.__\u003C\u003EAnon15(teamData)) > 0)
          ++num;
      }
      return num < 2;
    }

    [LineNumberTable(new byte[] {163, 84, 255, 0, 83, 127, 18, 248, 69, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sync()
    {
      IOException ioException;
      try
      {
        Groups.player.each((Boolf) new NetServer.__\u003C\u003EAnon18(), (Cons) new NetServer.__\u003C\u003EAnon19(this));
        if (Groups.player.size() <= 0 || !Core.settings.getBool("blocksync") || !this.timer.get(0, 360f))
          return;
        this.writeBlockSnapshots();
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      Log.err((Exception) ioException);
    }

    [LineNumberTable(new byte[] {163, 58, 110, 110, 137, 122, 127, 7, 109, 138, 130, 103, 109, 223, 7, 2, 97, 226, 48, 233, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string checkColor([In] string obj0)
    {
      for (int index = 1; index < String.instancehelper_length(obj0); ++index)
      {
        if (String.instancehelper_charAt(obj0, index) == ']')
        {
          string hex = String.instancehelper_substring(obj0, 1, index);
          if (Colors.get(String.instancehelper_toUpperCase(hex)) == null)
          {
            if (Colors.get(String.instancehelper_toLowerCase(hex)) == null)
            {
              string str;
              try
              {
                if ((double) Color.valueOf(hex).a <= 0.800000011920929)
                  str = String.instancehelper_substring(obj0, index + 1);
                else
                  continue;
              }
              catch (Exception ex)
              {
                if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
                  throw;
                else
                  goto label_12;
              }
              return str;
label_12:
              return obj0;
            }
          }
          if ((double) (Colors.get(String.instancehelper_toLowerCase(hex)) != null ? Colors.get(String.instancehelper_toLowerCase(hex)) : Colors.get(String.instancehelper_toUpperCase(hex))).a <= 0.800000011920929)
            return String.instancehelper_substring(obj0, index + 1);
        }
      }
      return obj0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 211, 139, 98, 127, 3, 111, 133, 113, 118, 145, 114, 107, 108, 116, 98, 139, 133, 100, 107, 109, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBlockSnapshots()
    {
      this.syncStream.reset();
      int num = 0;
      Iterator iterator = Groups.build.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building.block.sync)
        {
          num = (int) (short) (num + 1);
          this.dataStream.writeInt(building.pos());
          this.dataStream.writeShort((int) building.block.__\u003C\u003Eid);
          building.writeAll(Writes.get((DataOutput) this.dataStream));
          if (this.syncStream.size() > 800)
          {
            ((FilterOutputStream) this.dataStream).close();
            byte[] byteArray = this.syncStream.toByteArray();
            Call.blockSnapshot((short) num, (short) byteArray.Length, Vars.net.compressSnapshot(byteArray));
            num = 0;
            this.syncStream.reset();
          }
        }
      }
      if (num <= 0)
        return;
      ((FilterOutputStream) this.dataStream).close();
      byte[] byteArray1 = this.syncStream.toByteArray();
      Call.blockSnapshot((short) num, (short) byteArray1.Length, Vars.net.compressSnapshot(byteArray1));
    }

    [LineNumberTable(new byte[] {161, 161, 104, 102, 161, 112, 109, 107, 127, 27, 171, 127, 8, 178, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void onDisconnect(Player player, string reason)
    {
      if (player.con == null)
      {
        player.remove();
      }
      else
      {
        if (!player.con.hasDisconnected)
        {
          if (player.con.hasConnected)
          {
            Events.fire((object) new EventType.PlayerLeave(player));
            if (Administration.Config.__\u003C\u003EshowConnectMessages.@bool())
              Call.sendMessage(new StringBuilder().append("[accent]").append(player.name).append("[accent] has disconnected.").toString());
            Call.playerDisconnect(player.id());
          }
          string str = Strings.format("&lb@&fi&lk has disconnected. &fi&lk[&lb@&fi&lk] (@)", (object) player.name, (object) player.uuid(), (object) reason);
          if (Administration.Config.__\u003C\u003EshowConnectMessages.@bool())
            Log.info((object) str);
        }
        player.remove();
        player.con.hasDisconnected = true;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 239, 107, 159, 0, 140, 127, 13, 127, 2, 119, 119, 98, 133, 107, 173, 159, 56, 159, 29, 139, 131, 159, 4, 114, 114, 146, 134, 114, 107, 109, 126, 99, 139, 133, 101, 139, 109, 190})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeEntitySnapshot(Player player)
    {
      this.syncStream.reset();
      this.dataStream.writeInt(Vars.state.teams.present.sum((Intf) new NetServer.__\u003C\u003EAnon17()));
      Iterator iterator1 = Vars.state.teams.present.iterator();
label_1:
      while (iterator1.hasNext())
      {
        Iterator iterator2 = ((Teams.TeamData) iterator1.next()).__\u003C\u003Ecores.iterator();
        while (true)
        {
          if (iterator2.hasNext())
          {
            CoreBlock.CoreBuild coreBuild = (CoreBlock.CoreBuild) iterator2.next();
            this.dataStream.writeInt(coreBuild.tile.pos());
            coreBuild.items.write(Writes.get((DataOutput) this.dataStream));
          }
          else
            goto label_1;
        }
      }
      ((FilterOutputStream) this.dataStream).close();
      byte[] byteArray1 = this.syncStream.toByteArray();
      Call.stateSnapshot(player.con, Vars.state.wavetime, Vars.state.wave, Vars.state.enemies, Vars.state.serverPaused, Vars.state.gameOver, Vars.universe.seconds(), (short) byteArray1.Length, Vars.net.compressSnapshot(byteArray1));
      NetServer.viewport.setSize(player.con.viewWidth, player.con.viewHeight).setCenter(player.con.viewX, player.con.viewY);
      this.syncStream.reset();
      int num = 0;
      Iterator iterator3 = Groups.sync.iterator();
      while (iterator3.hasNext())
      {
        Syncc syncc = (Syncc) iterator3.next();
        this.dataStream.writeInt(syncc.id());
        this.dataStream.writeByte(syncc.classId());
        syncc.writeSync(Writes.get((DataOutput) this.dataStream));
        ++num;
        if (this.syncStream.size() > 800)
        {
          ((FilterOutputStream) this.dataStream).close();
          byte[] byteArray2 = this.syncStream.toByteArray();
          Call.entitySnapshot(player.con, (short) num, (short) byteArray2.Length, Vars.net.compressSnapshot(byteArray2));
          num = 0;
          this.syncStream.reset();
        }
      }
      if (num <= 0)
        return;
      ((FilterOutputStream) this.dataStream).close();
      byte[] byteArray3 = this.syncStream.toByteArray();
      Call.entitySnapshot(player.con, (short) num, (short) byteArray3.Length, Vars.net.compressSnapshot(byteArray3));
    }

    [LineNumberTable(new byte[] {161, 141, 102, 103, 103, 102, 113, 140, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendWorldData(Player player)
    {
      ByteArrayOutputStream arrayOutputStream = new ByteArrayOutputStream();
      FastDeflaterOutputStream deflaterOutputStream = new FastDeflaterOutputStream((OutputStream) arrayOutputStream);
      NetworkIO.writeWorld(player, (OutputStream) deflaterOutputStream);
      Packets.WorldStream worldStream = new Packets.WorldStream();
      worldStream.stream = new ByteArrayInputStream(arrayOutputStream.toByteArray());
      player.con.sendStream((Streamable) worldStream);
      Log.debug("Packed @ bytes of world data.", (object) Integer.valueOf(arrayOutputStream.size()));
    }

    [LineNumberTable(new byte[] {163, 34, 104, 122, 166, 110, 127, 23, 105, 104, 136, 248, 58, 233, 74, 103, 99, 127, 1, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string fixName([In] string obj0)
    {
      obj0 = String.instancehelper_trim(obj0);
      if (String.instancehelper_equals(obj0, (object) "[") || String.instancehelper_equals(obj0, (object) "]"))
        return "";
      for (int index = 0; index < String.instancehelper_length(obj0); ++index)
      {
        if (String.instancehelper_charAt(obj0, index) == '[' && index != String.instancehelper_length(obj0) - 1 && String.instancehelper_charAt(obj0, index + 1) != '[' && (index == 0 || String.instancehelper_charAt(obj0, index - 1) != '['))
        {
          string str1 = String.instancehelper_substring(obj0, 0, index);
          string str2 = this.checkColor(String.instancehelper_substring(obj0, index));
          obj0 = new StringBuilder().append(str1).append(str2).toString();
        }
      }
      StringBuilder stringBuilder1 = new StringBuilder();
      int num1 = 0;
      while (num1 < String.instancehelper_length(obj0) && String.instancehelper_getBytes(stringBuilder1.toString(), Strings.__\u003C\u003Eutf8).Length < 40)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string str = obj0;
        int num2 = num1;
        ++num1;
        int num3 = (int) String.instancehelper_charAt(str, num2);
        stringBuilder2.append((char) num3);
      }
      return stringBuilder1.toString();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 191, 145, 255, 7, 75, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Team lambda\u0024new\u00241([In] Player obj0, [In] Iterable obj1)
    {
      if (!Vars.state.rules.pvp)
        return Vars.state.rules.defaultTeam;
      return ((Teams.TeamData) Vars.state.teams.getActive().min((Floatf) new NetServer.__\u003C\u003EAnon31(obj1, obj0)))?.__\u003C\u003Eteam;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 139, 127, 7, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] NetConnection obj0, [In] Packets.Connect obj1)
    {
      Events.fire((object) new EventType.ConnectionEvent(obj0));
      if (!this.__\u003C\u003Eadmins.isIPBanned(obj1.addressTCP) && !this.__\u003C\u003Eadmins.isSubnetBanned(obj1.addressTCP))
        return;
      obj0.kick(Packets.KickReason.__\u003C\u003Ebanned);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {42, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] NetConnection obj0, [In] Packets.Disconnect obj1)
    {
      if (obj0.player == null)
        return;
      NetServer.onDisconnect(obj0.player, obj1.reason);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 137, 114, 187, 139, 103, 103, 102, 105, 103, 106, 104, 110, 107, 161, 159, 8, 104, 107, 161, 142, 103, 140, 112, 107, 161, 110, 107, 161, 121, 107, 161, 127, 30, 107, 161, 109, 142, 149, 108, 105, 127, 9, 173, 105, 159, 9, 175, 121, 109, 109, 109, 107, 107, 127, 3, 107, 161, 127, 25, 127, 5, 161, 158, 100, 119, 107, 161, 119, 107, 193, 146, 115, 107, 161, 104, 171, 136, 148, 126, 127, 0, 161, 105, 167, 103, 121, 104, 114, 109, 114, 109, 109, 189, 114, 205, 107, 255, 2, 69, 226, 60, 98, 107, 103, 161, 168, 143, 136, 138, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246([In] NetConnection obj0, [In] Packets.ConnectPacket obj1)
    {
      if (obj0.kicked)
        return;
      if (String.instancehelper_startsWith(obj0.__\u003C\u003Eaddress, "steam:"))
        obj1.uuid = String.instancehelper_substring(obj0.__\u003C\u003Eaddress, String.instancehelper_length("steam:"));
      obj0.connectTime = Time.millis();
      string uuid = obj1.uuid;
      byte[] numArray = Base64Coder.decode(uuid);
      CRC32 crC32 = new CRC32();
      crC32.update(numArray, 0, 8);
      ByteBuffer byteBuffer = ByteBuffer.allocate(8);
      byteBuffer.put(numArray, 8, 8);
      ((Buffer) byteBuffer).position(0);
      if (crC32.getValue() != byteBuffer.getLong())
      {
        obj0.kick(Packets.KickReason.__\u003C\u003EclientOutdated);
      }
      else
      {
        if (this.__\u003C\u003Eadmins.isIPBanned(obj0.__\u003C\u003Eaddress) || this.__\u003C\u003Eadmins.isSubnetBanned(obj0.__\u003C\u003Eaddress))
          return;
        if (obj0.hasBegunConnecting)
        {
          obj0.kick(Packets.KickReason.__\u003C\u003EidInUse);
        }
        else
        {
          Administration.PlayerInfo info = this.__\u003C\u003Eadmins.getInfo(uuid);
          obj0.hasBegunConnecting = true;
          obj0.mobile = obj1.mobile;
          if (obj1.uuid == null || obj1.usid == null)
            obj0.kick(Packets.KickReason.__\u003C\u003EidInUse);
          else if (this.__\u003C\u003Eadmins.isIDBanned(uuid))
            obj0.kick(Packets.KickReason.__\u003C\u003Ebanned);
          else if (Time.millis() < this.__\u003C\u003Eadmins.getKickTime(uuid, obj0.__\u003C\u003Eaddress))
            obj0.kick(Packets.KickReason.__\u003C\u003ErecentKick);
          else if (this.__\u003C\u003Eadmins.getPlayerLimit() > 0 && Groups.player.size() >= this.__\u003C\u003Eadmins.getPlayerLimit() && !Vars.netServer.__\u003C\u003Eadmins.isAdmin(uuid, obj1.usid))
          {
            obj0.kick(Packets.KickReason.__\u003C\u003EplayerLimit);
          }
          else
          {
            Seq @out = obj1.mods.copy();
            Seq incompatibility = Vars.mods.getIncompatibility(@out);
            if (!@out.isEmpty() || !incompatibility.isEmpty())
            {
              StringBuilder stringBuilder = new StringBuilder("[accent]Incompatible mods![]\n\n");
              if (!incompatibility.isEmpty())
              {
                stringBuilder.append("Missing:[lightgray]\n").append("> ").append(incompatibility.toString("\n> "));
                stringBuilder.append("[]\n");
              }
              if (!@out.isEmpty())
                stringBuilder.append("Unnecessary mods:[lightgray]\n").append("> ").append(@out.toString("\n> "));
              obj0.kick(stringBuilder.toString(), 0L);
            }
            if (!this.__\u003C\u003Eadmins.isWhitelisted(obj1.uuid, obj1.usid))
            {
              info.adminUsid = obj1.usid;
              info.lastName = obj1.name;
              info.id = obj1.uuid;
              this.__\u003C\u003Eadmins.save();
              Call.infoMessage(obj0, "You are not whitelisted here.");
              Log.info("&lcDo &lywhitelist-add @&lc to whitelist the player &lb'@'", (object) obj1.uuid, (object) obj1.name);
              obj0.kick(Packets.KickReason.__\u003C\u003Ewhitelist);
            }
            else if (obj1.versionType == null || (obj1.version == -1 || !String.instancehelper_equals(obj1.versionType, (object) Version.type)) && (Version.build != -1 && !this.__\u003C\u003Eadmins.allowsCustomClients()))
            {
              obj0.kick(String.instancehelper_equals(Version.type, (object) obj1.versionType) ? Packets.KickReason.__\u003C\u003EcustomClient : Packets.KickReason.__\u003C\u003EtypeMismatch);
            }
            else
            {
              if ((!Vars.headless || !Vars.netServer.__\u003C\u003Eadmins.isStrict() ? 0 : 1) != 0)
              {
                if (Groups.player.contains((Boolf) new NetServer.__\u003C\u003EAnon29(obj1)))
                {
                  obj0.kick(Packets.KickReason.__\u003C\u003EnameInUse);
                  return;
                }
                if (Groups.player.contains((Boolf) new NetServer.__\u003C\u003EAnon30(obj1)))
                {
                  obj0.kick(Packets.KickReason.__\u003C\u003EidInUse);
                  return;
                }
              }
              obj1.name = this.fixName(obj1.name);
              if (String.instancehelper_length(String.instancehelper_trim(obj1.name)) <= 0)
              {
                obj0.kick(Packets.KickReason.__\u003C\u003EnameEmpty);
              }
              else
              {
                if (obj1.locale == null)
                  obj1.locale = "en";
                string address = obj0.__\u003C\u003Eaddress;
                this.__\u003C\u003Eadmins.updatePlayerJoined(uuid, address, obj1.name);
                if (obj1.version != Version.build && Version.build != -1 && obj1.version != -1)
                {
                  obj0.kick(obj1.version <= Version.build ? Packets.KickReason.__\u003C\u003EclientOutdated : Packets.KickReason.__\u003C\u003EserverOutdated);
                }
                else
                {
                  if (obj1.version == -1)
                    obj0.modclient = true;
                  Player player = Player.create();
                  player.admin = this.__\u003C\u003Eadmins.isAdmin(uuid, obj1.usid);
                  player.con = obj0;
                  player.con.usid = obj1.usid;
                  player.con.uuid = uuid;
                  player.con.mobile = obj1.mobile;
                  player.name = obj1.name;
                  player.locale = obj1.locale;
                  player.color.set(obj1.color).a(1f);
                  if (!player.admin)
                  {
                    if (!info.admin)
                      info.adminUsid = obj1.usid;
                  }
                  Exception exception;
                  try
                  {
                    this.writeBuffer.reset();
                    player.write(this.outputBuffer);
                    goto label_47;
                  }
                  catch (Exception ex)
                  {
                    exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                  }
                  Exception th = exception;
                  obj0.kick(Packets.KickReason.__\u003C\u003EnameEmpty);
                  Log.err(th);
                  return;
label_47:
                  obj0.player = player;
                  player.team(this.assignTeam(player));
                  this.sendWorldData(player);
                  Vars.platform.updateRPC();
                  Events.fire((object) new EventType.PlayerConnect(player));
                }
              }
            }
          }
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 144, 177, 255, 28, 73, 229, 56, 97, 255, 3, 71, 226, 58, 97, 127, 10, 159, 7, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247([In] NetConnection obj0, [In] Packets.InvokePacket obj1)
    {
      if (obj0.player == null)
        return;
      if (obj0.kicked)
        return;
      ValidateException validateException1;
      RuntimeException runtimeException1;
      try
      {
        try
        {
          RemoteReadServer.readPacket(obj1.reader(), (int) (sbyte) obj1.type, obj0.player);
          return;
        }
        catch (ValidateException ex)
        {
          validateException1 = (ValidateException) ByteCodeHelper.MapException<ValidateException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          runtimeException1 = (RuntimeException) m0;
          goto label_9;
        }
      }
      ValidateException validateException2 = validateException1;
      Log.debug("Validation failed for '@': @", (object) validateException2.__\u003C\u003Eplayer, (object) Throwable.instancehelper_getMessage((Exception) validateException2));
      return;
label_9:
      RuntimeException runtimeException2 = runtimeException1;
      Exception cause = Throwable.instancehelper_getCause((Exception) runtimeException2);
      ValidateException validateException3;
      if (!(cause is ValidateException) || !object.ReferenceEquals((object) (validateException3 = (ValidateException) cause), (object) (ValidateException) cause))
        throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException2);
      Log.debug("Validation failed for '@': @", (object) validateException3.__\u003C\u003Eplayer, (object) Throwable.instancehelper_getMessage((Exception) validateException3));
    }

    [Modifiers]
    [LineNumberTable(278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024init\u00248([In] Mod obj0) => obj0.registerClientCommands(this.__\u003C\u003EclientCommands);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 111, 107, 129, 98, 113, 155, 132, 104, 127, 11, 161, 102, 159, 12, 127, 7, 121, 31, 47, 203, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerCommands\u00249([In] string[] obj0, [In] Player obj1)
    {
      if (obj0.Length > 0 && !Strings.canParseInt(obj0[0]))
      {
        obj1.sendMessage("[scarlet]'page' must be a number.");
      }
      else
      {
        int num1 = 6;
        int num2 = obj0.Length <= 0 ? 1 : Strings.parseInt(obj0[0]);
        int num3 = Mathf.ceil((float) this.__\u003C\u003EclientCommands.getCommandList().size / (float) num1);
        int num4 = num2 - 1;
        if (num4 >= num3 || num4 < 0)
        {
          obj1.sendMessage(new StringBuilder().append("[scarlet]'page' must be a number between[orange] 1[] and[orange] ").append(num3).append("[scarlet].").toString());
        }
        else
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.append(Strings.format("[orange]-- Commands Page[lightgray] @[gray]/[lightgray]@[orange] --\n\n", (object) Integer.valueOf(num4 + 1), (object) Integer.valueOf(num3)));
          for (int index = num1 * num4; index < Math.min(num1 * (num4 + 1), this.__\u003C\u003EclientCommands.getCommandList().size); ++index)
          {
            CommandHandler.Command command = (CommandHandler.Command) this.__\u003C\u003EclientCommands.getCommandList().get(index);
            stringBuilder.append("[orange] /").append(command.__\u003C\u003Etext).append("[white] ").append(command.__\u003C\u003EparamText).append("[lightgray] - ").append(command.__\u003C\u003Edescription).append("\n");
          }
          obj1.sendMessage(stringBuilder.toString());
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 195, 112, 99, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerCommands\u002412([In] string[] obj0, [In] Player obj1)
    {
      string str = this.__\u003C\u003Eadmins.filterMessage(obj1, obj0[0]);
      if (str == null)
        return;
      Groups.player.each((Boolf) new NetServer.__\u003C\u003EAnon27(obj1), (Cons) new NetServer.__\u003C\u003EAnon28(str, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 202, 104, 107, 161, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerCommands\u002414([In] string[] obj0, [In] Player obj1)
    {
      if (!obj1.admin)
        obj1.sendMessage("[scarlet]You must be admin to use this command.");
      else
        Groups.player.each((Boolf) new NetServer.__\u003C\u003EAnon25(), (Cons) new NetServer.__\u003C\u003EAnon26(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 9, 108, 108, 161, 109, 108, 161, 105, 108, 161, 101, 108, 161, 101, 102, 140, 191, 2, 109, 133, 127, 14, 112, 123, 98, 188, 102, 104, 113, 104, 113, 116, 145, 158, 104, 127, 15, 161, 111, 106, 102, 101, 130, 191, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerCommands\u002420(
      [In] NetServer.\u0031VoteSession[] obj0,
      [In] ObjectMap obj1,
      [In] int obj2,
      [In] float obj3,
      [In] int obj4,
      [In] string[] obj5,
      [In] Player obj6)
    {
      if (!Administration.Config.__\u003C\u003EenableVotekick.@bool())
        obj6.sendMessage("[scarlet]Vote-kick is disabled on this server.");
      else if (Groups.player.size() < 3)
        obj6.sendMessage("[scarlet]At least 3 players are needed to start a votekick.");
      else if (obj6.isLocal())
        obj6.sendMessage("[scarlet]Just kick them yourself if you're the host.");
      else if (obj0[0] != null)
        obj6.sendMessage("[scarlet]A vote is already in progress.");
      else if (obj5.Length == 0)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append("[orange]Players to kick: \n");
        Groups.player.each((Boolf) new NetServer.__\u003C\u003EAnon20(obj6), (Cons) new NetServer.__\u003C\u003EAnon21(stringBuilder));
        obj6.sendMessage(stringBuilder.toString());
      }
      else
      {
        Player player;
        if (String.instancehelper_length(obj5[0]) > 1 && String.instancehelper_startsWith(obj5[0], "#") && Strings.canParseInt(String.instancehelper_substring(obj5[0], 1)))
        {
          int num = Strings.parseInt(String.instancehelper_substring(obj5[0], 1));
          player = (Player) Groups.player.find((Boolf) new NetServer.__\u003C\u003EAnon22(num));
        }
        else
          player = (Player) Groups.player.find((Boolf) new NetServer.__\u003C\u003EAnon23(obj5));
        if (player != null)
        {
          if (player.admin)
            obj6.sendMessage("[scarlet]Did you really expect to be able to kick an admin?");
          else if (player.isLocal())
            obj6.sendMessage("[scarlet]Local players cannot be kicked.");
          else if (!object.ReferenceEquals((object) player.team(), (object) obj6.team()))
          {
            obj6.sendMessage("[scarlet]Only players on your team can be kicked.");
          }
          else
          {
            Timekeeper timekeeper = (Timekeeper) obj1.get((object) obj6.uuid(), (Prov) new NetServer.__\u003C\u003EAnon24(obj2));
            if (!timekeeper.get())
            {
              obj6.sendMessage(new StringBuilder().append("[scarlet]You must wait ").append(obj2 / 60).append(" minutes between votekicks.").toString());
            }
            else
            {
              NetServer.\u0031VoteSession obj = new NetServer.\u0031VoteSession(this, obj0, player, obj3, obj4);
              obj.vote(obj6, 1);
              timekeeper.reset();
              obj0[0] = obj;
            }
          }
        }
        else
          obj6.sendMessage(new StringBuilder().append("[scarlet]No player [orange]'").append(obj5[0]).append("'[scarlet] found.").toString());
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 73, 101, 144, 104, 107, 193, 127, 27, 107, 161, 112, 107, 161, 122, 107, 161, 127, 117, 99, 99, 162, 99, 107, 161, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerCommands\u002421(
      [In] NetServer.\u0031VoteSession[] obj0,
      [In] string[] obj1,
      [In] Player obj2)
    {
      if (obj0[0] == null)
        obj2.sendMessage("[scarlet]Nobody is being voted on.");
      else if (obj2.isLocal())
        obj2.sendMessage("Local players can't vote. Kick the player yourself instead.");
      else if (obj0[0].voted.contains((object) obj2.uuid()) || obj0[0].voted.contains((object) this.__\u003C\u003Eadmins.getInfo(obj2.uuid()).lastIP))
        obj2.sendMessage("[scarlet]You've already voted. Sit down.");
      else if (object.ReferenceEquals((object) obj0[0].target, (object) obj2))
        obj2.sendMessage("[scarlet]You can't vote on your own trial.");
      else if (!object.ReferenceEquals((object) obj0[0].target.team(), (object) obj2.team()))
      {
        obj2.sendMessage("[scarlet]You can't vote for other teams.");
      }
      else
      {
        string lowerCase = String.instancehelper_toLowerCase(obj1[0]);
        int num1 = -1;
        switch (String.instancehelper_hashCode(lowerCase))
        {
          case 110:
            if (String.instancehelper_equals(lowerCase, (object) "n"))
            {
              num1 = 2;
              break;
            }
            break;
          case 121:
            if (String.instancehelper_equals(lowerCase, (object) "y"))
            {
              num1 = 0;
              break;
            }
            break;
          case 3521:
            if (String.instancehelper_equals(lowerCase, (object) "no"))
            {
              num1 = 3;
              break;
            }
            break;
          case 119527:
            if (String.instancehelper_equals(lowerCase, (object) "yes"))
            {
              num1 = 1;
              break;
            }
            break;
        }
        int num2;
        switch (num1)
        {
          case 0:
          case 1:
            num2 = 1;
            break;
          case 2:
          case 3:
            num2 = -1;
            break;
          default:
            num2 = 0;
            break;
        }
        int num3 = num2;
        if (num3 == 0)
          obj2.sendMessage("[scarlet]Vote either 'y' (yes) or 'n' (no).");
        else
          obj0[0].vote(obj2, num3);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 113, 104, 141, 120, 107, 161, 112, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerCommands\u002422([In] string[] obj0, [In] Player obj1)
    {
      if (obj1.isLocal())
        obj1.sendMessage("[scarlet]Re-synchronizing as the host is pointless.");
      else if (Time.timeSinceMillis(obj1.getInfo().lastSyncTime) < 5000L)
      {
        obj1.sendMessage("[scarlet]You may only /sync every 5 seconds.");
      }
      else
      {
        obj1.getInfo().lastSyncTime = Time.millis();
        Call.worldDataBegin(obj1.con);
        Vars.netServer.sendWorldData(obj1);
      }
    }

    [Modifiers]
    [LineNumberTable(638)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024clientSnapshot\u002423([In] BuildPlan obj0, [In] BuildPlan obj1) => obj1.breaking == obj0.breaking && obj1.x == obj0.x && obj1.y == obj0.y;

    [Modifiers]
    [LineNumberTable(new byte[] {162, 15, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024clientSnapshot\u002424(
      [In] BuildPlan obj0,
      [In] Administration.PlayerAction obj1)
    {
      obj1.block = obj0.block;
      obj1.rotation = obj0.rotation;
      obj1.config = obj0.config;
    }

    [Modifiers]
    [LineNumberTable(785)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024isWaitingForPlayers\u002425([In] Teams.TeamData obj0, [In] Player obj1) => object.ReferenceEquals((object) obj1.team(), (object) obj0.__\u003C\u003Eteam);

    [Modifiers]
    [LineNumberTable(new byte[] {162, 174, 106, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002426()
    {
      Vars.net.closeServer();
      Vars.ui.loadfrag.hide();
      this.closing = false;
    }

    [Modifiers]
    [LineNumberTable(866)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024writeEntitySnapshot\u002427([In] Teams.TeamData obj0) => obj0.__\u003C\u003Ecores.size;

    [Modifiers]
    [LineNumberTable(966)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024sync\u002428([In] Player obj0) => !obj0.isLocal();

    [Modifiers]
    [LineNumberTable(new byte[] {163, 85, 117, 107, 161, 135, 156, 171, 185, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024sync\u002429([In] Player obj0)
    {
      if (obj0.con == null || !obj0.con.isConnected())
      {
        NetServer.onDisconnect(obj0, "disappeared");
      }
      else
      {
        NetConnection con = obj0.con;
        if (Time.timeSinceMillis(con.syncTime) < 200L || !con.hasConnected)
          return;
        con.syncTime = Time.millis();
        IOException ioException;
        try
        {
          this.writeEntitySnapshot(obj0);
          return;
        }
        catch (IOException ex)
        {
          ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        Throwable.instancehelper_printStackTrace((Exception) ioException);
      }
    }

    [Modifiers]
    [LineNumberTable(403)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerCommands\u002415([In] Player obj0, [In] Player obj1) => !obj1.admin && obj1.con != null && !object.ReferenceEquals((object) obj1, (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 34, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerCommands\u002416([In] StringBuilder obj0, [In] Player obj1) => obj0.append("[lightgray] ").append(obj1.name).append("[accent] (#").append(obj1.id()).append(")\n");

    [Modifiers]
    [LineNumberTable(411)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerCommands\u002417([In] int obj0, [In] Player obj1) => obj1.id() == obj0;

    [Modifiers]
    [LineNumberTable(413)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerCommands\u002418([In] string[] obj0, [In] Player obj1) => String.instancehelper_equalsIgnoreCase(obj1.name, obj0[0]);

    [Modifiers]
    [LineNumberTable(424)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Timekeeper lambda\u0024registerCommands\u002419([In] int obj0) => new Timekeeper((float) obj0);

    [Modifiers]
    [LineNumberTable(321)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerCommands\u002413(
      [In] string[] obj0,
      [In] Player obj1,
      [In] Player obj2)
    {
      obj2.sendMessage(obj0[0], obj1, new StringBuilder().append("[#").append(Pal.adminChat.toString()).append("]<A>").append(NetClient.colorizeName(obj1.id, obj1.name)).toString());
    }

    [Modifiers]
    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerCommands\u002410([In] Player obj0, [In] Player obj1) => object.ReferenceEquals((object) obj1.team(), (object) obj0.team());

    [Modifiers]
    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerCommands\u002411([In] string obj0, [In] Player obj1, [In] Player obj2) => obj2.sendMessage(obj0, obj1, new StringBuilder().append("[#").append(obj1.team().__\u003C\u003Ecolor.toString()).append("]<T>").append(NetClient.colorizeName(obj1.id(), obj1.name)).toString());

    [Modifiers]
    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00244([In] Packets.ConnectPacket obj0, [In] Player obj1) => String.instancehelper_equalsIgnoreCase(String.instancehelper_trim(obj1.name), String.instancehelper_trim(obj0.name));

    [Modifiers]
    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00245([In] Packets.ConnectPacket obj0, [In] Player obj1) => String.instancehelper_equals(obj1.uuid(), (object) obj0.uuid) || String.instancehelper_equals(obj1.usid(), (object) obj0.usid);

    [Modifiers]
    [LineNumberTable(new byte[] {2, 159, 33, 98, 123, 124, 132, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u00240([In] Iterable obj0, [In] Player obj1, [In] Teams.TeamData obj2)
    {
      if (object.ReferenceEquals((object) Vars.state.rules.waveTeam, (object) obj2.__\u003C\u003Eteam) && Vars.state.rules.waves || !obj2.__\u003C\u003Eteam.active())
        return (float) int.MaxValue;
      int num = 0;
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        Player player = (Player) iterator.next();
        if (object.ReferenceEquals((object) player.team(), (object) obj2.__\u003C\u003Eteam) && !object.ReferenceEquals((object) player, (object) obj1))
          ++num;
      }
      return (float) num;
    }

    [LineNumberTable(new byte[] {160, 164, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init() => Vars.mods.eachClass((Cons) new NetServer.__\u003C\u003EAnon5(this));

    [Signature("(Lmindustry/gen/Player;Ljava/lang/Iterable<Lmindustry/gen/Player;>;)Lmindustry/game/Team;")]
    [LineNumberTable(507)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team assignTeam(Player current, Iterable players) => this.assigner.assign(current, players);

    [Signature("(Ljava/lang/String;Larc/func/Cons2<Lmindustry/gen/Player;Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {161, 152, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPacketHandler(string type, Cons2 handler) => ((Seq) this.customPacketHandlers.get((object) type, (Prov) new NetServer.__\u003C\u003EAnon12())).add((object) handler);

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Larc/func/Cons2<Lmindustry/gen/Player;Ljava/lang/String;>;>;")]
    [LineNumberTable(526)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getPacketHandlers(string type) => (Seq) this.customPacketHandlers.get((object) type, (Prov) new NetServer.__\u003C\u003EAnon12());

    [LineNumberTable(new byte[] {161, 192, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void serverPacketUnreliable(Player player, string type, string contents) => NetServer.serverPacketReliable(player, type, contents);

    [LineNumberTable(new byte[] {158, 252, 79, 104, 175, 113, 113, 113, 113, 113, 113, 113, 145, 158, 155, 106, 106, 106, 170, 127, 3, 162, 127, 13, 162, 105, 105, 103, 103, 135, 109, 145, 107, 107, 140, 103, 124, 105, 122, 158, 124, 101, 127, 46, 101, 122, 101, 255, 22, 70, 127, 1, 110, 130, 242, 43, 235, 90, 141, 141, 107, 136, 110, 138, 190, 116, 146, 103, 154, 120, 141, 146, 105, 157, 187, 105, 137, 100, 107, 101, 103, 118, 239, 69, 109, 204, 119, 110, 109, 109, 171, 108, 98, 105, 169, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientSnapshot(
      Player player,
      int snapshotID,
      int unitID,
      bool dead,
      float x,
      float y,
      float pointerX,
      float pointerY,
      float rotation,
      float baseRotation,
      float xVelocity,
      float yVelocity,
      Tile mining,
      bool boosting,
      bool shooting,
      bool chatting,
      bool building,
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] BuildPlan[] requests,
      float viewX,
      float viewY,
      float viewWidth,
      float viewHeight)
    {
      int num1 = chatting ? 1 : 0;
      int num2 = shooting ? 1 : 0;
      int num3 = boosting ? 1 : 0;
      int num4 = building ? 1 : 0;
      int num5 = dead ? 1 : 0;
      NetConnection con = player.con;
      if (con == null || snapshotID < con.lastReceivedClientSnapshot)
        return;
      if (NetServer.invalid(x))
        x = 0.0f;
      if (NetServer.invalid(y))
        y = 0.0f;
      if (NetServer.invalid(xVelocity))
        xVelocity = 0.0f;
      if (NetServer.invalid(yVelocity))
        yVelocity = 0.0f;
      if (NetServer.invalid(pointerX))
        pointerX = 0.0f;
      if (NetServer.invalid(pointerY))
        pointerY = 0.0f;
      if (NetServer.invalid(rotation))
        rotation = 0.0f;
      if (NetServer.invalid(baseRotation))
        baseRotation = 0.0f;
      int num6 = !Vars.netServer.__\u003C\u003Eadmins.isStrict() || !Vars.headless ? 0 : 1;
      if (con.lastReceivedClientTime == 0L)
        con.lastReceivedClientTime = Time.millis() - 16L;
      con.viewX = viewX;
      con.viewY = viewY;
      con.viewWidth = viewWidth;
      con.viewHeight = viewHeight;
      if (!player.dead() && player.unit().isFlying() && player.unit() is Mechc)
        num2 = 0;
      if (!player.dead() && (player.unit().type.flying || !player.unit().type.canBoost))
        num3 = 0;
      player.mouseX = pointerX;
      player.mouseY = pointerY;
      player.typing = num1 != 0;
      player.shooting = num2 != 0;
      player.boosting = num3 != 0;
      player.unit().controlWeapons(num2 != 0, num2 != 0);
      player.unit().aim(pointerX, pointerY);
      if (player.isBuilder())
      {
        player.unit().clearBuilding();
        player.unit().updateBuilding(num4 != 0);
        if (requests != null)
        {
          BuildPlan[] buildPlanArray = requests;
          int length = buildPlanArray.Length;
          for (int index = 0; index < length; ++index)
          {
            BuildPlan buildPlan = buildPlanArray[index];
            if (buildPlan != null)
            {
              Tile tile = Vars.world.tile(buildPlan.x, buildPlan.y);
              if (tile != null && (buildPlan.breaking || buildPlan.block != null) && (!buildPlan.breaking || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air)) && (buildPlan.breaking || !object.ReferenceEquals((object) tile.block(), (object) buildPlan.block) || buildPlan.block.rotate && (tile.build == null || tile.build.rotation != buildPlan.rotation)) && !con.rejectedRequests.contains((Boolf) new NetServer.__\u003C\u003EAnon13(buildPlan)))
              {
                if (!Vars.netServer.__\u003C\u003Eadmins.allowAction(player, !buildPlan.breaking ? Administration.ActionType.__\u003C\u003EplaceBlock : Administration.ActionType.__\u003C\u003EbreakBlock, tile, (Cons) new NetServer.__\u003C\u003EAnon14(buildPlan)))
                {
                  Call.removeQueueBlock(player.con, buildPlan.x, buildPlan.y, buildPlan.breaking);
                  con.rejectedRequests.add((object) buildPlan);
                }
                else
                  player.unit().plans().addLast((object) buildPlan);
              }
            }
          }
        }
      }
      player.unit().mineTile = mining;
      con.rejectedRequests.clear();
      if (!player.dead())
      {
        Unit unit = player.unit();
        long num7 = Time.timeSinceMillis(con.lastReceivedClientTime);
        float limit1 = unit.realSpeed();
        float limit2 = (float) num7 / 1000f * 60f * limit1 * 1.2f;
        int num8 = num5 != 0 || unit.id != unitID ? 1 : 0;
        float num9 = unit.x;
        float num10 = unit.y;
        if (num8 == 0)
        {
          unit.vel.set(xVelocity, yVelocity).limit(limit1);
          NetServer.vector.set(x, y).sub((Position) unit);
          NetServer.vector.limit(limit2);
          float x1 = unit.x;
          float y1 = unit.y;
          if (!unit.isFlying())
            unit.move(NetServer.vector.x, NetServer.vector.y);
          else
            unit.trns(NetServer.vector.x, NetServer.vector.y);
          num9 = unit.x;
          num10 = unit.y;
          if (num6 == 0)
          {
            unit.set(x1, y1);
            num9 = x;
            num10 = y;
          }
          else if (!Mathf.within(x, y, num9, num10, 112f))
            Call.setPosition(player.con, num9, num10);
        }
        ((Buffer) NetServer.fbuffer).limit(20);
        ((Buffer) NetServer.fbuffer).position(0);
        if (unit is Mechc)
          NetServer.fbuffer.put(baseRotation);
        NetServer.fbuffer.put(rotation);
        NetServer.fbuffer.put(num9);
        NetServer.fbuffer.put(num10);
        ((Buffer) NetServer.fbuffer).flip();
        unit.readSyncManual(NetServer.fbuffer);
      }
      else
      {
        player.x = x;
        player.y = y;
      }
      con.lastReceivedClientSnapshot = snapshotID;
      con.lastReceivedClientTime = Time.millis();
    }

    [LineNumberTable(new byte[] {162, 96, 112, 118, 63, 20, 133, 161, 124, 121, 161, 173, 106, 126, 109, 123, 123, 107, 127, 8, 109, 107, 127, 8, 112, 118, 127, 26, 104, 143, 135, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void adminRequest(Player player, Player other, Packets.AdminAction action)
    {
      if (!player.admin && !player.isLocal())
        Log.warn("ACCESS DENIED: Player @ / @ attempted to perform admin action '@' on '@' without proper security access.", (object) player.name, player.con != null ? (object) player.con.__\u003C\u003Eaddress : (object) "null", (object) action.name(), (object) other?.name);
      else if (other == null || other.admin && !player.isLocal() && !object.ReferenceEquals((object) other, (object) player))
        Log.warn("@ attempted to perform admin action on nonexistant or admin player.", (object) player.name);
      else if (object.ReferenceEquals((object) action, (object) Packets.AdminAction.__\u003C\u003Ewave))
      {
        Vars.logic.skipWave();
        Log.info("&lc@ has skipped the wave.", (object) player.name);
      }
      else if (object.ReferenceEquals((object) action, (object) Packets.AdminAction.__\u003C\u003Eban))
      {
        Vars.netServer.__\u003C\u003Eadmins.banPlayerID(other.con.uuid);
        Vars.netServer.__\u003C\u003Eadmins.banPlayerIP(other.con.__\u003C\u003Eaddress);
        other.kick(Packets.KickReason.__\u003C\u003Ebanned);
        Log.info("&lc@ has banned @.", (object) player.name, (object) other.name);
      }
      else if (object.ReferenceEquals((object) action, (object) Packets.AdminAction.__\u003C\u003Ekick))
      {
        other.kick(Packets.KickReason.__\u003C\u003Ekick);
        Log.info("&lc@ has kicked @.", (object) player.name, (object) other.name);
      }
      else
      {
        if (!object.ReferenceEquals((object) action, (object) Packets.AdminAction.__\u003C\u003Etrace))
          return;
        Administration.PlayerInfo info1 = Vars.netServer.__\u003C\u003Eadmins.getInfo(other.uuid());
        Administration.TraceInfo info2 = new Administration.TraceInfo(other.con.__\u003C\u003Eaddress, other.uuid(), other.con.modclient, other.con.mobile, info1.timesJoined, info1.timesKicked);
        if (player.con != null)
          Call.traceInfo(player.con, other, info2);
        else
          NetClient.traceInfo(other, info2);
        Log.info("&lc@ has requested trace info of @.", (object) player.name, (object) other.name);
      }
    }

    [LineNumberTable(new byte[] {162, 134, 142, 134, 150, 140, 108, 127, 15, 127, 4, 166, 118, 176, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void connectConfirm(Player player)
    {
      if (player.con.kicked)
        return;
      player.add();
      if (player.con == null || player.con.hasConnected)
        return;
      player.con.hasConnected = true;
      if (Administration.Config.__\u003C\u003EshowConnectMessages.@bool())
      {
        Call.sendMessage(new StringBuilder().append("[accent]").append(player.name).append("[accent] has connected.").toString());
        Log.info((object) Strings.format("&lb@&fi&lk has connected. &fi&lk[&lb@&fi&lk]", (object) player.name, (object) player.uuid()));
      }
      if (!String.instancehelper_equalsIgnoreCase(Administration.Config.__\u003C\u003Emotd.@string(), "off"))
        player.sendMessage(Administration.Config.__\u003C\u003Emotd.@string());
      Events.fire((object) new EventType.PlayerJoin(player));
    }

    [LineNumberTable(new byte[] {162, 170, 127, 8, 103, 116, 246, 71, 120, 113, 176, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (!Vars.headless && !this.closing && (Vars.net.server() && Vars.state.isMenu()))
      {
        this.closing = true;
        Vars.ui.loadfrag.show("@server.closing");
        Time.runTask(5f, (Runnable) new NetServer.__\u003C\u003EAnon16(this));
      }
      if (!Vars.state.isGame() || !Vars.net.server())
        return;
      if (Vars.state.rules.pvp)
        Vars.state.serverPaused = this.isWaitingForPlayers();
      this.sync();
    }

    [LineNumberTable(new byte[] {162, 192, 116, 255, 26, 71, 226, 58, 97, 112, 207, 226, 61, 97, 102, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void openServer()
    {
      IOException ioException;
      try
      {
        try
        {
          Vars.net.host(Administration.Config.__\u003C\u003Eport.num());
          Log.info("Opened a server on port @.", (object) Integer.valueOf(Administration.Config.__\u003C\u003Eport.num()));
          return;
        }
        catch (BindException ex)
        {
        }
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_4;
      }
      Log.err("Unable to host: Port already in use! Make sure no other servers are running on the same port in your network.");
      Vars.state.set(GameState.State.__\u003C\u003Emenu);
      return;
label_4:
      Log.err((Exception) ioException);
      Vars.state.set(GameState.State.__\u003C\u003Emenu);
    }

    [LineNumberTable(new byte[] {162, 204, 127, 5, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kickAll(Packets.KickReason reason)
    {
      Iterator iterator = Vars.net.getConnections().iterator();
      while (iterator.hasNext())
        ((NetConnection) iterator.next()).kick(reason);
    }

    [LineNumberTable(new byte[] {159, 132, 77, 108, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NetServer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.core.NetServer"))
        return;
      NetServer.fbuffer = FloatBuffer.allocate(20);
      NetServer.vector = new Vec2();
      NetServer.viewport = new Rect();
    }

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

    [Modifiers]
    public Administration admins
    {
      [HideFromJava] get => this.__\u003C\u003Eadmins;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eadmins = value;
    }

    [Modifiers]
    public CommandHandler clientCommands
    {
      [HideFromJava] get => this.__\u003C\u003EclientCommands;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EclientCommands = value;
    }

    [EnclosingMethod(null, "registerCommands", "()V")]
    [SpecialName]
    internal class \u0031VoteSession : Object
    {
      internal Player target;
      [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
      internal ObjectSet voted;
      internal NetServer.\u0031VoteSession[] map;
      internal Timer.Task task;
      internal int votes;
      [Modifiers]
      internal float val\u0024voteDuration;
      [Modifiers]
      internal int val\u0024kickDuration;
      [Modifiers]
      internal NetServer this\u00240;

      [LineNumberTable(new byte[] {160, 247, 118, 127, 21, 127, 4, 127, 0, 105, 107, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool checkPass()
      {
        if (this.votes < this.this\u00240.votesRequired())
          return false;
        Call.sendMessage(Strings.format("[orange]Vote passed.[scarlet] @[orange] will be banned from the server for @ minutes.", (object) this.target.name, (object) Integer.valueOf(this.val\u0024kickDuration / 60)));
        this.target.getInfo().lastKicked = Time.millis() + (long) (this.val\u0024kickDuration * 1000);
        Groups.player.each((Boolf) new NetServer.\u0031VoteSession.__\u003C\u003EAnon1(this), (Cons) new NetServer.\u0031VoteSession.__\u003C\u003EAnon2());
        this.map[0] = (NetServer.\u0031VoteSession) null;
        this.task.cancel();
        return true;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 228, 104, 126, 100, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Player obj0, [In] NetServer.\u0031VoteSession[] obj1)
      {
        if (this.checkPass())
          return;
        Call.sendMessage(Strings.format("[lightgray]Vote failed. Not enough votes to kick[orange] @[lightgray].", (object) obj0.name));
        obj1[0] = (NetServer.\u0031VoteSession) null;
        this.task.cancel();
      }

      [Modifiers]
      [LineNumberTable(364)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024checkPass\u00241([In] Player obj0) => String.instancehelper_equals(obj0.uuid(), (object) this.target.uuid());

      [Modifiers]
      [LineNumberTable(364)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024checkPass\u00242([In] Player obj0) => obj0.kick(Packets.KickReason.__\u003C\u003Evote);

      [Signature("([Lmindustry/core/NetServer$1VoteSession;Lmindustry/gen/Player;)V")]
      [LineNumberTable(new byte[] {160, 224, 255, 1, 59, 235, 70, 103, 103, 254, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public \u0031VoteSession(
        [In] NetServer obj0,
        [In] NetServer.\u0031VoteSession[] obj1,
        [In] Player obj2,
        [In] float obj3,
        [In] int obj4)
      {
        this.this\u00240 = obj0;
        this.val\u0024voteDuration = obj3;
        this.val\u0024kickDuration = obj4;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        NetServer.\u0031VoteSession obj = this;
        this.voted = new ObjectSet();
        this.target = obj2;
        this.map = obj1;
        this.task = Timer.schedule((Runnable) new NetServer.\u0031VoteSession.__\u003C\u003EAnon0(this, obj2, obj1), this.val\u0024voteDuration);
      }

      [LineNumberTable(new byte[] {160, 237, 110, 159, 25, 127, 11, 57, 170, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void vote([In] Player obj0, [In] int obj1)
      {
        this.votes += obj1;
        this.voted.addAll((object[]) new string[2]
        {
          obj0.uuid(),
          this.this\u00240.__\u003C\u003Eadmins.getInfo(obj0.uuid()).lastIP
        });
        Call.sendMessage(Strings.format("[lightgray]@[lightgray] has voted on kicking[orange] @[].[accent] (@/@)\n[lightgray]Type[orange] /vote <y/n>[] to agree.", (object) obj0.name, (object) this.target.name, (object) Integer.valueOf(this.votes), (object) Integer.valueOf(this.this\u00240.votesRequired())));
        this.checkPass();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly NetServer.\u0031VoteSession arg\u00241;
        private readonly Player arg\u00242;
        private readonly NetServer.\u0031VoteSession[] arg\u00243;

        internal __\u003C\u003EAnon0(
          [In] NetServer.\u0031VoteSession obj0,
          [In] Player obj1,
          [In] NetServer.\u0031VoteSession[] obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly NetServer.\u0031VoteSession arg\u00241;

        internal __\u003C\u003EAnon1([In] NetServer.\u0031VoteSession obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024checkPass\u00241((Player) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Cons
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void get([In] object obj0) => NetServer.\u0031VoteSession.lambda\u0024checkPass\u00242((Player) obj0);
      }
    }

    public interface TeamAssigner
    {
      [Signature("(Lmindustry/gen/Player;Ljava/lang/Iterable<Lmindustry/gen/Player;>;)Lmindustry/game/Team;")]
      Team assign(Player p, Iterable i);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : NetServer.TeamAssigner
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public Team assign([In] Player obj0, [In] Iterable obj1) => NetServer.lambda\u0024new\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons2
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon1([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00242((NetConnection) obj0, (Packets.Connect) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons2
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0, [In] object obj1) => NetServer.lambda\u0024new\u00243((NetConnection) obj0, (Packets.Disconnect) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons2
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon3([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00246((NetConnection) obj0, (Packets.ConnectPacket) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons2
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0, [In] object obj1) => NetServer.lambda\u0024new\u00247((NetConnection) obj0, (Packets.InvokePacket) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon5([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024init\u00248((Mod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : CommandHandler.CommandRunner
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon6([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void accept([In] string[] obj0, [In] object obj1) => this.arg\u00241.lambda\u0024registerCommands\u00249(obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : CommandHandler.CommandRunner
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon7([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void accept([In] string[] obj0, [In] object obj1) => this.arg\u00241.lambda\u0024registerCommands\u002412(obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : CommandHandler.CommandRunner
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void accept([In] string[] obj0, [In] object obj1) => NetServer.lambda\u0024registerCommands\u002414(obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : CommandHandler.CommandRunner
    {
      private readonly NetServer arg\u00241;
      private readonly NetServer.\u0031VoteSession[] arg\u00242;
      private readonly ObjectMap arg\u00243;
      private readonly int arg\u00244;
      private readonly float arg\u00245;
      private readonly int arg\u00246;

      internal __\u003C\u003EAnon9(
        [In] NetServer obj0,
        [In] NetServer.\u0031VoteSession[] obj1,
        [In] ObjectMap obj2,
        [In] int obj3,
        [In] float obj4,
        [In] int obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void accept([In] string[] obj0, [In] object obj1) => this.arg\u00241.lambda\u0024registerCommands\u002420(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : CommandHandler.CommandRunner
    {
      private readonly NetServer arg\u00241;
      private readonly NetServer.\u0031VoteSession[] arg\u00242;

      internal __\u003C\u003EAnon10([In] NetServer obj0, [In] NetServer.\u0031VoteSession[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] string[] obj0, [In] object obj1) => this.arg\u00241.lambda\u0024registerCommands\u002421(this.arg\u00242, obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : CommandHandler.CommandRunner
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void accept([In] string[] obj0, [In] object obj1) => NetServer.lambda\u0024registerCommands\u002422(obj0, (Player) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      private readonly BuildPlan arg\u00241;

      internal __\u003C\u003EAnon13([In] BuildPlan obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024clientSnapshot\u002423(this.arg\u00241, (BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly BuildPlan arg\u00241;

      internal __\u003C\u003EAnon14([In] BuildPlan obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => NetServer.lambda\u0024clientSnapshot\u002424(this.arg\u00241, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolf
    {
      private readonly Teams.TeamData arg\u00241;

      internal __\u003C\u003EAnon15([In] Teams.TeamData obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024isWaitingForPlayers\u002425(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon16([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u002426();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Intf
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public int get([In] object obj0) => NetServer.lambda\u0024writeEntitySnapshot\u002427((Teams.TeamData) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Boolf
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public bool get([In] object obj0) => (NetServer.lambda\u0024sync\u002428((Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly NetServer arg\u00241;

      internal __\u003C\u003EAnon19([In] NetServer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024sync\u002429((Player) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Boolf
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon20([In] Player obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024registerCommands\u002415(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly StringBuilder arg\u00241;

      internal __\u003C\u003EAnon21([In] StringBuilder obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => NetServer.lambda\u0024registerCommands\u002416(this.arg\u00241, (Player) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolf
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon22([In] int obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024registerCommands\u002417(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolf
    {
      private readonly string[] arg\u00241;

      internal __\u003C\u003EAnon23([In] string[] obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024registerCommands\u002418(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Prov
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon24([In] int obj0) => this.arg\u00241 = obj0;

      public object get() => (object) NetServer.lambda\u0024registerCommands\u002419(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Boolf
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public bool get([In] object obj0) => (((Player) obj0).admin() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly string[] arg\u00241;
      private readonly Player arg\u00242;

      internal __\u003C\u003EAnon26([In] string[] obj0, [In] Player obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => NetServer.lambda\u0024registerCommands\u002413(this.arg\u00241, this.arg\u00242, (Player) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Boolf
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon27([In] Player obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024registerCommands\u002410(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly string arg\u00241;
      private readonly Player arg\u00242;

      internal __\u003C\u003EAnon28([In] string obj0, [In] Player obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => NetServer.lambda\u0024registerCommands\u002411(this.arg\u00241, this.arg\u00242, (Player) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Boolf
    {
      private readonly Packets.ConnectPacket arg\u00241;

      internal __\u003C\u003EAnon29([In] Packets.ConnectPacket obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024new\u00244(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Boolf
    {
      private readonly Packets.ConnectPacket arg\u00241;

      internal __\u003C\u003EAnon30([In] Packets.ConnectPacket obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (NetServer.lambda\u0024new\u00245(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Floatf
    {
      private readonly Iterable arg\u00241;
      private readonly Player arg\u00242;

      internal __\u003C\u003EAnon31([In] Iterable obj0, [In] Player obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => NetServer.lambda\u0024new\u00240(this.arg\u00241, this.arg\u00242, (Teams.TeamData) obj0);
    }
  }
}
