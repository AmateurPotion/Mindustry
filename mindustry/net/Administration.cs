// Decompiled with JetBrains decompiler
// Type: mindustry.net.Administration
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class Administration : Object
  {
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    public Seq bannedIPs;
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    public Seq whitelist;
    [Signature("Larc/struct/Seq<Lmindustry/net/Administration$ChatFilter;>;")]
    public Seq chatFilters;
    [Signature("Larc/struct/Seq<Lmindustry/net/Administration$ActionFilter;>;")]
    public Seq actionFilters;
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    public Seq subnetBans;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Long;>;")]
    public ObjectMap kickedIPs;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Lmindustry/net/Administration$PlayerInfo;>;")]
    private ObjectMap playerInfo;

    [LineNumberTable(408)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Administration.PlayerInfo getInfo(string id) => this.getCreateInfo(id);

    [LineNumberTable(new byte[] {161, 70, 117, 122, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void save()
    {
      Core.settings.putJson("player-data", (object) this.playerInfo);
      Core.settings.putJson("ip-bans", (Class) ClassLiteral<String>.Value, (object) this.bannedIPs);
      Core.settings.putJson("whitelist-ids", (Class) ClassLiteral<String>.Value, (object) this.whitelist);
      Core.settings.putJson("banned-subnets", (Class) ClassLiteral<String>.Value, (object) this.subnetBans);
    }

    [LineNumberTable(new byte[] {44, 159, 28, 104, 110, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleKicked(string uuid, string ip, long duration)
    {
      this.kickedIPs.put((object) ip, (object) Long.valueOf(Math.max(((Long) this.kickedIPs.get((object) ip, (object) Long.valueOf(0L))).longValue(), Time.millis() + duration)));
      Administration.PlayerInfo info = this.getInfo(uuid);
      ++info.timesKicked;
      info.lastKicked = Math.max(Time.millis() + duration, info.lastKicked);
    }

    [LineNumberTable(new byte[] {78, 98, 127, 1, 105, 101, 98})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string filterMessage(Player player, string message)
    {
      string str = message;
      Iterator iterator = this.chatFilters.iterator();
      while (iterator.hasNext())
      {
        str = ((Administration.ChatFilter) iterator.next()).filter(player, str);
        if (str == null)
          return (string) null;
      }
      return str;
    }

    [LineNumberTable(new byte[] {159, 171, 232, 54, 107, 107, 107, 107, 107, 171, 171, 166, 240, 96, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Administration()
    {
      Administration administration = this;
      this.bannedIPs = new Seq();
      this.whitelist = new Seq();
      this.chatFilters = new Seq();
      this.actionFilters = new Seq();
      this.subnetBans = new Seq();
      this.kickedIPs = new ObjectMap();
      this.playerInfo = new ObjectMap();
      this.load();
      this.addChatFilter((Administration.ChatFilter) new Administration.__\u003C\u003EAnon0());
      this.addActionFilter((Administration.ActionFilter) new Administration.__\u003C\u003EAnon1());
    }

    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isStrict() => Administration.Config.__\u003C\u003Estrict.@bool();

    [Signature("(Lmindustry/gen/Player;Lmindustry/net/Administration$ActionType;Lmindustry/world/Tile;Larc/func/Cons<Lmindustry/net/Administration$PlayerAction;>;)Z")]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool allowAction(
      Player player,
      Administration.ActionType type,
      Tile tile,
      Cons setter)
    {
      return this.allowAction(player, type, (Cons) new Administration.__\u003C\u003EAnon3(setter, player, type, tile));
    }

    [LineNumberTable(new byte[] {160, 103, 127, 7, 130, 141, 102, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool banPlayerID(string id)
    {
      if (this.playerInfo.containsKey((object) id) && ((Administration.PlayerInfo) this.playerInfo.get((object) id)).banned)
        return false;
      this.getCreateInfo(id).banned = true;
      this.save();
      Events.fire((object) new EventType.PlayerBanEvent((Player) Groups.player.find((Boolf) new Administration.__\u003C\u003EAnon5(id)), id));
      return true;
    }

    [LineNumberTable(new byte[] {160, 86, 111, 130, 127, 6, 111, 135, 130, 108, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool banPlayerIP(string ip)
    {
      if (this.bannedIPs.contains((object) ip, false))
        return false;
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.ips.contains((object) ip, false))
          playerInfo.banned = true;
      }
      this.bannedIPs.add((object) ip);
      this.save();
      Events.fire((object) new EventType.PlayerIpBanEvent(ip));
      return true;
    }

    [LineNumberTable(355)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIPBanned(string ip) => this.bannedIPs.contains((object) ip, false) || this.findByIP(ip) != null && this.findByIP(ip).banned;

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSubnetBanned(string ip)
    {
      Seq subnetBans = this.subnetBans;
      string str = ip;
      Objects.requireNonNull((object) str);
      Boolf predicate = (Boolf) new Administration.__\u003C\u003EAnon2(str);
      return subnetBans.contains(predicate);
    }

    [LineNumberTable(359)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIDBanned(string uuid) => this.getCreateInfo(uuid).banned;

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getKickTime(string uuid, string ip) => Math.max(this.getInfo(uuid).lastKicked, ((Long) this.kickedIPs.get((object) ip, (object) Long.valueOf(0L))).longValue());

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPlayerLimit() => Core.settings.getInt("playerlimit", 0);

    [LineNumberTable(new byte[] {160, 249, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdmin(string id, string usid)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      return createInfo.admin && String.instancehelper_equals(usid, (object) createInfo.adminUsid);
    }

    [LineNumberTable(333)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isWhitelisted(string id, string usid) => !this.isWhitelistEnabled() || this.whitelist.contains((object) new StringBuilder().append(usid).append(id).toString());

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool allowsCustomClients() => Administration.Config.__\u003C\u003EallowCustomClients.@bool();

    [LineNumberTable(new byte[] {160, 69, 104, 103, 103, 110, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePlayerJoined(string id, string ip, string name)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      createInfo.lastName = name;
      createInfo.lastIP = ip;
      ++createInfo.timesJoined;
      if (!createInfo.names.contains((object) name, false))
        createInfo.names.add((object) name);
      if (createInfo.ips.contains((object) ip, false))
        return;
      createInfo.ips.add((object) ip);
    }

    [Signature("(Lmindustry/gen/Player;Lmindustry/net/Administration$ActionType;Larc/func/Cons<Lmindustry/net/Administration$PlayerAction;>;)Z")]
    [LineNumberTable(new byte[] {99, 133, 122, 103, 103, 103, 127, 1, 105, 102, 130, 98, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool allowAction(Player player, Administration.ActionType type, Cons setter)
    {
      if (player == null)
        return true;
      Administration.PlayerAction apa = (Administration.PlayerAction) Pools.obtain((Class) ClassLiteral<Administration.PlayerAction>.Value, (Prov) new Administration.__\u003C\u003EAnon4());
      apa.player = player;
      apa.type = type;
      setter.get((object) apa);
      Iterator iterator = this.actionFilters.iterator();
      while (iterator.hasNext())
      {
        if (!((Administration.ActionFilter) iterator.next()).allow(apa))
        {
          Pools.free((object) apa);
          return false;
        }
      }
      Pools.free((object) apa);
      return true;
    }

    [LineNumberTable(new byte[] {161, 79, 127, 10, 127, 10, 127, 10, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load()
    {
      this.playerInfo = (ObjectMap) Core.settings.getJson("player-data", (Class) ClassLiteral<ObjectMap>.Value, (Prov) new Administration.__\u003C\u003EAnon9());
      this.bannedIPs = (Seq) Core.settings.getJson("ip-bans", (Class) ClassLiteral<Seq>.Value, (Prov) new Administration.__\u003C\u003EAnon10());
      this.whitelist = (Seq) Core.settings.getJson("whitelist-ids", (Class) ClassLiteral<Seq>.Value, (Prov) new Administration.__\u003C\u003EAnon10());
      this.subnetBans = (Seq) Core.settings.getJson("banned-subnets", (Class) ClassLiteral<Seq>.Value, (Prov) new Administration.__\u003C\u003EAnon10());
    }

    [LineNumberTable(new byte[] {73, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChatFilter(Administration.ChatFilter filter) => this.chatFilters.add((object) filter);

    [LineNumberTable(new byte[] {88, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addActionFilter(Administration.ActionFilter filter) => this.actionFilters.add((object) filter);

    [LineNumberTable(new byte[] {161, 59, 110, 146, 103, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Administration.PlayerInfo getCreateInfo([In] string obj0)
    {
      if (this.playerInfo.containsKey((object) obj0))
        return (Administration.PlayerInfo) this.playerInfo.get((object) obj0);
      Administration.PlayerInfo playerInfo = new Administration.PlayerInfo(obj0);
      this.playerInfo.put((object) obj0, (object) playerInfo);
      this.save();
      return playerInfo;
    }

    [LineNumberTable(329)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isWhitelistEnabled() => Administration.Config.__\u003C\u003Ewhitelist.@bool();

    [LineNumberTable(new byte[] {161, 46, 127, 6, 111, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Administration.PlayerInfo findByIP(string ip)
    {
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.ips.contains((object) ip, false))
          return playerInfo;
      }
      return (Administration.PlayerInfo) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 114, 159, 6, 158, 127, 20, 147, 127, 4, 150, 130, 204, 127, 12, 107, 162, 108, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024new\u00240([In] Player obj0, [In] string obj1)
    {
      long num = (long) (Administration.Config.__\u003C\u003EmessageRateLimit.num() * 1000);
      if (Administration.Config.__\u003C\u003EantiSpam.@bool() && !obj0.isLocal() && !obj0.admin)
      {
        if (num > 0L && Time.timeSinceMillis(obj0.getInfo().lastMessageTime) < num)
        {
          obj0.sendMessage(new StringBuilder().append("[scarlet]You may only send messages every ").append(Administration.Config.__\u003C\u003EmessageRateLimit.num()).append(" seconds.").toString());
          ++obj0.getInfo().messageInfractions;
          if (obj0.getInfo().messageInfractions >= Administration.Config.__\u003C\u003EmessageSpamKick.num() && Administration.Config.__\u003C\u003EmessageSpamKick.num() != 0)
            obj0.con.kick("You have been kicked for spamming.", 120000L);
          return (string) null;
        }
        obj0.getInfo().messageInfractions = 0;
        if (String.instancehelper_equals(obj1, (object) obj0.getInfo().lastSentMessage) && Time.timeSinceMillis(obj0.getInfo().lastMessageTime) < 50000L)
        {
          obj0.sendMessage("[scarlet]You may not send the same message twice.");
          return (string) null;
        }
        obj0.getInfo().lastSentMessage = obj1;
        obj0.getInfo().lastMessageTime = Time.millis();
      }
      return obj1;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 159, 16, 138, 113, 127, 4, 130, 114, 120, 124, 176, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] Administration.PlayerAction obj0)
    {
      if (object.ReferenceEquals((object) obj0.type, (object) Administration.ActionType.__\u003C\u003EbreakBlock) || object.ReferenceEquals((object) obj0.type, (object) Administration.ActionType.__\u003C\u003EplaceBlock) || !Administration.Config.__\u003C\u003EantiSpam.@bool())
        return true;
      Ratekeeper rate = obj0.player.getInfo().rate;
      if (rate.allow((long) (Administration.Config.__\u003C\u003EinteractRateWindow.num() * 1000), Administration.Config.__\u003C\u003EinteractRateLimit.num()))
        return true;
      if (rate.occurences > Administration.Config.__\u003C\u003EinteractRateKick.num())
        obj0.player.kick("You are interacting with too many blocks.", 30000L);
      else if (obj0.player.getInfo().messageTimer.get(120f))
        obj0.player.sendMessage("[scarlet]You are interacting with blocks too quickly.");
      return false;
    }

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024allowAction\u00242(
      [In] Cons obj0,
      [In] Player obj1,
      [In] Administration.ActionType obj2,
      [In] Tile obj3,
      [In] Administration.PlayerAction obj4)
    {
      obj0.get((object) obj4.set(obj1, obj2, obj3));
    }

    [Modifiers]
    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024banPlayerID\u00243([In] string obj0, [In] Player obj1) => String.instancehelper_equals(obj0, (object) obj1.uuid());

    [Modifiers]
    [LineNumberTable(262)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024unbanPlayerID\u00244([In] string obj0, [In] Player obj1) => String.instancehelper_equals(obj0, (object) obj1.uuid());

    [Modifiers]
    [LineNumberTable(387)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024searchNames\u00245([In] string obj0, [In] string obj1)
    {
      string lowerCase1 = String.instancehelper_toLowerCase(obj1);
      object lowerCase2 = (object) String.instancehelper_toLowerCase(obj0);
      CharSequence str;
      str.__\u003Cref\u003E = (__Null) lowerCase2;
      CharSequence charSequence1 = str;
      if (!String.instancehelper_contains(lowerCase1, charSequence1))
      {
        object obj2 = (object) obj1;
        str.__\u003Cref\u003E = (__Null) obj2;
        string lowerCase3 = String.instancehelper_toLowerCase(String.instancehelper_trim(Strings.stripColors(str)));
        object obj3 = (object) obj0;
        str.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence2 = str;
        if (!String.instancehelper_contains(lowerCase3, charSequence2))
          return false;
      }
      return true;
    }

    [Modifiers]
    [LineNumberTable(425)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024getWhitelisted\u00246([In] Administration.PlayerInfo obj0) => this.isWhitelisted(obj0.id, obj0.adminUsid);

    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getSubnetBans() => this.subnetBans;

    [LineNumberTable(new byte[] {56, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSubnetBan(string ip)
    {
      this.subnetBans.remove((object) ip);
      this.save();
    }

    [LineNumberTable(new byte[] {61, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSubnetBan(string ip)
    {
      this.subnetBans.add((object) ip);
      this.save();
    }

    [LineNumberTable(new byte[] {120, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPlayerLimit(int limit) => Core.settings.put("playerlimit", (object) Integer.valueOf(limit));

    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool banPlayer(string uuid) => this.banPlayerID(uuid) || this.banPlayerIP(this.getInfo(uuid).lastIP);

    [LineNumberTable(new byte[] {160, 118, 142, 127, 6, 111, 103, 130, 130, 142, 99, 102, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unbanPlayerIP(string ip)
    {
      int num = this.bannedIPs.contains((object) ip, false) ? 1 : 0;
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.ips.contains((object) ip, false))
        {
          playerInfo.banned = false;
          num = 1;
        }
      }
      this.bannedIPs.remove((object) ip, false);
      if (num != 0)
      {
        this.save();
        Events.fire((object) new EventType.PlayerIpUnbanEvent(ip));
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 141, 136, 138, 103, 115, 102, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unbanPlayerID(string id)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      if (!createInfo.banned)
        return false;
      createInfo.banned = false;
      this.bannedIPs.removeAll(createInfo.ips, false);
      this.save();
      Events.fire((object) new EventType.PlayerUnbanEvent((Player) Groups.player.find((Boolf) new Administration.__\u003C\u003EAnon6(id)), id));
      return true;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(new byte[] {160, 156, 102, 127, 6, 104, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getAdmins()
    {
      Seq seq = new Seq();
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.admin)
          seq.add((object) playerInfo);
      }
      return seq;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(new byte[] {160, 169, 102, 127, 6, 104, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getBanned()
    {
      Seq seq = new Seq();
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.banned)
          seq.add((object) playerInfo);
      }
      return seq;
    }

    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getBannedIPs() => this.bannedIPs;

    [LineNumberTable(new byte[] {160, 190, 136, 103, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool adminPlayer(string id, string usid)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      createInfo.adminUsid = usid;
      createInfo.admin = true;
      this.save();
      return true;
    }

    [LineNumberTable(new byte[] {160, 204, 136, 138, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unAdminPlayer(string id)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      if (!createInfo.admin)
        return false;
      createInfo.admin = false;
      this.save();
      return true;
    }

    [LineNumberTable(new byte[] {160, 223, 104, 127, 11, 127, 7, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool whitelist(string id)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      if (this.whitelist.contains((object) new StringBuilder().append(createInfo.adminUsid).append(id).toString()))
        return false;
      this.whitelist.add((object) new StringBuilder().append(createInfo.adminUsid).append(id).toString());
      this.save();
      return true;
    }

    [LineNumberTable(new byte[] {160, 231, 104, 127, 9, 127, 8, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unwhitelist(string id)
    {
      Administration.PlayerInfo createInfo = this.getCreateInfo(id);
      if (!this.whitelist.contains((object) new StringBuilder().append(createInfo.adminUsid).append(id).toString()))
        return false;
      this.whitelist.remove((object) new StringBuilder().append(createInfo.adminUsid).append(id).toString());
      this.save();
      return true;
    }

    [Signature("(Ljava/lang/String;)Larc/struct/ObjectSet<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(new byte[] {160, 255, 134, 127, 9, 127, 7, 127, 27, 117, 136, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet findByName(string name)
    {
      ObjectSet objectSet = new ObjectSet();
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (!String.instancehelper_equalsIgnoreCase(playerInfo.lastName, name) && !playerInfo.names.contains((object) name, false))
        {
          object lastName = (object) playerInfo.lastName;
          CharSequence str;
          str.__\u003Cref\u003E = (__Null) lastName;
          object obj = (object) Strings.stripColors(str);
          str.__\u003Cref\u003E = (__Null) obj;
          if (!String.instancehelper_equals(Strings.stripColors(str), (object) name) && !playerInfo.ips.contains((object) name, false) && !String.instancehelper_equals(playerInfo.id, (object) name))
            continue;
        }
        objectSet.add((object) playerInfo);
      }
      return objectSet;
    }

    [Signature("(Ljava/lang/String;)Larc/struct/ObjectSet<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(new byte[] {161, 14, 134, 127, 6, 120, 136, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet searchNames(string name)
    {
      ObjectSet objectSet = new ObjectSet();
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.names.contains((Boolf) new Administration.__\u003C\u003EAnon7(name)))
          objectSet.add((object) playerInfo);
      }
      return objectSet;
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(new byte[] {161, 26, 134, 127, 6, 111, 135, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq findByIPs(string ip)
    {
      Seq seq = new Seq();
      ObjectMap.Values values = this.playerInfo.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) ((Iterator) values).next();
        if (playerInfo.ips.contains((object) ip, false))
          seq.add((object) playerInfo);
      }
      return seq;
    }

    [LineNumberTable(412)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Administration.PlayerInfo getInfoOptional(string id) => (Administration.PlayerInfo) this.playerInfo.get((object) id);

    [Signature("()Larc/struct/Seq<Lmindustry/net/Administration$PlayerInfo;>;")]
    [LineNumberTable(425)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getWhitelisted() => this.playerInfo.values().toSeq().select((Boolf) new Administration.__\u003C\u003EAnon8(this));

    public interface ActionFilter
    {
      bool allow(Administration.PlayerAction apa);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/net/Administration$ActionType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ActionType : Enum
    {
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003EbreakBlock;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003EplaceBlock;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003Erotate;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003Econfigure;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003EwithdrawItem;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003EdepositItem;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003Econtrol;
      [Modifiers]
      internal static Administration.ActionType __\u003C\u003Ecommand;
      [Modifiers]
      private static Administration.ActionType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(647)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ActionType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(647)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Administration.ActionType[] values() => (Administration.ActionType[]) Administration.ActionType.\u0024VALUES.Clone();

      [LineNumberTable(647)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Administration.ActionType valueOf(string name) => (Administration.ActionType) Enum.valueOf((Class) ClassLiteral<Administration.ActionType>.Value, name);

      [LineNumberTable(new byte[] {158, 236, 77, 63, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ActionType()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Administration$ActionType"))
          return;
        Administration.ActionType.__\u003C\u003EbreakBlock = new Administration.ActionType(nameof (breakBlock), 0);
        Administration.ActionType.__\u003C\u003EplaceBlock = new Administration.ActionType(nameof (placeBlock), 1);
        Administration.ActionType.__\u003C\u003Erotate = new Administration.ActionType(nameof (rotate), 2);
        Administration.ActionType.__\u003C\u003Econfigure = new Administration.ActionType(nameof (configure), 3);
        Administration.ActionType.__\u003C\u003EwithdrawItem = new Administration.ActionType(nameof (withdrawItem), 4);
        Administration.ActionType.__\u003C\u003EdepositItem = new Administration.ActionType(nameof (depositItem), 5);
        Administration.ActionType.__\u003C\u003Econtrol = new Administration.ActionType(nameof (control), 6);
        Administration.ActionType.__\u003C\u003Ecommand = new Administration.ActionType(nameof (command), 7);
        Administration.ActionType.\u0024VALUES = new Administration.ActionType[8]
        {
          Administration.ActionType.__\u003C\u003EbreakBlock,
          Administration.ActionType.__\u003C\u003EplaceBlock,
          Administration.ActionType.__\u003C\u003Erotate,
          Administration.ActionType.__\u003C\u003Econfigure,
          Administration.ActionType.__\u003C\u003EwithdrawItem,
          Administration.ActionType.__\u003C\u003EdepositItem,
          Administration.ActionType.__\u003C\u003Econtrol,
          Administration.ActionType.__\u003C\u003Ecommand
        };
      }

      [Modifiers]
      public static Administration.ActionType breakBlock
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003EbreakBlock;
      }

      [Modifiers]
      public static Administration.ActionType placeBlock
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003EplaceBlock;
      }

      [Modifiers]
      public static Administration.ActionType rotate
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003Erotate;
      }

      [Modifiers]
      public static Administration.ActionType configure
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003Econfigure;
      }

      [Modifiers]
      public static Administration.ActionType withdrawItem
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003EwithdrawItem;
      }

      [Modifiers]
      public static Administration.ActionType depositItem
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003EdepositItem;
      }

      [Modifiers]
      public static Administration.ActionType control
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003Econtrol;
      }

      [Modifiers]
      public static Administration.ActionType command
      {
        [HideFromJava] get => Administration.ActionType.__\u003C\u003Ecommand;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        breakBlock,
        placeBlock,
        rotate,
        configure,
        withdrawItem,
        depositItem,
        control,
        command,
      }
    }

    public interface ChatFilter
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      string filter(Player p, string str);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/net/Administration$Config;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Config : Enum
    {
      [Modifiers]
      internal static Administration.Config __\u003C\u003Ename;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Edesc;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Eport;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EautoUpdate;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EshowConnectMessages;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EenableVotekick;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EstartCommands;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EcrashReport;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Elogging;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Estrict;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EantiSpam;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EinteractRateWindow;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EinteractRateLimit;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EinteractRateKick;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EmessageRateLimit;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EmessageSpamKick;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EsocketInput;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EsocketInputPort;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EsocketInputAddress;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EallowCustomClients;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Ewhitelist;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Emotd;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Eautosave;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EautosaveAmount;
      [Modifiers]
      internal static Administration.Config __\u003C\u003EautosaveSpacing;
      [Modifiers]
      internal static Administration.Config __\u003C\u003Edebug;
      internal static Administration.Config[] __\u003C\u003Eall;
      internal object __\u003C\u003EdefaultValue;
      internal string __\u003C\u003Ekey;
      internal string __\u003C\u003Edescription;
      [Modifiers]
      internal Runnable changed;
      [Modifiers]
      private static Administration.Config[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(526)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool @bool() => Core.settings.getBool(this.__\u003C\u003Ekey, ((Boolean) this.__\u003C\u003EdefaultValue).booleanValue());

      [LineNumberTable(534)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string @string() => Core.settings.getString(this.__\u003C\u003Ekey, (string) this.__\u003C\u003EdefaultValue);

      [LineNumberTable(530)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int num() => Core.settings.getInt(this.__\u003C\u003Ekey, ((Integer) this.__\u003C\u003EdefaultValue).intValue());

      [Signature("(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Runnable;)V")]
      [LineNumberTable(new byte[] {161, 132, 106, 103, 116, 104, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Config(
        [In] string obj0,
        [In] int obj1,
        [In] string obj2,
        [In] object obj3,
        [In] string obj4,
        [In] Runnable obj5)
        : base(obj0, obj1)
      {
        Administration.Config config = this;
        this.__\u003C\u003Edescription = obj2;
        this.__\u003C\u003Ekey = obj4 != null ? obj4 : this.name();
        this.__\u003C\u003EdefaultValue = obj3;
        this.changed = obj5 != null ? obj5 : (Runnable) new Administration.Config.__\u003C\u003EAnon0();
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(543)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool debug() => Administration.Config.__\u003C\u003Edebug.@bool();

      [Signature("(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {161, 125, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Config([In] string obj0, [In] int obj1, [In] string obj2, [In] object obj3, [In] string obj4)
        : this(obj0, obj1, obj2, obj3, obj4, (Runnable) null)
      {
        GC.KeepAlive((object) this);
      }

      [Signature("(Ljava/lang/String;Ljava/lang/Object;)V")]
      [LineNumberTable(new byte[] {161, 121, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Config([In] string obj0, [In] int obj1, [In] string obj2, [In] object obj3)
        : this(obj0, obj1, obj2, obj3, (string) null, (Runnable) null)
      {
        GC.KeepAlive((object) this);
      }

      [Signature("(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Runnable;)V")]
      [LineNumberTable(new byte[] {161, 129, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Config([In] string obj0, [In] int obj1, [In] string obj2, [In] object obj3, [In] Runnable obj4)
        : this(obj0, obj1, obj2, obj3, (string) null, obj4)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(456)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Administration.Config[] values() => (Administration.Config[]) Administration.Config.\u0024VALUES.Clone();

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00244()
      {
      }

      [Modifiers]
      [LineNumberTable(473)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024static\u00240() => Events.fire((object) EventType.Trigger.__\u003C\u003EsocketConfigChanged);

      [Modifiers]
      [LineNumberTable(474)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024static\u00241() => Events.fire((object) EventType.Trigger.__\u003C\u003EsocketConfigChanged);

      [Modifiers]
      [LineNumberTable(475)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024static\u00242() => Events.fire((object) EventType.Trigger.__\u003C\u003EsocketConfigChanged);

      [Modifiers]
      [LineNumberTable(482)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024static\u00243() => Log.level = !Administration.Config.debug() ? Log.LogLevel.__\u003C\u003Einfo : Log.LogLevel.__\u003C\u003Edebug;

      [LineNumberTable(456)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Administration.Config valueOf(string name) => (Administration.Config) Enum.valueOf((Class) ClassLiteral<Administration.Config>.Value, name);

      [LineNumberTable(510)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isNum() => this.__\u003C\u003EdefaultValue is Integer;

      [LineNumberTable(514)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isBool() => this.__\u003C\u003EdefaultValue is Boolean;

      [LineNumberTable(518)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isString() => this.__\u003C\u003EdefaultValue is string;

      [LineNumberTable(522)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object get() => Core.settings.get(this.__\u003C\u003Ekey, this.__\u003C\u003EdefaultValue);

      [LineNumberTable(new byte[] {161, 168, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(object value)
      {
        Core.settings.put(this.__\u003C\u003Ekey, value);
        this.changed.run();
      }

      [LineNumberTable(new byte[] {159, 28, 109, 127, 0, 122, 127, 0, 123, 123, 123, 122, 127, 1, 123, 124, 127, 1, 124, 125, 125, 124, 124, 127, 12, 127, 11, 127, 6, 127, 12, 124, 123, 124, 125, 127, 1, 255, 7, 38, 255, 160, 142, 92})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Config()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Administration$Config"))
          return;
        Administration.Config.__\u003C\u003Ename = new Administration.Config(nameof (name), 0, "The server name as displayed on clients.", (object) "Server", "servername");
        Administration.Config.__\u003C\u003Edesc = new Administration.Config(nameof (desc), 1, "The server description, displayed under the name. Max 100 characters.", (object) "off");
        Administration.Config.__\u003C\u003Eport = new Administration.Config(nameof (port), 2, "The port to host on.", (object) Integer.valueOf(6567));
        Administration.Config.__\u003C\u003EautoUpdate = new Administration.Config(nameof (autoUpdate), 3, "Whether to auto-update and exit when a new bleeding-edge update arrives.", (object) Boolean.valueOf(false));
        Administration.Config.__\u003C\u003EshowConnectMessages = new Administration.Config(nameof (showConnectMessages), 4, "Whether to display connect/disconnect messages.", (object) Boolean.valueOf(true));
        Administration.Config.__\u003C\u003EenableVotekick = new Administration.Config(nameof (enableVotekick), 5, "Whether votekick is enabled.", (object) Boolean.valueOf(true));
        Administration.Config.__\u003C\u003EstartCommands = new Administration.Config(nameof (startCommands), 6, "Commands run at startup. This should be a comma-separated list.", (object) "");
        Administration.Config.__\u003C\u003EcrashReport = new Administration.Config(nameof (crashReport), 7, "Whether to send crash reports.", (object) Boolean.valueOf(false), "crashreport");
        Administration.Config.__\u003C\u003Elogging = new Administration.Config(nameof (logging), 8, "Whether to log everything to files.", (object) Boolean.valueOf(true));
        Administration.Config.__\u003C\u003Estrict = new Administration.Config(nameof (strict), 9, "Whether strict mode is on - corrects positions and prevents duplicate UUIDs.", (object) Boolean.valueOf(true));
        Administration.Config.__\u003C\u003EantiSpam = new Administration.Config(nameof (antiSpam), 10, "Whether spammers are automatically kicked and rate-limited.", (object) Boolean.valueOf(Vars.headless));
        Administration.Config.__\u003C\u003EinteractRateWindow = new Administration.Config(nameof (interactRateWindow), 11, "Block interaction rate limit window, in seconds.", (object) Integer.valueOf(6));
        Administration.Config.__\u003C\u003EinteractRateLimit = new Administration.Config(nameof (interactRateLimit), 12, "Block interaction rate limit.", (object) Integer.valueOf(25));
        Administration.Config.__\u003C\u003EinteractRateKick = new Administration.Config(nameof (interactRateKick), 13, "How many times a player must interact inside the window to get kicked.", (object) Integer.valueOf(60));
        Administration.Config.__\u003C\u003EmessageRateLimit = new Administration.Config(nameof (messageRateLimit), 14, "Message rate limit in seconds. 0 to disable.", (object) Integer.valueOf(0));
        Administration.Config.__\u003C\u003EmessageSpamKick = new Administration.Config(nameof (messageSpamKick), 15, "How many times a player must send a message before the cooldown to get kicked. 0 to disable.", (object) Integer.valueOf(3));
        Administration.Config.__\u003C\u003EsocketInput = new Administration.Config(nameof (socketInput), 16, "Allows a local application to control this server through a local TCP socket.", (object) Boolean.valueOf(false), "socket", (Runnable) new Administration.Config.__\u003C\u003EAnon1());
        Administration.Config.__\u003C\u003EsocketInputPort = new Administration.Config(nameof (socketInputPort), 17, "The port for socket input.", (object) Integer.valueOf(6859), (Runnable) new Administration.Config.__\u003C\u003EAnon2());
        Administration.Config.__\u003C\u003EsocketInputAddress = new Administration.Config(nameof (socketInputAddress), 18, "The bind address for socket input.", (object) "localhost", (Runnable) new Administration.Config.__\u003C\u003EAnon3());
        Administration.Config.__\u003C\u003EallowCustomClients = new Administration.Config(nameof (allowCustomClients), 19, "Whether custom clients are allowed to connect.", (object) Boolean.valueOf(!Vars.headless), "allow-custom");
        Administration.Config.__\u003C\u003Ewhitelist = new Administration.Config(nameof (whitelist), 20, "Whether the whitelist is used.", (object) Boolean.valueOf(false));
        Administration.Config.__\u003C\u003Emotd = new Administration.Config(nameof (motd), 21, "The message displayed to people on connection.", (object) "off");
        Administration.Config.__\u003C\u003Eautosave = new Administration.Config(nameof (autosave), 22, "Whether the periodically save the map when playing.", (object) Boolean.valueOf(false));
        Administration.Config.__\u003C\u003EautosaveAmount = new Administration.Config(nameof (autosaveAmount), 23, "The maximum amount of autosaves. Older ones get replaced.", (object) Integer.valueOf(10));
        Administration.Config.__\u003C\u003EautosaveSpacing = new Administration.Config(nameof (autosaveSpacing), 24, "Spacing between autosaves in seconds.", (object) Integer.valueOf(300));
        Administration.Config.__\u003C\u003Edebug = new Administration.Config(nameof (debug), 25, "Enable debug logging", (object) Boolean.valueOf(false), (Runnable) new Administration.Config.__\u003C\u003EAnon4());
        Administration.Config.\u0024VALUES = new Administration.Config[26]
        {
          Administration.Config.__\u003C\u003Ename,
          Administration.Config.__\u003C\u003Edesc,
          Administration.Config.__\u003C\u003Eport,
          Administration.Config.__\u003C\u003EautoUpdate,
          Administration.Config.__\u003C\u003EshowConnectMessages,
          Administration.Config.__\u003C\u003EenableVotekick,
          Administration.Config.__\u003C\u003EstartCommands,
          Administration.Config.__\u003C\u003EcrashReport,
          Administration.Config.__\u003C\u003Elogging,
          Administration.Config.__\u003C\u003Estrict,
          Administration.Config.__\u003C\u003EantiSpam,
          Administration.Config.__\u003C\u003EinteractRateWindow,
          Administration.Config.__\u003C\u003EinteractRateLimit,
          Administration.Config.__\u003C\u003EinteractRateKick,
          Administration.Config.__\u003C\u003EmessageRateLimit,
          Administration.Config.__\u003C\u003EmessageSpamKick,
          Administration.Config.__\u003C\u003EsocketInput,
          Administration.Config.__\u003C\u003EsocketInputPort,
          Administration.Config.__\u003C\u003EsocketInputAddress,
          Administration.Config.__\u003C\u003EallowCustomClients,
          Administration.Config.__\u003C\u003Ewhitelist,
          Administration.Config.__\u003C\u003Emotd,
          Administration.Config.__\u003C\u003Eautosave,
          Administration.Config.__\u003C\u003EautosaveAmount,
          Administration.Config.__\u003C\u003EautosaveSpacing,
          Administration.Config.__\u003C\u003Edebug
        };
        Administration.Config.__\u003C\u003Eall = Administration.Config.values();
      }

      [Modifiers]
      public static Administration.Config name
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Ename;
      }

      [Modifiers]
      public static Administration.Config desc
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Edesc;
      }

      [Modifiers]
      public static Administration.Config port
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Eport;
      }

      [Modifiers]
      public static Administration.Config autoUpdate
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EautoUpdate;
      }

      [Modifiers]
      public static Administration.Config showConnectMessages
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EshowConnectMessages;
      }

      [Modifiers]
      public static Administration.Config enableVotekick
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EenableVotekick;
      }

      [Modifiers]
      public static Administration.Config startCommands
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EstartCommands;
      }

      [Modifiers]
      public static Administration.Config crashReport
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EcrashReport;
      }

      [Modifiers]
      public static Administration.Config logging
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Elogging;
      }

      [Modifiers]
      public static Administration.Config strict
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Estrict;
      }

      [Modifiers]
      public static Administration.Config antiSpam
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EantiSpam;
      }

      [Modifiers]
      public static Administration.Config interactRateWindow
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EinteractRateWindow;
      }

      [Modifiers]
      public static Administration.Config interactRateLimit
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EinteractRateLimit;
      }

      [Modifiers]
      public static Administration.Config interactRateKick
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EinteractRateKick;
      }

      [Modifiers]
      public static Administration.Config messageRateLimit
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EmessageRateLimit;
      }

      [Modifiers]
      public static Administration.Config messageSpamKick
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EmessageSpamKick;
      }

      [Modifiers]
      public static Administration.Config socketInput
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EsocketInput;
      }

      [Modifiers]
      public static Administration.Config socketInputPort
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EsocketInputPort;
      }

      [Modifiers]
      public static Administration.Config socketInputAddress
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EsocketInputAddress;
      }

      [Modifiers]
      public static Administration.Config allowCustomClients
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EallowCustomClients;
      }

      [Modifiers]
      public static Administration.Config whitelist
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Ewhitelist;
      }

      [Modifiers]
      public static Administration.Config motd
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Emotd;
      }

      [Modifiers]
      public static Administration.Config autosave
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Eautosave;
      }

      [Modifiers]
      public static Administration.Config autosaveAmount
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EautosaveAmount;
      }

      [Modifiers]
      public static Administration.Config autosaveSpacing
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003EautosaveSpacing;
      }

      [Modifiers]
      public static Administration.Config debug
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Edebug;
      }

      [Modifiers]
      public static Administration.Config[] all
      {
        [HideFromJava] get => Administration.Config.__\u003C\u003Eall;
      }

      [Modifiers]
      public object defaultValue
      {
        [HideFromJava] get => this.__\u003C\u003EdefaultValue;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EdefaultValue = value;
      }

      [Modifiers]
      public string key
      {
        [HideFromJava] get => this.__\u003C\u003Ekey;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ekey = value;
      }

      [Modifiers]
      public string description
      {
        [HideFromJava] get => this.__\u003C\u003Edescription;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Edescription = value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        name,
        desc,
        port,
        autoUpdate,
        showConnectMessages,
        enableVotekick,
        startCommands,
        crashReport,
        logging,
        strict,
        antiSpam,
        interactRateWindow,
        interactRateLimit,
        interactRateKick,
        messageRateLimit,
        messageSpamKick,
        socketInput,
        socketInputPort,
        socketInputAddress,
        allowCustomClients,
        whitelist,
        motd,
        autosave,
        autosaveAmount,
        autosaveSpacing,
        debug,
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void run() => Administration.Config.lambda\u0024new\u00244();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void run() => Administration.Config.lambda\u0024static\u00240();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Runnable
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void run() => Administration.Config.lambda\u0024static\u00241();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : Runnable
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public void run() => Administration.Config.lambda\u0024static\u00242();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon4 : Runnable
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public void run() => Administration.Config.lambda\u0024static\u00243();
      }
    }

    public class PlayerAction : Object, Pool.Poolable
    {
      public Player player;
      public Administration.ActionType type;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Tile tile;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Block block;
      public int rotation;
      public object config;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Item item;
      public int itemAmount;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Unit unit;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Administration.PlayerAction set(
        Player player,
        Administration.ActionType type,
        Tile tile)
      {
        this.player = player;
        this.type = type;
        this.tile = tile;
        return this;
      }

      [LineNumberTable(601)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerAction()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Administration.PlayerAction set(
        Player player,
        Administration.ActionType type,
        Unit unit)
      {
        this.player = player;
        this.type = type;
        this.unit = unit;
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.item = (Item) null;
        this.itemAmount = 0;
        this.config = (object) null;
        this.player = (Player) null;
        this.type = (Administration.ActionType) null;
        this.tile = (Tile) null;
        this.block = (Block) null;
        this.unit = (Unit) null;
      }
    }

    public class PlayerInfo : Object
    {
      public string id;
      public string lastName;
      public string lastIP;
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      public Seq ips;
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      public Seq names;
      public string adminUsid;
      public int timesKicked;
      public int timesJoined;
      public bool banned;
      public bool admin;
      public long lastKicked;
      [NonSerialized]
      public long lastMessageTime;
      [NonSerialized]
      public long lastSyncTime;
      [NonSerialized]
      public string lastSentMessage;
      [NonSerialized]
      public int messageInfractions;
      [NonSerialized]
      public Ratekeeper rate;
      [NonSerialized]
      public Interval messageTimer;

      [LineNumberTable(new byte[] {161, 194, 232, 49, 118, 107, 235, 74, 107, 171, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PlayerInfo([In] string obj0)
      {
        Administration.PlayerInfo playerInfo = this;
        this.lastName = "<unknown>";
        this.lastIP = "<unknown>";
        this.ips = new Seq();
        this.names = new Seq();
        this.rate = new Ratekeeper();
        this.messageTimer = new Interval();
        this.id = obj0;
      }

      [LineNumberTable(new byte[] {161, 198, 232, 45, 118, 107, 235, 74, 107, 235, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerInfo()
      {
        Administration.PlayerInfo playerInfo = this;
        this.lastName = "<unknown>";
        this.lastIP = "<unknown>";
        this.ips = new Seq();
        this.names = new Seq();
        this.rate = new Ratekeeper();
        this.messageTimer = new Interval();
      }
    }

    public class TraceInfo : Object
    {
      public string ip;
      public string uuid;
      public bool modded;
      public bool mobile;
      public int timesJoined;
      public int timesKicked;

      [LineNumberTable(new byte[] {158, 251, 101, 104, 103, 103, 103, 103, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TraceInfo(
        string ip,
        string uuid,
        bool modded,
        bool mobile,
        int timesJoined,
        int timesKicked)
      {
        int num1 = modded ? 1 : 0;
        int num2 = mobile ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Administration.TraceInfo traceInfo = this;
        this.ip = ip;
        this.uuid = uuid;
        this.modded = num1 != 0;
        this.mobile = num2 != 0;
        this.timesJoined = timesJoined;
        this.timesKicked = timesKicked;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Administration.ChatFilter
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public string filter([In] Player obj0, [In] string obj1) => Administration.lambda\u0024new\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Administration.ActionFilter
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool allow([In] Administration.PlayerAction obj0) => (Administration.lambda\u0024new\u00241(obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon2([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (String.instancehelper_startsWith(this.arg\u00241, (string) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Cons arg\u00241;
      private readonly Player arg\u00242;
      private readonly Administration.ActionType arg\u00243;
      private readonly Tile arg\u00244;

      internal __\u003C\u003EAnon3(
        [In] Cons obj0,
        [In] Player obj1,
        [In] Administration.ActionType obj2,
        [In] Tile obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => Administration.lambda\u0024allowAction\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new Administration.PlayerAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon5([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Administration.lambda\u0024banPlayerID\u00243(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon6([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Administration.lambda\u0024unbanPlayerID\u00244(this.arg\u00241, (Player) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon7([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Administration.lambda\u0024searchNames\u00245(this.arg\u00241, (string) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      private readonly Administration arg\u00241;

      internal __\u003C\u003EAnon8([In] Administration obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024getWhitelisted\u00246((Administration.PlayerInfo) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new ObjectMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new Seq();
    }
  }
}
